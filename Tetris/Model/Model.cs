﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tetris
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Model _instance = null;
        /// <summary>
        /// Поле игры
        /// </summary>
        private TetrisGrid _tetrisGrid = new TetrisGrid();
        /// <summary>
        /// Создатель форм
        /// </summary>
        private ShapeCreator _shapeCreator = new ShapeCreator();
        /// <summary>
        /// Следующая фигура
        /// </summary>
        private Shape _nextShape;
        /// <summary>
        /// Текущая фигура
        /// </summary>
        private Shape _currentShape;
        /// <summary>
        /// В игре
        /// </summary>
        private bool _inPlay = false;
        /// <summary>
        /// Очки
        /// </summary>
        private int _score;
        /// <summary>
        /// Уровень
        /// </summary>
        private int _level;
        /// <summary>
        /// Список игроков
        /// </summary>
        public List<User> _users = new List<User>();
        /// <summary>
        /// Количество упавших фигур
        /// </summary>
        private int _countShape = 1;

        /// <summary>
        /// Конструктор
        /// </summary>
        private Model()
        {
            InitializeMatch();
        }

        /// <summary>
        /// Получение экземпляра класса
        /// </summary>
        /// <returns>Экземпляр класса</returns>
        public static Model GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Model();
            }
            return _instance;
        }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        public void InitializeMatch()
        {
            _currentShape = null;
            _nextShape = null;
            _tetrisGrid.ClearGrid();
            _inPlay = true;
            Score = 0;
            Level = 1;
            ExtractShape();
            if (!File.Exists("Score.xml"))
            {
                CreateUserFile();
            }
            UploadScores();
           
        }
        /// <summary>
        /// Создание файла рекордов
        /// </summary>
        public void CreateUserFile()
        {
            XmlSerializer writer = new XmlSerializer(_users.GetType(), "Tetris");
            FileStream file = File.Create("Score.xml");

            writer.Serialize(file, _users);
            file.Close();
        }
        /// <summary>
        /// Загрузить рекорды
        /// </summary>
        private void UploadScores()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(_users.GetType(), "Tetris");
                object obj;
                using (StreamReader reader = new StreamReader("Score.xml"))
                {
                    obj = serializer.Deserialize(reader.BaseStream);
                    reader.Close();
                }
                _users = (List<User>)obj;
            }
            catch (InvalidOperationException)
            {
                CreateUserFile();
                UploadScores();
            }
        }
        /// <summary>
        /// Сохранить результаты
        /// </summary>
        /// <param name="parName">Имя</param>
        /// <param name="parScore">Очки</param>
        public void SaveScore(string parName, int parScore)
        {
            var User = new User()
            {
                Score = _score,
                Name = parName
            };

            _users.Add(User);

            try
            {
                XmlSerializer writer = new XmlSerializer(_users.GetType(), "Tetris");

                FileStream file = File.Create("Score.xml");

                writer.Serialize(file, _users);
                file.Close();
            }
            catch (UnauthorizedAccessException)
            {
               
                System.Windows.Forms.MessageBox.Show("Не удалось записать файл 'Score.xml'. \n ");
            }
            catch (IOException)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось сохранить файл «Score.xml». \n Вероятно, диск заполнен.");
            }

        }
        
        /// <summary>
        /// Завершение игры
        /// </summary>
        private void GameOver()
        {
            InPlay = false;
        }
        /// <summary>
        /// Извлечение фигуры
        /// </summary>
        public void ExtractShape()
        {
            // Если это первый старт, обе части должны быть извлечены
            if (_currentShape == null && _nextShape == null)
            {
                _currentShape = _shapeCreator.CreateShape();
                _nextShape = _shapeCreator.CreateShape();
            }
            else
            {
                _countShape++;
                _currentShape = _nextShape;
                _nextShape = _shapeCreator.CreateShape();
            }
        }



        /// <summary>
        /// Проверка возможности перемещения
        /// </summary>
        /// <param name="parX">Координата х</param>
        /// <param name="parY">Координата у</param>
        /// <returns></returns>
        private bool CanMove(int parX, int parY)
        {
            bool canMove = true;

            for (int i = parY, line = 0; i < (parY + CurrentShapeLines); i++, line++)
            {
                for (int j = parX, column = 0; j < (parX + CurrentShapeColumns); j++, column++)
                {
                    if ((_tetrisGrid.GameGrid[i, j] != 0) && (_currentShape.Pattern[line, column] != 0))
                    {
                        canMove = false;
                    }
                }
            }
            return canMove;
        }
        /// <summary>
        /// Фиксация фигуры в поле
        /// </summary>
        private void FixedShape()
        {
            for (int i = _currentShape.Y, lineShape = 0; i < (_currentShape.Y + CurrentShapeLines); i++, lineShape++)
            {
                for (int j = _currentShape.X, columnShape = 0; (j < (_currentShape.X + CurrentShapeColumns)); j++, columnShape++)
                {
                    if (_currentShape.Pattern[lineShape, columnShape] != 0)
                    {
                        _tetrisGrid.GameGrid[i, j] = _currentShape.Pattern[lineShape, columnShape];
                    }
                }
            }
        }
        /// <summary>
        /// Проверка поворота
        /// </summary>
        /// <returns></returns>
        private bool CanRotate()
        {
            bool canRotate = true;
            // Временная матрица вращения после текущей
            int[,] rotationTemp = _currentShape.NextRotation(_currentShape.Rotation);
            // Новые x и y для вращения
            int nextX = _currentShape.NextRotationX();
            int nextY = _currentShape.NextRotationY();
            // Выходит ли следующая сетка из сетки
            if ((nextY + rotationTemp.GetLength(0)) > _tetrisGrid.GameGrid.GetLength(0))
            {
                canRotate = false;
            }
            if ((nextX + rotationTemp.GetLength(1)) > _tetrisGrid.GameGrid.GetLength(1))
            {
                canRotate = false;
            }
            if (nextX < 0)
            {
                canRotate = false;
            }

            if (canRotate)
            {
                for (int i = nextY; (i < (nextY + rotationTemp.GetLength(0))); i++)
                {
                    for (int j = nextX; (j < (nextX + rotationTemp.GetLength(1))); j++)
                    {

                        if (_tetrisGrid.GameGrid[i, j] != 0)
                        {
                            canRotate = false;
                        }
                    }
                }
            }

            return canRotate;
        }

        /// <summary>
        /// Перемещение влево 
        /// </summary>
        public void MoveLeft()
        {
            if (_currentShape.X != 0)
            {
                if (CanMove(_currentShape.X - 1, _currentShape.Y))
                {
                    _currentShape.X--;
                }
            }
        }

        /// <summary>
        /// Перемещение вправо
        /// </summary>
        public void MoveRight()
        {
            if ((_currentShape.X + CurrentShapeColumns) < _tetrisGrid.GameGrid.GetLength(1))
            {
                if (CanMove(_currentShape.X + 1, _currentShape.Y))
                {
                    _currentShape.X++;
                }
            }
        }
       
        /// <summary>
        /// Метод перемещения фигуры вниз
        /// </summary>
        /// <returns></returns>
        public bool MoveDown()
        {
            bool fixedShape = false;
            // Проверяем, что игра все еще в игре
            if ((_tetrisGrid.GameGrid[0, 4] != 0) || (_tetrisGrid.GameGrid[0, 3] != 0))
            {
                GameOver();
            }
            else
            {
                // Проверка, что кусок еще не находится на нижнем краю
                if (((_currentShape.Y + CurrentShapeLines) < _tetrisGrid.GameGrid.GetLength(0)) &&
                    (CanMove(_currentShape.X, _currentShape.Y + 1)))
                {
                    _currentShape.Y++;
                }
                else
                {
                    // Кусок больше не может двигаться, он должен быть «зафиксирован» до
                    // сетка ниже и убедитесь, что она не сформирована
                    // полная строка, и в этом случае удалите ее
                    FixedShape();
                    fixedShape = true;
                    CompleteLineVerification();
                }
            }
            return fixedShape;
        }

        /// <summary>
        /// Вращение фигуры
        /// </summary>
        /// <returns></returns>
        public bool ShapeWheel()
        {
            bool flag = false;

            if (CanRotate())
            {
                _currentShape.Wheel();
                flag = true;
            }

            return flag;
        }
        /// <summary>
        /// Проверка собранности строки
        /// </summary>
        /// <returns></returns>
        private bool CompleteLineVerification()
        {
            bool completeLine = true;

            for (int i = 0; i < _tetrisGrid.GameGrid.GetLength(0); i++)
            {
                completeLine = true;

                // Происходит, если есть хотя бы один элемент == 0, если строка не завершена
                // и следующее, если будет пропущено. Перейдите к следующей строке (если есть)
                for (int j = 0; (j < _tetrisGrid.GameGrid.GetLength(1)) && (completeLine == true); j++)
                {
                    if (_tetrisGrid.GameGrid[i, j] == 0)
                    {
                        completeLine = false;
                    }
                }
                if (completeLine)
                {
                    // Получаем полную строку (i) и копируем все элементы на ней
                    // из вышеприведенной строки, то же самое, пока не дойдем до строки 0
                    // где он установлен в 0, потому что все вниз по одной строке
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < _tetrisGrid.GameGrid.GetLength(1); j++)
                        {
                            _tetrisGrid.GameGrid[k, j] = _tetrisGrid.GameGrid[k - 1, j];
                        }
                    }
                    // септ на 0 линия 0
                    for (int j = 0; j < _tetrisGrid.GameGrid.GetLength(1); j++)
                    {
                        _tetrisGrid.GameGrid[0, j] = 0;
                    }
                    Score += 10;

                    if (Score % 100 == 0)
                    {
                        Level++;
                    }
                }
            }
            return completeLine;
        }
#region Свойства
        /// <summary>
        /// Количество столбцов текущей фигуры
        /// </summary>
        private int CurrentShapeColumns
        {
            get
            {
                return _currentShape.Pattern.GetLength(1);
            }
        }
        /// <summary>
        /// Количество строк текущей фигуры
        /// </summary>
        private int CurrentShapeLines
        {
            get
            {
                return _currentShape.Pattern.GetLength(0);
            }
        }

        /// <summary>
        /// Уровень
        /// </summary>
        public int Level
        {
            get
            {
                return _level;
            }
            private set
            {
                _level = value;
            }
        }
        /// <summary>
        /// Количество упавших фигур
        /// </summary>
        public int CountShape
        {
            get
            {
                return _countShape;
            }
            set
            {
                _countShape = value;
            }
        }
        /// <summary>
        /// Очки
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
            private set
            {
                _score = value;
            }
        }
        /// <summary>
        /// Игровое поле
        /// </summary>
        public TetrisGrid TetrisGrid
        {
            get
            {
                return _tetrisGrid;
            }
        }
        /// <summary>
        /// В игре
        /// </summary>
        public bool InPlay
        {
            get
            {
                return _inPlay;
            }
            set
            {
                _inPlay = value;
            }
        }

        /// <summary>
        /// Следующая фигура
        /// </summary>
        public Shape NextShape
        {
            get
            {
                return _nextShape;
            }
        }
        /// <summary>
        /// Текущая фигура
        /// </summary>
        public Shape CurrentShape
        {
            get
            {
                return _currentShape;
            }
        }
#endregion
    }
}

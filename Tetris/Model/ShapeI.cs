using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// I - образная фигура
    /// </summary>
    public class ShapeI : Shape
    {
        /// <summary>
        /// Изображение
        /// </summary>
        private Image _imageI = Properties.Resources.imageI;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        private const char NAME = 'I';
        /// <summary>
        /// Координата x
        /// </summary>
        private int _x;
        /// <summary>
        /// Координата y
        /// </summary>
        private int _y;
        /// <summary>
        /// Поворот
        /// </summary>
        private int _rotation;
        /// <summary>
        /// Шаблонное расположение 0- градусов
        /// </summary>
        private int[,] _pattern0 = new int[4, 1]
        {
            { 1 },
            { 1 },
            { 1 },
            { 1 }
        };
        /// <summary>
        /// Шаблонное расположение 90- градусов
        /// </summary>
        private int[,] _pattern90 = new int[1, 4]
        {
            { 1, 1, 1, 1 }
        };
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeI()
        {
            X = 4;
            Y = 0;
            Rotation = 0;
        }
        /// <summary>
        /// Получение матрицы для вращения
        /// </summary>
        /// <param name="parDirectionRotation">Направление поворота</param>
        /// <returns>Шаблонное расположеие</returns>
        public override int[,] NextRotation(int parDirectionRotation)
        {
            int[,] currentPattern = null;

            parDirectionRotation++;
            if (parDirectionRotation % 4 == 0)
            {
                parDirectionRotation = 0;
            }

            switch (parDirectionRotation)
            {
                case 0:
                    currentPattern = _pattern0;
                    break;
                case 1:
                    currentPattern = _pattern90;
                    break;
                case 2:
                    currentPattern = _pattern0;
                    break;
                case 3:
                    currentPattern = _pattern90;
                    break;
            }

            return currentPattern;
        }
        /// <summary>
        /// Новая координата x при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationX()
        {
            int nextX =_x;
            int nextRotation = _rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
            {
                nextRotation = 0;
            }
            switch (nextRotation)
            {
                case 0:
                    nextX++;
                    break;
                case 1:
                    nextX--;
                    break;
                case 2:
                    nextX += 2;
                    break;
                case 3:
                    nextX -= 2;
                    break;
            }
            return nextX;
        }
        /// <summary>
        /// Новая координата y при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationY()
        {
            int nextY = _y;
            int nextRotation = _rotation;

            nextRotation++;
            
            if (nextRotation % 4 == 0)
            {
                nextRotation = 0;
            }

            switch (nextRotation)
            {
                case 0:
                    nextY -= 2;
                    break;
                case 1:
                    nextY++;
                    break;
                case 2:
                    nextY--;
                    break;
                case 3:
                    nextY += 2;
                    break;
            }
            return nextY;
        }

        /// <summary>
        /// Вращение по кругу
        /// </summary>
        public override void Wheel()
        {

            Rotation++;
            if (Rotation % 4 == 0)
            {
                Rotation = 0;
            }
            _imageI.RotateFlip(RotateFlipType.Rotate90FlipNone);

            switch (Rotation)
            {
                case 0:
                    Y -= 2;
                    X++;
                    break;
                case 1:
                    Y++;
                    X--;
                    break;
                case 2:
                    X += 2;
                    Y--;
                    break;
                case 3:
                    X -= 2;
                    Y += 2;
                    break;
            }
        }

        #region Свойства



        /// <summary>
        /// Шаблон для получения конкретного положения относительно поворота
        /// </summary>
        public override int[,] Pattern
        {
            get
            {
                int[,] currentPattern = null;

                switch (Rotation)
                {
                    case 0:
                        currentPattern = _pattern0;
                        break;
                    case 1:
                        currentPattern = _pattern90;
                        break;
                    case 2:
                        currentPattern = _pattern0;
                        break;
                    case 3:
                        currentPattern = _pattern90;
                        break;
                }
                return currentPattern;
            }

        }
        /// <summary>
        /// Поворот
        /// </summary>
        public override int Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                if (value < 0 || value >= 5)
                {
                    throw new Exception("Поворот не может быть меньше 0 и больше 4");
                }
                else
                {
                    _rotation = value;
                }
            }
        }

        /// <summary>
        /// Координата х
        /// </summary>
        public override int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value < 0 || value >= 11)
                {
                    throw new Exception("Координата x не может быть меньше 0 и больше 11");
                }
                else
                {
                    _x = value;
                }
            }
        }
        /// <summary>
        /// Координата у
        /// </summary>
        public override int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value <0 || value >= 17)
                {
                    throw new Exception("Координата y не может быть меньше 0 и больше 16");
                }
                else
                {
                    _y = value;
                }
            } 
        }

        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        public override char Name
        {
            get
            {
                return NAME;
            }
        }
        /// <summary>
        /// Изображение
        /// </summary>
        public override Image Image
        {
            get
            {
                return _imageI;
            }
        }
#endregion
    }
}

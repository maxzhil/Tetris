using System.Drawing;
using System;
namespace Tetris
{
    /// <summary>
    /// Квадратная фигура
    /// </summary>
    public class ShapeSquare : Shape
    {
        /// <summary>
        /// Изображение
        /// </summary>
        private Image _imageO = Properties.Resources.imageO;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        private const char NAME = 'O';
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
        private int[,] _pattern0 = new int[2, 2]
        {
            { 2, 2 },
            { 2, 2 }
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeSquare()
        {
            X = 4;
            Y = 0;
            Rotation = 0;
        }
        
        /// <summary>
        /// Вращение по кругу
        /// </summary>
        public override void Wheel()
        {
            Rotation = 0;
        }

        
        /// <summary>
        /// Получение матрицы для вращения
        /// </summary>
        /// <param NAME="parDirectionRotation">Направление поворота</param>
        /// <returns>Шаблонное расположеие</returns>
        public override int[,] NextRotation(int parDirectionRotation)
        {
            return Pattern;
        }
        /// <summary>
        /// Новая координата х при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationX()
        {
            return _x;
        }
        /// <summary>
        /// Новая координата _y при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationY()
        {
            return _y;
        }

        #region Свойства

        

        /// <summary>
        /// Шаблон для получения конкретного положения относительно поворота
        /// </summary>
        public override int[,] Pattern
        {
            get
            {
                return _pattern0;
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
                return _imageO;
            }
        }

        /// <summary>
        /// Координата _х
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
        /// Координата _y
        /// </summary>
        public override int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value < 0 || value >= 17)
                {
                    throw new Exception("Координата y не может быть меньше 0 и больше 16");
                }
                else
                {
                    _y = value;
                }
            }
        }

        #endregion
    }
}

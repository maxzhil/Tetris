using System.Drawing;

namespace Tetris
{
    /// <summary>
    /// Т - образная фигура
    /// </summary>
    public class ShapeT : Shape
    {
        /// <summary>
        /// Изображение
        /// </summary>
        private Image imageT = Tetris.Properties.Resources.imageT;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        private const char NAME = 'T';
        /// <summary>
        /// координата _x
        /// </summary>
        private int _x;
        /// <summary>
        /// координата _Y
        /// </summary>
        private int _y;
        /// <summary>
        /// Поворот
        /// </summary>
        private int _rotation;

        /// <summary>
        /// Шаблонное расположение 0- градусов
        /// </summary>
        private int[,] pattern0 = new int[2, 3]
        {
            { 0, 6, 0 },
            { 6, 6, 6 }
        };
        /// <summary>
        /// Шаблонное расположение 90- градусов
        /// </summary>
        private int[,] pattern90 = new int[3, 2]
        {
            { 6, 0 },
            { 6, 6 },
            { 6, 0 }
        };
        /// <summary>
        /// Шаблонное расположение 180- градусов
        /// </summary>
        private int[,] pattern180 = new int[2, 3]
        {
            { 6, 6, 6 },
            { 0, 6, 0 }
        };
        /// <summary>
        /// Шаблонное расположение 270- градусов
        /// </summary>
        private int[,] pattern270 = new int[3, 2]
        {
            { 0, 6 },
            { 6, 6 },
            { 0, 6 }
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeT()
        {
            X = 3;
            Y = 0;
            this._rotation = 0;
        }
        /// <summary>
        /// Вращение по кругу
        /// </summary>
        public override void Wheel()
        {
            
            _rotation++;
            if (_rotation % 4 == 0)
                _rotation = 0;
            imageT.RotateFlip(RotateFlipType.Rotate90FlipNone);

            switch (_rotation)
            {
                case 0:
                    break;
                case 1:
                    _x++;
                    break;
                case 2:
                    _x--;
                    _y++;
                    break;
                case 3:
                    _y--;
                    break;
            }
        }
        /// <summary>
        /// Получение матрицы для вращения
        /// </summary>
        /// <param name="parDirectionRotation">Направление поворота</param>
        /// <returns>Шаблонное расположеие</returns>
        public override int[,] NextRotation(int parDirectionRotation)
        {
            int[,] patt = null;

            parDirectionRotation++;
            if (parDirectionRotation % 4 == 0)
                parDirectionRotation = 0;

            switch (parDirectionRotation)
            {
                case 0:
                    patt = pattern0;
                    break;
                case 1:
                    patt = pattern90;
                    break;
                case 2:
                    patt = pattern180;
                    break;
                case 3:
                    patt = pattern270;
                    break;
            }

            return patt;
        }
        /// <summary>
        /// Новая координата x при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationX()
        {
            int nextX = this._x;
            int nextRotation = _rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
                nextRotation = 0;

            switch (nextRotation)
            {
                case 0:
                    break;
                case 1:
                    nextX++;
                    break;
                case 2:
                    nextX--;
                    break;
                case 3:
                    break;
            }
            return nextX;
        }
        /// <summary>
        /// Новая координата у при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationY()
        {
            int nextY = this._y;
            int nextRotation = _rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
                nextRotation = 0;

            switch (nextRotation)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    nextY++;
                    break;
                case 3:
                    nextY--;
                    break;
            }
            return nextY;
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

                switch (_rotation)
                {
                    case 0:
                        currentPattern = pattern0;
                        break;
                    case 1:
                        currentPattern = pattern90;
                        break;
                    case 2:
                        currentPattern = pattern180;
                        break;
                    case 3:
                        currentPattern = pattern270;
                        break;
                }
                return currentPattern;
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
                _x = value;
            }
        }

        /// <summary>
        /// Координата _у
        /// </summary>
        public override int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
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
        }

        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        public override char Name
        {
            get { return NAME; }
        }
        /// <summary>
        /// Изображение
        /// </summary>
        public override Image Image
        {
            get
            {
                return imageT;
            }
        }

        #endregion

    }
}

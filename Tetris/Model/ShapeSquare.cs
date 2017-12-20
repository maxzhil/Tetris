using System.Drawing;

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
        private Image imageO = Tetris.Properties.Resources.imageO;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        private const char NAME = 'O';
        /// <summary>
        /// Координата _x
        /// </summary>
        private int _x;
        /// <summary>
        /// Координата _y
        /// </summary>
        private int _y;
        /// <summary>
        /// Поворот
        /// </summary>
        private int _rotazione;
        /// <summary>
        /// Шаблонное расположение 0- градусов
        /// </summary>
        private int[,] pattern0 = new int[2, 2]
        {
            { 2, 2 },
            { 2, 2 }
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeSquare()
        {
            this._x = 4;
            this._y = 0;
            this._rotazione = 0;
        }
        
        /// <summary>
        /// Вращение по кругу
        /// </summary>
        public override void Wheel()
        {
            _rotazione = 0;
        }

        
        /// <summary>
        /// Получение матрицы для вращения
        /// </summary>
        /// <param NAME="parDirectionRotation">Направление поворота</param>
        /// <returns>Шаблонное расположеие</returns>
        public override int[,] NextRotation(int parDirectionRotation)
        {
            return pattern0;
        }
        /// <summary>
        /// Новая координата х при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationX()
        {
            return this._x;
        }
        /// <summary>
        /// Новая координата _y при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationY()
        {
            return this._y;
        }

        #region Свойства

        

        /// <summary>
        /// Шаблон для получения конкретного положения относительно поворота
        /// </summary>
        public override int[,] Pattern
        {
            get
            {
                return pattern0;
            }
        }
        /// <summary>
        /// Поворот
        /// </summary>
        public override int Rotation
        {
            get
            {
                return _rotazione;
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
                return imageO;
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
                _y = value;
            }
        }

        #endregion
    }
}

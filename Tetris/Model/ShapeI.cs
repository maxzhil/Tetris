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
        private Image imageI = Tetris.Properties.Resources.imageI;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        public const char NAME = 'I';
        /// <summary>
        /// координата _x
        /// </summary>
        private int _x;
        /// <summary>
        /// координата _y
        /// </summary>
        private int _y;
        /// <summary>
        /// Поворот
        /// </summary>
        private int _rotation;
        /// <summary>
        /// Шаблонное расположение 0- градусов
        /// </summary>
        private int[,] pattern0 = new int[4, 1]
        {
            { 1 },
            { 1 },
            { 1 },
            { 1 }
        };
        /// <summary>
        /// Шаблонное расположение 90- градусов
        /// </summary>
        private int[,] pattern90 = new int[1, 4]
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
            _rotation = 0;
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
                parDirectionRotation = 0;

            switch (parDirectionRotation)
            {
                case 0:
                    currentPattern = pattern0;
                    break;
                case 1:
                    currentPattern = pattern90;
                    break;
                case 2:
                    currentPattern = pattern0;
                    break;
                case 3:
                    currentPattern = pattern90;
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
            int nextX = this._x;
            int nextRotation = _rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
                nextRotation = 0;

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
            int nextY = this._y;
            int nextRotation = _rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
                nextRotation = 0;

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

            _rotation++;
            if (_rotation % 4 == 0)
                _rotation = 0;
            imageI.RotateFlip(RotateFlipType.Rotate90FlipNone);

            switch (_rotation)
            {
                case 0:
                    _y -= 2;
                    _x++;
                    break;
                case 1:
                    _y++;
                    _x--;
                    break;
                case 2:
                    _x += 2;
                    _y--;
                    break;
                case 3:
                    _x -= 2;
                    _y += 2;
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

                switch (_rotation)
                {
                    case 0:
                        currentPattern = pattern0;
                        break;
                    case 1:
                        currentPattern = pattern90;
                        break;
                    case 2:
                        currentPattern = pattern0;
                        break;
                    case 3:
                        currentPattern = pattern90;
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
            get { return _rotation; }
        }

        /// <summary>
        /// Координата х
        /// </summary>
        public override int X
        {
            get { return _x; }
            set { _x = value; }
        }
        /// <summary>
        /// Координата у
        /// </summary>
        public override int Y
        {
            get { return _y; }
            set { _y = value; } 
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
            get { return imageI; }
        }
#endregion
    }
}

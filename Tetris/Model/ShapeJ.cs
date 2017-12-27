﻿using System.Drawing;
using System;

namespace Tetris
{
    /// <summary>
    /// J - образная фигура
    /// </summary>
    public class ShapeJ : Shape
    {
        /// <summary>
        /// Изображение
        /// </summary>
        private Image _imageJ = Properties.Resources.imageJ;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        private const char NAME = 'J';
        /// <summary>
        /// Координата x
        /// </summary>
        private int _x;
        /// <summary>
        /// Координата у
        /// </summary>
        private int _y;
        /// <summary>
        /// Поворот
        /// </summary>
        private int _rotation;
       
        /// <summary>
        /// Шаблонное расположение 0- градусов
        /// </summary>
        private int[,] _pattern0 = new int[3, 2]
        {
            { 0, 4 },
            { 0, 4 },
            { 4, 4 }
        };
        /// <summary>
        /// Шаблонное расположение 90- градусов
        /// </summary>
        private int[,] _pattern90 = new int[2, 3]
        {
            { 4, 0, 0 },
            { 4, 4, 4 }
        };
        /// <summary>
        /// Шаблонное расположение 180- градусов
        /// </summary>
        private int[,] _pattern180 = new int[3, 2]
        {
            { 4, 4 },
            { 4, 0 },
            { 4, 0 }
        };
        /// <summary>
        /// Шаблонное расположение 270- градусов
        /// </summary>
        private int[,] _pattern270 = new int[2, 3]
        {
            { 4, 4, 4 },
            { 0, 0, 4 }
        };
        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeJ()
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
            
            Rotation++;
            if (Rotation % 4 == 0)
            {
                Rotation = 0;
            }
            _imageJ.RotateFlip(RotateFlipType.Rotate90FlipNone);

      
            switch (Rotation)
            {
                case 0:
                    Y--;
                    break;
                case 1:
                    break;
                case 2:
                    X++;
                    break;
                case 3:
                    Y++;
                    X--;
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
                    currentPattern = _pattern180;
                    break;
                case 3:
                    currentPattern = _pattern270;
                    break;
            }

            return currentPattern;
        }
        /// <summary>
        /// Новая координата х при вращении
        /// </summary>
        /// <returns></returns>
        public override int NextRotationX()
        {
            int nextX = _x;
            int nextRotation = _rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
            {
                nextRotation = 0;
            }

            switch (nextRotation)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    nextX++;
                    break;
                case 3:
                    nextX--;
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
            {
                nextRotation = 0;
            }

            switch (nextRotation)
            {
                case 0:
                    nextY--;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    nextY++;
                    break;
            }
            return nextY;
        }

        #region Свойства

        

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
                        currentPattern = _pattern180;
                        break;
                    case 3:
                        currentPattern = _pattern270;
                        break;
                }
                return currentPattern;
            }
        }
        
        /// <summary>
        /// Изображение
        /// </summary>
        public override Image Image
        {
            get
            {
                return _imageJ;
            }
        }
        /// <summary>
        /// Координата x
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

        #endregion
    }
}

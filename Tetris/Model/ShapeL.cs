﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// L - образная фигура
    /// </summary>
    public class ShapeL : Shape
    {
        /// <summary>
        /// Изображение
        /// </summary>
        private Image imageL = Tetris.Properties.Resources.imageL;
        /// <summary>
        /// Сокращенное обозначение фигуры
        /// </summary>
        private const char NAME = 'L';
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
        private int _rotation;
        /// <summary>
        /// Шаблонное расположение 0- градусов
        /// </summary>
        private int[,] pattern0 = new int[3, 2]
        {
            { 3, 0 },
            { 3, 0 },
            { 3, 3 }
        };
        /// <summary>
        /// Шаблонное расположение 90- градусов
        /// </summary>
        private int[,] pattern90 = new int[2, 3]
        {
            { 3, 3, 3 },
            { 3, 0, 0 }
        };
        /// <summary>
        /// Шаблонное расположение 180- градусов
        /// </summary>
        private int[,] pattern180 = new int[3, 2]
        {
            { 3, 3 },
            { 0, 3 },
            { 0, 3 }
        };
        /// <summary>
        /// Шаблонное расположение 270- градусов
        /// </summary>
        private int[,] pattern270 = new int[2, 3]
        {
            { 0, 0, 3 },
            { 3, 3, 3 }
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeL()
        {
            this._x = 4;
            this._y = 0;
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
            imageL.RotateFlip(RotateFlipType.Rotate90FlipNone);

            switch (_rotation)
            {
                case 0:
                    _x++;
                    break;
                case 1:
                    _y++;
                    _x--;
                    break;
                case 2:
                    _y--;
                    break;
                case 3:
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
        /// Новая координата х при вращении
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
                    break;
                case 3:
                    break;
            }
            return nextX;
        }
        /// <summary>
        /// Новая координата y при вращении
        /// </summary>
        /// <returns></returns>ы
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
                    nextY++;
                    break;
                case 2:
                    nextY--;
                    break;
                case 3:
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
        }
        /// <summary>
        /// Шаблон для получения конкретного положения относительно поворота
        /// </summary>
        public override int[,] Pattern
        {
            get
            {
                int[,] patt = null;

                switch (_rotation)
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
        }
        /// <summary>
        /// Координата _x
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
                return imageL;
            }
        }

        #endregion
    }
}


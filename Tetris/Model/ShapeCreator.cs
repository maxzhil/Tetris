using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Создание форм
    /// </summary>
    public class ShapeCreator
    {
        /// <summary>
        /// Рандом
        /// </summary>
        private Random rnd = new Random();
        /// <summary>
        /// Создание формы
        /// </summary>
        /// <returns>Форма</returns>
        public Shape CreateShape()
        {
            Shape currentShape = null;
          
            switch ((ShapeTypes)rnd.Next(7))
            {
                case ShapeTypes.TShape:
                    currentShape = new ShapeT();
                    break;
                case ShapeTypes.IShape:
                    currentShape = new ShapeI();
                    break;
                case ShapeTypes.JShape:
                    currentShape = new ShapeJ();
                    break;
                case ShapeTypes.LShape:
                    currentShape = new ShapeL();
                    break;
                case ShapeTypes.SquareShape:
                    currentShape = new ShapeSquare();
                    break;
                case ShapeTypes.SShape:
                    currentShape = new ShapeS();
                    break;
                case ShapeTypes.ZShape:
                    currentShape = new ShapeZ();
                    break;
            }

            return currentShape;
        }
    }
}

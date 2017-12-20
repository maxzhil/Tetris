using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Игровое поле тетриса
    /// </summary>
    public class TetrisGrid
    {
        /// <summary>
        /// Количество столбцов поля
        /// </summary>
        private const int GRID_COLUMS = 10;
        /// <summary>
        /// Количество строк поля
        /// </summary>
        private const int GRID_LINES = 16;
        /// <summary>
        /// Игровое поле
        /// </summary>
        private static int[,] _grid = new int[GRID_LINES, GRID_COLUMS];
        /// <summary>
        /// Конструктор
        /// </summary>
        public TetrisGrid()
        {
            ClearGrid();
        }
       
        /// <summary>
        /// Очистить грид
        /// </summary>
        public void ClearGrid()
        {
            for (int i = 0; i < GRID_LINES; i++)
                for (int j = 0; j < GRID_COLUMS; j++)
                    _grid[i, j] = 0;
        }

        /// <summary>
        /// Игровое поле
        /// </summary>
        public int[,] Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
    }
}

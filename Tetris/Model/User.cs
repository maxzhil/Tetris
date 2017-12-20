using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Пользователь 
    /// </summary>
    [Serializable()]
   public class User
    {
        /// <summary>
        /// Очки
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
    }
}

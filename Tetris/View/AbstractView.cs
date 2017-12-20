using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris.View
{
    /// <summary>
    /// Абстрактная вью
    /// </summary>
    public abstract class AbstractView
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public abstract void InitializeForm();
    }
}

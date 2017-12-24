using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tetris.View;

namespace Tetris.Controller
{
    /// <summary>
    /// Контроллер просмотра рекордов
    /// </summary>
    public class ControllerViewScore
    {
        /// <summary>
        /// Вью 
        /// </summary>
        private ViewScore _viewScore;
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Конструктор
        /// </summary>
        public ControllerViewScore(Model parModel)
        {
            _model = parModel;
            _viewScore = new ViewScore();
            _viewScore.DataGrid.DataSource = parModel._users;
            _viewScore.ButtonClear.MouseClick += ClearListScore;
            _viewScore.ButtonExit.MouseClick += delegate { _viewScore.FormViewRecord.Close(); };
            _viewScore.FormViewRecord.ShowDialog();
        }
        /// <summary>
        /// Очистить список рекордов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClearListScore(object sender, MouseEventArgs e)
        {
            _viewScore.DataGrid.DataSource = null;
            _model._users.Clear();
            _model.CreateUserFile();
            _viewScore.DataGrid.DataSource = _model._users;
        }
    }
}

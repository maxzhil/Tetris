using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tetris.View;

namespace Tetris.Controller
{
    /// <summary>
    /// Контроллер просмотра рекордов
    /// </summary>
    public class ControllerViewScore
    {
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model= new Model();
        /// <summary>
        /// Форма просмотра рекордов
        /// </summary>
        private FormViewRecord _formViewRecord;
        /// <summary>
        /// Вью 
        /// </summary>
        private ViewScore _viewScore;
        /// <summary>
        /// Конструктор
        /// </summary>
        public ControllerViewScore()
        {
            _formViewRecord = new FormViewRecord();
            _viewScore = new ViewScore(_model,_formViewRecord);
            _viewScore.DataGrid.DataSource = _model._users;
            _formViewRecord.ShowDialog();
        }

    }
}

using System.Drawing;
using System.Windows.Forms;

namespace Tetris.View
{
    /// <summary>
    /// Вью просмотра рекордов
    /// </summary>
    public class ViewScore
    {
        /// <summary>
        /// Таблица
        /// </summary>
        private DataGrid _dataGrid = new DataGrid();
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Форма просмотра рекордов
        /// </summary>
        private FormViewRecord _formViewRecord;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parModel">модель</param>
        /// <param name="parFormViewRecord">Форма</param>
        public ViewScore(Model parModel, FormViewRecord parFormViewRecord)
        {
            _model = parModel;
            _formViewRecord = parFormViewRecord;
            _formViewRecord.StartPosition = FormStartPosition.CenterScreen;
            _formViewRecord.Size = new Size(400,600);
            _formViewRecord.MaximizeBox = false;
            _dataGrid.Location = new Point(10, 10);
            _dataGrid.Width = 300;
            _dataGrid.Height = 500;
            _formViewRecord.Controls.Add(_dataGrid);
            

        }
        /// <summary>
        /// Таблица
        /// </summary>
        public DataGrid DataGrid
        {
            get { return _dataGrid; }
            set { _dataGrid = value; }
        }
    }
}

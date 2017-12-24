using System.Drawing;
using System.Windows.Forms;

namespace Tetris.View
{
    /// <summary>
    /// Вью просмотра рекордов
    /// </summary>
    public class ViewScore : AbstractView
    {
        /// <summary>
        /// Таблица
        /// </summary>
        private DataGrid _dataGrid = new DataGrid();
        /// <summary>
        /// Форма просмотра рекордов
        /// </summary>
        private FormViewRecord _formViewRecord;
        /// <summary>
        /// Кнопка очистить список рекордов
        /// </summary>
        private Button _buttonClear = new Button();
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        private Button _buttonExit = new Button();
        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewScore()
        {
            InitializeForm();

        }
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public override void InitializeForm()
        {
            _formViewRecord = new FormViewRecord();
            _formViewRecord.StartPosition = FormStartPosition.CenterScreen;
            _formViewRecord.Size = new Size(400, 350);
            _formViewRecord.MaximizeBox = false;
            _formViewRecord.MinimumSize = _formViewRecord.Size;
            _formViewRecord.MaximumSize = _formViewRecord.Size;
            _formViewRecord.Text = "Score";
            _formViewRecord.MaximizeBox = false;
            _dataGrid.Location = new Point(10, 10);
            _dataGrid.Width = 250;
            _dataGrid.Height = 300;
            _formViewRecord.Controls.Add(_dataGrid);
            _buttonExit.Text = "Exit";
            _buttonExit.Location = new Point(300, 200);
            _buttonExit.BackColor = Color.White;
            _formViewRecord.Controls.Add(_buttonExit);
            _buttonClear.Text = "Clear";
            _buttonClear.Location = new Point(300, 150);
            _buttonClear.BackColor = Color.White;
            _formViewRecord.Controls.Add(_buttonClear);

        }
        /// <summary>
        /// Таблица
        /// </summary>
        public DataGrid DataGrid
        {
            get { return _dataGrid; }
            set { _dataGrid = value; }
        }
        /// <summary>
        /// Форма просмотра рекордов
        /// </summary>
        public FormViewRecord FormViewRecord
        {
            get { return _formViewRecord; }
        }
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        public Button ButtonExit
        {
            get { return _buttonExit; }
        }
        /// <summary>
        /// Кнопка очистить список рекордов
        /// </summary>
        public Button ButtonClear
        {
            get { return _buttonClear; }
        }
    }
}

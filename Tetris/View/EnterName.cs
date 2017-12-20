using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris.View
{
    /// <summary>
    /// Вью формы ввода имени
    /// </summary>
    public class EnterName : AbstractView
    {
        /// <summary>
        /// Форма ввода
        /// </summary>
        private FormEnterName _enterForm;
        /// <summary>
        /// Поле ввода имени
        /// </summary>
        private TextBox _textBoxName = new TextBox();
        /// <summary>
        /// Поле просмотра очков
        /// </summary>
        private TextBox _textBoxScore = new TextBox();
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        private Button _buttonCancel = new Button();
        /// <summary>
        /// Кнопка сохранения
        /// </summary>
        private Button _buttonSave = new Button();
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parForm">Форма</param>
        /// <param name="parModel">Модель</param>
        public EnterName(FormEnterName parForm,Model parModel)
        {
            _model = parModel;
            _enterForm = parForm;
            InitializeForm();
        }
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public override void InitializeForm()
        {
            _enterForm.Size = new Size(200, 200);
            _enterForm.MinimumSize = _enterForm.Size;
            _enterForm.MaximumSize = _enterForm.Size;
            _enterForm.Text = "Tetris";
            _enterForm.MaximizeBox = false;
            _textBoxName.Location = new Point(10, 10);
            _enterForm.Controls.Add(_textBoxName);
            _textBoxScore.Location = new Point(10, 50);
            _textBoxScore.Text = "" + _model.Score;
            _textBoxScore.ReadOnly = true;
            _enterForm.Controls.Add(_textBoxScore);
            _buttonCancel.Text = "Cancel";
            _buttonCancel.Location = new Point(50, 130);
            _buttonCancel.BackColor = Color.White;
            _enterForm.Controls.Add(_buttonCancel);
            _buttonSave.Text = "Save";
            _buttonSave.BackColor = Color.White;
            _buttonSave.Location = new Point(50, 100);
            _enterForm.Controls.Add(_buttonSave);
        }

#region Свойства
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        public Button ButtonCancel
        {
            get { return _buttonCancel; }
        }
        /// <summary>
        /// Кнопка сохранения
        /// </summary>
        public Button ButtonSave
        {
            get { return _buttonSave; }
        }
        /// <summary>
        /// Форма ввода
        /// </summary>
        public FormEnterName FormEnterName
        {
            get { return _enterForm; }
        }
        /// <summary>
        /// Поле ввода имени
        /// </summary>
        public TextBox TextBoxName
        {
            get { return _textBoxName; }
        }
        /// <summary>
        /// Поле просмотра очков
        /// </summary>
        public TextBox TextBoxScore
        {
            get { return _textBoxScore; }
        }
#endregion
    }
}

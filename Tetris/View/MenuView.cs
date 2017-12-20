using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Tetris.View
{
    /// <summary>
    /// Вью меню
    /// </summary>
    public class MenuView : AbstractView
    {
        
        /// <summary>
        /// Форма меню
        /// </summary>
        private FormMenu _formMenu;
        /// <summary>
        /// Начать игру
        /// </summary>
        private Button _playButton = new Button();
        /// <summary>
        /// Выход из игры
        /// </summary>
        private Button _exitButton = new Button();
        /// <summary>
        /// Просмотр очков
        /// </summary>
        private Button _scoreButton = new Button();
        /// <summary>
        /// Конструктор
        /// </summary>
        public MenuView()
        {
            InitializeForm();
        }
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public override void InitializeForm()
        {
            _formMenu = new FormMenu();
            _formMenu.BackgroundImage = Properties.Resources.menuView;
            _formMenu.StartPosition = FormStartPosition.CenterScreen;
            _formMenu.Size = Properties.Resources.menuView.Size;
            _formMenu.MaximizeBox = false;
            _formMenu.Text = "Tetris";
            _playButton.Location = new Point((_formMenu.Width - _playButton.Width) / 2, (_formMenu.Height + _playButton.Height) / 2);
            _playButton.Text = "Play";
            _playButton.BackColor = Color.White;
            _scoreButton.Location = new Point(_playButton.Left, _playButton.Top + PlayButton.Height + 10);
            _scoreButton.Text = "Score";
            _scoreButton.BackColor = Color.White;
            _exitButton.Text = "Exit";
            _exitButton.Location = new Point(_playButton.Left, ScoreButton.Top + ScoreButton.Height + 10);
            _formMenu.Controls.Add(_playButton);
            _formMenu.Controls.Add(_scoreButton);
            _formMenu.Controls.Add(_exitButton);
        }
        /// <summary>
        /// Запуск программы
        /// </summary>
        public void OnMenu()
        {
            Application.EnableVisualStyles();
            Application.Run(_formMenu);
        }
#region Свойства
        /// <summary>
        /// Начать игру
        /// </summary>
        public Button PlayButton
        {
            get { return _playButton; }
        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        public Button ExitButton
        {
            get { return _exitButton; }
        }
        /// <summary>
        /// Просмотр очков
        /// </summary>
        public Button ScoreButton
        {
            get { return _scoreButton; }
        }
        /// <summary>
        /// Форма меню
        /// </summary>
        public FormMenu FormMenu
        {
            get { return _formMenu; }
        }
#endregion
    }
}

using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Tetris.View;

namespace Tetris.Controller
{
    /// <summary>
    /// Контроллер меню
    /// </summary>
    public class ControllerMenu
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        private MenuView _menuView;
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model = Model.GetInstance();
        /// <summary>
        /// Конструктор
        /// </summary>
        public ControllerMenu()
        {
            _menuView = new MenuView();
            _menuView.PlayButton.MouseClick += PlayGame;
            _menuView.ScoreButton.MouseClick += ViewScore;
            _menuView.ExitButton.MouseClick += delegate { _menuView.FormMenu.Close(); };
            _menuView.OnMenu();

        }
        /// <summary>
        /// Начать игру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayGame(object sender, MouseEventArgs e)
        {
            new ControllerGame(_model);
        }
        /// <summary>
        /// Просмотр результатов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ViewScore(object sender, MouseEventArgs e)
        {
            new ControllerViewScore(_model);
        }
    }
}


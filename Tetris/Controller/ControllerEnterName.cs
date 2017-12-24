using System;
using System.Windows.Forms;
using Tetris.View;

namespace Tetris
{   
    /// <summary>
    /// Контроллер ввода имени
    /// </summary>
    public class ControllerEnterName
    {
        /// <summary>
        /// Вью ввода имени
        /// </summary>
        private EnterNameView _enterNameView;
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parModel">Mодель</param>
        public ControllerEnterName(Model parModel)
        {
            _model = parModel;
            _enterNameView = new EnterNameView(_model);
            _enterNameView.ButtonCancel.MouseClick += delegate { _enterNameView.FormEnterName.Close(); };
            _enterNameView.ButtonSave.MouseClick += SaveScore;
            _enterNameView.FormEnterName.ShowDialog();
        }

        /// <summary>
        /// Сохранение результата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveScore(object sender, MouseEventArgs e)
        {
            if (_enterNameView.TextBoxName.Text == "")
            {
                MessageBox.Show("Enter your name");
            }
            else
            {
                _model.SaveScore(_enterNameView.TextBoxName.Text.ToString(), _model.Score);
                _enterNameView.FormEnterName.Close();
            }
        }
    }
}

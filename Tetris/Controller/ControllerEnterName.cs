using System;
using System.Windows.Forms;

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
        private EnterName _enterName;
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parForm">Форма</param>
        /// <param name="parModel">модель</param>
        public ControllerEnterName(FormEnterName parForm,Model parModel)
        {

            _model = parModel;
            _enterName = new EnterName(parForm,_model);
            _enterName.ButtonCancel.MouseClick += delegate { parForm.Close(); };
            _enterName.ButtonSave.MouseClick += SaveScore;
            _enterName.FormEnterName.ShowDialog();
        }

        /// <summary>
        /// Сохранение результата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveScore(object sender, MouseEventArgs e)
        {
            _model.SaveScore(_enterName.TextBoxName.Text.ToString(), _model.Score);
           _enterName.FormEnterName.Close();
        }
    }
}

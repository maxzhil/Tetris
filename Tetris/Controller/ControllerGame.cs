using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.View;

namespace Tetris.Controller
{
    /// <summary>
    /// Контроллер игры
    /// </summary>
    public class ControllerGame
    {
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Контроллер ввода имени
        /// </summary>
        private ControllerEnterName _controllerEnterName;
        /// <summary>
        /// Представление игры
        /// </summary>
        private GameView _gameView;
        /// <summary>
        /// Вью ввода имени
        /// </summary>
        public EnterNameView _enterNameView;
        /// <summary>
        /// Фиксация фигуры 
        /// </summary>
        private bool _fixedShape = false;
        /// <summary>
        /// Пауза
        /// </summary>
        private bool _inPause = false;
        /// <summary>
        /// Уровень
        /// </summary>
        private int _level;
     
        /// <summary>
        /// Конструктор
        /// </summary>
        public ControllerGame(Model parModel)
        {
            _model = parModel;
            _gameView = new GameView(_model);
            _gameView.FormGame.Paint += OnPaint;
            _gameView.Timer.Tick += OnDraw;
            _gameView.FormGame.KeyDown += FormKeyDown;
            _gameView.ButtonPause.MouseClick += PauseResumeGame;
            _gameView.ButtonExit.MouseClick += ExitGame;
            _model.InitializeMatch();
            _gameView.FormGame.ShowDialog();
        }

        /// <summary>
        /// Нажатие кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (_gameView.FormGame != null)
            {
                if (!_inPause)
                    switch (e.KeyData)
                    {
                        case Keys.NumPad8:
                            _model.ShapeWheel();
                            _gameView.FormGame.Refresh();
                            break;
                        case Keys.NumPad5:
                            MoveDown();
                            _gameView.FormGame.Refresh();
                            break;
                        case Keys.NumPad4:
                            _model.MoveLeft();
                            _gameView.FormGame.Refresh();
                            break;
                        case Keys.NumPad6:
                            _model.MoveRight();
                            _gameView.FormGame.Refresh();
                            break;
                    }
            }
        }
     
        /// <summary>
        /// Остановка игры
        /// </summary>
        private void GameBreak()
        {
            _inPause = true;
            _gameView.Timer.Enabled = false;
        }

        /// <summary>
        /// Продолжение игры
        /// </summary>
        private void ResumeGame()
        {
            _inPause = false;
            _gameView.Timer.Enabled = true;
        }

        /// <summary>
        /// Ставит на паузу или продолжает игру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseResumeGame(object sender, MouseEventArgs e)
        {
            if (_gameView.Timer.Enabled == true)
                GameBreak();
            else
                ResumeGame();
        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitGame(object sender, MouseEventArgs e)
        {
            GameBreak();
            OpenFormEnterName();
            _gameView.FormGame.Close();
        }

        /// <summary>
        /// Уменьшение интервыла таймера
        /// </summary>
        private void DecreaseTimerRange()
        {
            if (_gameView.TimerInterval >= 200)
                _gameView.TimerInterval -= 50;
        }

        /// <summary>
        /// Способ перемещения фигуры в игре вниз
        /// </summary>
        private void MoveDown()
        {
            if (_model.InPlay)
            {
                if (!_fixedShape)
                {
                    _fixedShape = _model.MoveDown();
                    if (_fixedShape)
                    {
                        _model.ExtractShape();
                        _fixedShape = false;
                        _gameView.LabelScore = "Score: " + _model.Score.ToString();
                        if (_level < _model.Level)
                        {
                            DecreaseTimerRange();
                            _level = _model.Level;
                            _gameView.LabelLevel = "Level: " + _level.ToString();
                        }
                    }
                }
            }
            else
            {
                _gameView.Timer.Enabled = false;
                _gameView.Timer.Stop();
                OpenFormEnterName();                   
                _gameView.FormGame.Close();
                _gameView.FormGame = null;
            }

        }
        /// <summary>
        /// Открытие формы ввода имени
        /// </summary>
        private void OpenFormEnterName()
        {
            _controllerEnterName = new ControllerEnterName(_model);
        }
        /// <summary>
        /// Обработка отрисовки модели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDraw(object sender, EventArgs e)
        {
            MoveDown();
            if (_gameView.FormGame != null)
                _gameView.FormGame.Refresh();
        }

        /// <summary>
        /// Обработка перерисовки формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            _gameView.FormGame.BackColor = Color.DimGray;
            _gameView.DrawBlocks(e);
            _gameView.DrawShape(_model.CurrentShape, e);
            _gameView.DrawNextShape(_model.NextShape, e);
        }
    }
}

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
    /// Контроллер формы игры
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
        /// Форма ввода имени 
        /// </summary>
        private FormEnterName _formEnterName = new FormEnterName();
        /// <summary>
        /// Представление игры
        /// </summary>
        private GameView _gameView;
        /// <summary>
        /// Вью ввода имени
        /// </summary>
        public EnterName _enterName;
        /// <summary>
        /// Контейнер 
        /// </summary>
        private Rectangle _containerShape;
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
        /// Размер блоков
        /// </summary>
        private const int _blockSize = 25;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parForm">Форма</param>
        public ControllerGame(FormGame parForm)
        {
            _model = new Model();
            parForm.KeyPreview = true;

            this._gameView = new GameView(_model, parForm);
            _gameView.GameForm.Paint += OnPaint;
            _gameView.Timer.Tick += OnDraw;
            _gameView.GameForm.KeyDown += FormKeyDown;
            _gameView.PauseButton.MouseClick += PauseResumeGame;
            _gameView.ExitButton.MouseClick += delegate { OpenFormEnterName();_gameView.GameForm.Close(); };
            _model.InitializeMatch();
            _gameView.GameForm.ShowDialog();
        }

        /// <summary>
        /// Нажатие кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (_gameView.GameForm != null)
            {
                if (!_inPause)
                    switch (e.KeyData)
                    {
                        case Keys.NumPad8:
                            _model.ShapeWheel();
                            _gameView.GameForm.Refresh();
                            break;
                        case Keys.NumPad5:
                            MoveDown();
                            _gameView.GameForm.Refresh();
                            break;
                        case Keys.NumPad4:
                            _model.MoveLeft();
                            _containerShape.X -= _blockSize;
                            _gameView.GameForm.Refresh();
                            break;
                        case Keys.NumPad6:
                            _model.MoveRight();
                            _containerShape.X += _blockSize;
                            _gameView.GameForm.Refresh();
                            break;
                    }
            }
        }
     
        /// <summary>
        /// Пауза 
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
                        
                        _gameView.ScoreLabel = "Score: " + _model.Score.ToString();
                        if (_level < _model.Level)
                        {
                            DecreaseTimerRange();
                            _level = _model.Level;
                            _gameView.LevelLabel = "Level: " + _level.ToString();
                        }
                    }
                }
            }
            else
            {
                this._gameView.Timer.Enabled = false;
                _gameView.Timer.Stop();
                OpenFormEnterName();                   
                _gameView.GameForm.Close();
                _gameView.GameForm = null;

            }

        }
        
        /// <summary>
        /// Открытие формы ввода имени
        /// </summary>
        private void OpenFormEnterName()
        {

            _controllerEnterName = new ControllerEnterName(_formEnterName,_model);

        }
        /// <summary>
        /// Обработка отрисовки модели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDraw(object sender, EventArgs e)
        {
            MoveDown();
            if (_gameView.GameForm != null)
                _gameView.GameForm.Refresh();
        }

        /// <summary>
        /// Обработка перерисовки формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.FillRectangle(_gameView.Brush, _gameView.Sidebar);
            _gameView.GameForm.BackColor = Color.DimGray;
            _gameView.DrawBlocks(e);
            _gameView.DrawShape(_model.CurrentShape, e);
            _gameView.DrawNextShape(_model.NextShape, e);
        }
    }
}

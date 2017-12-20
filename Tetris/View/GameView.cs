using System;
using System.Drawing;
using System.Windows.Forms;
using Tetris.View;

namespace Tetris
{
    /// <summary>
    /// Вью игры
    /// </summary>
    public class GameView : AbstractView
    {
                
        /// <summary>
        /// Изображение I - образной фигуры
        /// </summary>
        private Image _imageI_25;
        /// <summary>
        /// Изображение J - образной фигуры
        /// </summary>
        private Image _imageJ_25;
        /// <summary>
        /// Изображение L - образной фигуры
        /// </summary>
        private Image _imageL_25;
        /// <summary>
        /// Изображение O - образной фигуры
        /// </summary>
        private Image _imageO_25;
        /// <summary>
        /// Изображение S - образной фигуры
        /// </summary>
        private Image _imageS_25;
        /// <summary>
        /// /Изображение T - образной фигуры
        /// </summary>
        private Image _imageT_25;
        /// <summary>
        /// Изображение Z - образной фигуры
        /// </summary>
        private Image _imageZ_25;
        /// <summary>
        /// Форма игры
        /// </summary>
        private FormGame _formGame;
        /// <summary>
        /// Контейнер для фигур
        /// </summary>
        private Rectangle containerShape;
        /// <summary>
        /// Размер блоков
        /// </summary>
        private const int blockSize = 25;
        /// <summary>
        /// Кнопка паузы
        /// </summary>
        private Button _buttonPause = new Button();
        /// <summary>
        /// Выход из игры11
        /// </summary>
        private Button _buttonExit  = new Button();
        /// <summary>
        /// Уровень
        /// </summary>
        private Label _labelLevel = new Label();
        /// <summary>
        /// Очки
        /// </summary>
        private Label _labelScore = new Label();
        /// <summary>
        /// Информация о игре
        /// </summary>
        private Label _labelInfo = new Label();
        /// <summary>
        /// Модель
        /// </summary>
        private Model _model;
        /// <summary>
        /// Боковая панельы
        /// </summary>
        private Rectangle _sidebar = new Rectangle(250, 0, 130, 400);
        /// <summary>
        /// Таймер
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// Кисть для рисования
        /// </summary>
        private SolidBrush _brush = new SolidBrush(Color.CadetBlue);
        /// <summary>
        /// Конструктор
        /// </summary>
        public GameView(Model parModel,FormGame parFormGame)
        { 
            InitializeTexture();
            _model = parModel;
            InitializeForm(parFormGame);
            InitializeTimer(); 
                      
        }
        /// <summary>
        /// Инициализация формы
        /// </summary>
        /// <param name="parFormGame">Форма игры</param>
        private void InitializeForm(FormGame parFormGame)
        {
            _formGame = parFormGame;
            _formGame.ClientSize = new Size(380, 400);
            _formGame.MinimumSize = _formGame.Size;
            _formGame.MaximumSize = _formGame.Size;
            _formGame.Text = "Tetris";
            _formGame.MaximizeBox = false;
            _buttonPause.Location = new Point(260, 300);
            _buttonPause.Text = "Pause";
            _buttonPause.BackColor = Color.White;
            _formGame.Controls.Add(_buttonPause);
            _buttonExit.Text = "Exit";
            _buttonExit.Location = new Point(260, 320);
            _buttonExit.BackColor = Color.White;
            _formGame.Controls.Add(_buttonExit);
            _labelLevel.Location = new Point(260, 180);
            _labelLevel.BackColor = Color.CadetBlue;
            _labelLevel.Text = "Level : 1";
            _formGame.Controls.Add(_labelLevel);
            _labelScore.Location = new Point(260, 200);
            _labelScore.BackColor = Color.CadetBlue;
            _labelScore.Text = "Score : 0";
            _labelInfo.Location = new Point(260,220);
            _labelInfo.Text = "Up : NumPad8 \n Left: NumPad4 \n Right: NumPad6 \n Down: NumPad5";
            _labelInfo.Height = 80;
            _labelInfo.BackColor = Color.CadetBlue;
            _formGame.Controls.Add(_labelInfo);
            _formGame.Controls.Add(_labelScore);
        }
        /// <summary>
        /// Инициализация таймера
        /// </summary>
        public void InitializeTimer()
        {
            _timer = new Timer();
            Timer.Interval = 600;
            Timer.Enabled = true;
        }
        /// <summary>
        /// Инициализация текстур
        /// </summary>
        private void InitializeTexture()
        {
            _imageI_25 = Properties.Resources.imageI_25;
            _imageJ_25 = Properties.Resources.imageJ_25;
            _imageL_25 = Properties.Resources.imageL_25;
            _imageO_25 = Properties.Resources.imageO_25;
            _imageS_25 = Properties.Resources.imageS_25;
            _imageT_25 = Properties.Resources.imageT_25;
            _imageZ_25 = Properties.Resources.imageZ_25;
        }


        /// <summary>
        /// Появление новой формы в контейнере
        /// </summary>
        /// <param name="parShape"></param>
        /// <param name="e"></param>
        public void DrawShape(Shape parShape, PaintEventArgs e)
        {
            containerShape = new Rectangle(_model.CurrentShape.X * blockSize,
                                           _model.CurrentShape.Y * blockSize,
                                           _model.CurrentShape.Image.Width,
                                           _model.CurrentShape.Image.Height);

            e.Graphics.DrawImage(parShape.Image,containerShape);
           
        }
        /// <summary>
        /// Отображение следующей фигуры
        /// </summary>
        /// <param name="parShape"></param>
        /// <param name="e"></param>
        public void DrawNextShape(Shape parShape,PaintEventArgs e)
        {
            e.Graphics.DrawImage(parShape.Image,
                parShape.Name == 'I' ? 295 : 280,
               50);
        }
        /// <summary>
        /// Отрисовка блоков 
        /// </summary>
        /// <param name="e"></param>
        public void DrawBlocks(PaintEventArgs e)
        {
            for (int i = 0; i < _model.TetrisGrid.Grid.GetLength(0); i++)
                for (int j = 0; j < _model.TetrisGrid.Grid.GetLength(1); j++)
                    switch (_model.TetrisGrid.Grid[i, j])
                    {
                        case 1:
                            e.Graphics.DrawImage(_imageI_25, j * 25, i * 25);
                            break;
                        case 2:
                            e.Graphics.DrawImage(_imageO_25, j * 25, i * 25);
                            break;
                        case 3:
                            e.Graphics.DrawImage(_imageL_25, j * 25, i * 25);
                            break;
                        case 4:
                            e.Graphics.DrawImage(_imageJ_25, j * 25, i * 25);
                            break;
                        case 5:
                            e.Graphics.DrawImage(_imageZ_25, j * 25, i * 25);
                            break;
                        case 6:
                            e.Graphics.DrawImage(_imageT_25, j * 25, i * 25);
                            break;
                        case 7:
                            e.Graphics.DrawImage(_imageS_25, j * 25, i * 25);
                            break;
                    }
        }
#region Свойства
        /// <summary>
        /// Интервал таймера
        /// </summary>
        public int TimerInterval
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }
        /// <summary>
        /// Модель
        /// </summary>
        public Model Model
        {
            get { return _model; }
            set { _model = value; }
        }

        /// <summary>
        /// Кисть
        /// </summary>
        public SolidBrush Brush
        {
            get { return _brush; }
        }
        /// <summary>
        /// Боковая панель
        /// </summary>
        public Rectangle Sidebar
        {
            get { return _sidebar; }
        }
        /// <summary>
        /// Кнопка паузы
        /// </summary>
        public Button PauseButton
        {
            get { return _buttonPause; }
        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        public Button ExitButton
        {
            get { return _buttonExit; }
        }

        /// <summary>
        /// Таймер для рисования
        /// </summary>
        public Timer Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }
        /// <summary>
        /// Очки
        /// </summary>
        public string ScoreLabel
        {
            get { return _labelScore.ToString(); }
            set { _labelScore.Text = value; }
        }
        /// <summary>
        /// Уровень
        /// </summary>
        public string LevelLabel
        {
            get { return _labelLevel.ToString(); }
            set { _labelLevel.Text = value; }
        }
        /// <summary>
        /// Форма для рисования
        /// </summary>
        public FormGame GameForm
        {
            get { return _formGame; }
            set { _formGame = value; }
        }
#endregion 
    }
}

using System;
using System.Windows.Forms;
using System.Drawing;

namespace BreakoutGame
{
    public partial class Form1 : Form
    {
        private Game game;
        private Timer gameTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            game = new Game(gamePanel.Width, gamePanel.Height);
            gameTimer = new Timer { Interval = 16 };
            gameTimer.Tick += GameTimer_Tick;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            startButton.Enabled = false;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            game.Update(gamePanel.Width, gamePanel.Height);
            scoreLabel.Text = $"Score: {game.Score}";
            gamePanel.Invalidate();
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.White, game.Ball.GetBallRect());
            e.Graphics.FillRectangle(Brushes.White, game.Paddle.PaddleRect);

            foreach (var brick in game.Bricks)
            {
                brick.Draw(e.Graphics);
            }
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            game.Paddle.MoveTo(e.X);
        }
    }
}

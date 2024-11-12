using System;
using System.Drawing;
using System.Windows.Forms;

namespace BreakoutGame
{
    public partial class Form1 : Form
    {
        private Panel paddle;
        private PictureBox ball;
        private int score = 0;
        private int ballXSpeed = 4;
        private int ballYSpeed = 4;
        private int paddleSpeed = 30;

        // Constructor
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Initialize game objects
        private void InitializeGame()
        {
            // Initialize Paddle
            paddle = new Panel
            {
                Size = new Size(100, 20),
                Location = new Point((gamePanel.Width / 2) - 50, gamePanel.Height - 30),
                BackColor = Color.Blue
            };
            gamePanel.Controls.Add(paddle);

            // Initialize Ball
            ball = new PictureBox
            {
                Size = new Size(15, 15),
                Location = new Point(gamePanel.Width / 2, gamePanel.Height / 2),
                BackColor = Color.Red
            };
            gamePanel.Controls.Add(ball);

            // Initialize Timer
            gameTimer.Start();
        }

        // Game timer tick handler
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MoveBall();
            CheckCollision();
        }

        // Move the ball based on its speed
        private void MoveBall()
        {
            ball.Left += ballXSpeed;
            ball.Top += ballYSpeed;

            // Ball bouncing off the left and right walls
            if (ball.Left <= 0 || ball.Right >= gamePanel.Width)
            {
                ballXSpeed = -ballXSpeed;
            }

            // Ball bouncing off the top wall
            if (ball.Top <= 0)
            {
                ballYSpeed = -ballYSpeed;
            }

            // Ball falling off the bottom (game over)
            if (ball.Bottom >= gamePanel.Height)
            {
                gameTimer.Stop();
                MessageBox.Show("Game Over! Final Score: " + score);
                score = 0;
                ResetGame();
            }
        }

        // Check for collisions (ball and paddle)
        private void CheckCollision()
        {
            if (ball.Bounds.IntersectsWith(paddle.Bounds))
            {
                ballYSpeed = -ballYSpeed;
                score += 10;
                scoreLabel.Text = "Score: " + score;
            }
        }

        // Reset the game after game over
        private void ResetGame()
        {
            ball.Location = new Point(gamePanel.Width / 2, gamePanel.Height / 2);
            paddle.Location = new Point((gamePanel.Width / 2) - 50, gamePanel.Height - 30);
            scoreLabel.Text = "Score: 0";
            gameTimer.Start();
        }

        // Start button click handler
        private void startButton_Click(object sender, EventArgs e)
        {
            score = 0;
            scoreLabel.Text = "Score: 0";
            gameTimer.Start();
        }

        // Move paddle based on mouse movement
        private void gamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            paddle.Left = e.X - (paddle.Width / 2);

            // Keep paddle within the panel boundaries
            if (paddle.Left < 0)
            {
                paddle.Left = 0;
            }
            if (paddle.Right > gamePanel.Width)
            {
                paddle.Left = gamePanel.Width - paddle.Width;
            }
        }
    }
}

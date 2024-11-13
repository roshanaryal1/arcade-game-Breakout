using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BreakoutGame
{
    public partial class Form1 : Form
    {
        private Panel paddle;
        private PictureBox ball;
        private List<PictureBox> bricks;
        private int score = 0;
        private int ballXSpeed = 4;
        private int ballYSpeed = 4;
        private bool isGameRunning = false;

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

            // Initialize Bricks
            bricks = new List<PictureBox>();
            CreateBricks();

            // Stop the timer initially
            gameTimer.Stop();
        }

        // Method to create bricks
        private void CreateBricks()
        {
            int brickWidth = 70;
            int brickHeight = 20;
            int rows = 5;
            int cols = 10;
            Color[] colors = { Color.Purple, Color.Blue, Color.Green, Color.Yellow, Color.Red };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PictureBox brick = new PictureBox
                    {
                        Size = new Size(brickWidth, brickHeight),
                        Location = new Point(j * (brickWidth + 5), i * (brickHeight + 5)),
                        BackColor = colors[i],
                        Tag = "brick",
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    bricks.Add(brick);
                    gamePanel.Controls.Add(brick);
                }
            }
        }

        // Game timer tick handler
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (isGameRunning)
            {
                MoveBall();
                CheckCollision();
            }
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
                isGameRunning = false;
                MessageBox.Show("Game Over! Final Score: " + score);
                ResetGame();
            }
        }

        // Check for collisions with paddle and bricks
        private void CheckCollision()
        {
            // Collision with paddle
            if (ball.Bounds.IntersectsWith(paddle.Bounds))
            {
                ballYSpeed = -ballYSpeed;
            }

            // Collision with bricks
            for (int i = bricks.Count - 1; i >= 0; i--)
            {
                var brick = bricks[i];
                if (ball.Bounds.IntersectsWith(brick.Bounds))
                {
                    ballYSpeed = -ballYSpeed; // Reverse the ball's Y direction
                    score += 10;
                    scoreLabel.Text = "Score: " + score;
                    gamePanel.Controls.Remove(brick);
                    bricks.Remove(brick);
                    break; // Exit loop after collision to avoid multiple bounces
                }
            }
        }

        // Reset the game after game over
        private void ResetGame()
        {
            ball.Location = new Point(gamePanel.Width / 2, gamePanel.Height / 2);
            paddle.Location = new Point((gamePanel.Width / 2) - 50, gamePanel.Height - 30);
            gamePanel.Controls.Clear();
            gamePanel.Controls.Add(paddle);
            gamePanel.Controls.Add(ball);
            CreateBricks();
            score = 0;
            scoreLabel.Text = "Score: 0";
        }

        // Start button click handler
        private void startButton_Click(object sender, EventArgs e)
        {
            score = 0;
            scoreLabel.Text = "Score: 0";
            isGameRunning = true;
            gameTimer.Start();
        }

        // Move paddle based on mouse movement
        private void gamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isGameRunning) return;
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

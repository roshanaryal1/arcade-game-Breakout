using System.Collections.Generic;
using System.Drawing;

public class Game
{
    public Ball Ball;
    public Paddle Paddle;
    public List<Brick> Bricks;
    public int Score;

    public Game(int gameWidth, int gameHeight)
    {
        Ball = new Ball(gameWidth / 2, gameHeight / 2, 15, 5);
        Paddle = new Paddle(gameWidth / 2 - 50, gameHeight - 30, 100, 10);
        Bricks = new List<Brick>();
        Score = 0;

        // Initialize Bricks
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Brush color = new SolidBrush(Color.FromArgb(255, i * 50, j * 25, 150));
                Bricks.Add(new Brick(j * 80 + 30, i * 25 + 50, 70, 20, color));
            }
        }
    }

    public void Update(int gameWidth, int gameHeight)
    {
        Ball.Move();

        // Ball collision with walls
        if (Ball.BallRect.Left < 0 || Ball.BallRect.Right > gameWidth)
            Ball.BounceOffWall();

        if (Ball.BallRect.Top < 0)
            Ball.BounceOffBrick();

        // Ball collision with paddle
        if (Ball.BallRect.IntersectsWith(Paddle.PaddleRect))
            Ball.BounceOffPaddle();

        // Ball collision with bricks
        for (int i = 0; i < Bricks.Count; i++)
        {
            if (Ball.BallRect.IntersectsWith(Bricks[i].BrickRect))
            {
                Bricks.RemoveAt(i);
                Ball.BounceOffBrick();
                Score += 10;
                break;
            }
        }
    }
}

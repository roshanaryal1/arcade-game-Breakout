using System.Drawing;

public class Ball
{
    public Rectangle BallRect;
    public int XSpeed;
    public int YSpeed;
    public int Size;

    public Ball(int x, int y, int size, int speed)
    {
        BallRect = new Rectangle(x, y, size, size);
        Size = size;
        XSpeed = speed;
        YSpeed = speed;
    }

    public void Move()
    {
        BallRect.X += XSpeed;
        BallRect.Y += YSpeed;
    }

    public void BounceOffPaddle() => YSpeed = -YSpeed;
    public void BounceOffWall() => XSpeed = -XSpeed;
    public void BounceOffBrick() => YSpeed = -YSpeed;

    public Rectangle GetBallRect() => BallRect;
}

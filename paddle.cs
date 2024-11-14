using System.Drawing;

public class Paddle
{
    public Rectangle PaddleRect;
    private int speed = 10;

    public Paddle(int x, int y, int width, int height)
    {
        PaddleRect = new Rectangle(x, y, width, height);
    }

    public void MoveLeft()
    {
        if (PaddleRect.Left > 0)
            PaddleRect.X -= speed;
    }

    public void MoveRight(int gameWidth)
    {
        if (PaddleRect.Right < gameWidth)
            PaddleRect.X += speed;
    }

    public void MoveTo(int x) => PaddleRect.X = x - PaddleRect.Width / 2;
}

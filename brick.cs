using System.Drawing;

public class Brick
{
    public Rectangle BrickRect;
    public Brush BrickBrush;

    public Brick(int x, int y, int width, int height, Brush brush)
    {
        BrickRect = new Rectangle(x, y, width, height);
        BrickBrush = brush;
    }

    public void Draw(Graphics g)
    {
        g.FillRectangle(BrickBrush, BrickRect);
        g.DrawRectangle(Pens.Black, BrickRect);
    }
}

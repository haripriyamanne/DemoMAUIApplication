using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Controls;

namespace DemoMAUIApplication
{
    public partial class GraphicsPage : ContentPage
    {
        public GraphicsPage()
        {
            InitializeComponent();
            graphicsView.Drawable = new CustomDrawable();
        }
    }

    public class CustomDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float yOffset = 0;

            // Draw circles
            PointF center = new PointF(dirtyRect.Center.X, dirtyRect.Center.Y);
            float radius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 8; // Reduced size to fit all drawings vertically
            float distance = 0.8f * radius;

            PointF center1 = new PointF(distance * (float)Math.Cos(9 * Math.PI / 6) + center.X,
                distance * (float)Math.Sin(9 * Math.PI / 6) + center.Y + yOffset);
            PointF center2 = new PointF(distance * (float)Math.Cos(1 * Math.PI / 6) + center.X,
                distance * (float)Math.Sin(1 * Math.PI / 6) + center.Y + yOffset);
            PointF center3 = new PointF(distance * (float)Math.Cos(5 * Math.PI / 6) + center.X,
                distance * (float)Math.Sin(5 * Math.PI / 6) + center.Y + yOffset);

            canvas.BlendMode = BlendMode.Multiply;

            canvas.FillColor = Colors.Cyan;
            canvas.FillCircle(center1, radius);

            canvas.FillColor = Colors.Magenta;
            canvas.FillCircle(center2, radius);

            canvas.FillColor = Colors.Yellow;
            canvas.FillCircle(center3, radius);

            yOffset += radius * 3; // Move down for next drawing
            yOffset += 100; 
            // Draw the line after the circles
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            canvas.DrawLine(dirtyRect.Center.X - 40, yOffset, dirtyRect.Center.X + 40, yOffset + 90);

            yOffset += 100; // Move down for next drawing

            // Draw dashed line
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            canvas.StrokeDashPattern = new float[] { 2, 2 };
            canvas.DrawLine(10, yOffset, 90, yOffset + 90);

            yOffset += 100; // Move down for next drawing

            // Draw ellipses
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(10, yOffset, 100, 50);

            yOffset += 60; // Move down for next drawing

            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(10, yOffset, 100, 100);

            yOffset += 110; // Move down for next drawing

            canvas.FillColor = Colors.Red;
            canvas.FillEllipse(10, yOffset, 150, 50);

            yOffset += 60; // Move down for next drawing

            // Draw rectangles
            canvas.StrokeColor = Colors.DarkBlue;
            canvas.StrokeSize = 4;
            canvas.DrawRectangle(10, yOffset, 100, 50);
            PathF path = new PathF();
            for (int i = 0; i < 11; i++)
            {
                double angle = 5 * i * 2 * Math.PI / 11;
                PointF point = new PointF(100 * (float)Math.Sin(angle), -100 * (float)Math.Cos(angle));

                if (i == 0)
                    path.MoveTo(point);
                else
                    path.LineTo(point);
            }

            canvas.FillColor = Colors.Red;
            canvas.Translate(150, 150);
            canvas.FillPath(path);
        }
    }
}

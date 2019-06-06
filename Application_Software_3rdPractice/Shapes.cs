using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    public class Shape
    {
        public virtual void DrawShape(PaintEventArgs e)
        {
            ;
        }
    }
    public class MyCircle : Shape
    {
        private SolidBrush brush;
        private Pen pen;
        private Rectangle rectC;

        public MyCircle()
        {
            rectC = new Rectangle();
        }

        public void setRectC(Point start, Point finish, Pen pen, SolidBrush brush)
        {
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);

            this.pen = pen;
            this.brush = brush;
        }

        public Rectangle getRectC()
        {
            return rectC;
        }

        public Pen GetPen()
        {
            return pen;
        }

        public SolidBrush GetBrush()
        {
            return brush;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(this.brush, this.getRectC());
            e.Graphics.DrawEllipse(this.pen, this.getRectC());
        }
    }

    public class MyLine : Shape
    {
        private Pen pen;
        private Point[] point = new Point[2];

        public MyLine()
        {
            point[0] = new Point();
            point[1] = new Point();
        }

        public void setPoint(Point start, Point finish, Pen pen)
        {
            point[0] = start;
            point[1] = finish;
            this.pen = pen;
        }

        public Point getPoint1()
        {
            return point[0];
        }

        public Point getPoint2()
        {
            return point[1];
        }

        public Pen GetPen()
        {
            return pen;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.DrawLine(this.pen, this.getPoint1(), this.getPoint2());
        }
    }

    public class MyRect : Shape
    {
        private Pen pen;
        private SolidBrush brush;
        private Rectangle rect;

        public MyRect()
        {
            rect = new Rectangle();
        }

        public void setRect(Point start, Point finish, Pen pen, SolidBrush brush)
        {
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);

            this.pen = pen;
            this.brush = brush;
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public Pen GetPen()
        {
            return pen;
        }

        public SolidBrush GetBrush()
        {
            return brush;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(this.brush, this.getRect());
            e.Graphics.DrawRectangle(this.pen, this.getRect());
        }
    }
}

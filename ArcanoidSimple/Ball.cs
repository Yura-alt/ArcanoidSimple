using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ArcanoidSimple
{
    class Ball : ObjShape
    {
        public double speedX = 3;
        public double speedY = 3;
        public int diametr = 10;
        public Ball()
        {
            basePoint.X = (450 - diametr/2)/2;
            basePoint.Y = 550-65; 
            objColor = Colors.Yellow;
        }
        public override void Draw(ref Canvas MapSpace)
        {
           // SolidColorBrush brush = new SolidColorBrush(objColor);
            Ellipse ball = new Ellipse
            {
               // Stroke = brush,
                StrokeThickness = 10,
                Width = diametr,
                Height = diametr,
                Fill = new SolidColorBrush(objColor)

            };
            Canvas.SetLeft(ball, basePoint.X);
            Canvas.SetTop(ball, basePoint.Y);

            MapSpace.Children.Insert(1, ball);
        }
        public void Move(ref Canvas mapSpace)
        {
            Canvas.SetLeft(mapSpace.Children[1], basePoint.X);
            Canvas.SetTop(mapSpace.Children[1], basePoint.Y);
        }
        public override Extents GetExtents()
        {
            return new Extents(basePoint, new Point(basePoint.X + diametr/2, basePoint.Y + diametr/2));
        }
    }
}

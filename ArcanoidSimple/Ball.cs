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
        private double speedX = -3;
        private double speedY = 3;
        const int diametr = 10;

        private Extents extents = new Extents();

        public Ball()
        {
            basePoint.X = (450 - diametr/2)/2;
            basePoint.Y = 550-65; 
            objColor = Colors.Yellow;
        }
        public void MirrorBall(int i)
        {
            //if (basePoint.Y>500 || basePoint.Y<0)
            //    speedY = -speedY;
            //if (basePoint.X < 0 || basePoint.X + 10 > 450)
            //{
            //    speedX = -speedX;
            //}
            if (i==0)
            {
                if (basePoint.Y> 500 || basePoint.Y <0)
                {
                    speedY = -speedY;
                }
                if (basePoint.X>420 || basePoint.X< 0)
                {
                    speedX = -speedX;
                }
            }
            if (i == 1)
                    speedY = -speedY;

        }
        public void MirrorBall(int i, ref List<ObjShape> shapes)
        {
            if (basePoint.Y< shapes[i].basePoint.Y+10 & basePoint.Y> shapes[i].basePoint.Y)
            {
                speedY = -speedY;
            }
            else
            {
                speedX = -speedX;
            }
        }

        public override void Draw(ref Canvas MapSpace)
        {
            Ellipse ball = new Ellipse
            {
                StrokeThickness = 10,
                Width = diametr,
                Height = diametr,
                Fill = new SolidColorBrush(objColor)

            };
            Canvas.SetLeft(ball, basePoint.X);
            Canvas.SetTop(ball, basePoint.Y);

            MapSpace.Children.Insert(MapSpace.Children.Count, ball);
        }
        public void Move(ref Canvas mapSpace)
        {
            basePoint.X += speedX;
            basePoint.Y += speedY;
            Canvas.SetLeft(mapSpace.Children[mapSpace.Children.Count-1], basePoint.X);
            Canvas.SetTop(mapSpace.Children[mapSpace.Children.Count-1], basePoint.Y);
        }
        public override Extents GetExtents()
        {
            extents.ptMin = basePoint;

            extents.ptMax.X = basePoint.X + diametr;
            extents.ptMax.Y = basePoint.Y + diametr;


            return extents; 
         }
    }
}

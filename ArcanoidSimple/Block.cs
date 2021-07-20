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
    class Block : Barrier
    {
        private Extents extents = new Extents();
        public Block()
        {
           
        }
        public Block(double Left, double Top)
        {
            basePoint.X = Left;
            basePoint.Y = Top;
        }
        public override int BorderCrossing(double X, double Y, ref List<Barrier> barriers) //список платформжжж
        {
           
            return -1;
        }


       
        public override void Draw(ref Canvas MapSpace)
        {
           
            SolidColorBrush brush = new SolidColorBrush(objColor);
            Rectangle rectangle = new Rectangle
            {
                Stroke = brush,
                StrokeThickness = 10,
                Width = Widht,
                Height = Height,

            };
            Canvas.SetLeft(rectangle, basePoint.X);
            Canvas.SetTop(rectangle, basePoint.Y);
            
            MapSpace.Children.Add(rectangle);
            
        }
        public override Extents GetExtents()
        {
            extents.ptMin = basePoint;
            extents.ptMax.X = basePoint.X + Widht;
            extents.ptMax.Y = basePoint.Y + Height;
            return extents;
        }
    }
}


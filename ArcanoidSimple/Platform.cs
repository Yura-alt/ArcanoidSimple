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
    class Platform : ObjShape
    {

        public int height = 10;
        public int widht = 100;
       public Platform()
        {
            basePoint.X = 450/2 - widht/2; 
            basePoint.Y = 550 - 50; 
            objColor = Colors.DarkCyan;
        }
        public override Extents GetExtents()
        {

            return new Extents(basePoint, new Point(basePoint.X+widht,basePoint.Y+height));
        }
        public override void Draw(ref Canvas MapSpace)
        {
            Rectangle rectangle = new Rectangle
            {
                RadiusX = 10,
                RadiusY = 10,
                Height = height,
                Width = widht,
                Fill = new SolidColorBrush(objColor)
            };

            Canvas.SetLeft(rectangle, basePoint.X);
            Canvas.SetTop(rectangle, basePoint.Y);

            
            MapSpace.Children.Insert(2, rectangle);
        }
    }
}


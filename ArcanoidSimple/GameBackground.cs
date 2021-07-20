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
    class GameBackground : ObjShape
    {
        public double height;
        public double width;
        private Extents extents = new Extents();
        public override void Draw(ref Canvas MapSpace)
        {
            Rectangle rectangle = new Rectangle
            {
                Height = height,
                Width = width,
                Fill = Brushes.Black
            };
            MapSpace.Children.Add(rectangle);
        }

        public GameBackground()
        {
            width = 450;
            height = 550;
        }
        public override Extents GetExtents()
          {
            extents.ptMin.X = 15;
            extents.ptMin.Y = 15;
            extents.ptMax.X =  width-25;
            extents.ptMax.Y =  height-45;

            return extents;
        }
    }
}

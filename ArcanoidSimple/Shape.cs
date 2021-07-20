using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ArcanoidSimple
{
    abstract class ObjShape: ICollisionTest
    {
        public Point basePoint;// оставить только базлвую точку, остальное реализуется в
        public Color objColor;

        public abstract void Draw(ref Canvas MapSpace);

    }
}

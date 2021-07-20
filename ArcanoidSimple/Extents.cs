using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArcanoidSimple
{
    class Extents
    {
        public Point ptMin;
        public Point ptMax;

        public Extents()
        {

        }
        public Extents (Point ptMin, Point ptMax)
        {
            this.ptMin = ptMin;
            this.ptMax = ptMax;
        }
        public bool IsIntersect( Extents other)
        {     
            if ((other.ptMin.X < ptMax.X || other.ptMin.X <= ptMin.X) & other.ptMax.X > ptMin.X & (other.ptMin.Y < ptMax.Y || other.ptMin.Y < ptMin.Y) & other.ptMax.Y > ptMin.Y)
            {
                
                    return true;
                
            }
            else
            {
                return false;
            }
            

        }
        
    }
}

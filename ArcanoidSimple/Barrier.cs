using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ArcanoidSimple
{
    abstract class Barrier: ObjShape
    {

        public static double Height
        {
            get
            {
                return 10;
            }
        }


        public static double Widht
        {
           get
            {
                return (450 - 40)/10;
            }
        }

        private int blockLevelLife;
        

        public int BlockLevelLife
        {
            set
            {
                blockLevelLife = value;
            }
            get
            {
                return blockLevelLife;
            }
        }
        
        public Barrier()
        {
            basePoint.X = 10;
            basePoint.Y = 10;
            objColor = Colors.Red;
            
        }

        public virtual int BorderCrossing(double X, double Y, ref List<Barrier> barriers)
        {
            return 0;   // должен быть сначала в шейпе и переопределный во всех наследниках???
        }
        public virtual void BlockLevelDown(int index, ref Canvas MapSpace, ref List<Barrier> barriers) { }
    }
}


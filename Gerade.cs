using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMapProject
{
    class Gerade
    {
        int x1, x2, y1, y2;

        public Gerade(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }


        public bool iscrossed(Gerade g)
        {
            var dx1 = x2 - x1;
            var m = (y2 - y1) / dx1;
            var b = y1 - (m * x1);

            Console.WriteLine(m + "* x" + " + " + b);

            //if ()

            return true;
        }

        public int X1
        {
            get
            {
                return x1;
            }

            set
            {
                x1 = value;
            }
        }

        public int X2
        {
            get
            {
                return x2;
            }

            set
            {
                x2 = value;
            }
        }

        public int Y1
        {
            get
            {
                return y1;
            }

            set
            {
                y1 = value;
            }
        }

        public int Y2
        {
            get
            {
                return y2;
            }

            set
            {
                y2 = value;
            }
        }
    }
}

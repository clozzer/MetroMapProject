using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroMapProject
{
    [Serializable]
    public class Knoten
    {
        int x, y;
        string name;

        Vector disp, pos;

        float fax, frx, fex, fay, fry, fey = 0;


        public Knoten(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            disp = new Vector(0, 0);
            pos = new Vector(x, y);
            this.name = name;
        }

        public float Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public float Frx
        {
            get
            {
                return frx;
            }

            set
            {
                frx = value;
            }
        }

        public float Fex
        {
            get
            {
                return fex;
            }

            set
            {
                fex = value;
            }
        }

        public float Fay
        {
            get
            {
                return fay;
            }

            set
            {
                fay = value;
            }
        }

        public float Fry
        {
            get
            {
                return fry;
            }

            set
            {
                fry = value;
            }
        }

        public float Fey
        {
            get
            {
                return fey;
            }

            set
            {
                fey = value;
            }
        }


        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
        public Vector getdisp()
        {
            return disp;
        }
        public void setdisp(Vector disp)
        {
            this.disp = disp;
        }
        public Vector getpos()
        {
            return pos;
        }
        public void setpos(Vector pos)
        {
            this.pos = pos;
        }
        public void setx(int x)
        {
            this.x = x;
        }
        public void sety(int y)
        {
            this.y = y;
        }
        public string getname()
        {
            return name;
        }
        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Knoten secondKnoten = (Knoten)obj;
            return (x == secondKnoten.x) && (y == secondKnoten.y);
        }
        public Vector[] getarea()
        {
            Vector[] vectorarea = new Vector[24];
            vectorarea[0] = new Vector(x - 10, y - 10);
            vectorarea[1] = new Vector(x, y - 10);
            vectorarea[2] = new Vector(x + 10, y - 10);
            vectorarea[3] = new Vector(x - 10, y);
            vectorarea[4] = new Vector(x + 10, y);
            vectorarea[5] = new Vector(x - 10, y + 10);
            vectorarea[6] = new Vector(x, y - 10);
            vectorarea[7] = new Vector(x + 10, y + 10);
            vectorarea[8] = new Vector(x - 20, y - 20);
            vectorarea[9] = new Vector(x - 10, y - 20);
            vectorarea[10] = new Vector(x, y - 20);
            vectorarea[11] = new Vector(x + 10, y - 20);
            vectorarea[12] = new Vector(x + 20, y - 20);
            vectorarea[13] = new Vector(x - 20, y - 10);
            vectorarea[14] = new Vector(x + 20, y - 10);
            vectorarea[15] = new Vector(x - 20, y);
            vectorarea[16] = new Vector(x + 20, y);
            vectorarea[17] = new Vector(x - 20, y + 10);
            vectorarea[18] = new Vector(x + 20, y + 10);
            vectorarea[19] = new Vector(x - 20, y + 20);
            vectorarea[20] = new Vector(x - 10, y + 20);
            vectorarea[21] = new Vector(x, y + 20);
            vectorarea[22] = new Vector(x + 10, y + 20);
            vectorarea[23] = new Vector(x + 20, y + 20);

            return vectorarea;
        }
    }
}

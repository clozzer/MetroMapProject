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

        public Knoten(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            disp = new Vector(0,0);
            pos = new Vector(x, y);
            this.name = name;
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
    }
}

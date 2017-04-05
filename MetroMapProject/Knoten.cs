using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMapProject
{
    [Serializable]
    public class Knoten
    {
        int x, y;
        string name;
        public Knoten(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
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
    }
}

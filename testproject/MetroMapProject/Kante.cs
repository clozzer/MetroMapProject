using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMapProject
{
    [Serializable]
    public class Kante
    {
        Knoten start, ende;
        public Kante(Knoten start, Knoten ende)
        {
            this.start = start;
            this.ende = ende;
        }
        public Knoten getstart()
        {
            return start;
        }
        public Knoten getende()
        {
            return ende;
        }
        public void setstart(Knoten start)
        {
            this.start = start;
        }
        public void getende(Knoten ende)
        {
            this.ende = ende;
        }
    }
}

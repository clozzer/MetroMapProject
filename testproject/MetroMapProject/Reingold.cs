using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroMapProject
{
    class Reingold
    {
        Graph g1;
        List<Knoten> knoten;
        List<Kante> kanten;
        public Reingold(Graph g1)
        {
            this.g1 = g1;
            knoten = g1.getknoten();
            kanten = g1.getkanten();
        }
        public Graph getgraph()
        {
            return g1;
        }
        public bool isadjacent(Knoten first, Knoten second)
        {
            foreach (Kante e in kanten)
            {
                if (first.Equals(e.getstart()))
                {
                    if (second.Equals(e.getende()))
                    {
                        return true;
                    }
                }
                if (second.Equals(e.getstart()))
                {
                    if (first.Equals(e.getende()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public float eucliddistance(Knoten first, Knoten second)
        {
            int x0 = first.getx();
            int y0 = first.gety();

            int x1 = second.getx();
            int y1 = second.gety();

            int dX = x1 - x0;
            int dY = y1 - y0;
            return (float)Math.Sqrt(dX * dX + dY * dY);
        }
        public System.Drawing.Point vektorzweierpunkte(Knoten start, Knoten ende)
        {
            return new System.Drawing.Point(ende.getx() - start.getx(), ende.gety() - start.gety());
        }
        public float lengthvektorzweierpunkte(System.Drawing.Point p)
        {
            return (float)Math.Sqrt((float)(p.X * p.X) + (float)(p.Y * p.Y));
        }
        public float area(float width, float length)
        {
            return length * width;
        }
        public float optimaldistance(float area)
        {
            return (float)Math.Sqrt(area / knoten.Count) / 16;
        }

        public float functionabstoßend(float value, float width, float length)
        {
            return (optimaldistance(area(width, length)) * optimaldistance(area(width, length))) / (value * 8);
        }


        public float functionanziehend(float value, float width, float length)
        {
            return (value * value) / optimaldistance(area(width, length));
        }

        public void far(int iterations, int width, int length)
        {
            for (int i = 0; i < iterations; i++)
            {
                //abstoßendeKraftBerechnen

                foreach (Knoten v in knoten)
                {
                    v.setdisp(new Vector(0, 0));
                    foreach (Knoten u in knoten)
                    {
                        if (v != u)
                        {
                            Vector p = v.getpos() - u.getpos();
                            Vector normalized = p;
                            normalized.Normalize();
                            v.setdisp(v.getdisp() + (normalized) * functionabstoßend((float)p.Length, width, length));
                        }
                    }
                }

                //anziehendeKraft
                foreach (Kante e in kanten)
                {
                    Vector p = e.getende().getpos() - e.getstart().getpos();
                    Vector normalized = p;
                    normalized.Normalize();
                    e.getende().setdisp(e.getende().getdisp() - (normalized) * (functionanziehend((float)p.Length, width, length)));
                    e.getstart().setdisp(e.getstart().getdisp() + (normalized) * (functionanziehend((float)p.Length, width, length)));
                }


                foreach (Knoten v in knoten)
                {
                    if(v.ismoveablereingold())
                    {
                        Vector normalized = v.getdisp();
                        normalized.Normalize();
                        v.setpos(v.getpos() + (normalized));
                        v.setx((int)v.getpos().X);
                        v.sety((int)v.getpos().Y);
                        v.setx(Math.Min(width / 2, Math.Max(width * -1, v.getx())));
                        v.sety(Math.Min(length / 2, Math.Max(length * -1, v.gety())));
                    }

                }
            }
        }
    }
}

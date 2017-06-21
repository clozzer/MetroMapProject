using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroMapProject
{
    class KamadaKawai
    {
        Graph g1;
        List<Knoten> knoten;
        List<Kante> kanten;
        public KamadaKawai(Graph g1)
        {
            this.g1 = g1;
            knoten = g1.getknoten();
            kanten = g1.getkanten();
        }
        public Graph getgraph()
        {
            return g1;
        }

        public float optimaldistance(float area)
        {
            return (float)Math.Sqrt(area / knoten.Count);
        }
        public float functionabstoßend(float value, float width, float length)
        {
            return optimaldistance(area(width, length)) / (value * 0.005f);
            //return value * value / optimaldistance(area(width, length));
           
        }
        public float area(float width, float length)
        {
            return 700 * 700;
        }
        public float functionanziehend(float value, float width, float length)
        {
            //return value / optimaldistance(area(width, length));
            return value * value * value;
            //return 0;
        }
        public void algorithmethod(int iterations, int width, int length)
        {
            for(int i = 0; i < iterations; i++)
            {
                //abstoßend
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
                            v.setdisp(v.getdisp() + ((normalized)* functionabstoßend((float)p.Length, width, length))) ;
                        }
                    }
                }

                //haltende Kraft
                foreach (Knoten v in knoten)
                {
                    if(v.getxalt() - v.getx() != 0 && v.getyalt() - v.gety() != 0)
                    {
                        Vector p = new Vector(v.getxalt() - v.getx(), v.getyalt() - v.gety());
                        Vector normalized = p;
                        normalized.Normalize();
                        v.setdisp(v.getdisp() + (normalized) *0.5f* (functionanziehend((float)p.Length, width, length)));
                    };
                }

                //anziehendeKraft
                foreach (Kante e in kanten)
                {
                    Vector p = e.getende().getpos() - e.getstart().getpos();
                    Vector normalized = p;
                    normalized.Normalize();
                    e.getende().setdisp(e.getende().getdisp() - (normalized) * 0.01f * (functionanziehend((float)p.Length, width, length)));
                    e.getstart().setdisp(e.getstart().getdisp() + (normalized) * 0.01f * (functionanziehend((float)p.Length, width, length)));
                }

                foreach (Knoten v in knoten)
                {
                    if (v.ismoveable())
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetroMapProject
{
    [Serializable]
    public class Graph
    {
        public List<Knoten> knoten;
        public List<Kante> kanten;
        public Graph()
        {
            knoten = new List<Knoten>();
            kanten = new List<Kante>();
        }
        public List<Knoten> getknoten()
        {
            return knoten;
        }
        public List<Kante> getkanten()
        {
            return kanten;
        }
        public void createKnoten(int x, int y, string name)
        {
            knoten.Add(new Knoten(x, y, name));
            Console.WriteLine("Knoten hinzugefügt: " + x + " " + y + " " + name);
        }
        public void createKanten(string start, string ende, string id)
        {
            foreach (Knoten startknoten in knoten)
            {
                if (startknoten.getname() == start)
                {
                    foreach (Knoten endknoten in knoten)
                    {
                        if (endknoten.getname() == ende)
                        {
                            kanten.Add(new MetroMapProject.Kante(startknoten, endknoten, id));
                            Console.WriteLine("Kante hinzugefügt: " + startknoten.getname() + " " + endknoten.getname() + " " + id);
                            return;

                        }
                    }
                }
            }
        }
        public bool isadjacent(Knoten first, Knoten second)
        {
            foreach(Kante e in kanten)
            {
                if(first.Equals(e.getstart()))
                {
                    if(second.Equals(e.getende()))
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
        public float area(float height, float width)
        {
            return height * width;
        }
        public float optimaldistance(float area)
        {
            return (float)Math.Sqrt(area / knoten.Count);
        }

        public float functionabstoßend(Knoten first, Knoten second, float height, float width)
        {
            return (optimaldistance(area(height, width)) * optimaldistance(area(height, width))) / eucliddistance(first, second);
        }

        public float functionanziehend(Knoten first, Knoten second, float height, float width)
        {
            return (eucliddistance(first, second) * eucliddistance(first, second)) / optimaldistance(area(height, width));
        }

        public void far(int iterations, int t)
        {
            Console.WriteLine("Test" );
            for(int i = 0; i < iterations; i++)
            {
                //abstoßendeKraftBerechnen
                foreach(Knoten v in knoten)
                {
                    v.setdisp(new Vector(0,0));
                    foreach(Knoten u in knoten)
                    {
                        if(v != u)
                        {
                            Vector p = v.getpos() - u.getpos();
                            Vector normalized = p;
                            normalized.Normalize();
                            v.setdisp(v.getdisp() + (p / normalized.Length) * functionabstoßend(v, u, 100, 100));
                        }
                    }
                }

                //anziehendeKraft
                foreach(Kante e in kanten)
                {
                    Vector p = e.getstart().getpos() - e.getende().getpos();
                    e.getstart().setdisp(e.getstart().getdisp() - (p / p.Length) * (functionanziehend(e.getstart(), e.getende(), 100, 100)));
                    e.getende().setdisp(e.getende().getdisp() + (p / p.Length) * (functionanziehend(e.getstart(), e.getende(), 100, 100)));
                }


                foreach(Knoten v in knoten)
                {
                    v.setpos(v.getpos() + (v.getdisp() / v.getdisp().Length) );
                    //v.setpos(new Vector(Math.Min(v.getpos().X * v.getdisp().X, t), Math.Min(v.getpos().Y * v.getdisp().Y,t)));
                    v.setx((int)v.getpos().X);
                    v.sety((int)v.getpos().Y);
                    Console.WriteLine(v.getx());
                    Console.WriteLine(v.gety());
                    Console.WriteLine("disp.X = " + v.getdisp().X);
                    Console.WriteLine("disp.Y = " + v.getdisp().Y);
                    v.setx(Math.Min(110, Math.Max(10, v.getx())));
                    v.sety(Math.Min(110, Math.Max(10, v.gety())));
                }
                //v.pos := v.pos + (v.disp / | v.disp |) * min(v.disp, t);
                //v.pos.x := min(W / 2, max(-W / 2, v.pos.x));
                //v.pos.y := min(L / 2, max(–L / 2, v.pos.y))

                t--;



            }

        }
    }
}

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
        float metric = 0;
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

        public void handleduplicate()
        {
            List<Kante> doppelte = new List<Kante>();
            foreach(Kante i in kanten)
            {
                foreach(Kante j in kanten)
                {
                    if(i.getstart() == j.getstart() && i.getende() == j.getende() && i.getid() != j.getid() && !doppelte.Contains(j))
                    {
                        doppelte.Add(i);
                    }
                }
            }

            foreach (Kante k in doppelte)
            {
                Console.WriteLine("doppelte " + k.getid());
            }

            if (doppelte.Count == 0)
            {
                return;
            }


            foreach(Kante z in doppelte)
            {
                handledupplicatehelper(z);
            }
            
        }

        public void handledupplicatehelper(Kante m)
        {
            Kante current = m;
            Knoten start = current.getstart();
            Knoten ende = current.getende();
            List<Knoten> adjacentstart = new List<Knoten>();
            List<Knoten> adjacentende = new List<Knoten>();

            foreach (Knoten k in knoten)
            {
                if (isadjacent(start, k))
                {
                    adjacentstart.Add(k);

                }
                if (isadjacent(ende, k))
                {
                    adjacentende.Add(k);
                }
            }



            adjacentstart.Remove(ende);
            adjacentende.Remove(start);

            foreach (Knoten k in adjacentstart)
            {
                Console.WriteLine(k.getname());
            }
            Console.WriteLine();
            foreach (Knoten k in adjacentende)
            {
                Console.WriteLine(k.getname());
            }

            createKnoten(start.getx() + 50, start.gety() + 50, start.getname() + "'");
            createKnoten(ende.getx() + 50, ende.gety() + 50, ende.getname() + "'");
            createKanten(start.getname() + "'", ende.getname() + "'", m.getid() + "'");


            foreach (Knoten k in adjacentstart)
            {
                for (int i = 0; i < kanten.Count; i++)
                {
                    if ((kanten[i].getstart() == start && kanten[i].getende() == k) || (kanten[i].getende() == start && kanten[i].getstart() == k))
                    {
                        createKanten(start.getname() + "'", k.getname(), kanten[i].getid() + "'");
                        break;
                    }
                }
            }


            foreach (Knoten k in adjacentende)
            {
                for (int i = 0; i < kanten.Count; i++)
                {
                    if ((kanten[i].getstart() == ende && kanten[i].getende() == k) || (kanten[i].getende() == ende && kanten[i].getstart() == k))
                    {
                        createKanten(ende.getname() + "'", k.getname(), kanten[i].getid() + "'");
                        break;
                    }
                }
            }

            kanten.Remove(m);



            foreach (Kante k in kanten)
            {
                Console.WriteLine(k.getid());
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
        public float area(float width, float length)
        {
            return length * width;
        }
        public float optimaldistance(float area)
        {
            return (float)Math.Sqrt(area / knoten.Count) / 2;
        }

        public float functionabstoßend(float value, float width, float length)
        {
            return (optimaldistance(area(width, length)) * optimaldistance(area(width, length))) / value;
        }


        public float functionanziehend(float value, float width, float length)
        {
            return (value * value) / optimaldistance(area(width, length));
        }

        public void far(int iterations, int width, int length)
        {
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
                            v.setdisp(v.getdisp() + (normalized) * functionabstoßend((float)p.Length ,width, length));
                        }
                    }
                }

                //anziehendeKraft
                foreach(Kante e in kanten)
                {
                    Vector p = e.getende().getpos() - e.getstart().getpos();
                    Vector normalized = p;
                    normalized.Normalize();
                    e.getende().setdisp(e.getende().getdisp() - (normalized) * (functionanziehend((float)p.Length, width, length)));
                    e.getstart().setdisp(e.getstart().getdisp() + (normalized) * (functionanziehend((float)p.Length, width, length)));
                }


                foreach(Knoten v in knoten)
                {
                    Vector normalized = v.getdisp();
                    normalized.Normalize();
                    v.setpos( v.getpos() + (normalized) );
                    v.setx((int)v.getpos().X);
                    v.sety((int)v.getpos().Y);
                    v.setx(Math.Min(width / 2, Math.Max(width * -1, v.getx())));
                    v.sety(Math.Min(length / 2, Math.Max(length * - 1, v.gety())));
                }             
            }
        }


        //pred algorithm
        public void pred(int iterations, float edgelength, int paramdistance)
        {
            for(int i = 0; i < iterations; i++)
            {
                foreach(Knoten v  in knoten)
                {
                    v.Frx = 0;
                    v.Fry = 0;
                    v.Fax = 0;
                    v.Fay = 0;
                    v.Fex = 0;
                    v.Fey = 0;
                }
                //abstoßende Kraft
                foreach (Knoten v in knoten)
                {
                    foreach (Knoten u in knoten)
                    {
                        if (v != u)
                        {
                            v.Frx = v.Frx + predabstoßendx(v, u, edgelength);
                            v.Fry = v.Fry + predabstoßendy(v, u, edgelength);
                        }
                    }
                }

                //anziehende Kraft
                foreach (Kante e in kanten)
                {
                    e.getstart().Fax = e.getstart().Fax + predabanziehendx(e.getstart(), e.getende(), edgelength);
                    e.getstart().Fay = e.getstart().Fay + predabanziehendy(e.getstart(), e.getende(), edgelength);

                    e.getende().Fax = e.getende().Fax + predabanziehendx(e.getende(), e.getstart(), edgelength);
                    e.getende().Fay = e.getende().Fay + predabanziehendy(e.getende(), e.getstart(), edgelength);
                }

                //knoten und kante kraft
                //foreach(Knoten v in knoten)
                //{
                //    foreach(Kante e in kanten)
                //    {
                //        v.Fex = v.Fex + predfex(v, e, paramdistance);
                //        v.Fey = v.Fex + predfey(v, e, paramdistance);
                //    }
                //}

                //foreach(Knoten v in knoten)
                //{
                //    foreach(Knoten u in knoten)
                //    {
                //        foreach (Kante e in kanten)
                //        {
                //            if (e.getstart() == v)
                //            {
                //                v.Fex = v.Fex - predfex(u, e, paramdistance);
                //                v.Fey = v.Fey - predfey(u, e, paramdistance);
                //            }
                //        }
                //    }
                //}

                //jedenKnoten moven
                foreach (Knoten v in knoten)
                {
                    v.setx((int)Math.Min(Math.Max((v.getx() + (int)v.Fax + (int)v.Frx + (int)v.Fex), v.getx() - edgelength), v.getx() + edgelength));
                    v.sety((int)Math.Min(Math.Max((v.gety() + (int)v.Fay + (int)v.Fry + (int)v.Fey), v.gety() - edgelength), v.gety() + edgelength ));
                }
            }


        }



        public float predabstoßendx(Knoten v, Knoten u, float edgelength)
        {
            return -1 * ( (edgelength * edgelength)  /  (eucliddistance(v, u) * eucliddistance(v, u)) * ( v.getx() - u.getx() ) );
        }
        public float predabstoßendy(Knoten v, Knoten u, float edgelength)
        {
            return -1 * ((edgelength * edgelength) / (eucliddistance(v, u) * eucliddistance(v, u)) * (v.gety() - u.gety()));
        }

        public float predabanziehendx(Knoten v, Knoten u, float edgelength)
        {
            return eucliddistance(v, u)  / edgelength * (v.getx() - u.getx());
        }
        public float predabanziehendy(Knoten v, Knoten u, float edgelength)
        {
            return eucliddistance(v, u) / edgelength * (v.gety() - u.gety());
        }
        public float predfex(Knoten v, Kante e, int paramdistance)
        {
            Vector vnew = new Vector(0, 0);
            vnew.X = e.getstart().getx() - e.getende().getx();
            vnew.Y = e.getstart().gety() - e.getende().gety();
            Vector v1 = new Vector(v.getx(), v.gety());

            vnew = ((vnew * v1) / vnew.Length * vnew.Length ) * vnew;

            Knoten virtualKnoten = new Knoten((int)vnew.X, (int)vnew.Y, "virtualKnoten");

            if (e.getstart() != v && e.getende() != v && eucliddistance(v, virtualKnoten) < paramdistance )
            {
                float zwischensumme = (paramdistance - eucliddistance(v, virtualKnoten)) * (paramdistance - eucliddistance(v, virtualKnoten));
                return -1 * ((zwischensumme / eucliddistance(v, virtualKnoten)) * (virtualKnoten.getx() - v.getx()) );
            }
            return 0;
        }
        public float predfey(Knoten v, Kante e, int paramdistance)
        {
            Vector vnew = new Vector(0, 0);
            vnew.X = e.getstart().getx() - e.getende().getx();
            vnew.Y = e.getstart().gety() - e.getende().gety();
            Vector v1 = new Vector(v.getx(), v.gety());

            vnew = ((vnew * v1) / vnew.Length * vnew.Length) * vnew;

            Knoten virtualKnoten = new Knoten((int)vnew.X, (int)vnew.Y, "virtualKnoten");

            //hier weitermchen
            Vector vkante = new Vector(e.getende().getx() - e.getstart().getx(), e.getende().gety() - e.getstart().gety());
            if (e.getstart() != v && e.getende() != v && eucliddistance(v, virtualKnoten) < paramdistance)
            {
                Console.WriteLine("HalloTest");
                float zwischensumme = (paramdistance - eucliddistance(v, virtualKnoten)) * (paramdistance - eucliddistance(v, virtualKnoten));
                return -1 * ((zwischensumme / eucliddistance(v, virtualKnoten)) * (virtualKnoten.gety() - v.gety()));
            }
            return 0;
        }






        public void metricalgorithm()
        {
            setmetricofgraph();
            //Edge Length Metric
            foreach (Kante e in kanten)
            {
                Vector[] knotenareastart = e.getstart().getarea();
                for (int i = 0; i < 23; i++)
                {
                    //mit dem startknoten eine besserung finden
                    float metric2 = metric - eucliddistance(e.getstart(), e.getende()) / 10;
                    if(metric2 + eucliddistance(new Knoten((int)knotenareastart[i].X, (int)knotenareastart[i].Y, "test"), e.getende()) / 10 < metric
                        && isspotfree((int)knotenareastart[i].X, (int)knotenareastart[i].Y))
                    {
                        movenode(e.getstart(), (int)knotenareastart[i].X, (int)knotenareastart[i].Y);
                    }
                }

                Vector[] knotenareaende = e.getende().getarea();
                for (int i = 0; i < 23; i++)
                {
                    //mit dem endknoten eine besserung finden
                    float metric2 = metric - eucliddistance(e.getstart(), e.getende()) / 10;
                    if (metric2 + eucliddistance(e.getstart(), new Knoten((int)knotenareaende[i].X, (int)knotenareaende[i].Y, "test")) / 10 < metric
                        && isspotfree((int)knotenareaende[i].X, (int)knotenareaende[i].Y))
                    {
                        movenode(e.getende(), (int)knotenareaende[i].X, (int)knotenareaende[i].Y);
                    }
                }
            }




            foreach(Knoten v in knoten)
            {
                foreach(Kante e in kanten)
                {
                    Vector[] knotenarea = v.getarea();
                    for(int i = 0; i < 23; i ++)
                    {



                    }
                }
            }

        }

        public void movenode(Knoten v, int x, int y)
        {
            v.setx(x);
            v.sety(y);
            setmetricofgraph();
        }
        public void setmetricofgraph()
        {
            metric = 0;

            //Edge Length Metric
            foreach (Kante e in kanten)
            {
                metric = metric + eucliddistance(e.getstart(), e.getende()) / 10;
            }
        }

        public bool isspotfree(int x, int y)
        {
            foreach(Knoten v in knoten)
            {
                if(v.getx() == x && v.gety() == y)
                {
                    return false;
                }
            }
            return true;
        }

    }
}

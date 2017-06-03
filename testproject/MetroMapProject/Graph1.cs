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
        public void createKnoten(int x, int y, string name, bool moveable)
        {
            knoten.Add(new Knoten(x, y, name, moveable));
            Console.WriteLine("Knoten hinzugefügt: " + x + " " + y + " " + name);
        }
        public void createKanten(string start, string ende)
        {
            foreach (Knoten startknoten in knoten)
            {
                if (startknoten.getname() == start)
                {
                    foreach (Knoten endknoten in knoten)
                    {
                        if (endknoten.getname() == ende)
                        {
                            kanten.Add(new MetroMapProject.Kante(startknoten, endknoten));
                            Console.WriteLine("Kante hinzugefügt: " + startknoten.getname() + " " + endknoten.getname());
                            return;

                        }
                    }
                }
            }
        }
    }
}

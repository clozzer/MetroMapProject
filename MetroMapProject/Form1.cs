using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroMapProject
{
    public partial class Form1 : Form
    {
        private Graph g1;
        Graphics graphic;
        public Form1()
        {
            InitializeComponent();
            graphic = pictureBox1.CreateGraphics();
        }

        public Form1(Graph g1)
        {
            InitializeComponent();
            this.g1 = g1;
            graphic = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            SolidBrush sbBlack = new SolidBrush(Color.Black);

            foreach (Knoten knoten in g1.getknoten())
            {
                string knotenname = knoten.getname();
                int x = knoten.getx();
                int y = knoten.gety();
              
                graphic.FillEllipse(sbBlack, x - 25 , y - 25, 50, 50);

                Console.WriteLine("Knoten: " + knotenname + " " + x + " " + y + " wurde gezeichnet");
            }
            Console.WriteLine();

            foreach(Kante kante in g1.getkanten())
            {
                string kantenname = kante.getid();
                int x1 = kante.getstart().getx();
                int y1 = kante.getstart().gety();

                int x2 = kante.getende().getx();
                int y2 = kante.getende().gety();

                graphic.DrawLine(blackPen, x1, y1, x2, y2);

                Console.WriteLine("Kante: " + kantenname + " von " + x1 + " " + y1 + " nach " + x2 + " " + y2 + " wurde gezeichnet");
            }
            Console.WriteLine();
        }
    }
}

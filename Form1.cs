using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        int zoomfactor = 0;
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
            pictureBox1.BackColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 1;
            SolidBrush sbBlack = new SolidBrush(Color.Black);

            foreach (Knoten knoten in g1.getknoten())
            {
                string knotenname = knoten.getname();
                int x = knoten.getx();
                int y = knoten.gety();
              
                graphic.FillEllipse(sbBlack, x - 4 , y - 4, 8, 8);

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
            //Console.WriteLine(graphic.Transform.OffsetX);
            //Console.WriteLine(graphic.Transform.OffsetY);


        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            if (zoomfactor == 5)
            {
                Console.WriteLine("Zoom bereits bei 5");
                return;
            }
            graphic.Clear(Color.White);
            graphic.ScaleTransform(2, 2);
            pictureBox1_Click(sender, e);
            zoomfactor++;
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            if (zoomfactor == 0)
            {
                Console.WriteLine("Zoom bereits bei 0");
                return;
            }
            graphic.Clear(Color.White);
            zoomfactor = zoomfactor - 1;
            graphic.ScaleTransform(0.5f, 0.5f);
            pictureBox1_Click(sender, e); 
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            zoomfactor = 0;
            graphic.ResetTransform();
            graphic.Clear(Color.White);
            pictureBox1_Click(sender, e);
        }

        private void untenlinksregelbutton_Click(object sender, EventArgs e)
        {
            graphic.TranslateTransform(8, 0);
            graphic.Clear(Color.White);
            pictureBox1_Click(sender, e);
        }

        private void untenrechtsregelbutton_Click(object sender, EventArgs e)
        {
            graphic.TranslateTransform(-8, 0);
            graphic.Clear(Color.White);
            pictureBox1_Click(sender, e);
        }

        private void rechtsuntenbutton_Click(object sender, EventArgs e)
        {
            graphic.TranslateTransform(0, -8);
            graphic.Clear(Color.White);
            pictureBox1_Click(sender, e);
        }

        private void rechtsobenbutton_Click(object sender, EventArgs e)
        {
            graphic.TranslateTransform(0, 8);
            graphic.Clear(Color.White);
            pictureBox1_Click(sender, e);
        }
    }
}

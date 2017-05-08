using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroMapProject
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 

        static public Graph g1;
                    
        [STAThread]
        static void Main()
        {
            //randomtestgraph();
            //testgraph2();
            //saveGraph();
            //loadGraph();

            //g1.metricalgorithm();

            //g1.handleduplicate();

            //g1.pred(5, 50, 150);
            //g1.far(1000, 500, 500);

            Gerade gerade = new Gerade(1, 1, 2, 3);
            if(gerade.iscrossed(gerade))
            {

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1(g1);
            Application.Run(form1);
        }



        static void testgraph()
        {
            g1 = new MetroMapProject.Graph();
            g1.createKnoten(10, 10, "A");
            g1.createKnoten(20, 45, "B");
            g1.createKnoten(25, 30, "C");
            g1.createKnoten(40, 20, "D");
            g1.createKnoten(45, 35, "E");
            Console.WriteLine();

            g1.createKanten("A", "B", "1AB");
            g1.createKanten("A", "C", "1AC");
            g1.createKanten("C", "D", "1CD");
            g1.createKanten("B", "D", "1BD");
            g1.createKanten("D", "E", "1DE");

            g1.createKanten("A", "B", "2AB");
            g1.createKanten("C", "D", "2CD");
            Console.WriteLine();
        }

        static void testgraph2()
        {
            g1 = new MetroMapProject.Graph();
            g1.createKnoten(5, 5, "A");
            g1.createKnoten(15, 45, "B");
            g1.createKnoten(25, 25, "C");
            g1.createKnoten(35, 25, "D");
            g1.createKnoten(45, 35, "E");
            g1.createKnoten(55, 45, "F");
            g1.createKnoten(65, 55, "G");
            g1.createKnoten(65, 45, "H");
            g1.createKnoten(75, 45, "I");

            Console.WriteLine();

            g1.createKanten("A", "B", "1AB");
            g1.createKanten("A", "C", "1AC");
            g1.createKanten("C", "D", "1CD");
            g1.createKanten("B", "D", "1BD");
            g1.createKanten("D", "E", "1DE");
            g1.createKanten("E", "F", "1EF");
            g1.createKanten("F", "G", "1FG");
            g1.createKanten("F", "H", "1FH");
            g1.createKanten("H", "I", "1HI");

            g1.createKanten("A", "G", "1AG");

            Console.WriteLine();
        }
        static void randomtestgraph()
        {
            Random r1 = new Random();
            g1 = new MetroMapProject.Graph();
            g1.createKnoten(r1.Next(10,90), r1.Next(10, 90), "A");
            g1.createKnoten(r1.Next(10, 90), r1.Next(10, 90), "B");
            g1.createKnoten(r1.Next(10, 90), r1.Next(10, 90), "C");
            g1.createKnoten(r1.Next(10, 90), r1.Next(10, 90), "D");
            g1.createKnoten(r1.Next(10, 90), r1.Next(10, 90), "E");
            Console.WriteLine();

            g1.createKanten("A", "B", "1AB");
            g1.createKanten("A", "C", "1AC");
            g1.createKanten("C", "D", "1CD");
            g1.createKanten("B", "D", "1BD");
            g1.createKanten("D", "E", "1DE");

            g1.createKanten("A", "B", "2AB");
            g1.createKanten("C", "D", "2CD");
            Console.WriteLine();
        }

        static void saveGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyGraph.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, g1);
            stream.Close();
        }

        static void loadGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            g1 = (Graph)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}

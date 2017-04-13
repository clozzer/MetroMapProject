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
            randomtestgraph();
            //testgraph();
            //saveGraph();
            //loadGraph();


            g1.far(10000, 10);

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

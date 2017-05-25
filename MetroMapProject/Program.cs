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
            //testgraph();
            realgraph();
            //saveGraph();
            //loadGraph();

            //Reingold modify = new Reingold(g1);
            Algorithm modify = new Algorithm(g1);

            modify.algorithm2(1000, 800, 800);
            g1 = modify.getgraph();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1(g1);
            Application.Run(form1);
        }



        static void testgraph()
        {
            g1 = new Graph();
            g1.createKnoten(10, 10, "A", false);
            g1.createKnoten(20, 45, "B");
            g1.createKnoten(25, 30, "C");
            g1.createKnoten(40, 20, "D", false);
            g1.createKnoten(45, 35, "E");
            Console.WriteLine();

            g1.createKanten("A", "B");
            g1.createKanten("A", "C");
            g1.createKanten("C", "D");
            g1.createKanten("B", "D");
            g1.createKanten("D", "E");

            g1.createKanten("A", "B");
            g1.createKanten("C", "D");
            Console.WriteLine();
        }
        static void realgraph()
        {
            g1 = new Graph();
            g1.createKnoten(0, 30, "A", false);
            g1.createKnoten(40, 10, "a1");
            g1.createKnoten(40, 30, "a2");
            g1.createKnoten(40, 50, "a3");
            g1.createKnoten(60, 10, "a4");
            g1.createKnoten(60, 30, "a5");
            g1.createKnoten(60, 50, "a6");
            g1.createKnoten(80, 10, "a7");
            g1.createKnoten(80, 30, "a8");
            g1.createKnoten(80, 50, "a9");
            g1.createKnoten(100, 10, "a10");
            g1.createKnoten(100, 30, "a11");
            g1.createKnoten(100, 50, "a12");
            g1.createKnoten(140, 30, "B", false);
            g1.createKnoten(120, 70, "b1");
            g1.createKnoten(140, 70, "b2");
            g1.createKnoten(160, 70, "b3");
            g1.createKnoten(120, 90, "b4");
            g1.createKnoten(140, 90, "b5");
            g1.createKnoten(160, 90, "b6");
            g1.createKnoten(120, 110, "b7");
            g1.createKnoten(140, 110, "b8");
            g1.createKnoten(160, 110, "b9");
            g1.createKnoten(140, 150, "C", false);
            g1.createKnoten(180, 130, "c1");
            g1.createKnoten(180, 150, "c2");
            g1.createKnoten(180, 170, "c3");
            g1.createKnoten(200, 130, "c4");
            g1.createKnoten(200, 150, "c5");
            g1.createKnoten(200, 170, "c6");
            g1.createKnoten(220, 130, "c7");
            g1.createKnoten(220, 150, "c8");
            g1.createKnoten(220, 170, "c9");
            g1.createKnoten(240, 130, "c10");
            g1.createKnoten(240, 150, "c11");
            g1.createKnoten(240, 170, "c12");
            g1.createKnoten(280, 150, "D", false);



            g1.createKanten("A", "a1");
            g1.createKanten("A", "a2");
            g1.createKanten("A", "a3");
            g1.createKanten("a1", "a4");
            g1.createKanten("a2", "a5");
            g1.createKanten("a3", "a6");
            g1.createKanten("a4", "a7");
            g1.createKanten("a5", "a8");
            g1.createKanten("a6", "a9");
            g1.createKanten("a7", "a10");
            g1.createKanten("a8", "a11");
            g1.createKanten("a9", "a12");
            g1.createKanten("B", "a10");
            g1.createKanten("B", "a11");
            g1.createKanten("B", "a12");
            g1.createKanten("B", "b1");
            g1.createKanten("B", "b2");
            g1.createKanten("B", "b3");
            g1.createKanten("b1", "b4");
            g1.createKanten("b2", "b5");
            g1.createKanten("b3", "b6");
            g1.createKanten("b4", "b7");
            g1.createKanten("b5", "b8");
            g1.createKanten("b6", "b9");
            g1.createKanten("C", "b7");
            g1.createKanten("C", "b8");
            g1.createKanten("C", "b9");
            g1.createKanten("C", "c1");
            g1.createKanten("C", "c2");
            g1.createKanten("C", "c3");
            g1.createKanten("c1", "c4");
            g1.createKanten("c2", "c5");
            g1.createKanten("c3", "c6");
            g1.createKanten("c4", "c7");
            g1.createKanten("c5", "c8");
            g1.createKanten("c6", "c9");
            g1.createKanten("c7", "c10");
            g1.createKanten("c8", "c11");
            g1.createKanten("c9", "c12");
            g1.createKanten("c10", "D");
            g1.createKanten("c11", "D");
            g1.createKanten("c12", "D");


        }
        static void testgraph2()
        {
            g1 = new MetroMapProject.Graph();
            g1.createKnoten(5, 5, "A", false);
            g1.createKnoten(15, 45, "B");
            g1.createKnoten(25, 25, "C", false);
            g1.createKnoten(35, 25, "D");
            g1.createKnoten(45, 35, "E");
            g1.createKnoten(55, 45, "F");
            g1.createKnoten(65, 55, "G", false);
            g1.createKnoten(65, 45, "H");
            g1.createKnoten(75, 45, "I");

            Console.WriteLine();

            g1.createKanten("A", "B");
            g1.createKanten("A", "C");
            g1.createKanten("C", "D");
            g1.createKanten("B", "D");
            g1.createKanten("D", "E");
            g1.createKanten("E", "F");
            g1.createKanten("F", "G");
            g1.createKanten("F", "H");
            g1.createKanten("H", "I");

            g1.createKanten("A", "G");

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

            g1.createKanten("A", "B");
            g1.createKanten("A", "C");
            g1.createKanten("C", "D");
            g1.createKanten("B", "D");
            g1.createKanten("D", "E");

            g1.createKanten("A", "B");
            g1.createKanten("C", "D");
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

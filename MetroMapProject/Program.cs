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
            testgraph();
            saveGraph();
            //loadGraph();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1(g1);
            Application.Run(form1);
        }



        static void testgraph()
        {
            g1 = new MetroMapProject.Graph();
            g1.createKnoten(100, 100, "A");
            g1.createKnoten(200, 450, "B");
            g1.createKnoten(250, 300, "C");
            g1.createKnoten(400, 200, "D");
            g1.createKnoten(450, 350, "E");
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

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
            //realgraph();
            //saveGraph();
            //loadGraph();
            kleindeutschstrom();

            //Algorithm modify = new Algorithm(g1);
            //modify.algorithm2(100, 800, 800);
            //g1 = modify.getgraph();
            //Reingold rmodify = new Reingold(g1);
            //rmodify.far(100, 1200, 1200);
            //g1 = rmodify.getgraph();


            KamadaKawai kkmodify = new KamadaKawai(g1);
            kkmodify.algorithmethod(200, 1600, 1600);
            g1 = kkmodify.getgraph();

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
        static void kleindeutschstrom()
        {
            g1 = new Graph();
            g1.createKnoten(450, 0, "Borken", false);
            g1.createKnoten(630, 240, "Dipperz", false);
            g1.createKnoten(615, 60, "Mecklar", false);
            g1.createKnoten(0, 180, "Dauersberg", false);
            g1.createKnoten(165, 195, "Dillenburg", false);
            g1.createKnoten(225, 270, "Asslar", false);
            g1.createKnoten(300, 255, "Giessen", false);
            g1.createKnoten(60, 360, "Limburg", false);
            g1.createKnoten(180, 480, "Kriftel", false);
            g1.createKnoten(295, 420, "Karben", false);
            g1.createKnoten(240, 450, "Bommersheim", false);
            g1.createKnoten(360, 465, "Frankfurt", false);

            
            g1.createKnoten(435, 60, "Borken-Giessen1");
            g1.createKnoten(430, 55, "Borken-Giessen12");
            g1.createKnoten(440, 65, "Borken-Giessen13");
            
            g1.createKnoten(390, 105, "Borken-Giessen2");
            g1.createKnoten(385, 100, "Borken-Giessen22");
            g1.createKnoten(395, 110, "Borken-Giessen23");

            g1.createKnoten(345, 165, "Borken-Giessen3");
            g1.createKnoten(340, 160, "Borken-Giessen32");
            g1.createKnoten(350, 170, "Borken-Giessen33");

            g1.createKnoten(330, 210, "Borken-Giessen4");
            g1.createKnoten(325, 205, "Borken-Giessen42");
            g1.createKnoten(335, 215, "Borken-Giessen43");


            g1.createKnoten(215, 270, "Asslar-Dauersberg1");
            g1.createKnoten(220, 265, "Asslar-Dauersberg12");
            g1.createKnoten(210, 275, "Asslar-Dauersberg13");

            g1.createKnoten(195, 265, "Asslar-Dauersberg2");
            g1.createKnoten(200, 260, "Asslar-Dauersberg22");
            g1.createKnoten(190, 270, "Asslar-Dauersberg23");

            g1.createKnoten(25, 220, "Asslar-Dauersberg3");
            g1.createKnoten(30, 215, "Asslar-Dauersberg32");
            g1.createKnoten(20, 225, "Asslar-Dauersberg33");

            g1.createKnoten(-10, 200, "Dauersberg-Limburg1");
            g1.createKnoten(-5, 205, "Dauersberg-Limburg12");
            g1.createKnoten(-15, 195, "Dauersberg-Limburg13");

            g1.createKnoten(5, 230, "Dauersberg-Limburg2");
            g1.createKnoten(10, 225, "Dauersberg-Limburg22");
            g1.createKnoten(0, 235, "Dauersberg-Limburg23");

            g1.createKnoten(50, 260, "Dauersberg-Limburg3");
            g1.createKnoten(55, 255, "Dauersberg-Limburg32");
            g1.createKnoten(45, 265, "Dauersberg-Limburg33");

            g1.createKnoten(95, 300, "Dauersberg-Limburg4");
            g1.createKnoten(100, 295, "Dauersberg-Limburg42");
            g1.createKnoten(90, 305, "Dauersberg-Limburg43");

            g1.createKnoten(90, 330, "Dauersberg-Limburg5");
            g1.createKnoten(95, 330, "Dauersberg-Limburg52");
            g1.createKnoten(85, 330, "Dauersberg-Limburg53");

            g1.createKnoten(55, 400, "Limburg-Kriftel1");
            g1.createKnoten(60, 395, "Limburg-Kriftel12");
            g1.createKnoten(50, 405, "Limburg-Kriftel13");

            g1.createKnoten(110, 430, "Limburg-Kriftel2");
            g1.createKnoten(115, 425, "Limburg-Kriftel22");
            g1.createKnoten(105, 435, "Limburg-Kriftel23");

            g1.createKnoten(150, 465, "Limburg-Kriftel3");
            g1.createKnoten(155, 460, "Limburg-Kriftel32");
            g1.createKnoten(145, 470, "Limburg-Kriftel33");

            g1.createKnoten(225, 465, "Kriftel-Karben1");
            g1.createKnoten(220, 460, "Kriftel-Karben12");
            g1.createKnoten(230, 470, "Kriftel-Karben13");

            g1.createKnoten(260, 465, "Kriftel-Karben2");
            g1.createKnoten(255, 460, "Kriftel-Karben22");
            g1.createKnoten(265, 470, "Kriftel-Karben23");

            g1.createKnoten(270, 435, "Kriftel-Karben3");
            g1.createKnoten(265, 430, "Kriftel-Karben32");
            g1.createKnoten(275, 440, "Kriftel-Karben33");

            g1.createKnoten(320, 455, "Karben-Frankfurt1");
            g1.createKnoten(325, 450, "Karben-Frankfurt12");
            g1.createKnoten(315, 460, "Karben-Frankfurt13");

            g1.createKnoten(300, 410, "Karben-Giessen1");
            g1.createKnoten(295, 415, "Karben-Giessen12");
            g1.createKnoten(305, 405, "Karben-Giessen13");

            g1.createKnoten(280, 370, "Karben-Giessen2");
            g1.createKnoten(275, 370, "Karben-Giessen22");
            g1.createKnoten(285, 370, "Karben-Giessen23");

            g1.createKnoten(295, 350, "Karben-Giessen3");
            g1.createKnoten(290, 350, "Karben-Giessen32");
            g1.createKnoten(300, 350, "Karben-Giessen33");

            g1.createKnoten(275, 330, "Karben-Giessen4");
            g1.createKnoten(270, 330, "Karben-Giessen42");
            g1.createKnoten(280, 330, "Karben-Giessen43");

            g1.createKnoten(270, 275, "Karben-Giessen5");
            g1.createKnoten(265, 270, "Karben-Giessen52");
            g1.createKnoten(275, 280, "Karben-Giessen53");

            g1.createKnoten(490, 30, "Borken-Mecklar1");
            g1.createKnoten(490, 25, "Borken-Mecklar12");
            g1.createKnoten(490, 35, "Borken-Mecklar13");

            g1.createKnoten(530, 30, "Borken-Mecklar2");
            g1.createKnoten(530, 25, "Borken-Mecklar22");
            g1.createKnoten(530, 35, "Borken-Mecklar23");

            g1.createKnoten(623, 150, "Mecklar-Dipperz1");
            g1.createKnoten(618, 150, "Mecklar-Dipperz12");
            g1.createKnoten(628, 150, "Mecklar-Dipperz13");

            g1.createKnoten(615, 265, "Dipperz-Frankfurt1");
            g1.createKnoten(610, 265, "Dipperz-Frankfurt12");
            g1.createKnoten(620, 265, "Dipperz-Frankfurt13");

            g1.createKnoten(515, 350, "Dipperz-Frankfurt2");
            g1.createKnoten(515, 345, "Dipperz-Frankfurt22");
            g1.createKnoten(515, 355, "Dipperz-Frankfurt23");

            g1.createKnoten(465, 350, "Dipperz-Frankfurt3");
            g1.createKnoten(465, 345, "Dipperz-Frankfurt32");
            g1.createKnoten(465, 355, "Dipperz-Frankfurt33");

            g1.createKnoten(355, 410, "Dipperz-Frankfurt4");
            g1.createKnoten(350, 405, "Dipperz-Frankfurt42");
            g1.createKnoten(360, 415, "Dipperz-Frankfurt43");

            g1.createKnoten(385, 450, "Dipperz-Frankfurt5");
            g1.createKnoten(380, 450, "Dipperz-Frankfurt52");
            g1.createKnoten(390, 450, "Dipperz-Frankfurt53");

            g1.createKanten("Borken", "Borken-Giessen1");
            g1.createKanten("Borken", "Borken-Giessen12");
            g1.createKanten("Borken", "Borken-Giessen13");

            g1.createKanten("Borken-Giessen1", "Borken-Giessen2");
            g1.createKanten("Borken-Giessen12", "Borken-Giessen22");
            g1.createKanten("Borken-Giessen13", "Borken-Giessen23");

            g1.createKanten("Borken-Giessen2", "Borken-Giessen3");
            g1.createKanten("Borken-Giessen22", "Borken-Giessen32");
            g1.createKanten("Borken-Giessen23", "Borken-Giessen33");

            g1.createKanten("Borken-Giessen3", "Borken-Giessen4");
            g1.createKanten("Borken-Giessen32", "Borken-Giessen42");
            g1.createKanten("Borken-Giessen33", "Borken-Giessen43");

            g1.createKanten("Borken-Giessen4", "Giessen");
            g1.createKanten("Borken-Giessen42", "Giessen");
            g1.createKanten("Borken-Giessen43", "Giessen");

            g1.createKanten("Giessen", "Asslar");

            g1.createKanten("Asslar-Dauersberg1", "Dillenburg");
            g1.createKanten("Asslar-Dauersberg12", "Dillenburg");
            g1.createKanten("Asslar-Dauersberg13", "Dillenburg");

            g1.createKanten("Asslar-Dauersberg1", "Asslar");
            g1.createKanten("Asslar-Dauersberg12", "Asslar");
            g1.createKanten("Asslar-Dauersberg13", "Asslar");

            g1.createKanten("Asslar-Dauersberg1", "Asslar-Dauersberg2");
            g1.createKanten("Asslar-Dauersberg12", "Asslar-Dauersberg22");
            g1.createKanten("Asslar-Dauersberg13", "Asslar-Dauersberg23");

            g1.createKanten("Asslar-Dauersberg3", "Asslar-Dauersberg2");
            g1.createKanten("Asslar-Dauersberg32", "Asslar-Dauersberg22");
            g1.createKanten("Asslar-Dauersberg33", "Asslar-Dauersberg23");

            g1.createKanten("Asslar-Dauersberg3", "Dauersberg");
            g1.createKanten("Asslar-Dauersberg32", "Dauersberg");
            g1.createKanten("Asslar-Dauersberg33", "Dauersberg");

            g1.createKanten("Dauersberg-Limburg1", "Dauersberg");
            g1.createKanten("Dauersberg-Limburg12", "Dauersberg");
            g1.createKanten("Dauersberg-Limburg13", "Dauersberg");

            g1.createKanten("Dauersberg-Limburg1", "Dauersberg-Limburg2");
            g1.createKanten("Dauersberg-Limburg12", "Dauersberg-Limburg22");
            g1.createKanten("Dauersberg-Limburg13", "Dauersberg-Limburg23");

            g1.createKanten("Dauersberg-Limburg3", "Dauersberg-Limburg2");
            g1.createKanten("Dauersberg-Limburg32", "Dauersberg-Limburg22");
            g1.createKanten("Dauersberg-Limburg33", "Dauersberg-Limburg23");

            g1.createKanten("Dauersberg-Limburg3", "Dauersberg-Limburg4");
            g1.createKanten("Dauersberg-Limburg32", "Dauersberg-Limburg42");
            g1.createKanten("Dauersberg-Limburg33", "Dauersberg-Limburg43");

            g1.createKanten("Dauersberg-Limburg5", "Dauersberg-Limburg4");
            g1.createKanten("Dauersberg-Limburg52", "Dauersberg-Limburg42");
            g1.createKanten("Dauersberg-Limburg53", "Dauersberg-Limburg43");

            g1.createKanten("Dauersberg-Limburg5", "Limburg");
            g1.createKanten("Dauersberg-Limburg52", "Limburg");
            g1.createKanten("Dauersberg-Limburg53", "Limburg");


            g1.createKanten("Limburg-Kriftel1", "Limburg");
            g1.createKanten("Limburg-Kriftel12", "Limburg");
            g1.createKanten("Limburg-Kriftel13", "Limburg");

            g1.createKanten("Limburg-Kriftel1", "Limburg-Kriftel2");
            g1.createKanten("Limburg-Kriftel12", "Limburg-Kriftel22");
            g1.createKanten("Limburg-Kriftel13", "Limburg-Kriftel23");

            g1.createKanten("Limburg-Kriftel3", "Limburg-Kriftel2");
            g1.createKanten("Limburg-Kriftel32", "Limburg-Kriftel22");
            g1.createKanten("Limburg-Kriftel33", "Limburg-Kriftel23");

            g1.createKanten("Limburg-Kriftel3", "Kriftel");
            g1.createKanten("Limburg-Kriftel32", "Kriftel");
            g1.createKanten("Limburg-Kriftel33", "Kriftel");

            g1.createKanten("Kriftel-Karben1", "Kriftel");
            g1.createKanten("Kriftel-Karben12", "Kriftel");
            g1.createKanten("Kriftel-Karben13", "Kriftel");

            g1.createKanten("Kriftel-Karben1", "Bommersheim");
            g1.createKanten("Kriftel-Karben12", "Bommersheim");
            g1.createKanten("Kriftel-Karben13", "Bommersheim");

            g1.createKanten("Kriftel-Karben1", "Kriftel-Karben2");
            g1.createKanten("Kriftel-Karben12", "Kriftel-Karben22");
            g1.createKanten("Kriftel-Karben13", "Kriftel-Karben23");

            g1.createKanten("Kriftel-Karben3", "Kriftel-Karben2");
            g1.createKanten("Kriftel-Karben32", "Kriftel-Karben22");
            g1.createKanten("Kriftel-Karben33", "Kriftel-Karben23");

            g1.createKanten("Kriftel-Karben3", "Karben");
            g1.createKanten("Kriftel-Karben32", "Karben");
            g1.createKanten("Kriftel-Karben33", "Karben");

            g1.createKanten("Karben-Frankfurt1", "Karben");
            g1.createKanten("Karben-Frankfurt12", "Karben");
            g1.createKanten("Karben-Frankfurt13", "Karben");

            g1.createKanten("Karben-Frankfurt1", "Frankfurt");
            g1.createKanten("Karben-Frankfurt12", "Frankfurt");
            g1.createKanten("Karben-Frankfurt13", "Frankfurt");

            g1.createKanten("Karben", "Karben-Giessen1");
            g1.createKanten("Karben", "Karben-Giessen12");
            g1.createKanten("Karben", "Karben-Giessen13");

            g1.createKanten("Karben-Giessen2", "Karben-Giessen1");
            g1.createKanten("Karben-Giessen22", "Karben-Giessen12");
            g1.createKanten("Karben-Giessen23", "Karben-Giessen13");

            g1.createKanten("Karben-Giessen2", "Karben-Giessen3");
            g1.createKanten("Karben-Giessen22", "Karben-Giessen32");
            g1.createKanten("Karben-Giessen23", "Karben-Giessen33");

            g1.createKanten("Karben-Giessen4", "Karben-Giessen3");
            g1.createKanten("Karben-Giessen42", "Karben-Giessen32");
            g1.createKanten("Karben-Giessen43", "Karben-Giessen33");

            g1.createKanten("Karben-Giessen4", "Karben-Giessen5");
            g1.createKanten("Karben-Giessen42", "Karben-Giessen52");
            g1.createKanten("Karben-Giessen43", "Karben-Giessen53");

            g1.createKanten("Giessen", "Karben-Giessen5");
            g1.createKanten("Giessen", "Karben-Giessen52");
            g1.createKanten("Giessen", "Karben-Giessen53");

            g1.createKanten("Borken", "Borken-Mecklar1");
            g1.createKanten("Borken", "Borken-Mecklar12");
            g1.createKanten("Borken", "Borken-Mecklar13");

            g1.createKanten("Borken-Mecklar2", "Borken-Mecklar1");
            g1.createKanten("Borken-Mecklar22", "Borken-Mecklar12");
            g1.createKanten("Borken-Mecklar23", "Borken-Mecklar13");

            g1.createKanten("Borken-Mecklar2", "Mecklar");
            g1.createKanten("Borken-Mecklar22", "Mecklar");
            g1.createKanten("Borken-Mecklar23", "Mecklar");

            g1.createKanten("Mecklar-Dipperz1", "Mecklar");
            g1.createKanten("Mecklar-Dipperz12", "Mecklar");
            g1.createKanten("Mecklar-Dipperz13", "Mecklar");

            g1.createKanten("Mecklar-Dipperz1", "Dipperz");
            g1.createKanten("Mecklar-Dipperz12", "Dipperz");
            g1.createKanten("Mecklar-Dipperz13", "Dipperz");

            g1.createKanten("Dipperz-Frankfurt1", "Dipperz");
            g1.createKanten("Dipperz-Frankfurt12", "Dipperz");
            g1.createKanten("Dipperz-Frankfurt13", "Dipperz");

            g1.createKanten("Dipperz-Frankfurt1", "Dipperz-Frankfurt2");
            g1.createKanten("Dipperz-Frankfurt12", "Dipperz-Frankfurt22");
            g1.createKanten("Dipperz-Frankfurt13", "Dipperz-Frankfurt23");

            g1.createKanten("Dipperz-Frankfurt3", "Dipperz-Frankfurt2");
            g1.createKanten("Dipperz-Frankfurt32", "Dipperz-Frankfurt22");
            g1.createKanten("Dipperz-Frankfurt33", "Dipperz-Frankfurt23");

            g1.createKanten("Dipperz-Frankfurt3", "Dipperz-Frankfurt4");
            g1.createKanten("Dipperz-Frankfurt32", "Dipperz-Frankfurt42");
            g1.createKanten("Dipperz-Frankfurt33", "Dipperz-Frankfurt43");

            g1.createKanten("Dipperz-Frankfurt5", "Dipperz-Frankfurt4");
            g1.createKanten("Dipperz-Frankfurt52", "Dipperz-Frankfurt42");
            g1.createKanten("Dipperz-Frankfurt53", "Dipperz-Frankfurt43");

            g1.createKanten("Dipperz-Frankfurt5", "Frankfurt");
            g1.createKanten("Dipperz-Frankfurt52", "Frankfurt");
            g1.createKanten("Dipperz-Frankfurt53", "Frankfurt");
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

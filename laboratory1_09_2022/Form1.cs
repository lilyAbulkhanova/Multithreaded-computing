using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace laboratory1_09_2022
{

public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var matrix1 = new float[1000, 1000];
            var matrix2 = new float[1000, 1000];
            //   var masLong = new long[8];
            matrix1.FillMatrixRandom();
            matrix2.FillMatrixRandom();
           
            chart1.Series[0].Points.Clear();
            //chart1.Size;


           // int[] mas = new int[9];
            
            for (int i = 0; i < 8; i++)
            {
                Stopwatch sw = new Stopwatch();
               // var matrix3 = matrix1;
                sw.Start();
                LilMultithreading.SumAndOperationParallel(ref matrix1, matrix2, LilMultithreading.Operation, i+1);
                sw.Stop();
                // temp.Append<int>(unchecked((int)sw.ElapsedTicks));
                Console.WriteLine(sw.ElapsedMilliseconds);
                // chart1.Series[0].Points.AddXY(i, sw.Elapsed.TotalSeconds);
                //  mas[i] = (int)sw.ElapsedMilliseconds;
                chart1.Series[0].Points.AddXY(i+1,sw.ElapsedMilliseconds);
            }
            //chart1.Series[0].Points.DataBindY(mas);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

           

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

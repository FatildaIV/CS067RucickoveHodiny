using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS066RucickoveHodiny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double Rad(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            //g.DrawLine(new Pen(Color.Red, 5), 0, 0, this.Width, this.Height);
            Point stred = new Point(200, 200);
            float rVnejsiDilky = 100;
            float r5Min = 85;
            float rMin = 90;
            float rCisla = 65;
            int pocetSegmentu = 60;
            float uhelCelkem = 360;
            float uhelSegmentVelikost = uhelCelkem / pocetSegmentu;
            float uhelSegment = 0;
            Pen pMin = new Pen(Color.Black, 0.5f);
            Pen p5Min = new Pen(Color.Black, 2f);
            Font cislaFont= new Font("Arial", 16);
            Brush cislaBrush = new SolidBrush(Color.Black);
            for (int i = 0; i < pocetSegmentu; i++)
            {
                double cos = Math.Cos(Rad(uhelSegment));
                double sin = Math.Sin(Rad(uhelSegment));
                Pen p = ((i % 5) == 0) ? p5Min : pMin;
                double r  = ((i % 5) == 0) ? r5Min : rMin;

                g.DrawLine(
                    p,
                    new Point(
                        (int)(cos * r + 200),
                        (int)(sin * r + 200)),
                    new Point(
                        (int)(cos * rVnejsiDilky + 200),
                        (int)(sin * rVnejsiDilky + 200)));

                int cislo= ((i / 5) + 3) % 12;

                if ((i % 5) == 0)
                    g.DrawString(
                        string.Format("{0}", cislo==0?12:cislo),
                        cislaFont,
                        cislaBrush,
                        (int)(cos * rCisla + 200),
                        (int)(sin * rCisla + 200));

                uhelSegment += uhelSegmentVelikost;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.Clear(this.BackColor);
            //g.DrawLine(new Pen(Color.Red, 5), 0, 0, this.Width, this.Height);
            //Point stred = new Point(200,200);
            //float polomer = 100;
            //int pocetSegmentu = 12;
            //float uhelCelkem = 360;
            //float uhelSegmentVelikost = uhelCelkem / pocetSegmentu;
            //float uhelSegment = 0;
            //for (int i = 0; i < pocetSegmentu; i++)
            //{
            //    g.DrawLine(
            //        new Pen(Color.Red, 2),
            //        stred,
            //        new Point(
            //            (int)(Math.Cos(uhelSegment)*polomer+200),
            //            (int)(Math.Sin(uhelSegment)*polomer+200)));

            //    uhelSegment += uhelSegmentVelikost;
            //}
        }
    }
}

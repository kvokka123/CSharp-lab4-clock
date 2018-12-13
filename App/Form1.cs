using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;



namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            const int w = 300;
            const int h = 300;
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;               
            GraphicsState gs;
            GraphicsState gs1;
            GraphicsState gs2;

            g.TranslateTransform(w / 2, h / 2);
            g.ScaleTransform(w / 200, h / 200);
            g.DrawEllipse(cir_pen, -120, -120, 240, 240);

            gs = g.Save();
            g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
            g.DrawLine(new Pen(new SolidBrush(Color.Blue), 4), 0, 0, 0, -80);
            g.Restore(gs);

            gs1 = g.Save();
            g.RotateTransform(6 * (float)dt.Second );
            g.DrawLine(new Pen(new SolidBrush(Color.Yellow), 4), 0, 0, 0, -100);
            g.Restore(gs1);

            gs2 = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60+(float)dt.Second/3600));
            g.DrawLine(new Pen(new SolidBrush(Color.DarkViolet), 4), 0, 0, 0, -50);
            g.Restore(gs2);

            g.FillEllipse(new SolidBrush(Color.Black),-3,-3,7,7);

            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(-10, -110));
            g.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(-110, 0));
            g.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(-10, 95));
            g.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(100, 0));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}

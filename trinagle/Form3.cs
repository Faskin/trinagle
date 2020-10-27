using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trinagle
{
    public partial class Form3 : Form
    {
        Graphics gp;
        Pen p = new Pen(Brushes.Black, 2);
        public Form3()
        {
            Button btndraw = new Button();
            {

                
                InitializeComponent();
                gp = panel1.CreateGraphics();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point p1 = new Point(5, 5);
            Point p2 = new Point(150, 5);
            Point p3 = new Point(75, 30);

            gp.DrawLine(p, p1, p2);
            gp.DrawLine(p, p2, p3);
            gp.DrawLine(p, p3, p1);
            Point[] list = new Point[3] { p1, p2, p3 };
            gp.DrawPolygon(p, list);
        }
    }
}

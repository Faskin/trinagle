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
    public partial class Form1 : Form
    {
        Form2 form2;
        
        public Form1()
        {
            this.Height = 400;
            this.Width = 800;
            this.Text = "Trinagle";

            Button btn1 = new Button();
            {
                btn1.Text = "Запуск";
                btn1.Location = new Point(544, 96);
                btn1.Width = 200;
                btn1.Height = 100;
                btn1.Cursor = Cursors.Hand;
                btn1.BackColor = Color.FromArgb(255, 255, 192);
                btn1.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
                btn1.FlatAppearance.BorderSize = 10;
                btn1.FlatStyle = FlatStyle.Flat;
                btn1.Font = new Font(btn1.Font.FontFamily, 18);
                btn1.Click += Btn1_Click;
                Controls.Add(btn1);



            };

           /* PictureBox img1 = new PictureBox();
            {
                img1.Location = new Point(600, 1);
                img1.Image = new Bitmap("triangle.png");
                img1.Size = new Size(100, 100);
                img1.SizeMode = PictureBoxSizeMode.Zoom;
                Controls.Add(img1);
            }
           */
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

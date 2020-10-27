using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trinagle
{
    public partial class Form2 : Form
    {
        Graphics gp;
        Pen p = new Pen(Brushes.Black, 2);
        Trinagle tri = new Trinagle();
        Trinagle triabc = new Trinagle();
        Trinagle trideh = new Trinagle();
        public Form2()
        {
            Height = 790;
            Width = 1000;


            Label lblA = new Label();
            {
                lblA.Text = "Сторона A";
                Controls.Add(lblA);
            }

            Label lblB = new Label();
            {
                lblB.Text = "Сторона B";
                Controls.Add(lblB);
            }
            Label lblC = new Label();
            {
                lblC.Text = "Сторона C";
                Controls.Add(lblC);
            }
            Button btnStart = new Button();
            {
                
                btnStart.Text = "Вычислить";
                btnStart.BackColor = Color.AliceBlue;
                btnStart.Location = new Point(659, 98);
                btnStart.Width = 248;
                btnStart.Height = 65;
                Controls.Add(btnStart);
                
            }
            Button btndraw = new Button();
            {

                btndraw.Text = "Нарисовать треугольник";
                btndraw.BackColor = Color.AliceBlue;
                btndraw.Location = new Point(659, 170);
                btndraw.Width = 248;
                btndraw.Height = 65;
                Controls.Add(btndraw);
                btndraw.Click += Btndraw_Click;
                
            }
            TextBox txtA = new TextBox();
            {
                txtA.Location = new Point(521,45);
                Controls.Add(txtA);
            }
            TextBox txtB = new TextBox();
            {
                txtB.Location = new Point(521, 84);
                Controls.Add(txtB);
            }
            TextBox txtC = new TextBox();
            {
                txtC.Location = new Point(521, 125);
                Controls.Add(txtC);
            }
            RadioButton radio1 = new RadioButton();
            {
                Controls.Add(radio1);
            }
            RadioButton radio3 = new RadioButton();
            {
                Controls.Add(radio3);
            }




            void clearText()
            {
                txtA.Text = "";
                txtB.Text = "";
                txtC.Text = "";
            }
            radio1.CheckedChanged += (s, e) =>
            {
                // S =  a /2 *h
                lblB.Text = "Высота";
                lblC.Visible = false;
                txtC.Visible = false;
                clearText();
            };
            radio3.CheckedChanged += (s, e) =>
            {
                lblB.Text = "Сторона B";
                lblC.Visible = true;
                txtC.Visible = true;
                clearText();
            };
            /*btnForm2.Click += (s, e) =>
            {
                Form2 form2 = new Form2();
                form2.Owner = this;
                form2.ShowDialog();
            };*/

            InitializeComponent();
            gp = panel1.CreateGraphics();


           /* btnStart.Click += (s, e) =>
           {
                if (radio3.Checked)
                {
                    if (txtA.Text.Length != 0 && txtB.Text.Length != 0 && txtC.Text.Length != 0
                    && Regex.IsMatch(txtA.Text, @"^\d+$") && Regex.IsMatch(txtB.Text, @"^\d+$")
                    && Regex.IsMatch(txtC.Text, @"^\d+$"))
                    {
                        Trinagle triangle = new Trinagle(Convert.ToDouble(txtA.Text), Convert.ToDouble(txtB.Text), Convert.ToDouble(txtC.Text));
                        listTriangle.Items.Clear();
                        listTriangle.Items.Add("Сторона a");
                        listTriangle.Items.Add("Сторона b");
                        listTriangle.Items.Add("Сторона c");
                        listTriangle.Items[0].SubItems.Add(triangle.outputA());
                        listTriangle.Items[1].SubItems.Add(triangle.outputB());
                        listTriangle.Items[2].SubItems.Add(triangle.outputC());
                        listTriangle.Items.Add("Периметр");
                        listTriangle.Items[3].SubItems.Add(Convert.ToString(triangle.Perimeter()));
                        listTriangle.Items.Add("Полу периметр");
                        listTriangle.Items[4].SubItems.Add(Convert.ToString(triangle.SemiPerimter()));
                        listTriangle.Items.Add("Площадь");
                        listTriangle.Items[5].SubItems.Add(Convert.ToString(triangle.Surface()));
                        listTriangle.Items.Add("Существует?");
                        if (triangle.ExistTriangle)
                        {
                            listTriangle.Items[6].SubItems.Add("Существует");
                        }
                        else
                        {
                            listTriangle.Items[6].SubItems.Add("Не существует");
                        }
                        listTriangle.Items.Add("Высота");
                        listTriangle.Items[7].SubItems.Add(Convert.ToString(triangle.Height()));
                        listTriangle.Items.Add("Высота A");
                        listTriangle.Items.Add("Высота B");
                        listTriangle.Items.Add("Высота C");
                        listTriangle.Items[8].SubItems.Add(Convert.ToString(triangle.hA()));
                        listTriangle.Items[9].SubItems.Add(Convert.ToString(triangle.hB()));
                        listTriangle.Items[10].SubItems.Add(Convert.ToString(triangle.hC()));
                        listTriangle.Items.Add("Медиана");
                        listTriangle.Items[11].SubItems.Add(Convert.ToString(triangle.Median()));
                        listTriangle.Items.Add("Спецификатор");
                        listTriangle.Items[12].SubItems.Add(triangle.TriangleType());
                        pictureTriangle.Image = Image.FromFile(triangle.ImageSource());
                    }
                    else
                    {
                        MyMethods.WrongValues(this, new List<Control>() { txtA, txtB, txtC });
                    }
                }
                else if (radio1.Checked)
                {
                    if (txtA.Text.Length != 0 && txtB.Text.Length != 0
                   && Regex.IsMatch(txtA.Text, @"^\d+$") && Regex.IsMatch(txtB.Text, @"^\d+$"))
                    {
                        Triangle triangle = new Triangle(Convert.ToDouble(txtA.Text), Convert.ToDouble(txtB.Text));
                        listTriangle.Items.Clear();
                        listTriangle.Items.Add("Сторона A");
                        listTriangle.Items[0].SubItems.Add(triangle.outputA());
                        listTriangle.Items.Add("Высота");
                        listTriangle.Items[1].SubItems.Add(Convert.ToString(triangle.outputH()));
                        listTriangle.Items.Add("Площадь");
                        listTriangle.Items[2].SubItems.Add(Convert.ToString(triangle.Side1Surface()));
                    }
                    else
                    {
                        MyMethods.WrongValues(this, new List<Control>() { txtA, txtB });
                    }
                }

            };*/
            
        }

        private void Btndraw_Click(object sender, EventArgs e)
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
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

            InitializeComponent();
            gp = panel1.CreateGraphics();
            Load += (s, e) =>
            {
                bool firstTime = true;
                Size = new Size(788, 190);
                void ClearCalculated()
                {
                    foreach (var lbl in panelValues.Controls.OfType<Label>())
                    {
                        lbl.Text = "";
                    }
                }
                void HideValues()
                {
                    if (firstTime)
                    {
                        Size = new Size(788, 470);
                        firstTime = false;
                    }
                }
                btn3Side.Click += (ss, ee) =>
                {
                    HideValues();
                    btn3Side.Enabled = false;
                    panel3Side.Enabled = true;
                    panel1Side.Enabled = false;
                    btn1Side.Enabled = true;
                    btnCalculate.Enabled = true;
                };
                btn1Side.Click += (ss, ee) =>
                {
                    HideValues();
                    btn1Side.Enabled = false;
                    panel1Side.Enabled = true;
                    panel3Side.Enabled = false;
                    btn3Side.Enabled = true;
                    btnCalculate.Enabled = true;
                };


                /*Button btn3Side = new Button();

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
                */
                void HideValues()
                {
                    if (firstTime)
                    {
                        Size = new Size(788, 470);
                        firstTime = false;
                    }
                }
                Load += (s, e) =>
                {
                    bool firstTime = true;
                    Size = new Size(788, 190);
                    void ClearCalculated()
                    {
                        foreach (var lbl in panelValues.Controls.OfType<Label>())
                        {
                            lbl.Text = "";
                        }
                    }

                    HideValues();
                    btn3Side.Enabled = false;
                    panel3Side.Enabled = true;
                    panel1Side.Enabled = false;
                    btn1Side.Enabled = true;
                    btnCalculate.Enabled = true;
                };


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

                btnStart.Click += (ss, ee) =>
                {
                    if (!btn3Side.Enabled)
                    {
                        if (numericA.Value.ToString().Trim().Length != 0 && numericB.Value.ToString().Trim().Length != 0
                        && numericC.Value.ToString().Trim().Length != 0 && Regex.IsMatch(numericA.Value.ToString(), @"^\d+$") &&
                        Regex.IsMatch(numericB.Value.ToString(), @"^\d+$") && Regex.IsMatch(numericC.Value.ToString(), @"^\d+$"))
                        {
                            Triangle triangle = new Triangle((double)numericA.Value, (double)numericB.Value, (double)numericC.Value);
                            ClearCalculated();
                            lblValues.Text = "Значения";
                            lblValA.Text = "Сторона А:";
                            lblValB.Text = "Сторона B:";
                            lblValC.Text = "Сторона C:";
                            lblValPerimeter.Text = "Периметр:";
                            lblValSemiPerimeter.Text = "Полу периметр:";
                            lblValSurface.Text = "Площадь:";
                            lblValHeight.Text = "Высота:";
                            lblValHeightA.Text = "Высота A:";
                            lblValHeightB.Text = "Высота B:";
                            lblValHeightC.Text = "Высота C:";
                            lblValMedian.Text = "Медиана:";
                            lblValSpecification.Text = "Спецификатор:";
                            lblValExists.Text = "Существует:";
                            lblValuesSideA.Text = triangle.outputA();
                            lblValuesSideB.Text = triangle.outputB();
                            lblValuesSideC.Text = triangle.outputC();
                            lblValuesPerimeter.Text = Convert.ToString(Math.Round(triangle.Perimeter(), 3));
                            lblValuesSemiPerimeter.Text = Convert.ToString(Math.Round(triangle.SemiPerimter(), 3));
                            lblValuesSurface.Text = Convert.ToString(Math.Round(triangle.Surface(), 3));
                            lblValuesHeight.Text = Convert.ToString(Math.Round(Convert.ToDouble(triangle.outputH()), 3));
                            lblValuesHeightA.Text = Convert.ToString(Math.Round(triangle.hA(), 3));
                            lblValuesHeightB.Text = Convert.ToString(Math.Round(triangle.hB(), 3));
                            lblValuesHeightC.Text = Convert.ToString(Math.Round(triangle.hC(), 3));
                            lblValuesMedian.Text = Convert.ToString(triangle.Median());
                            lblValuesSpecification.Text = triangle.TriangleType();
                            lblValuesExists.Text = triangle.ExistTriangle ? "Да" : "Нет";
                            panelValues.Size = new Size(745, 330);
                            panelPicture.Location = new Point(9, 770);
                            drawtriangle.Image = Image.FromFile(triangle.ImageSource());
                            Size = new Size(788, 963);
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля правильно", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MyMethods.WrongValuesNumeric(this, new List<NumericUpDown>() { numericA, numericB, numericC });
                        }
                    }
                    else
                    {
                        if (numericAHeight.Value.ToString().Trim().Length != 0 && numericHeight.Value.ToString().Trim().Length != 0
                        && Regex.IsMatch(numericAHeight.Value.ToString(), @"^\d+$") && Regex.IsMatch(numericAHeight.Value.ToString(), @"^\d+$"))
                        {
                            Triangle triangle = new Triangle((double)numericAHeight.Value, (double)numericAHeight.Value);
                            ClearCalculated();
                            lblValues.Text = "Значения";
                            lblValA.Text = "Сторона А:";
                            lblValB.Text = "Высота:";
                            lblValC.Text = "Площадь:";
                            panelValues.Size = new Size(745, 106);
                            panelPicture.Location = new Point(9, 550);
                            Size = new Size(788, 600);
                            lblValuesSideA.Text = triangle.outputA();
                            lblValuesSideB.Text = triangle.outputH();
                            lblValuesSideC.Text = Convert.ToString(Math.Round(triangle.Side1Surface(), 3));
                            drawtriangle.Image = Image.FromFile(triangle.ImageSource());
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля правильно", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MyMethods.WrongValuesNumeric(this, new List<NumericUpDown>() { numericAHeight, numericHeight });
                        }
                    }
                };

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






                /*private void Btndraw_Click(object sender, EventArgs e)
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
                */

            };
        }

        
    }
}
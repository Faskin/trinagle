using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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
             void ShowParamsOfTriangleToUser(Trinagle trinagle)
            {
                if (trinagle.ExistTriangle)
                {
                    trinagle.DrawTriangle(gp);
                }
            }

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
                    btnStart.Enabled = true;
                };
                btn1Side.Click += (ss, ee) =>
                {
                    HideValues();
                    btn1Side.Enabled = false;
                    panel1Side.Enabled = true;
                    panel3Side.Enabled = false;
                    btn3Side.Enabled = true;
                    btnStart.Enabled = true;
                };



                btnStart.Click += (ss, ee) =>
                {
                    if (!btn3Side.Enabled)
                    {
                        if (numericA.Value.ToString().Trim().Length != 0 && numericB.Value.ToString().Trim().Length != 0
                        && numericC.Value.ToString().Trim().Length != 0 && Regex.IsMatch(numericA.Value.ToString(), @"^\d+$") &&
                        Regex.IsMatch(numericB.Value.ToString(), @"^\d+$") && Regex.IsMatch(numericC.Value.ToString(), @"^\d+$"))
                        {
                            Trinagle triangle = new Trinagle((double)numericA.Value, (double)numericB.Value, (double)numericC.Value);
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
                            ShowParamsOfTriangleToUser(triangle);
                            if (triangle.ExistTriangle)
                            {
                                gp.Clear(Color.White);
                            }

                                Size = new Size(788, 963);
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля правильно", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            meth.WrongValuesNumeric(this, new List<NumericUpDown>() { numericA, numericB, numericC });
                        }
                    }
                    else
                    {
                        if (numericAHeight.Value.ToString().Trim().Length != 0 && numericHeight.Value.ToString().Trim().Length != 0
                        && Regex.IsMatch(numericAHeight.Value.ToString(), @"^\d+$") && Regex.IsMatch(numericAHeight.Value.ToString(), @"^\d+$"))
                        {
                            Trinagle triangle = new Trinagle((double)numericAHeight.Value, (double)numericAHeight.Value);
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
                            ShowParamsOfTriangleToUser(triangle);
                        }
                        else
                        {
                            MessageBox.Show("Заполните поля правильно", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            meth.WrongValuesNumeric(this, new List<NumericUpDown>() { numericAHeight, numericHeight });
                        }
                    }
                };
            };


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

        }
    };

}



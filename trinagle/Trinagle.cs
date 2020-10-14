using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trinagle
{
    class Trinagle
    {
        public double a;
        public double b;
        public double c;
        public double h;
        public Trinagle() { }
        public Trinagle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }
        public Trinagle(double A, double H)
        {
            a = A;
            h = H;
        }
        public string OutputA()
        {
            return Convert.ToString(a);
        }

        public string outputB()
        {
            return Convert.ToString(b);
        }
        public string outputC()
        {
            return Convert.ToString(c);
        }

        public string outputH()
        {
            return Convert.ToString(h);

        }
        public double Perimeter()
        {
            return a + b + c;
        }
        public double Height()
        {
            return Surface() * 2 / a;
        }
        public double Median()
        {
            return (Math.Sqrt(2 * b * b +
                            2 * c * c -
                            a * a) / 2);
        }
        public double hA()
        {
            return Surface() / 2 / a;
        }
        public double hB()
        {
            return Surface() / 2 / b;
        }
        public double hC()
        {
            return Surface() / 2 / c;
        }
        public double SemiPerimter()
        {
            return Perimeter() / 2;
        }
        public double Surface()
        {
            double p = a + b + c;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public string TriangleType()
        {
            string type = "";
            if (a == b && b == c)
            {
                type = "Равносторонний";
            }
            else if ((a == b) && (a != c) || (b == c) && (b != a) || (a == c) && (a != b))
            {
                type = "Равнобедренный";
            }
            else if (a != b || b != c)
            {
                type = "Разносторонний";
            }
            else if (c * 2 == (a * 2 + b * 2))
            {
                type = "Правильный";
            }
            else if (c * 2 > (a * 2 + b * 2))
            {
                type = "Тупоугольный";
            }
            else if (c * 2 < (a * 2 + b * 2))
            {
                type = "Остроугольный";
            }
            return type;


        }
        public double Side1Surface()
        {
            return a / 2 * h;
        }
        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }
        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }
        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }
        public double GetSetH
        {
            get { return h; }
            set { h = value; }
        }
        public bool ExistTriangle
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b)) return true;
                else return false;
            }
        }

    }
 
}

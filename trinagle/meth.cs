using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trinagle
{
    public static class meth
    {
        public static async void WrongValues(Form form, List<Control> fields)
        {
            Random rnd = new Random();
            bool isNullText = false;
            foreach (var txt in fields)
            {
                if (txt.Text.Trim().Length == 0 || !Regex.IsMatch(txt.Text, @"^\d+$"))
                {
                    isNullText = true;
                    txt.BackColor = Color.Tomato;
                }
            }
            if (isNullText)
            {
                foreach (var control in form.Controls.Cast<Control>())
                {
                    control.Enabled = false;
                }
                var defaultBackColor = form.BackColor;
                for (form.Opacity = 0.3; form.Opacity < 1; form.Opacity += 0.05)
                {
                    await Task.Delay(40);
                    form.BackColor = Color.FromArgb(rnd.Next(0, 256),
                    rnd.Next(0, 256), rnd.Next(0, 256));
                    await Task.Delay(40);

                }
                form.BackColor = defaultBackColor;
                foreach (var control in form.Controls.Cast<Control>())
                {
                    control.Enabled = true;
                }
                fields.FindAll(f => f.BackColor == Color.Tomato).ForEach(f => f.BackColor = SystemColors.Menu);
            }
        }
        public static async void WrongValuesNumeric(Form form, List<NumericUpDown> fields)
        {
            Random rnd = new Random();
            bool isNullValue = false;
            foreach (var txt in fields)
            {
                if (txt.Value.ToString().Trim().Length == 0 || !Regex.IsMatch(txt.Value.ToString(), @"^\d+$"))
                {
                    isNullValue = true;
                    txt.BackColor = Color.Tomato;
                }
            }
            if (isNullValue)
            {
                foreach (var control in form.Controls.Cast<Control>())
                {
                    control.Enabled = false;
                }
                var defaultBackColor = form.BackColor;
                for (form.Opacity = 0.3; form.Opacity < 1; form.Opacity += 0.1)
                {
                    await Task.Delay(40);
                    form.BackColor = Color.FromArgb(rnd.Next(0, 256),
                    rnd.Next(0, 256), rnd.Next(0, 256));
                    await Task.Delay(40);

                }
                form.BackColor = defaultBackColor;
                foreach (var control in form.Controls.Cast<Control>())
                {
                    control.Enabled = true;
                }
                fields.FindAll(f => f.BackColor == Color.Tomato).ForEach(f => f.BackColor = SystemColors.Menu);
            }
        }
    }
}
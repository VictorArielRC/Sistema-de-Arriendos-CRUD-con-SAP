using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public static class LoginVisualStyleManager
    {
        public static void Apply(Form form)
        {
            form.BackColor = ColorTranslator.FromHtml("#F5F8FC"); // Fondo claro, moderno
            form.Font = new Font("Segoe UI", 10);

            foreach (Control ctrl in form.Controls)
            {
                ApplyStyle(ctrl);
            }
        }

        private static void ApplyStyle(Control ctrl)
        {
            switch (ctrl)
            {
                case Label lbl:
                    lbl.ForeColor = ColorTranslator.FromHtml("#2C3E50");
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    break;

                case TextBox txt:
                    txt.BackColor = Color.White;
                    txt.ForeColor = ColorTranslator.FromHtml("#34495E");
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 10);
                    txt.Enter += (s, e) => txt.BackColor = ColorTranslator.FromHtml("#EBF5FB");
                    txt.Leave += (s, e) => txt.BackColor = Color.White;
                    break;

                case Button btn:
                    ConfigureButton(btn);
                    break;

                case CheckBox chk:
                    chk.ForeColor = ColorTranslator.FromHtml("#2C3E50");
                    chk.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    break;
            }

            foreach (Control child in ctrl.Controls)
                ApplyStyle(child);
        }

        private static void ConfigureButton(Button btn)
        {
            string tipo = btn.Tag?.ToString()?.ToLower() ?? "";

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            if (tipo == "salir")
            {
                btn.BackColor = ColorTranslator.FromHtml("#E74C3C");
                btn.ForeColor = Color.White;
                btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#C0392B");
                btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#E74C3C");
            }
            else if (tipo == "limpiar")
            {
                btn.BackColor = ColorTranslator.FromHtml("#D6DBDF");
                btn.ForeColor = ColorTranslator.FromHtml("#2C3E50");
                btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#B2BABB");
                btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#D6DBDF");
            }
            else // Ingreso o principal
            {
                btn.BackColor = ColorTranslator.FromHtml("#3498DB");
                btn.ForeColor = Color.White;
                btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#2E86C1");
                btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#3498DB");
            }
        }
    }
}
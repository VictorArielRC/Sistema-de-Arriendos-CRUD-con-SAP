using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public static class ThemeManager
    {
        public static void ApplyExecutiveTheme(Form form) // Aplica tema ejecutivo al formulario
        {
            form.BackColor = ColorTranslator.FromHtml("#F4F4F4"); // Establece color de fondo

            foreach (Control ctrl in form.Controls) // Itera sobre controles del formulario
            {
                ApplyStyle(ctrl); // Aplica estilo a cada control
            }
        }

        private static void ApplyStyle(Control control) // Aplica estilo a un control
        {
            // 🎯 Label con jerarquía visual.
            if (control is Label lbl) // Si el control es una etiqueta
            {
                lbl.ForeColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de texto

                switch (lbl.Tag?.ToString()) // Evalúa la propiedad Tag
                {
                    case "Titulo": // Si es título
                        lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Establece fuente negrita 14
                        break; // Sale del switch
                    case "Subtitulo": // Si es subtítulo
                        lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular); // Establece fuente regular 12
                        break; // Sale del switch
                    default: // Para otros casos
                        lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Establece fuente regular 10
                        break; // Sale del switch
                }
            }
            // ✍️ TextBox con foco elegante.
            else if (control is TextBox txt) // Si el control es un TextBox
            {
                txt.BorderStyle = BorderStyle.FixedSingle; // Establece estilo de borde
                txt.BackColor = Color.White; // Establece color de fondo blanco
                txt.ForeColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de texto
                txt.Font = new Font("Segoe UI", 10); // Establece la fuente

                txt.Enter += (s, e) => txt.BackColor = ColorTranslator.FromHtml("#ECF8FF"); // Cambia fondo al entrar
                txt.Leave += (s, e) => txt.BackColor = Color.White; // Restaura fondo al salir
            }
            // 🧲 Botón con variaciones.
            else if (control is Button btn) // Si el control es un botón
            {
                bool esPrincipal = btn.Tag?.ToString() != "Secundario"; // Determina si es principal
                EstiloBoton(btn, esPrincipal); // Aplica estilo al botón
            }
            // 📋 DataGridView profesional.
            else if (control is DataGridView dgv) // Si el control es un DataGridView
            {
                dgv.BackgroundColor = Color.White; // Establece color de fondo
                dgv.GridColor = ColorTranslator.FromHtml("#BDC3C7"); // Establece color de cuadrícula
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10); // Establece fuente de celdas
                dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de texto de celdas
                dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de fondo de encabezados
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Establece color de texto de encabezados
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Establece fuente de encabezados
                dgv.EnableHeadersVisualStyles = false; // Deshabilita estilos visuales de encabezados
            }
            // 🧰 ToolStrip ejecutivo.
            else if (control is ToolStrip toolStrip) // Si el control es un ToolStrip
            {
                toolStrip.BackColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de fondo
                toolStrip.ForeColor = Color.White; // Establece color de texto
                toolStrip.Font = new Font("Segoe UI", 10); // Establece la fuente

                foreach (ToolStripItem item in toolStrip.Items) // Itera sobre ítems del ToolStrip
                {
                    item.ForeColor = Color.White; // Establece color de texto del ítem
                    item.BackColor = Color.Transparent; // Establece fondo transparente del ítem
                }
            }

            // ⛏️ Recursivo: aplica a contenedores.
            foreach (Control child in control.Controls) // Itera sobre controles hijos
            {
                ApplyStyle(child); // Aplica estilo recursivamente
            }
        }

        // 🔧 Estilos de botón (primario/secundario).
        private static void EstiloBoton(Button btn, bool esPrincipal) // Aplica estilo al botón
        {
            btn.FlatStyle = FlatStyle.Flat; // Establece estilo plano
            btn.FlatAppearance.BorderSize = 0; // Elimina borde del botón
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Establece fuente negrita
            btn.Cursor = Cursors.Hand; // Cambia cursor a mano

            if (esPrincipal) // Si es botón principal
            {
                btn.BackColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de fondo
                btn.ForeColor = Color.White; // Establece color de texto

                btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#34495E"); // Cambia fondo al pasar ratón
                btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#2C3E50"); // Restaura fondo al salir ratón
            }
            else // Si es botón secundario
            {
                btn.BackColor = ColorTranslator.FromHtml("#BDC3C7"); // Establece color de fondo
                btn.ForeColor = ColorTranslator.FromHtml("#2C3E50"); // Establece color de texto

                btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#D5D8DC"); // Cambia fondo al pasar ratón
                btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#BDC3C7"); // Restaura fondo al salir ratón
            }
        }
    }
}



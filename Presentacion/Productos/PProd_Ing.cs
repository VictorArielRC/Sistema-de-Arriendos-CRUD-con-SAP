// Importa dependencias.
using Entidad;
// Importa dependencias.
using Negocio;
// Importa dependencias.
using System;
// Importa dependencias.
using System.Collections.Generic;
// Importa dependencias.
using System.ComponentModel;
// Importa dependencias.
using System.Data;
// Importa dependencias.
using System.Drawing;
// Importa dependencias.
using System.Linq;
// Importa dependencias.
using System.Text;
// Importa dependencias.
using System.Windows.Forms;
// Importa dependencias.
using CrystalDecisions.CrystalReports.ViewerObjectModel;


namespace Presentacion.Productos
{
    public partial class PProd_Ing : Form
    {
        EProd Ent = new EProd(); // Instancia de la entidad Producto.

        public PProd_Ing() // Constructor del formulario.
        {
            InitializeComponent(); // Inicializa los componentes.
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PProd_Ing_Load(object sender, EventArgs e) // Evento al cargar el formulario.
        {
            TextFech.Text = DateTime.Now.ToString("dd-MM-yyyy"); // Muestra fecha actual.
        }

        public void HabBotIng() // Habilita o deshabilita botón Ingresar.
        {
            // Habilita si campos no están vacíos.
            if ((TextNom.Text.Trim() != "") && (TextCIni.Text.Trim() != "") && (TextCArr.Text.Trim() != "") && (TextVArr.Text.Trim() != ""))
            {
                ButIng.Enabled = true; // Habilita botón Ingresar.
            }
            else
            {
                ButIng.Enabled = false; // Deshabilita botón Ingresar.
            }
        }

        public void HabBotLim() // Habilita o deshabilita botón Limpiar.
        {
            // Habilita si algún campo no está vacío.
            if ((TextNom.Text.Trim() != "") || (TextCIni.Text.Trim() != "") || (TextCArr.Text.Trim() != "") || (TextVArr.Text.Trim() != ""))
            {
                ButLim.Enabled = true; // Habilita botón Limpiar.
            }
            else
            {
                ButLim.Enabled = false; // Deshabilita botón Limpiar.
            }
        }

        private void TextNom_TextChanged(object sender, EventArgs e) // Evento cambio texto nombre.
        {
            TextNom.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextNom.Text); // Convierte a formato título.
            TextNom.SelectionStart = TextNom.Text.Length; // Mueve cursor al final.
            if (TextNom.Text.Trim() != "") // Si campo no está vacío.
            {
                TextCIni.TabStop = true; // Habilita tab en CIni.
                TextNom.TabStop = false; // Deshabilita tab en Nom.
            }
            else // Si campo está vacío.
            {
                TextCIni.TabStop = false; // Deshabilita tab en CIni.
                TextNom.TabStop = true; // Habilita tab en Nom.
            }
            HabBotIng(); // Actualiza estado botón Ingresar.
            HabBotLim(); // Actualiza estado botón Limpiar.
        }

        private void TextCIni_KeyPress(object sender, KeyPressEventArgs e) // Evento tecla presionada cantidad inicial.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla es una letra.
            {
                e.Handled = true; // Suprime la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra advertencia.
            }
        }

        private void TextCIni_TextChanged(object sender, EventArgs e) // Evento cambio texto cantidad inicial.
        {
            if (TextCIni.Text.Trim() != "") // Si campo no está vacío.
            {
                TextCArr.TabStop = true; // Habilita tab en CArr.
                TextCIni.TabStop = false; // Deshabilita tab en CIni.
            }
            else // Si campo está vacío.
            {
                TextCArr.TabStop = false; // Deshabilita tab en CArr.
                TextCIni.TabStop = true; // Habilita tab en CIni.
            }
            HabBotIng(); // Actualiza estado botón Ingresar.
            HabBotLim(); // Actualiza estado botón Limpiar.
        }

        private void TextCArr_KeyPress(object sender, KeyPressEventArgs e) // Evento tecla presionada cantidad arriendo.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla es una letra.
            {
                e.Handled = true; // Suprime la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra advertencia.
            }
        }

        private void TextCArr_Leave(object sender, EventArgs e) // Evento al salir de cantidad arriendo.
        {
            if ((TextCIni.Text.Trim() != "") && (TextCArr.Text.Trim() != "")) // Si ambos campos no están vacíos.
            {
                int numero1 = int.Parse(TextCIni.Text); // Convierte cantidad inicial a entero.
                int numero2 = int.Parse(TextCArr.Text); // Convierte cantidad arriendo a entero.
                int resta = numero1 - numero2; // Calcula la resta.
                if ((numero1 == 0) || (numero1 < numero2)) // Si cantidad inicial es cero o menor.
                {
                    MessageBox.Show("La cantidad a arrendar no puede ser mayor a la cantidad inicial.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de error.
                    TextCArr.Clear(); // Limpia cantidad arriendo.
                    TextTAct.Clear(); // Limpia stock actual.
                }
                else if ((resta < numero1) || (resta == numero1)) // Si resta es menor o igual inicial.
                {
                    MessageBox.Show("Ingreso valido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje válido.
                    TextTAct.Text = resta.ToString(); // Asigna resta a stock actual.
                }
            }
        }
        private void TextCArr_TextChanged(object sender, EventArgs e) // Evento cambio texto cantidad arriendo.
        {
            if (TextCArr.Text.Trim() != "") // Si campo no está vacío.
            {
                TextVArr.TabStop = true; // Habilita tab en VArr.
                TextCArr.TabStop = false; // Deshabilita tab en CArr.
            }
            else // Si campo está vacío.
            {
                TextCArr.TabStop = false; // Deshabilita tab en CArr.
                TextCArr.TabStop = true; // Habilita tab en CArr.
            }
            HabBotIng(); // Actualiza estado botón Ingresar.
            HabBotLim(); // Actualiza estado botón Limpiar.
        }

        private void TextVArr_KeyPress(object sender, KeyPressEventArgs e) // Evento tecla presionada valor arriendo.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla es una letra.
            {
                e.Handled = true; // Suprime la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra advertencia.
            }
        }

        private void TextVArr_TextChanged(object sender, EventArgs e) // Evento cambio texto valor arriendo.
        {
            if (TextVArr.Text.Trim() != "") // Si campo no está vacío.
            {
                ButIng.TabStop = true; // Habilita tab en ButIng.
                TextCArr.TabStop = false; // Deshabilita tab en CArr.
            }
            else // Si campo está vacío.
            {
                ButIng.TabStop = false; // Deshabilita tab en ButIng.
                TextCArr.TabStop = true; // Habilita tab en CArr.
            }
            HabBotIng(); // Actualiza estado botón Ingresar.
            HabBotLim(); // Actualiza estado botón Limpiar.
        }

        private void ButIng_Click(object sender, EventArgs e) // Evento clic botón Ingresar.
        {
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Confirma acción.
            string Mensaje = string.Empty; // Inicializa mensaje vacío.
            Ent.Nombre = TextNom.Text; // Asigna nombre del producto.
            Ent.FInc = TextFech.Text; // Asigna fecha de incorporación.
            Ent.CInc = TextCIni.Text; // Asigna cantidad inicial.
            Ent.CArr = TextCArr.Text; // Asigna cantidad arrendada.
            Ent.CAct = TextCArr.Text; // Asigna cantidad actual. (Revisar lógica: ¿CAct no debería ser igual a TAct?)
            Ent.TAct = TextTAct.Text; // Asigna stock total actual.
            Ent.VArr = TextVArr.Text; // Asigna valor de arriendo.
            if (res == DialogResult.Yes) // Si la respuesta es "Sí".
            {
                Respuesta<bool> resultado = NProd.Ingresar(Ent); // Intenta ingresar el producto.

                if (resultado.estado) // Si el ingreso es exitoso.
                {
                    MessageBox.Show("Ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    ButLim.PerformClick(); // Simula clic en botón Limpiar.
                }
                else // Si el ingreso falla.
                {
                    MessageBox.Show(Mensaje); // Muestra el mensaje de error. (Mensaje está vacío, revisar lógica)
                }
            }
            else if (res == DialogResult.No) // Si la respuesta es "No".
            {
                ButVol.Focus(); // Enfoca el botón Volver.
            }
            else if (res == DialogResult.Cancel) // Si la respuesta es "Cancelar".
            {
                ButSal.Focus(); // Enfoca el botón Salir.
            }
            HabBotIng(); // Actualiza estado botón Ingresar.
            HabBotLim(); // Actualiza estado botón Limpiar.
        }

        private void ButLim_Click(object sender, EventArgs e) // Evento clic botón Limpiar.
        {
            TextNom.Clear(); // Limpia campo nombre.
            TextCIni.Clear(); // Limpia cantidad inicial.
            TextTAct.Clear(); // Limpia stock actual.
            TextCArr.Clear(); // Limpia cantidad arrendada.
            TextVArr.Clear(); // Limpia valor de arriendo.
            HabBotIng(); // Actualiza estado botón Ingresar.
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento clic botón Volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento clic botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }
    }
}


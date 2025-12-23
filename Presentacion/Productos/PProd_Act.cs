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


namespace Presentacion.Productos
{
    public partial class PProd_Act : Form
    {

        EProd Ent = new EProd(); // Instancia de la entidad Producto.
        NProd Neg = new NProd(); // Instancia de la capa de negocio Producto.

        public PProd_Act() // Constructor del formulario PProd_Act.
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PProd_Act_Load(object sender, EventArgs e) // Evento al cargar el formulario.
        {
            // No hay lógica implementada en este evento.
        }

        public void Validar() // Valida si hay cambios en los campos para habilitar/deshabilitar el botón Modificar.
        {
            // Habilita el botón Modificar si algún campo 'final' difiere de su valor 'inicial'.
            if ((TextNomF.Text.Trim() != TextNomI.Text.Trim()) || (TextCIniF.Text.Trim() != TextCIniI.Text.Trim()) || (TextCActF.Text.Trim() != TextCActI.Text.Trim()) || (TextCArrF.Text.Trim() != TextCArrI.Text.Trim()) || (TextVArrF.Text.Trim() != TextVArrI.Text.Trim()))
            {
                ButMod.Enabled = true;    // Habilita el botón Modificar.
                LabelNom.Enabled = false; // Deshabilita el Label de Nombre.
                Label3.Enabled = false;   // Deshabilita Label3.
                LabelCanI.Enabled = false; // Deshabilita el Label de Cantidad Inicial.
                LabeCAct.Enabled = false; // Deshabilita el Label de Cantidad Actual.
                LabelCArr.Enabled = false; // Deshabilita el Label de Cantidad a Arrendar.
                LabelVArr.Enabled = false; // Deshabilita el Label de Valor de Arriendo.
            }
            else // Si no hay cambios en los campos.
            {
                ButMod.Enabled = false;   // Deshabilita el botón Modificar.
                LabelNom.Enabled = true;  // Habilita el Label de Nombre.
                Label3.Enabled = true;    // Habilita Label3.
                LabelCanI.Enabled = true; // Habilita el Label de Cantidad Inicial.
                LabeCAct.Enabled = true;  // Habilita el Label de Cantidad Actual.
                LabelCArr.Enabled = true; // Habilita el Label de Cantidad a Arrendar.
                LabelVArr.Enabled = true; // Habilita el Label de Valor de Arriendo.
            }
        }

        public void CalVal() // Calcula y valida los valores de cantidad.
        {
            // Si los campos de cantidad inicial final y cantidad a arrendar final no están vacíos.
            if ((TextCIniF.Text.Trim() != "") && (TextCArrF.Text.Trim() != ""))
            {
                int numero1 = int.Parse(TextCActF.Text); // Obtiene la cantidad actual final.
                int numero2 = int.Parse(TextCArrF.Text); // Obtiene la cantidad a arrendar final.
                int resta = numero1 - numero2; // Calcula la resta.
                if ((numero1 == 0) || (numero1 < numero2)) // Si la cantidad actual es cero o menor que la cantidad a arrendar.
                {
                    MessageBox.Show("La cantidad a arrendar no puede ser mayor a la cantidad inicial.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de error.
                    TextCArrF.Clear(); // Limpia el campo de cantidad a arrendar final.
                    TextTActF.Clear(); // Limpia el campo de total actual final.
                }
                else if ((resta < numero1) || (resta == numero1)) // Si la resta es menor o igual a la cantidad inicial.
                {
                    MessageBox.Show("Ingreso valido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de validación.
                    TextTActF.Text = resta.ToString(); // Asigna el resultado de la resta al campo total actual final.
                }
            }
        }

        private void LabelNom_Click(object sender, EventArgs e) // Evento clic en el Label de Nombre.
        {
            TextNomF.Enabled = true; // Habilita el campo de texto de nombre final.
        }

        private void TextNomF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de nombre final.
        {
            TextNomF.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextNomF.Text); // Convierte a formato de título.
            TextNomF.SelectionStart = TextNomF.Text.Length; // Mueve el cursor al final del texto.
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelCanI_Click(object sender, EventArgs e) // Evento clic en el Label de Cantidad Inicial.
        {
            TextCIniF.Enabled = true; // Habilita el campo de texto de cantidad inicial final.
        }

        private void TextCIniF_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo cantidad inicial final.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla presionada es una letra.
            {
                e.Handled = true; // Suprime la entrada de la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra mensaje de advertencia.
            }
        }

        private void TextCIniF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo cantidad inicial final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabeCAct_Click(object sender, EventArgs e) // Evento clic en el Label de Cantidad Actual.
        {
            TextCActF.Enabled = true; // Habilita el campo de texto de cantidad actual final.
        }

        private void TextCActF_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo cantidad actual final.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla presionada es una letra.
            {
                e.Handled = true; // Suprime la entrada de la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra mensaje de advertencia.
            }
        }

        private void TextCActF_Leave(object sender, EventArgs e) // Evento al salir del campo cantidad actual final.
        {
            CalVal(); // Llama a la función de cálculo y validación.
        }

        private void TextCActF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo cantidad actual final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelCArr_Click(object sender, EventArgs e) // Evento clic en el Label de Cantidad a Arrendar.
        {
            TextCArrF.Enabled = true; // Habilita el campo de texto de cantidad a arrendar final.
        }

        private void TextCArrF_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo cantidad a arrendar final.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla presionada es una letra.
            {
                e.Handled = true; // Suprime la entrada de la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra mensaje de advertencia.
            }
        }

        private void TextCArrF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo cantidad a arrendar final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelVArr_Click(object sender, EventArgs e) // Evento clic en el Label de Valor de Arriendo.
        {
            TextVArrF.Enabled = true; // Habilita el campo de texto de valor de arriendo final.
        }

        private void TextVArrF_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo valor de arriendo final.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla presionada es una letra.
            {
                e.Handled = true; // Suprime la entrada de la tecla.
                MessageBox.Show("solo se permiten numeros"); // Muestra mensaje de advertencia.
            }
        }

        private void TextVArrF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo valor de arriendo final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        public void Cambio() // Restablece el estado de los campos de texto y labels después de una operación.
        {
            LabelNom.Enabled = true;  // Habilita el Label de Nombre.
            Label3.Enabled = true;    // Habilita Label3.
            LabelCanI.Enabled = true; // Habilita el Label de Cantidad Inicial.
            LabeCAct.Enabled = true;  // Habilita el Label de Cantidad Actual.
            LabelCArr.Enabled = true; // Habilita el Label de Cantidad a Arrendar.
            LabelVArr.Enabled = true; // Habilita el Label de Valor de Arriendo.
            TextNomF.Enabled = false; // Deshabilita el campo de nombre final.
            TextCIniF.Enabled = false; // Deshabilita el campo de cantidad inicial final.
            TextCActF.Enabled = false; // Deshabilita el campo de cantidad actual final.
            TextCArrF.Enabled = false; // Deshabilita el campo de cantidad a arrendar final.
            TextVArrF.Enabled = false; // Deshabilita el campo de valor de arriendo final.
            ButMod.Enabled = false;   // Deshabilita el botón Modificar.
        }

        private void ButMod_Click(object sender, EventArgs e) // Evento clic en el botón Modificar.
        {
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Pide confirmación.
            Ent.IdProd = Convert.ToInt32(TextBox1.Text); // Asigna el ID del producto.
            Ent.Nombre = TextNomF.Text;                 // Asigna el nombre final.
            Ent.FInc = TextFecIni.Text;                 // Asigna la fecha de incorporación.
            Ent.CInc = TextCIniF.Text;                 // Asigna la cantidad inicial final.
            Ent.CArr = TextCArrF.Text;                 // Asigna la cantidad a arrendar final.
            Ent.CAct = TextCActF.Text;                 // Asigna la cantidad actual final.
            Ent.TAct = TextTActF.Text;                 // Asigna el total actual final.
            Ent.VArr = TextVArrF.Text;                 // Asigna el valor de arriendo final.
            if (res == DialogResult.Yes) // Si la respuesta es "Sí".
            {
                Respuesta<bool> resultado = NProd.Actualizar(Ent); // Intenta actualizar el producto.
                if (resultado.estado) // Si la actualización es exitosa.
                {
                    MessageBox.Show("Actualización fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    TextNomI.Text = TextNomF.Text;     // Actualiza el nombre inicial con el final.
                    TextCIniI.Text = TextCIniF.Text;     // Actualiza la cantidad inicial inicial con la final.
                    TextCActI.Text = TextCActF.Text;     // Actualiza la cantidad actual inicial con la final.
                    TextCArrI.Text = TextCArrF.Text;     // Actualiza la cantidad a arrendar inicial con la final.
                    TextTActI.Text = TextTActF.Text;     // Actualiza el total actual inicial con el final.
                    TextVArrI.Text = TextVArrF.Text;     // Actualiza el valor de arriendo inicial con el final.
                }
                else // Si la actualización falla.
                {
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de información.
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
            Cambio();  // Restablece el estado de los campos y labels.
            Validar(); // Vuelve a validar el estado de los botones.
        }

        private void button1_Click(object sender, EventArgs e) // Evento clic en el botón "Cancelar Cambios".
        {
            TextNomF.Text = TextNomI.Text;     // Restaura el nombre final al inicial.
            TextCIniF.Text = TextCIniI.Text;     // Restaura la cantidad inicial final al inicial.
            TextCActF.Text = TextCActI.Text;     // Restaura la cantidad actual final al inicial.
            TextCArrF.Text = TextCArrI.Text;     // Restaura la cantidad a arrendar final al inicial.
            TextTActF.Text = TextTActI.Text;     // Restaura el total actual final al inicial.
            TextVArrF.Text = TextVArrI.Text;     // Restaura el valor de arriendo final al inicial.
            Cambio(); // Restablece el estado de los campos y labels.
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento clic en el botón Volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento clic en el botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }
    }
}


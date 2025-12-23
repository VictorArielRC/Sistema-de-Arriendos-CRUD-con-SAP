// Importa dependencias.
using Entidad;
// Importa dependencias.
using Negocio;
// Importa dependencias.
using Presentacion.AAClases;
// Importa dependencias.
using System;
// Importa dependencias.
using System.Data;
// Importa dependencias.
using System.Windows.Forms;
// Importa dependencias.
using Application = System.Windows.Forms.Application;


namespace Presentacion.Cliente
{
    public partial class PCli_Ing : Form
    {
        ValidaRut Rut = new ValidaRut(); // Instancia validador de RUT
        ECliente Ent = new ECliente(); // Crea un nuevo cliente
        // NCliente Neg = new NCliente();
        NLocCom NegCom = new NLocCom(); // Instancia la lógica de comuna
        NLocPro NegPro = new NLocPro(); // Instancia la lógica de provincia
        NLocReg NegReg = new NLocReg(); // Instancia la lógica de región

        public PCli_Ing()
        {
            InitializeComponent();
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PCli_Ing_Load(object sender, EventArgs e)
        {

        }

        public void LleComReg() // Carga el ComboBox de regiones.
        {
            CBReg.DisplayMember = "Nombre";   // Muestra el nombre de la región.
            CBReg.ValueMember = "IdReg";     // Usa el ID de la región como valor.
            CBReg.DataSource = NegReg.Listar(); // Obtiene la lista de regiones.
        }

        private void CargaCBPro() // Carga el ComboBox de provincias.
        {
            int IdReg = Convert.ToInt32(CBReg.SelectedValue); // Obtiene el ID de la región seleccionada.
            DataTable dt = NegPro.Filtrar(IdReg);             // Filtra las provincias por región.
            CBPro.DisplayMember = "Nombre";                   // Muestra el nombre de la provincia.
            CBPro.ValueMember = "IdPro";                     // Usa el ID de la provincia como valor.
            CBPro.DataSource = dt;                          // Asigna los datos al ComboBox.
        }

        private void CargaCBCom() // Carga el ComboBox de comunas.
        {
            int IdPro = Convert.ToInt32(CBPro.SelectedValue); // Obtiene el ID de la provincia seleccionada.
            DataTable dt = NegCom.Filtrar(IdPro);             // Filtra las comunas por provincia.
            CBCom.DisplayMember = "Nombre";                   // Muestra el nombre de la comuna.
            CBCom.ValueMember = "IdCom";                     // Usa el ID de la comuna como valor.
            CBCom.DataSource = dt;                          // Asigna los datos al ComboBox.
        }

        public void HabBotIng() // Habilita o deshabilita el botón de Ingresar.
        {
            // Habilita si todos los campos están llenos.
            if ((TextRut.Text.Trim() != "") && (TextNom.Text.Trim() != "") && (CBReg.Text.Trim() != "") && (CBPro.Text.Trim() != "") && (CBCom.Text.Trim() != "") && (TextDire.Text.Trim() != "") && (TextTel.Text.Trim() != "") && (TextEma.Text.Trim() != "") && (TextGir.Text.Trim() != ""))
            {
                ButIng.Enabled = true; // Habilita el botón.
            }
            else // Si algún campo está vacío.
            {
                ButIng.Enabled = false; // Deshabilita el botón.
            }
        }
        public void HabBotLim() // Habilita o deshabilita el botón de Limpiar.
        {
            // Habilita si al menos un campo tiene contenido.
            if ((TextRut.Text.Trim() != "") || (TextNom.Text.Trim() != "") || (CBReg.Text.Trim() != "") || (CBPro.Text.Trim() != "") || (CBCom.Text.Trim() != "") || (TextDire.Text.Trim() != "") || (TextTel.Text.Trim() != "") || (TextEma.Text.Trim() != "") || (TextGir.Text.Trim() != ""))
            {
                ButLim.Enabled = true; // Habilita el botón.
            }
            else // Si todos los campos están vacíos.
            {
                ButLim.Enabled = false; // Deshabilita el botón.
            }
        }

        private void TextRut_Leave(object sender, EventArgs e) // Evento al salir del campo RUT.
        {
            Ent.Rut = TextRut.Text;         // Asigna el texto del RUT a la entidad.
            bool respuesta = false;         // Variable para la respuesta de validación.
            respuesta = Rut.validarRut(TextRut.Text); // Valida el formato del RUT.

            if (respuesta == false) // Si el RUT es inválido.
            {
                TextRut.Clear(); // Limpia el campo de texto del RUT.
                MessageBox.Show("Rut Malo", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
            }
            else // Si el RUT es válido.
            {
                MessageBox.Show("Rut Bueno", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                HabBotLim(); // Actualiza estado del botón Limpiar.
                HabBotIng(); // Actualiza estado del botón Ingresar.
            }
        }

        private void TextRut_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto del RUT.
        {
            if (TextRut.Text.Trim() != "") // Si el campo RUT no está vacío.
            {
                TextNom.TabStop = true;  // Habilita tabulación a Nombre.
                TextRut.TabStop = false; // Deshabilita tabulación a RUT.
            }
            else // Si el campo RUT está vacío.
            {
                TextNom.TabStop = false; // Deshabilita tabulación a Nombre.
                TextRut.TabStop = true;  // Habilita tabulación a RUT.
            }
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void TextNom_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar tecla en Nombre.
        {
            if (char.IsDigit(e.KeyChar)) // Si la tecla presionada es un dígito.
            {
                e.Handled = true; // Suprime la entrada del carácter.
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra advertencia.
            }
        }

        private void TextNom_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto del Nombre.
        {
            TextNom.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextNom.Text); // Convierte a formato de título.
            TextNom.SelectionStart = TextNom.Text.Length; // Mueve el cursor al final del texto.
            if (TextNom.Text.Trim() != "") // Si el campo Nombre no está vacío.
            {
                CBReg.TabStop = true;  // Habilita tabulación a Región.
                TextNom.TabStop = false; // Deshabilita tabulación a Nombre.
                LleComReg();           // Carga las regiones.
            }
            else // Si el campo Nombre está vacío.
            {
                CBReg.TabStop = false; // Deshabilita tabulación a Región.
                TextNom.TabStop = true;  // Habilita tabulación a Nombre.
            }
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void CBReg_SelectedIndexChanged(object sender, EventArgs e) // Evento al cambiar la selección de Región.
        {
            if (CBReg.Text.Trim() != "") // Si se ha seleccionado una región.
            {
                CBPro.TabStop = true;  // Habilita tabulación a Provincia.
                CBReg.TabStop = false; // Deshabilita tabulación a Región.
                CargaCBPro();          // Carga las provincias.
            }
            else // Si no se ha seleccionado una región.
            {
                CBReg.TabStop = false; // Deshabilita tabulación a Región.
                CBPro.TabStop = true;  // Habilita tabulación a Provincia.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void CBPro_SelectedIndexChanged(object sender, EventArgs e) // Evento al cambiar la selección de Provincia.
        {
            if (CBPro.Text.Trim() != "") // Si se ha seleccionado una provincia.
            {
                CBCom.TabStop = true;  // Habilita tabulación a Comuna.
                CBPro.TabStop = false; // Deshabilita tabulación a Provincia.
                CargaCBCom();          // Carga las comunas.
            }
            else // Si no se ha seleccionado una provincia.
            {
                CBPro.TabStop = false; // Deshabilita tabulación a Provincia.
                CBCom.TabStop = true;  // Habilita tabulación a Comuna.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void CBCom_SelectedIndexChanged(object sender, EventArgs e) // Evento al cambiar la selección de Comuna.
        {
            if (CBCom.Text.Trim() != "") // Si se ha seleccionado una comuna.
            {
                TextDire.TabStop = true; // Habilita tabulación a Dirección.
                CBCom.TabStop = false;   // Deshabilita tabulación a Comuna.
            }
            else // Si no se ha seleccionado una comuna.
            {
                TextDire.TabStop = false; // Deshabilita tabulación a Dirección.
                CBCom.TabStop = true;    // Habilita tabulación a Comuna.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void TextDire_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto de Dirección.
        {
            if (TextDire.Text.Trim() != "") // Si el campo Dirección no está vacío.
            {
                TextTel.TabStop = true;  // Habilita tabulación a Teléfono.
                TextDire.TabStop = false; // Deshabilita tabulación a Dirección.
            }
            else // Si el campo Dirección está vacío.
            {
                TextTel.TabStop = false; // Deshabilita tabulación a Teléfono.
                TextDire.TabStop = true;  // Habilita tabulación a Dirección.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void TextTel_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto de Teléfono.
        {
            if (TextTel.Text.Trim() != "") // Si el campo Teléfono no está vacío.
            {
                TextEma.TabStop = true;  // Habilita tabulación a Email.
                TextTel.TabStop = false; // Deshabilita tabulación a Teléfono.
            }
            else // Si el campo Teléfono está vacío.
            {
                TextEma.TabStop = false; // Deshabilita tabulación a Email.
                TextTel.TabStop = true;  // Habilita tabulación a Teléfono.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void TextEma_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto de Email.
        {
            if (TextEma.Text.Trim() != "") // Si el campo Email no está vacío.
            {
                TextGir.TabStop = true;  // Habilita tabulación a Giro.
                TextEma.TabStop = false; // Deshabilita tabulación a Email.
            }
            else // Si el campo Email está vacío.
            {
                TextGir.TabStop = false; // Deshabilita tabulación a Giro.
                TextEma.TabStop = true;  // Habilita tabulación a Email.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void TextGir_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto de Giro.
        {
            if (TextGir.Text.Trim() != "") // Si el campo Giro no está vacío.
            {
                ButIng.TabStop = true;   // Habilita tabulación a Ingresar.
                TextGir.TabStop = false; // Deshabilita tabulación a Giro.
            }
            else // Si el campo Giro está vacío.
            {
                ButIng.TabStop = false;  // Deshabilita tabulación a Ingresar.
                TextGir.TabStop = true;  // Habilita tabulación a Giro.
            }
            HabBotLim(); // Actualiza estado del botón Limpiar.
            HabBotIng(); // Actualiza estado del botón Ingresar.
        }

        private void ButLim_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Limpiar.
        {
            TextRut.Clear();     // Limpia el campo RUT.
            TextNom.Clear();     // Limpia el campo Nombre.
            TextDire.Clear();    // Limpia el campo Dirección.
            TextTel.Clear();     // Limpia el campo Teléfono.
            TextEma.Clear();     // Limpia el campo Email.
            TextGir.Clear();     // Limpia el campo Giro.
            CBReg.DataSource = null; // Limpia el ComboBox de Regiones.
            CBPro.DataSource = null; // Limpia el ComboBox de Provincias.
            CBCom.DataSource = null; // Limpia el ComboBox de Comunas.
            HabBotIng();         // Actualiza el estado del botón Ingresar.
        }

        private void ButIng_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Ingresar.
        {
            // Muestra un mensaje de confirmación al usuario.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            string Mensaje = string.Empty; // Variable para almacenar mensajes de error.
            Ent.Nombre = TextNom.Text;     // Asigna el nombre a la entidad.
            Ent.Rut = TextRut.Text;        // Asigna el RUT a la entidad.
            Ent.IdCom = Convert.ToInt32(CBCom.SelectedValue); // Asigna el ID de la comuna a la entidad.
            Ent.Direccion = TextDire.Text; // Asigna la dirección a la entidad.
            Ent.Tel = TextTel.Text;        // Asigna el teléfono a la entidad.
            Ent.Email = TextEma.Text;      // Asigna el email a la entidad.
            Ent.Giro = TextGir.Text;       // Asigna el giro a la entidad.

            if (res == DialogResult.Yes) // Si el usuario confirma la acción.
            {
                Respuesta<bool> resultado = NCliente.Ingresar(Ent); // Intenta ingresar el cliente.

                if (resultado.estado) // Si el ingreso fue exitoso.
                {
                    MessageBox.Show("Ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    ButLim.PerformClick(); // Simula un clic en el botón Limpiar.
                }
                else // Si el ingreso falló.
                {
                    MessageBox.Show(Mensaje); // Muestra el mensaje de error.
                }
            }
            else if (res == DialogResult.No) // Si el usuario elige "No".
            {
                ButVol.Focus(); // Enfoca el botón "Volver".
            }
            else if (res == DialogResult.Cancel) // Si el usuario elige "Cancelar".
            {
                ButSal.Focus(); // Enfoca el botón "Salir".
            }
            HabBotIng(); // Actualiza el estado del botón Ingresar.
            HabBotLim(); // Actualiza el estado del botón Limpiar.
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }

    }
}


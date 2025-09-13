// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using Presentacion.AAClases;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Data;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using Application = System.Windows.Forms.Application;


namespace Presentacion.Proveedor
{
    public partial class PProv_Act : Form
    {
        public PProv_Act()
        {
            InitializeComponent();
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        ValidaRut Rut = new ValidaRut(); // Instancia para la validación de RUT.
        EProv Ent = new EProv();         // Instancia de la entidad Proveedor.
        NProv Neg = new NProv();         // Instancia de la capa de negocio Proveedor.
        NLocCom NegCom = new NLocCom();  // Instancia de la capa de negocio para Localidades (Comunas).
        NLocPro NegPro = new NLocPro();  // Instancia de la capa de negocio para Localidades (Provincias).
        NLocReg NegReg = new NLocReg();  // Instancia de la capa de negocio para Localidades (Regiones).

        private void PProv_Act_Load(object sender, EventArgs e) // Evento al cargar el formulario.
        {
            // No hay lógica implementada en este evento.
        }

        public void LleComReg() // Carga las regiones en el ComboBox de Regiones.
        {
            CBReg.DisplayMember = "Nombre"; // Establece la propiedad a mostrar en el ComboBox.
            CBReg.ValueMember = "IdReg";    // Establece el valor asociado en el ComboBox.
            CBReg.DataSource = NegReg.Listar(); // Asigna la lista de regiones como origen de datos.
        }

        private void CargaCBPro() // Carga las provincias según la región seleccionada.
        {
            int IdReg = Convert.ToInt32(CBReg.SelectedValue); // Obtiene el ID de la región seleccionada.
            DataTable dt = NegPro.Filtrar(IdReg);             // Filtra las provincias por ID de región.
            CBPro.DisplayMember = "Nombre";                   // Establece la propiedad a mostrar en el ComboBox.
            CBPro.ValueMember = "IdPro";                      // Establece el valor asociado en el ComboBox.
            CBPro.DataSource = dt;                            // Asigna el DataTable de provincias como origen de datos.
        }

        private void CargaCBCom() // Carga las comunas según la provincia seleccionada.
        {
            int IdPro = Convert.ToInt32(CBPro.SelectedValue); // Obtiene el ID de la provincia seleccionada.
            DataTable dt = NegCom.Filtrar(IdPro);             // Filtra las comunas por ID de provincia.
            CBCom.DisplayMember = "Nombre";                   // Establece la propiedad a mostrar en el ComboBox.
            CBCom.ValueMember = "IdCom";                      // Establece el valor asociado en el ComboBox.
            CBCom.DataSource = dt;                            // Asigna el DataTable de comunas como origen de datos.
        }

        public void Validar() // Valida si hay cambios en los campos para habilitar/deshabilitar el botón Modificar.
        {
            // Compara los valores 'finales' con los 'iniciales' para determinar si ha habido cambios.
            if ((TextNomF.Text.Trim() != TextNomI.Text.Trim()) || (TextRutF.Text.Trim() != labelRtI.Text.Trim()) || (TextComIdeF.Text.Trim() != TextComIdeI.Text.Trim()) || (TextComI.Text.Trim() != TextComF.Text.Trim()) || (TextDireF.Text.Trim() != TextDireI.Text.Trim()) || (TextGirF.Text.Trim() != TextGirI.Text.Trim()) || (TextDesF.Text.Trim() != TextDesI.Text.Trim()) || (TextTelF.Text.Trim() != TextTelI.Text.Trim()) || (TextEmaF.Text.Trim() != TextEmaI.Text.Trim()))
            {
                ButMod.Enabled = true;    // Habilita el botón Modificar.
                LabelRut.Enabled = false; // Deshabilita el Label del RUT.
                LabelNom.Enabled = false; // Deshabilita el Label de Nombre.
                labelActCom.Enabled = false; // Deshabilita el Label para activar Comunas.
                LabelDir.Enabled = false; // Deshabilita el Label de Dirección.
                LabelTel.Enabled = false; // Deshabilita el Label de Teléfono.
                LabelEma.Enabled = false; // Deshabilita el Label de Email.
                LabelGir.Enabled = false; // Deshabilita el Label de Giro.
                LabelDes.Enabled = false; // Deshabilita el Label de Descripción.
            }
            else // Si no hay cambios en los campos.
            {
                ButMod.Enabled = false;   // Deshabilita el botón Modificar.
                LabelRut.Enabled = true;  // Habilita el Label del RUT.
                LabelNom.Enabled = true;  // Habilita el Label de Nombre.
                labelActCom.Enabled = true; // Habilita el Label para activar Comunas.
                LabelDir.Enabled = true;  // Habilita el Label de Dirección.
                LabelTel.Enabled = true;  // Habilita el Label de Teléfono.
                LabelEma.Enabled = true;  // Habilita el Label de Email.
                LabelGir.Enabled = true;  // Habilita el Label de Giro.
                LabelDes.Enabled = true;  // Habilita el Label de Descripción.
            }
        }

        private void LabelRut_Click(object sender, EventArgs e) // Evento clic en el Label del RUT.
        {
            TextRutF.Enabled = true; // Habilita el campo de texto del RUT final.
        }

        private void TextRutF_Leave(object sender, EventArgs e) // Evento al salir del campo de texto del RUT final.
        {
            Ent.Rut = TextRutF.Text; // Asigna el RUT al objeto de entidad.
            bool respuesta = false;
            respuesta = Rut.validarRut(TextRutF.Text); // Valida el formato del RUT.
            if (respuesta == false) // Si el RUT es inválido.
            {
                TextRutF.Clear(); // Limpia el campo del RUT.
                MessageBox.Show("Rut Malo", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
            }
            else // Si el RUT es válido.
            {
                MessageBox.Show("Rut Bueno", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                Validar(); // Llama a la función de validación para actualizar el estado del botón.
            }
        }

        private void LabelNom_Click(object sender, EventArgs e) // Evento clic en el Label de Nombre.
        {
            TextNomF.Enabled = true; // Habilita el campo de texto de nombre final.
        }

        private void TextNomF_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo de nombre final.
        {
            if (char.IsNumber(e.KeyChar)) // Si la tecla presionada es un número.
            {
                e.Handled = true; // Suprime la entrada de la tecla.
                MessageBox.Show("solo se permiten letras"); // Muestra mensaje de advertencia.
            }
        }

        private void TextNomF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de nombre final.
        {
            TextNomF.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextNomF.Text); // Convierte a formato de título.
            TextNomF.SelectionStart = TextNomF.Text.Length; // Mueve el cursor al final del texto.
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelTel_Click(object sender, EventArgs e) // Evento clic en el Label de Teléfono.
        {
            TextTelF.Enabled = true; // Habilita el campo de texto de teléfono final.
        }

        private void TextTelF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de teléfono final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void labelActCom_Click(object sender, EventArgs e) // Evento clic en el Label para activar la selección de Comuna.
        {
            LleComReg();              // Carga las regiones.
            labelActReg.Enabled = true; // Habilita el Label de Región.
            CBReg.Enabled = true;     // Habilita el ComboBox de Regiones.
            labelAcPro.Enabled = true; // Habilita el Label de Provincia.
            CBPro.Enabled = true;     // Habilita el ComboBox de Provincias.
            LabelAcCom.Enabled = true; // Habilita el Label de Comuna.
            CBCom.Enabled = true;     // Habilita el ComboBox de Comunas.
        }

        private void CBReg_SelectedIndexChanged(object sender, EventArgs e) // Evento cuando cambia la selección en el ComboBox de Regiones.
        {
            CargaCBPro(); // Carga las provincias según la región seleccionada.
        }

        private void CBPro_SelectedIndexChanged(object sender, EventArgs e) // Evento cuando cambia la selección en el ComboBox de Provincias.
        {
            CargaCBCom(); // Carga las comunas según la provincia seleccionada.
        }

        private void CBCom_SelectedIndexChanged(object sender, EventArgs e) // Evento cuando cambia la selección en el ComboBox de Comunas.
        {
            TextComF.Text = CBCom.Text; // Asigna el texto de la comuna seleccionada al campo de comuna final.
            TextComIdeF.Text = Convert.ToString(CBCom.SelectedValue); // Asigna el ID de la comuna al campo de ID de comuna final.
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelDir_Click(object sender, EventArgs e) // Evento clic en el Label de Dirección.
        {
            TextDireF.Enabled = true; // Habilita el campo de texto de dirección final.
        }

        private void TextDireF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de dirección final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelEma_Click(object sender, EventArgs e) // Evento clic en el Label de Email.
        {
            TextEmaF.Enabled = true; // Habilita el campo de texto de email final.
        }

        private void TextEmaF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de email final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelGir_Click(object sender, EventArgs e) // Evento clic en el Label de Giro.
        {
            TextGirF.Enabled = true; // Habilita el campo de texto de giro final.
        }

        private void TextGirF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de giro final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        private void LabelDes_Click(object sender, EventArgs e) // Evento clic en el Label de Descripción.
        {
            TextDesF.Enabled = true; // Habilita el campo de texto de descripción final.
        }

        private void TextDesF_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de descripción final.
        {
            Validar(); // Llama a la función de validación para actualizar el estado del botón.
        }

        public void Cambio() // Restablece el estado de los campos de texto y labels después de una operación.
        {
            LabelRut.Enabled = true;  // Habilita el Label del RUT.
            LabelNom.Enabled = true;  // Habilita el Label de Nombre.
            labelActCom.Enabled = true; // Habilita el Label para activar Comunas.
            LabelDir.Enabled = true;  // Habilita el Label de Dirección.
            LabelTel.Enabled = true;  // Habilita el Label de Teléfono.
            LabelEma.Enabled = true;  // Habilita el Label de Email.
            LabelGir.Enabled = true;  // Habilita el Label de Giro.
            LabelDes.Enabled = true;  // Habilita el Label de Descripción.
            TextNomF.Enabled = false; // Deshabilita el campo de nombre final.
            TextRutF.Enabled = false; // Deshabilita el campo de RUT final.
            TextDireF.Enabled = false; // Deshabilita el campo de dirección final.
            TextTelF.Enabled = false; // Deshabilita el campo de teléfono final.
            TextEmaF.Enabled = false; // Deshabilita el campo de email final.
            TextGirF.Enabled = false; // Deshabilita el campo de giro final.
            TextDesF.Enabled = false; // Deshabilita el campo de descripción final.
            ButMod.Enabled = false;   // Deshabilita el botón Modificar.
            labelActReg.Enabled = false; // Deshabilita el Label de Región.
            CBReg.Enabled = false;     // Deshabilita el ComboBox de Regiones.
            labelAcPro.Enabled = false; // Deshabilita el Label de Provincia.
            CBPro.Enabled = false;     // Deshabilita el ComboBox de Provincias.
            LabelAcCom.Enabled = false; // Deshabilita el Label de Comuna.
            CBCom.Enabled = false;     // Deshabilita el ComboBox de Comunas.
        }

        private void ButMod_Click(object sender, EventArgs e) // Evento clic en el botón Modificar.
        {
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Pide confirmación.
            string Mensaje = string.Empty; // Variable para almacenar mensajes (no utilizada en este bloque).
            Ent.IdProv = Convert.ToInt32(TextIdCli.Text); // Asigna el ID del proveedor.
            Ent.Nombre = TextNomF.Text;                 // Asigna el nombre final.
            Ent.Rut = TextRutF.Text;                     // Asigna el RUT final.
            Ent.IdCom = Convert.ToInt32(TextComIdeF.Text); // Asigna el ID de la comuna final.
            Ent.Direccion = TextDireF.Text;             // Asigna la dirección final.
            Ent.Tel = TextTelF.Text;                     // Asigna el teléfono final.
            Ent.Email = TextEmaF.Text;                 // Asigna el email final.
            Ent.Giro = TextGirF.Text;                     // Asigna el giro final.
            Ent.Descr = TextDesF.Text;                 // Asigna la descripción final.
            if (res == DialogResult.Yes) // Si la respuesta es "Sí".
            {
                Respuesta<bool> resultado = NProv.Actualizar(Ent); // Intenta actualizar el proveedor.
                if (resultado.estado) // Si la actualización es exitosa.
                {
                    MessageBox.Show("Actualización fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    TextNomI.Text = TextNomF.Text;         // Actualiza el nombre inicial con el final.
                    labelRtI.Text = TextRutF.Text;         // Actualiza el RUT inicial con el final.
                    TextComIdeI.Text = TextComIdeF.Text;     // Actualiza el ID de comuna inicial con el final.
                    TextComI.Text = TextComF.Text;         // Actualiza la comuna inicial con la final.
                    TextDireI.Text = TextDireF.Text;         // Actualiza la dirección inicial con la final.
                    TextTelI.Text = TextTelF.Text;         // Actualiza el teléfono inicial con el final.
                    TextEmaI.Text = TextEmaF.Text;         // Actualiza el email inicial con el final.
                    TextGirI.Text = TextGirF.Text;         // Actualiza el giro inicial con el final.
                    TextDesI.Text = TextDesF.Text;         // Actualiza la descripción inicial con la final.
                }
                else // Si la actualización falla.
                {
                    MessageBox.Show(Mensaje); // Muestra el mensaje (que está vacío en este caso).
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

        private void ButAnu_Click(object sender, EventArgs e) // Evento clic en el botón "Anular Cambios".
        {
            TextNomF.Text = TextNomI.Text;     // Restaura el nombre final al inicial.
            TextRutF.Text = labelRtI.Text;     // Restaura el RUT final al inicial.
            TextComIdeF.Text = TextComIdeI.Text; // Restaura el ID de comuna final al inicial.
            TextComF.Text = TextComI.Text;     // Restaura la comuna final al inicial.
            TextDireF.Text = TextDireI.Text;     // Restaura la dirección final al inicial.
            TextTelF.Text = TextTelI.Text;     // Restaura el teléfono final al inicial.
            TextEmaF.Text = TextEmaI.Text;     // Restaura el email final al inicial.
            TextGirF.Text = TextGirI.Text;     // Restaura el giro final al inicial.
            TextDesF.Text = TextDesI.Text;     // Restaura la descripción final al inicial.
            Cambio(); // Restablece el estado de los campos y labels.
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento clic en el botón Volver.
        {
            PProv_Con ver = new PProv_Con(); // Crea una nueva instancia del formulario de consulta de proveedores.
            ver.ButMod.Visible = true;       // Hace visible el botón Modificar en el formulario PProv_Con (puede ser redundante si ya lo es).
            this.Close();                    // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento clic en el botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }
    }
}
using Entidad;
// Usa las clases de datos.
using Negocio;
// Usa las reglas de negocio.
using Presentacion.AAClases;
// Clases de ayuda visual.
using System;
// Funciones básicas del sistema.
using System.Data;
// Para manejar tablas de datos.
using System.Windows.Forms;
// Para crear ventanas y botones.
using Application = System.Windows.Forms.Application;
// Un alias para el programa.

namespace Presentacion.Cliente
// Carpeta para formularios de cliente.
{
    public partial class PCli_Act : Form
    // Se ejecuta al abrir la ventana.
    {
        public PCli_Act()
        // Se ejecuta al abrir la ventana.
        {
            InitializeComponent(); // Dibuja los controles en pantalla
        }

        ValidaRut Rut = new ValidaRut(); // Herramienta para validar RUT
        ECliente Ent = new ECliente(); // Guarda datos del cliente
        NCliente Neg = new NCliente(); // Lógica para guardar clientes
        NLocCom NegCom = new NLocCom(); // Lógica para buscar comunas
        NLocPro NegPro = new NLocPro(); // Lógica para buscar provincias
        NLocReg NegReg = new NLocReg(); // Lógica para buscar regiones

        private void PCli_Act_Load(object sender, EventArgs e)
        // Al cargar la ventana.
        {
         
        }

        public void LleComReg()
        // Rellena la lista de regiones.
        {
            CBReg.DisplayMember = "Nombre"; // Muestra el nombre de la región
            CBReg.ValueMember = "IdReg"; // Guarda el ID de la región
            CBReg.DataSource = NegReg.Listar(); // Carga las regiones de la base
        }

        private void CargaCBPro()
        // Carga las provincias según región.
        {
            int IdReg = Convert.ToInt32(CBReg.SelectedValue); // Obtiene el ID de la región
            DataTable dt = NegPro.Filtrar(IdReg); // Busca provincias por región
            CBPro.DisplayMember = "Nombre"; // Muestra el nombre de provincia
            CBPro.ValueMember = "IdPro"; // Guarda el ID de la provincia
            CBPro.DataSource = dt; // Carga las provincias encontradas
        }

        private void CargaCBCom()
        // Carga las comunas según provincia.
        {
            int IdPro = Convert.ToInt32(CBPro.SelectedValue); // Obtiene el ID de la provincia
            DataTable dt = NegCom.Filtrar(IdPro); // Busca comunas por provincia
            CBCom.DisplayMember = "Nombre"; // Muestra el nombre de comuna
            CBCom.ValueMember = "IdCom"; // Guarda el ID de la comuna
            CBCom.DataSource = dt; // Carga las comunas encontradas
        }

        public void Validar()
        // Comprueba si hay cambios.
        {
            if ((TextNomF.Text.Trim() != TextNomI.Text.Trim()) || (TextRutF.Text.Trim() != labelRtI.Text.Trim()) || (TextComIdeF.Text.Trim() != TextComIdeI.Text.Trim()) || (TextComI.Text.Trim() != TextComF.Text.Trim()) || (TextDireF.Text.Trim() != TextDireI.Text.Trim()) || (TextGirF.Text.Trim() != TextGirI.Text.Trim()) || (TextTelF.Text.Trim() != TextTelI.Text.Trim()) || (TextEmaF.Text.Trim() != TextEmaI.Text.Trim()))
            // Si algún campo es diferente.
            {
                ButMod.Enabled = true; // Activa el botón de modificar
                LabelRut.Enabled = false; // Desactiva la  Label del RUT
                LabelNom.Enabled = false; // Desactiva la  Label del nombre
                labelActCom.Enabled = false; // Desactiva la  Label de comuna
                LabelDir.Enabled = false; // Desactiva la  Label de dirección
                LabelTel.Enabled = false; // Desactiva la  Label de teléfono
                LabelEma.Enabled = false; // Desactiva la  Label de email
                LabelGir.Enabled = false; // Desactiva la  Label de giro
            }
            else
            // Si no hay ningún cambio.
            {
                ButMod.Enabled = false; // Desactiva el botón de modificar
                LabelRut.Enabled = true; // Activa la  Label del RUT
                LabelNom.Enabled = true; // Activa la  Label del nombre
                labelActCom.Enabled = true; // Activa la  Label de comuna
                LabelDir.Enabled = true; // Activa la  Label de dirección
                LabelTel.Enabled = true; // Activa la  Label de teléfono
                LabelEma.Enabled = true; // Activa la  Label de email
                LabelGir.Enabled = true; // Activa la  Label de giro
            }
        }

        private void LabelRut_Click(object sender, EventArgs e)
        // Al pulsar el Label RUT.
        {
            TextRutF.Enabled = true; // Activa el textbox RUT
        }

        private void TextRutF_Leave(object sender, EventArgs e)
        // Al salir del textbox RUT.
        {
            Ent.Rut = TextRutF.Text; // Guarda el RUT ingresado
            bool respuesta = false; // Prepara para validar el RUT
            respuesta = Rut.validarRut(TextRutF.Text); // Valida el RUT ingresado
            if (respuesta == false)
            // Si el RUT es incorrecto.
            {
                TextRutF.Clear(); // Limpia la caja de texto
                MessageBox.Show("Rut Malo", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
            }
            else
            // Si el RUT es correcto.
            {
                MessageBox.Show("Rut Bueno", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito
                Validar(); // Comprueba si hay cambios
            }
        }

        private void LabelNom_Click(object sender, EventArgs e)
        // Al pulsar el label.
        {
            TextNomF.Enabled = true; // Activa el textbox
        }

        private void TextNomF_KeyPress(object sender, KeyPressEventArgs e)
        // Al presionar una tecla.
        {
            if (char.IsNumber(e.KeyChar))
            // Si la tecla es un número.
            {
                e.Handled = true; // Bloquea la tecla presionada
                MessageBox.Show("solo se permiten letras"); // Muestra un mensaje de aviso
            }
        }

        private void TextNomF_TextChanged(object sender, EventArgs e)
        // Al cambiar texto del nombre.
        {
            TextNomF.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextNomF.Text); // Pone mayúscula a cada palabra
            TextNomF.SelectionStart = TextNomF.Text.Length; // Mueve el cursor al final
            Validar(); // Comprueba si hay cambios
        }

        private void LabelTel_Click(object sender, EventArgs e)
        // Al pulsar el label.
        {
            TextTelF.Enabled = true;  // Activa el textbox
        }

        private void TextTelF_TextChanged(object sender, EventArgs e)
        // Al cambiar texto del teléfono.
        {
            Validar(); // Comprueba si hay cambios
        }

        private void labelActCom_Click(object sender, EventArgs e)
        // Al pulsar el label.
        {
            LleComReg(); // Carga la lista de regiones
            labelActReg.Enabled = true; // Activa el label de región
            CBReg.Enabled = true; // Activa la lista de regiones
            labelAcPro.Enabled = true; // Activa el label de provincia
            CBPro.Enabled = true; // Activa la lista de provincias
            LabelAcCom.Enabled = true; // Activa el label de comuna
            CBCom.Enabled = true; // Activa la lista de comunas
        }

        private void CBReg_SelectedIndexChanged(object sender, EventArgs e)
        // Al cambiar la región.
        {
            CargaCBPro(); // Carga las provincias nuevas
        }

        private void CBPro_SelectedIndexChanged(object sender, EventArgs e)
        // Al cambiar la provincia.
        {
            CargaCBCom(); // Carga las comunas nuevas
        }

        private void CBCom_SelectedIndexChanged(object sender, EventArgs e)
        // Al cambiar la comuna.
        {
            TextComF.Text = CBCom.Text; // Pone el nombre de la comuna
            TextComIdeF.Text = Convert.ToString(CBCom.SelectedValue); // Pone el ID de la comuna
            Validar(); // Comprueba si hay cambios
        }

        private void LabelDir_Click(object sender, EventArgs e)
        // Al pulsar el label.
        {
            TextDireF.Enabled = true; // Activa el textbox
        }

        private void TextDireF_TextChanged(object sender, EventArgs e)
        // Al cambiar texto de dirección.
        {
            Validar(); // Comprueba si hay cambios
        }

        private void LabelEma_Click(object sender, EventArgs e)
        // Al pulsar el label.
        {
            TextEmaF.Enabled = true; // Activa el textbox 
        }

        private void TextEmaF_TextChanged(object sender, EventArgs e)
        // Al cambiar texto de email.
        {
            Validar(); // Comprueba si hay cambios
        }

        private void LabelGir_Click(object sender, EventArgs e)
        // Al pulsar el label.
        {
            TextGirF.Enabled = true; // Activa el textbox 
        }

        private void TextGirF_TextChanged(object sender, EventArgs e)
        // Al cambiar texto de giro.
        {
            Validar(); // Comprueba si hay cambios
        }

        public void Cambio()
        // Restaura los controles.
        {
            LabelRut.Enabled = true; // Activa el label
            LabelNom.Enabled = true; // Activa el label
            labelActCom.Enabled = true; // Activa el label
            LabelDir.Enabled = true; // Activa el label
            LabelTel.Enabled = true; // Activa el label
            LabelEma.Enabled = true; // Activa el label
            LabelGir.Enabled = true; // Activa el label
            TextNomF.Enabled = false; // Desactiva el textbox
            TextRutF.Enabled = false; // Desactiva el textbox
            TextDireF.Enabled = false; // Desactiva el textbox
            TextTelF.Enabled = false; // Desactiva el textbox
            TextEmaF.Enabled = false; // Desactiva el textbox
            TextGirF.Enabled = false; // Desactiva el textbox
            ButMod.Enabled = false;  // Desactiva botón
            labelActReg.Enabled = false; // Desactiva el label
            CBReg.Enabled = false; // Desactiva lista
            labelAcPro.Enabled = false; // Desactiva el label
            CBPro.Enabled = false; // Desactiva lista
            LabelAcCom.Enabled = false; // Desactiva el label
            CBCom.Enabled = false; // Desactiva lista
        }

        private void ButMod_Click(object sender, EventArgs e)
        // Al pulsar el botón Modificar.
        {
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Pregunta para confirmar
            string Mensaje = string.Empty; // Prepara un mensaje vacío
            Ent.IdP_Cli = Convert.ToInt32(TextIdCli.Text); // Guarda el ID del cliente
            Ent.Nombre = TextNomF.Text; // Guarda el nombre modificado
            Ent.Rut = TextRutF.Text; // Guarda el RUT modificado
            Ent.IdCom = Convert.ToInt32(TextComIdeF.Text); // Guarda el ID de comuna
            Ent.Direccion = TextDireF.Text; // Guarda la dirección modificada
            Ent.Tel = TextTelF.Text; // Guarda el teléfono modificado
            Ent.Email = TextEmaF.Text; // Guarda el email modificado
            Ent.Giro = TextGirF.Text; // Guarda el giro modificado
            if (res == DialogResult.Yes)
            // Si la respuesta es Sí.
            {
                Respuesta<bool> resultado = NCliente.Actualizar(Ent); // Intenta actualizar el cliente
                if (resultado.estado)
                // Si la actualización fue exitosa.
                {
                    MessageBox.Show("Actualización fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito
                    TextNomI.Text = TextNomF.Text; // Actualiza el campo de nombre
                    labelRtI.Text = TextRutF.Text; // Actualiza el campo de RUT
                    TextComIdeI.Text = TextComIdeF.Text; // Actualiza el ID de comuna
                    TextComI.Text = TextComF.Text; // Actualiza el nombre de comuna
                    TextDireI.Text = TextDireF.Text; // Actualiza el campo de dirección
                    TextTelI.Text = TextTelF.Text; // Actualiza el campo de teléfono
                    TextEmaI.Text = TextEmaF.Text; // Actualiza el campo de email
                    TextGirI.Text = TextGirF.Text; // Actualiza el campo de giro
                }
                else
                // Si la actualización falló.
                {
                    MessageBox.Show(Mensaje); // Muestra el mensaje de error
                }
            }
            else if (res == DialogResult.No)
            // Si la respuesta es No.
            {
                ButVol.Focus(); // Enfoca el botón Volver
            }
            else if (res == DialogResult.Cancel)
            // Si la respuesta es Cancelar.
            {
                ButSal.Focus(); // Enfoca el botón Salir
            }
            Cambio(); // Restaura los controles
            Validar(); // Comprueba si hay cambios
        }

        private void ButAnu_Click(object sender, EventArgs e)
        // Al pulsar el botón Anular.
        {
            TextNomF.Text = TextNomI.Text; // Restaura el nombre original
            TextRutF.Text = labelRtI.Text; // Restaura el RUT original
            TextComIdeF.Text = TextComIdeI.Text; // Restaura el ID de comuna
            TextComF.Text = TextComI.Text; // Restaura la comuna original
            TextDireF.Text = TextDireI.Text; // Restaura la dirección original
            TextTelF.Text = TextTelI.Text; // Restaura el teléfono original
            TextEmaF.Text = TextEmaI.Text; // Restaura el email original
            TextGirF.Text = TextGirI.Text; // Restaura el giro original
            Cambio(); // Restaura los controles
        }

        private void ButVol_Click(object sender, EventArgs e)
        // Al pulsar el botón Volver.
        {
            PCli_Con ver = new PCli_Con(); // Crea una nueva ventana
            ver.ButMod.Visible = true; // Hace visible el botón Modificar
            this.Close(); // Cierra esta ventana
        }

        private void ButSal_Click(object sender, EventArgs e)
        // Al pulsar el botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación
        }
    }
}

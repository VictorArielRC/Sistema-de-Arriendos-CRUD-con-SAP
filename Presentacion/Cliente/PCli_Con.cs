// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using Presentacion.AAClases;
// Accede a códigos de otra librería
using Presentacion.ArriFinal;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.Linq;
// Accede a códigos de otra librería
using System.Runtime.ConstrainedExecution;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using static System.Net.Mime.MediaTypeNames;
// Accede a códigos de otra librería
using Application = System.Windows.Forms.Application;


namespace Presentacion.Cliente
{
    public partial class PCli_Con : Form
    {
        
        public PArrIng FormularioPadre; // Referencia al formulario padre
        ECliente Ent = new ECliente(); // Crea una nueva instancia de cliente
        NCliente Neg = new NCliente(); // Instancia la lógica de cliente
        NLocCom NegCom = new NLocCom(); // Instancia la lógica de comuna
        NLocPro NegPro = new NLocPro(); // Instancia la lógica de provincia
        NLocReg NegReg = new NLocReg(); // Instancia la lógica de región
        public PCli_Con()
        {
            InitializeComponent();
            ButClien.Visible = false;
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PCli_Con_Load(object sender, EventArgs e)
        {
            if (FormularioPadre != null) // Valida si el formulario padre existe.
            {
                ButClien.Visible = true; // Hace visible el botón de cliente.
                ButMod.Enabled = false;  // Deshabilita el botón modificar.
                ButEli.Enabled = false;  // Deshabilita el botón eliminar.
            }
            foreach (DataGridViewColumn columna in Grilla.Columns) // Itera cada columna en la grilla.
            {
                if (columna.Visible == true && columna.Name != "Selec") // Si la columna es visible y no es "Selec".
                {
                    ComboBus.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText }); // Agrega columna al filtro.
                }
            }
            ComboBus.DisplayMember = "Texto";   // Define la propiedad a mostrar.
            ComboBus.ValueMember = "Valor";     // Define la propiedad de valor.
            ComboBus.SelectedIndex = 0;         // Selecciona el primer elemento.
            CarDat();       // Carga los datos iniciales.
        }

        public void CarDat()
        // Carga los datos en la grilla
        {
            try // Intenta cargar los datos
            {
                Grilla.Rows.Clear(); // Limpia las filas existentes
                List<ECliente> Listar = new NCliente().Listar(); // Obtiene la lista de clientes
                foreach (ECliente item in Listar)
                // Recorre cada cliente de la lista
                {
                    Grilla.Rows.Add(new object[] { "", item.IdP_Cli, item.Nombre, item.Rut, item.IdCom, item.Com.Nombre, item.Direccion, item.Tel, item.Email, item.Giro });
                    // Agrega una fila con datos
                }
            }
            catch (Exception ex)
            // Si ocurre un error
            {
                MessageBox.Show(ex.Message); // Muestra el mensaje de error
            }
            Grilla.ClearSelection(); // Quita la selección de la tabla
        }

        public void ResetGrid() // Reinicia la visibilidad de las filas.
        {
            foreach (DataGridViewRow row in Grilla.Rows) // Itera cada fila.
            {
                row.Visible = true; // Hace visible la fila.
            }
        }
        private void TextBus_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar tecla.
        {
            if (char.IsDigit(e.KeyChar)) // Si la tecla es un dígito.
            {
                e.Handled = true; // Suprime la entrada.
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error.
            }
        }

        private void TextBus_TextChanged(object sender, EventArgs e) // Evento al cambiar texto.
        {
            TextBus.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBus.Text); // Convierte a título.
            TextBus.SelectionStart = TextBus.Text.Length; // Posiciona el cursor al final.
        }

        private void ButBus_Click(object sender, EventArgs e) // Evento clic en botón buscar.
        {
            string columnaFiltro = ((Filtrar)ComboBus.SelectedItem).Valor.ToString(); // Obtiene columna para filtrar.
            if (Grilla.Rows.Count > 0) // Si la grilla tiene filas.
            {
                foreach (DataGridViewRow row in Grilla.Rows) // Itera cada fila.
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper())) // Si la celda contiene el texto.
                        row.Visible = true; // Hace visible la fila.
                    else
                        row.Visible = false; // Oculta la fila.
                }
            }
        }

        private void ButLimBus_Click(object sender, EventArgs e) // Evento clic en botón limpiar búsqueda.
        {
            TextBus.Text = ""; // Limpia el campo de búsqueda.
            CarDat();          // Recarga los datos de la grilla.
        }

        private void Grilla_DoubleClick(object sender, EventArgs e)
        // Al hacer doble clic en la tabla
        {
            ButMod.Enabled = true; // Activa el botón de modificar
            ButEli.Enabled = true; // Activa el botón de eliminar
            ButClien.Enabled = true; // Activa el botón de cliente
            TextBox1.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Guarda el ID del cliente
        }

        private void ButMod_Click(object sender, EventArgs e)
        // Al pulsar el botón Modificar
        {
            PCli_Act pasar = new PCli_Act(); // Crea la ventana de actualizar
            pasar.TextIdCli.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Pasa el ID del cliente
            pasar.TextNomF.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Pasa el nombre del cliente
            pasar.TextNomI.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Pasa el nombre inicial
            pasar.TextRutF.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString(); // Pasa el RUT del cliente
            pasar.labelRtI.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString(); // Pasa el RUT inicial
            pasar.TextComIdeF.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Pasa el ID de comuna
            pasar.TextComIdeI.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Pasa el ID inicial
            pasar.TextComI.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Pasa el nombre de comuna
            pasar.TextComF.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Pasa el nombre inicial
            pasar.TextDireF.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Pasa la dirección
            pasar.TextDireI.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Pasa la dirección inicial
            pasar.TextTelF.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Pasa el teléfono
            pasar.TextTelI.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Pasa el teléfono inicial
            pasar.TextEmaF.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Pasa el email
            pasar.TextEmaI.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Pasa el email inicial
            pasar.TextGirF.Text = this.Grilla.CurrentRow.Cells[9].Value.ToString(); // Pasa el giro
            pasar.TextGirI.Text = this.Grilla.CurrentRow.Cells[9].Value.ToString(); // Pasa el giro inicial
            pasar.LabelRut.Enabled = true; // Activa el Label
            pasar.LabelNom.Enabled = true; // Activa el Label
            pasar.labelActCom.Enabled = true; // Activa el Label
            pasar.LabelDir.Enabled = true; // Activa el Label
            pasar.LabelTel.Enabled = true; // Activa el Label
            pasar.LabelEma.Enabled = true; // Activa el Label
            pasar.LabelGir.Enabled = true; // Activa el Label
            pasar.labelRtI.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString(); // Pasa el RUT inicial
            pasar.Show(); // Muestra la ventana de actualizar.
            ButMod.Enabled = false; // Desactiva el botón 
            ButEli.Enabled = false; // Desactiva el botón 
            ButClien.Enabled = false; // Desactiva el botón 
                                      //this.Close();
        }
        private void ButEli_Click(object sender, EventArgs e) // Evento clic en botón eliminar.
        {
            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Pregunta confirmación.
            if (res == DialogResult.Yes) // Si confirma la eliminación.
            {
                int Id; // Declara variable para ID.
                if (int.TryParse(TextBox1.Text, out Id)) // Intenta convertir texto a ID.
                {
                    Respuesta<bool> resultado = NCliente.Eliminar(Id); // Elimina el cliente.
                    if (resultado.estado) // Si la eliminación fue exitosa.
                    {
                        MessageBox.Show("La eliminación se realizó correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra éxito.
                    }
                    else // Si la eliminación falló.
                    {
                        MessageBox.Show("No se pudo eliminar el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                    }
                }
                else // Si el ID no es válido.
                {
                    MessageBox.Show("Seleccione un registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra información.
                }
            }
            else if (res == DialogResult.No) // Si elige "No".
            {
                ButVol.Focus(); // Enfoca botón "Volver".
            }
            else if (res == DialogResult.Cancel) // Si elige "Cancelar".
            {
                ButSal.Focus(); // Enfoca botón "Salir".
            }
            Grilla.Rows.Clear(); // Limpia filas de la grilla.
            CarDat();            // Recarga los datos.
        }

        private void ButClien_Click(object sender, EventArgs e) // Evento clic en botón cliente.
        {
            ButClien.Visible = true; // Mantiene visible el botón.
            if (Grilla.CurrentRow == null) // Si no hay fila seleccionada.
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para importar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information); // Pide selección.
                return; // Sale del método.
            }

            if (FormularioPadre != null) // Si el formulario padre existe.
            {
                try // Intenta cargar datos en el padre.
                {
                    int idCliente = Convert.ToInt32(this.Grilla.CurrentRow.Cells["IdCli"].Value); // Obtiene ID de cliente.
                    string nombreCliente = this.Grilla.CurrentRow.Cells["Nombre"].Value?.ToString();     // Obtiene nombre.
                    string rutCliente = this.Grilla.CurrentRow.Cells["Rut"].Value?.ToString();         // Obtiene RUT.
                    string direccionCliente = this.Grilla.CurrentRow.Cells["Direccion"].Value?.ToString(); // Obtiene dirección.
                    string comunaCliente = this.Grilla.CurrentRow.Cells["Comuna"].Value?.ToString();     // Obtiene comuna.
                    string giroCliente = this.Grilla.CurrentRow.Cells["Giro"].Value?.ToString();         // Obtiene giro.
                    string telCliente = this.Grilla.CurrentRow.Cells["Tel"].Value?.ToString();         // Obtiene teléfono.

                    FormularioPadre.TextIdCli.Text = idCliente.ToString();     // Asigna ID al padre.
                    FormularioPadre.TextNomCli.Text = nombreCliente;           // Asigna nombre al padre.
                    FormularioPadre.TextRut.Text = rutCliente;                 // Asigna RUT al padre.
                    FormularioPadre.TextDir.Text = direccionCliente;           // Asigna dirección al padre.
                    FormularioPadre.TextCom.Text = comunaCliente;             // Asigna comuna al padre.
                    FormularioPadre.TextGir.Text = giroCliente;               // Asigna giro al padre.
                    FormularioPadre.TextTel.Text = telCliente;                 // Asigna teléfono al padre.

                    this.DialogResult = DialogResult.OK; // Establece resultado de diálogo.
                    this.Close(); // Cierra el formulario actual.
                }
                catch (Exception ex) // Captura errores al cargar.
                {
                    MessageBox.Show($"Error al cargar el cliente en el formulario principal: {ex.Message}\nVerifique los nombres de las columnas en la grilla o los índices de celdas.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error.
                }
            }
            else // Si el formulario padre no está establecido.
            {
                MessageBox.Show("El formulario padre no fue establecido. No se pueden cargar los datos.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error.
            }
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento clic en botón volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento clic en botón salir.
        {
            Application.Exit(); // Cierra la aplicación.
        }

        private void Grilla_CellContentClick(object sender, DataGridViewCellEventArgs e) // Evento clic en contenido de celda.
        {

        }
    }
}

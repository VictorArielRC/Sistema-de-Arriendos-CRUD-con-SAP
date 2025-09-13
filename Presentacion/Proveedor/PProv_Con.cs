// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using Presentacion.AAClases;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using Application = System.Windows.Forms.Application;


namespace Presentacion.Proveedor
{
    public partial class PProv_Con : Form
    {
        public PProv_Con()
        {
            InitializeComponent();
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        EProv Ent = new EProv();         // Instancia de la entidad Proveedor.
        NProv Neg = new NProv();         // Instancia de la capa de negocio Proveedor.
        NLocCom NegCom = new NLocCom();  // Instancia de la capa de negocio para Localidades (Comunas).
        NLocPro NegPro = new NLocPro();  // Instancia de la capa de negocio para Localidades (Provincias).
        NLocReg NegReg = new NLocReg();  // Instancia de la capa de negocio para Localidades (Regiones).

        private void PProv_Con_Load(object sender, EventArgs e) // Evento al cargar el formulario.
        {
            // Itera sobre las columnas de la DataGridView para poblar el ComboBox de búsqueda.
            foreach (DataGridViewColumn columna in Grilla.Columns)
            {
                // Si la columna es visible y no es la columna de selección.
                if (columna.Visible == true && columna.Name != "Selec")
                {
                    // Agrega un nuevo elemento al ComboBox de búsqueda con el nombre y texto de la columna.
                    ComboBus.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            ComboBus.DisplayMember = "Texto"; // Establece la propiedad a mostrar en el ComboBox.
            ComboBus.ValueMember = "Valor";   // Establece el valor asociado en el ComboBox.
            ComboBus.SelectedIndex = 0;       // Selecciona el primer elemento por defecto.
            CarDat(); // Llama al método para cargar los datos en la grilla.
        }

        public void CarDat() // Carga los datos de los proveedores en la DataGridView.
        {
            try
            {
                Grilla.Rows.Clear(); // Limpia las filas existentes en la grilla.
                List<EProv> Listar = new NProv().Listar(); // Obtiene la lista de proveedores desde la capa de negocio.
                foreach (EProv item in Listar) // Itera sobre cada proveedor en la lista.
                {
                    // Agrega una nueva fila a la grilla con los datos del proveedor.
                    Grilla.Rows.Add(new object[] { "", item.IdProv, item.Nombre, item.Rut, item.IdCom, item.Com.Nombre, item.Direccion, item.Tel, item.Email, item.Giro, item.Descr });
                }
            }
            catch (Exception ex) // Captura cualquier excepción.
            {
                MessageBox.Show(ex.Message); // Muestra el mensaje de error.
            }
            Grilla.ClearSelection(); // Deselecciona todas las filas en la grilla.
        }

        public void ResetGrid() // Restablece la visibilidad de todas las filas en la grilla.
        {
            foreach (DataGridViewRow row in Grilla.Rows) // Itera sobre cada fila en la grilla.
            {
                row.Visible = true; // Hace visible la fila.
            }
        }



        private void TextBus_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo de texto de búsqueda.
        {
            TextBus.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBus.Text); // Convierte el texto a formato de título.
            TextBus.SelectionStart = TextBus.Text.Length; // Mueve el cursor al final del texto.
        }

        private void ButBus_Click(object sender, EventArgs e) // Evento clic en el botón Buscar.
        {
            // Obtiene el nombre de la columna seleccionada para filtrar.
            string columnaFiltro = ((Filtrar)ComboBus.SelectedItem).Valor.ToString();
            if (Grilla.Rows.Count > 0) // Si hay filas en la grilla.
            {
                foreach (DataGridViewRow row in Grilla.Rows) // Itera sobre cada fila en la grilla.
                {
                    // Si el valor de la celda en la columna de filtro contiene el texto de búsqueda (ignorando mayúsculas/minúsculas).
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper()))
                        row.Visible = true; // Hace visible la fila.
                    else
                        row.Visible = false; // Oculta la fila.
                }
            }
        }

        private void ButLimBus_Click(object sender, EventArgs e) // Evento clic en el botón Limpiar Búsqueda.
        {
            TextBus.Text = ""; // Limpia el campo de texto de búsqueda.
            CarDat();         // Vuelve a cargar todos los datos en la grilla.
        }

        private void Grilla_DoubleClick(object sender, EventArgs e) // Evento doble clic en la DataGridView.
        {
            ButMod.Enabled = true; // Habilita el botón Modificar.
            ButEli.Enabled = true; // Habilita el botón Eliminar.
            TextBox1.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Asigna el ID del proveedor seleccionado a TextBox1.
        }

        private void ButMod_Click(object sender, EventArgs e) // Evento clic en el botón Modificar.
        {
            PProv_Act pasar = new PProv_Act(); // Crea una nueva instancia del formulario de actualización de proveedores.
                                               // Pasa los datos de la fila seleccionada en la grilla al formulario de actualización.
            pasar.TextIdCli.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Asigna ID de cliente
            pasar.TextNomF.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Asigna nombre a formulario
            pasar.TextNomI.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Asigna nombre a input
            pasar.TextRutF.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString(); // Asigna RUT a formulario
            pasar.labelRtI.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString(); // Asigna RUT a etiqueta
            pasar.TextComIdeF.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Asigna comuna ID a formulario
            pasar.TextComIdeI.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Asigna comuna ID a input
            pasar.TextComI.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Asigna comuna a input
            pasar.TextComF.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Asigna comuna a formulario
            pasar.TextDireF.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Asigna dirección a formulario
            pasar.TextDireI.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Asigna dirección a input
            pasar.TextTelF.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Asigna teléfono a formulario
            pasar.TextTelI.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Asigna teléfono a input
            pasar.TextEmaF.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Asigna email a formulario
            pasar.TextEmaI.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Asigna email a input
            pasar.TextGirF.Text = this.Grilla.CurrentRow.Cells[9].Value.ToString(); // Asigna giro a formulario
            pasar.TextGirI.Text = this.Grilla.CurrentRow.Cells[9].Value.ToString(); // Asigna giro a input
            pasar.TextDesF.Text = this.Grilla.CurrentRow.Cells[10].Value.ToString(); // Asigna descripción a formulario
            pasar.TextDesI.Text = this.Grilla.CurrentRow.Cells[10].Value.ToString(); // Asigna descripción a input
                                                                                     // Habilita los Labels para que los campos de texto puedan ser editados en el formulario de actualización.
            pasar.LabelRut.Enabled = true; // Habilita la etiqueta RUT
            pasar.LabelNom.Enabled = true; // Habilita la etiqueta Nombre
            pasar.labelActCom.Enabled = true; // Habilita la etiqueta de Comuna
            pasar.LabelDir.Enabled = true; // Habilita la etiqueta Dirección
            pasar.LabelTel.Enabled = true; // Habilita la etiqueta Teléfono
            pasar.LabelEma.Enabled = true; // Habilita la etiqueta Email
            pasar.LabelGir.Enabled = true; // Habilita la etiqueta Giro
            pasar.labelRtI.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString(); // Asigna el RUT inicial nuevamente.
            pasar.Show(); // Muestra el formulario de actualización.
            ButMod.Enabled = false; // Deshabilita el botón Modificar en este formulario.
            ButEli.Enabled = false; // Deshabilita el botón Eliminar en este formulario.
            this.Close();           // Cierra el formulario actual.
        }

        private void ButEli_Click(object sender, EventArgs e) // Evento clic en el botón Eliminar.
        {
            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Pide confirmación.
            if (res == DialogResult.Yes) // Si la respuesta es "Sí".
            {
                int Id;
                if (int.TryParse(TextBox1.Text, out Id)) // Intenta convertir el texto del TextBox1 a un entero (ID del proveedor).
                {
                    Respuesta<bool> resultado = NProv.Eliminar(Id); // Intenta eliminar el proveedor.
                    if (resultado.estado) // Si la eliminación es exitosa.
                    {
                        MessageBox.Show("La eliminación se realizó correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    }
                    else // Si la eliminación falla.
                    {
                        MessageBox.Show("No se pudo eliminar el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje de advertencia.
                    }
                }
                else // Si el ID no es un número válido.
                {
                    MessageBox.Show("Seleccione un registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de información.
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
            Grilla.Rows.Clear(); // Limpia la grilla.
            CarDat();            // Vuelve a cargar los datos en la grilla.
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

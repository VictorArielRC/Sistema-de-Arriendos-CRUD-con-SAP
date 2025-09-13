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
using System.Data;
// Accede a códigos de otra librería
using System.Reflection.Emit;
// Accede a códigos de otra librería
using System.Windows.Forms;


namespace Presentacion
{
    public partial class PCom : Form
    {
        ELocCom Ent = new ELocCom();     // Instancia de entidad para comunas.
        NLocPro NegPro = new NLocPro();   // Instancia de negocio para provincias.
        NLocReg NegReg = new NLocReg();   // Instancia de negocio para regiones.

        public PCom() // Constructor de la clase PCom.
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        private void PCom_Load(object sender, EventArgs e) // Evento al cargar el formulario PCom.
        {
            foreach (DataGridViewColumn columna in Grilla.Columns) // Itera sobre cada columna en la grilla.
            {
                if (columna.Visible == true && columna.Name != "Selec") // Si la columna es visible y no es "Selec".
                {
                    ComboBus.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText }); // Agrega la columna al ComboBox de búsqueda.
                }
            }
            ComboBus.DisplayMember = "Texto";   // Establece la propiedad a mostrar en el ComboBox.
            ComboBus.ValueMember = "Valor";     // Establece la propiedad de valor en el ComboBox.
            ComboBus.SelectedIndex = 0;         // Selecciona el primer elemento por defecto.
            CarDat();                           // Carga los datos iniciales en la grilla.
            LleComReg();                        // Carga las regiones en el ComboBox correspondiente.
            ThemeManager.ApplyExecutiveTheme(this); // Aplica tema ejecutivo.
        }

        public void CarDat() // Carga los datos de comunas en la grilla.
        {
            try // Intenta realizar la carga de datos.
            {
                Grilla.Rows.Clear(); // Limpia todas las filas de la grilla.
                List<ELocCom> Listar = new NLocCom().Listar(); // Obtiene una lista de comunas.
                foreach (ELocCom item in Listar) // Itera sobre cada comuna en la lista.
                {
                    // Agrega una nueva fila con los datos de la comuna.
                    Grilla.Rows.Add(new object[] { "", item.IdCom, item.Nombre, item.IdPro, item.Pro.Nombre, item.IdReg, item.Reg.Nombre });
                }
            }
            catch (Exception ex) // Captura cualquier excepción que ocurra.
            {
                MessageBox.Show(ex.Message); // Muestra un mensaje con el error.
            }
            Grilla.ClearSelection(); // Deselecciona todas las filas de la grilla.
        }

        public void Validar() // Valida el estado de los botones de acción (Modificar, Ingresar, Eliminar).
        {
            if (TextIngMod.Text.Trim() != "") // Si el campo de ingreso/modificación no está vacío.
            {
                if ((TextIngMod.Text == textConCom.Text) && (ComboIngModPro.Text == textConPro.Text)) // Si los datos no han cambiado.
                {
                    ButMod.Enabled = false; // Deshabilita el botón de Modificar.
                    ButIng.Enabled = false; // Deshabilita el botón de Ingresar.
                }
                else // Si los datos han cambiado.
                {
                    ButMod.Enabled = true; // Habilita el botón de Modificar.
                    ButIng.Enabled = true; // Habilita el botón de Ingresar.
                }
            }
            else // Si el campo de ingreso/modificación está vacío.
            {
                ButIng.Enabled = false; // Deshabilita el botón de Ingresar.
                ButMod.Enabled = false; // Deshabilita el botón de Modificar.
                ButEli.Enabled = false; // Deshabilita el botón de Eliminar.
            }
        }

        public void LleComReg() // Carga el ComboBox de regiones para ingreso/modificación.
        {
            ComboIngModReg.DisplayMember = "Nombre";   // Muestra el nombre de la región.
            ComboIngModReg.ValueMember = "IdReg";     // Usa el ID de la región como valor.
            ComboIngModReg.DataSource = NegReg.Listar(); // Obtiene la lista de regiones.
        }

        public void ResetGrid() // Restaura la visibilidad de todas las filas de la grilla.
        {
            foreach (DataGridViewRow row in Grilla.Rows) // Itera sobre cada fila en la grilla.
            {
                row.Visible = true; // Hace visible la fila.
            }
        }

        public void Check_funciones() // Resetea el estado de los CheckBoxes de función.
        {
            CheckIng.CheckState = CheckState.Unchecked; // Desmarca el CheckBox de Ingresar.
            CheckMod.CheckState = CheckState.Unchecked; // Desmarca el CheckBox de Modificar.
            CheckEli.CheckState = CheckState.Unchecked; // Desmarca el CheckBox de Eliminar.
            CheckIng.Enabled = true;                 // Habilita el CheckBox de Ingresar.
            CheckMod.Enabled = false;                // Deshabilita el CheckBox de Modificar.
            CheckEli.Enabled = false;                // Deshabilita el CheckBox de Eliminar.
        }

        private void ButBus_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Buscar.
        {
            string columnaFiltro = ((Filtrar)ComboBus.SelectedItem).Valor.ToString(); // Obtiene el nombre de la columna para filtrar.
            if (Grilla.Rows.Count > 0) // Si hay filas en la grilla.
            {
                foreach (DataGridViewRow row in Grilla.Rows) // Itera sobre cada fila.
                {
                    // Filtra las filas según el texto de búsqueda.
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper()))
                        row.Visible = true; // Hace visible la fila si coincide.
                    else
                        row.Visible = false; // Oculta la fila si no coincide.
                }
            }
        }

        private void TextBus_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo de búsqueda.
        {
            if (char.IsDigit(e.KeyChar)) // Si la tecla presionada es un dígito.
            {
                e.Handled = true; // Suprime la entrada del carácter.
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra advertencia.
            }
        }

        private void TextBus_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto del campo de búsqueda.
        {
            TextBus.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBus.Text); // Convierte a formato de título.
            TextBus.SelectionStart = TextBus.Text.Length; // Mueve el cursor al final del texto.
            Validar(); // Realiza la validación de botones.
        }

        private void ButLimBus_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Limpiar Búsqueda.
        {
            TextBus.Text = ""; // Limpia el campo de búsqueda.
            CarDat();          // Recarga los datos en la grilla.
        }

        private void Grilla_DoubleClick(object sender, EventArgs e) // Evento al hacer doble clic en una fila de la grilla.
        {
            textId.Clear();                                  // Limpia el campo de ID.
            TextIngMod.Clear();                              // Limpia el campo de ingreso/modificación.
            CheckMod.Enabled = true;                         // Habilita el CheckBox de Modificar.
            CheckEli.Enabled = true;                         // Habilita el CheckBox de Eliminar.
            CheckIng.CheckState = CheckState.Unchecked;      // Desmarca el CheckBox de Ingresar.
            CheckIng.Enabled = false;                        // Deshabilita el CheckBox de Ingresar.
            CheckMod.CheckState = CheckState.Unchecked;      // Desmarca el CheckBox de Modificar.
            CheckEli.CheckState = CheckState.Unchecked;      // Desmarca el CheckBox de Eliminar.
            textId.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString();       // Carga el ID de la comuna seleccionada.
            textConCom.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString();   // Carga el nombre de la comuna seleccionada.
            TextIngMod.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString();   // Carga el nombre de la comuna para modificación.
            textConPro.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString();   // Carga la provincia de la comuna.
            ComboIngModPro.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Carga la provincia en el ComboBox.
            ComboIngModReg.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Carga la región en el ComboBox.
            TextIngMod.Enabled = false;                      // Deshabilita el campo de ingreso/modificación.
            ComboIngModPro.Enabled = false;                  // Deshabilita el ComboBox de provincias.
        }

        private void CheckIng_CheckedChanged(object sender, EventArgs e) // Evento al cambiar el estado del CheckBox Ingresar.
        {
            if (CheckIng.CheckState == CheckState.Checked) // Si el CheckBox Ingresar está marcado.
            {
                CheckMod.CheckState = CheckState.Unchecked; // Desmarca el CheckBox Modificar.
                CheckEli.CheckState = CheckState.Unchecked; // Desmarca el CheckBox Eliminar.
                label7.Text = "Ingresar Comuna:";           // Cambia el texto de la etiqueta.
                TextIngMod.Enabled = true;                  // Habilita el campo de ingreso/modificación.
                ComboIngModPro.Enabled = true;              // Habilita el ComboBox de provincias.
                ComboIngModReg.Enabled = true;              // Habilita el ComboBox de regiones.
                TextIngMod.Clear();                         // Limpia el campo de ingreso/modificación.
                textId.Clear();                             // Limpia el campo de ID.
                ButIng.Visible = true;                      // Hace visible el botón de Ingresar.
            }
            else // Si el CheckBox Ingresar no está marcado.
            {
                label7.Text = "";    // Borra el texto de la etiqueta.
                ButIng.Visible = false; // Oculta el botón de Ingresar.
            }
            Validar(); // Realiza la validación de botones.
        }

        private void CheckMod_CheckedChanged(object sender, EventArgs e) // Evento al cambiar el estado del CheckBox Modificar.
        {
            if (CheckMod.CheckState == CheckState.Checked) // Si el CheckBox Modificar está marcado.
            {
                CheckIng.CheckState = CheckState.Unchecked; // Desmarca el CheckBox Ingresar.
                CheckEli.CheckState = CheckState.Unchecked; // Desmarca el CheckBox Eliminar.
                label7.Text = "Actualizar Comuna:";         // Cambia el texto de la etiqueta.
                TextIngMod.Enabled = true;                  // Habilita el campo de ingreso/modificación.
                ComboIngModReg.Enabled = true;              // Habilita el ComboBox de regiones.
                ComboIngModPro.Enabled = true;              // Habilita el ComboBox de provincias.
                ButMod.Visible = true;                      // Hace visible el botón de Modificar.
            }
            else // Si el CheckBox Modificar no está marcado.
            {
                label7.Text = "";    // Borra el texto de la etiqueta.
                ButMod.Visible = false; // Oculta el botón de Modificar.
            }
            Validar(); // Realiza la validación de botones.
        }

        private void CheckEli_CheckedChanged(object sender, EventArgs e) // Evento al cambiar el estado del CheckBox Eliminar.
        {
            if (CheckEli.CheckState == CheckState.Checked) // Si el CheckBox Eliminar está marcado.
            {
                CheckIng.CheckState = CheckState.Unchecked; // Desmarca el CheckBox Ingresar.
                CheckMod.CheckState = CheckState.Unchecked; // Desmarca el CheckBox Modificar.
                label7.Text = "Eliminar Región:";           // Cambia el texto de la etiqueta.
                TextIngMod.Enabled = false;                 // Deshabilita el campo de ingreso/modificación.
                ButEli.Visible = true;                      // Hace visible el botón de Eliminar.
                ButEli.Enabled = true;                      // Habilita el botón de Eliminar.
            }
            else // Si el CheckBox Eliminar no está marcado.
            {
                label7.Text = "";    // Borra el texto de la etiqueta.
                ButEli.Visible = false; // Oculta el botón de Eliminar.
                ButEli.Enabled = false; // Deshabilita el botón de Eliminar.
            }
        }

        private void ComboIngModReg_SelectedIndexChanged(object sender, EventArgs e) // Evento al cambiar la selección de Región para ingreso/modificación.
        {
            int IdPro = Convert.ToInt32(ComboIngModReg.SelectedValue); // Obtiene el ID de la región seleccionada.
            DataTable dt = NegPro.Filtrar(IdPro);                     // Filtra las provincias por la región.
            ComboIngModPro.DisplayMember = "Nombre";                   // Muestra el nombre de la provincia.
            ComboIngModPro.ValueMember = "IdPro";                     // Usa el ID de la provincia como valor.
            ComboIngModPro.DataSource = dt;                          // Asigna los datos al ComboBox de provincias.
        }

        private void ComboIngMod_SelectedIndexChanged(object sender, EventArgs e) // Evento al cambiar la selección de un ComboBox (posiblemente de provincia).
        {
            Validar(); // Realiza la validación de botones.
        }

        private void TextIngMod_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo de ingreso/modificación.
        {
            if (char.IsDigit(e.KeyChar)) // Si la tecla presionada es un dígito.
            {
                e.Handled = true; // Suprime la entrada del carácter.
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra advertencia.
            }
        }

        private void TextIngMod_TextChanged(object sender, EventArgs e) // Evento al cambiar el texto del campo de ingreso/modificación.
        {
            TextIngMod.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextIngMod.Text); // Convierte a formato de título.
            TextIngMod.SelectionStart = TextIngMod.Text.Length; // Mueve el cursor al final del texto.
            Validar(); // Realiza la validación de botones.
        }

        private void ButIng_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Ingresar.
        {
            // Muestra un mensaje de confirmación al usuario.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            string Mensaje = string.Empty; // Variable para almacenar mensajes de error (no utilizada en este bloque).
            Ent.Nombre = TextIngMod.Text;  // Asigna el nombre de la comuna a la entidad.
            Ent.IdPro = Convert.ToInt32(ComboIngModPro.SelectedValue); // Asigna el ID de la provincia a la entidad.

            if (res == DialogResult.Yes) // Si el usuario confirma la acción.
            {
                Respuesta<bool> resultado = NLocCom.Ingresar(Ent); // Intenta ingresar la comuna.

                if (resultado.estado) // Si el ingreso fue exitoso.
                {
                    MessageBox.Show("Ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    ButLim.PerformClick(); // Simula un clic en el botón Limpiar.
                }
                else // Si el ingreso falló.
                {
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de advertencia.
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
            Grilla.Rows.Clear(); // Limpia las filas de la grilla.
            CarDat();            // Recarga los datos en la grilla.
        }

        private void ButMod_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Modificar.
        {
            // Muestra un mensaje de confirmación al usuario.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            string Mensaje = string.Empty; // Variable para almacenar mensajes de error (no utilizada en este bloque).
            Ent.IdCom = Convert.ToInt32(textId.Text); // Asigna el ID de la comuna a la entidad.
            Ent.Nombre = TextIngMod.Text;  // Asigna el nuevo nombre a la entidad.
            Ent.IdPro = Convert.ToInt32(ComboIngModPro.SelectedValue); // Asigna el nuevo ID de provincia.

            if (res == DialogResult.Yes) // Si el usuario confirma la acción.
            {
                Respuesta<bool> resultado = NLocCom.Actualizar(Ent); // Intenta actualizar la comuna.
                if (resultado.estado) // Si la actualización fue exitosa.
                {
                    MessageBox.Show("Actualización fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                    ButLim.PerformClick(); // Simula un clic en el botón Limpiar.
                }
                else // Si la actualización falló.
                {
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de advertencia.
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
            Grilla.Rows.Clear(); // Limpia las filas de la grilla.
            CarDat();            // Recarga los datos en la grilla.
        }

        private void ButEli_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Eliminar.
        {
            // Muestra un mensaje de confirmación al usuario.
            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes) // Si el usuario confirma la acción.
            {
                int Id; // Variable para el ID de la comuna.
                if (int.TryParse(textId.Text, out Id)) // Intenta convertir el texto del ID a entero.
                {
                    Respuesta<bool> resultado = NLocCom.Eliminar(Id); // Intenta eliminar la comuna.
                    if (resultado.estado) // Si la eliminación fue exitosa.
                    {
                        MessageBox.Show("La eliminación se realizó correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de éxito.
                        ButLim.PerformClick(); // Simula un clic en el botón Limpiar.
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
            else if (res == DialogResult.No) // Si el usuario elige "No".
            {
                ButVol.Focus(); // Enfoca el botón "Volver".
            }
            else if (res == DialogResult.Cancel) // Si el usuario elige "Cancelar".
            {
                ButSal.Focus(); // Enfoca el botón "Salir".
            }
            Grilla.Rows.Clear(); // Limpia las filas de la grilla.
            CarDat();            // Recarga los datos en la grilla.
        }

        private void ButLim_Click(object sender, EventArgs e) // Evento al hacer clic en el botón Limpiar.
        {
            textId.Clear();           // Limpia el campo de ID.
            TextIngMod.Clear();       // Limpia el campo de ingreso/modificación.
            textConCom.Clear();       // Limpia el campo de comuna de consulta.
            textConPro.Clear();       // Limpia el campo de provincia de consulta.
            TextIngMod.Enabled = false; // Deshabilita el campo de ingreso/modificación.
            ComboIngModPro.Enabled = false; // Deshabilita el ComboBox de provincias.
            ResetGrid();              // Restaura la visibilidad de la grilla.
            Check_funciones();        // Resetea el estado de los CheckBoxes de función.
            CarDat();                 // Recarga los datos en la grilla.
            Validar();                // Realiza la validación de botones.
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
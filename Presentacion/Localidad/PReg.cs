// Importa dependencias.
using Entidad;
// Importa dependencias.
using Negocio;
// Importa dependencias.
using Presentacion.AAClases;
using Presentacion.Usuarios;

// Importa dependencias.
using System;
// Importa dependencias.
using System.Collections.Generic;
// Importa dependencias.
using System.Windows.Forms;
// Importa dependencias.
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Presentacion.Localidad
{
    public partial class PReg : Form
    {
        ELocReg Ent = new ELocReg(); // Crea una nueva región
        NLocReg Neg = new NLocReg(); // Instancia la lógica de región

        public PReg()
        {
            InitializeComponent();
        }

        // Manejador del evento 'Load' para el formulario 'PReg'.
        private void PReg_Load(object sender, EventArgs e)
        {
            // Itera sobre cada columna en la `Grilla` (DataGridView).
            foreach (DataGridViewColumn columna in Grilla.Columns)
            {
                // Verifica si la columna es visible y no se llama "Selec".
                if (columna.Visible == true && columna.Name != "Selec")
                {
                    // Agrega un nuevo elemento al 'ComboBusReg' para filtrar por columnas.
                    ComboBusReg.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            // Establece la propiedad 'DisplayMember' del 'ComboBusReg' a "Texto".
            ComboBusReg.DisplayMember = "Texto";
            // Establece la propiedad 'ValueMember' del 'ComboBusReg' a "Valor".
            ComboBusReg.ValueMember = "Valor";
            // Selecciona el primer elemento en el 'ComboBusReg'.
            ComboBusReg.SelectedIndex = 0;
            // Llama al método para cargar los datos en la grilla.
            CarDat();
            ThemeManager.ApplyExecutiveTheme(this); // Aplica tema ejecutivo.
            ConfigurarPermisosRegion(); // Configura permisos de usuario.
        }
        private void ConfigurarPermisosRegion()
        {
            var permisos = Sesion.Permisos;

            if (permisos != null)
            {
                CheckIng.Visible = (permisos.ILReg == "SI");
                CheckMod.Visible = (permisos.ALReg == "SI");
                CheckEli.Visible = (permisos.ELReg == "SI");
            }
            else
            {
                CheckIng.Visible = false;
                CheckMod.Visible = false;
                CheckEli.Visible = false;
            }
        }
        // Método para cargar los datos de regiones en la `Grilla`.
        public void CarDat()
        {
            // Inicia un bloque 'try-catch' para manejar posibles excepciones.
            try
            {
                // Limpia todas las filas existentes en la `Grilla`.
                Grilla.Rows.Clear();
                // Crea una nueva instancia de 'NLocReg' y obtiene la lista de regiones.
                List<ELocReg> Listar = new NLocReg().Listar();
                // Itera sobre cada 'item' (región) en la lista obtenida.
                foreach (ELocReg item in Listar)
                {
                    // Agrega una nueva fila a la `Grilla` con el Id y el Nombre de la región.
                    Grilla.Rows.Add(new object[] { "", item.IdReg, item.Nombre });
                }
            }
            // Captura cualquier excepción que ocurra durante la carga de datos.
            catch (Exception ex)
            {
                // Muestra un mensaje de error al usuario.
                MessageBox.Show(ex.Message);
            }
            // Borra cualquier selección actual en la `Grilla`.
            Grilla.ClearSelection();
        }

        // Método para validar la entrada y controlar el estado de los botones.
        public void Validar()
        {
            // Comprueba si el texto en 'TextIngMod' (sin espacios iniciales/finales) no está vacío.
            if (TextIngMod.Text.Trim() != "")
            {
                // Si no está vacío, habilita los botones 'ButIng', 'ButMod' y 'ButEli'.
                ButIng.Enabled = true;
                ButMod.Enabled = true;
                ButEli.Enabled = true;
            }
            // Si el texto en 'TextIngMod' está vacío.
            else
            {
                // Deshabilita los botones 'ButIng', 'ButMod' y 'ButEli'.
                ButIng.Enabled = false;
                ButMod.Enabled = false;
                ButEli.Enabled = false;
            }
        }

        // Método para restablecer la visibilidad de todas las filas de la `Grilla`.
        public void ResetGrid()
        {
            // Itera sobre cada fila en la `Grilla`.
            foreach (DataGridViewRow row in Grilla.Rows)
            {
                // Establece la propiedad 'Visible' de la fila a 'true'.
                row.Visible = true;
            }
        }

        // Método para inicializar el estado de los checkboxes de funciones (Ingresar, Modificar, Eliminar).
        public void Check_funciones()
        {
            // Desmarca el checkbox 'CheckIng'.
            CheckIng.CheckState = CheckState.Unchecked;
            // Desmarca el checkbox 'CheckMod'.
            CheckMod.CheckState = CheckState.Unchecked;
            // Desmarca el checkbox 'CheckEli'.
            CheckEli.CheckState = CheckState.Unchecked;
            // Habilita el checkbox 'CheckIng'.
            CheckIng.Enabled = true;
            // Deshabilita el checkbox 'CheckMod'.
            CheckMod.Enabled = false;
            // Deshabilita el checkbox 'CheckEli'.
            CheckEli.Enabled = false;
        }

        // Manejador del evento 'Click' para el botón 'ButBus' (Buscar).
        private void ButBus_Click(object sender, EventArgs e)
        {
            // Obtiene el nombre de la columna seleccionada para filtrar desde 'ComboBusReg'.
            string columnaFiltro = ((Filtrar)ComboBusReg.SelectedItem).Valor.ToString();

            // Verifica si la `Grilla` contiene alguna fila.
            if (Grilla.Rows.Count > 0)
            {
                // Itera sobre cada fila en la `Grilla`.
                foreach (DataGridViewRow row in Grilla.Rows)
                {
                    // Comprueba si el valor de la celda en la columna de filtro contiene el texto de búsqueda.
                    // Se realiza una comparación sin distinguir mayúsculas de minúsculas y sin espacios.
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper()))
                        // Si hay coincidencia, hace la fila visible.
                        row.Visible = true;
                    else
                        // Si no hay coincidencia, oculta la fila.
                        row.Visible = false;
                }
            }
        }

        // Manejador del evento 'TextChanged' para el cuadro de texto 'TextBus'.
        private void TextBus_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto en 'TextBus' a formato de título (primera letra de cada palabra en mayúscula).
            TextBus.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBus.Text);
            // Establece la posición del cursor al final del texto en 'TextBus'.
            TextBus.SelectionStart = TextBus.Text.Length;
            // Llama al método 'Validar' para actualizar el estado de los botones.
            Validar();
        }

        // Manejador del evento 'Click' para el botón 'ButLimBus' (Limpiar Búsqueda).
        private void ButLimBus_Click(object sender, EventArgs e)
        {
            // Limpia el contenido del cuadro de texto 'TextBus'.
            TextBus.Text = "";
            // Llama al método 'CarDat' para recargar todos los datos en la grilla.
            CarDat();
        }

        // Manejador del evento 'DoubleClick' para la `Grilla`.
        private void Grilla_DoubleClick(object sender, EventArgs e)
        {
            // Limpia el contenido del cuadro de texto 'textId'.
            textId.Clear();
            // Limpia el contenido del cuadro de texto 'TextIngMod'.
            TextIngMod.Clear();
            // Habilita el checkbox 'CheckMod'.
            CheckMod.Enabled = true;
            // Habilita el checkbox 'CheckEli'.
            CheckEli.Enabled = true;
            // Desmarca el checkbox 'CheckIng'.
            CheckIng.CheckState = CheckState.Unchecked;
            // Deshabilita el checkbox 'CheckIng'.
            CheckIng.Enabled = false;
            // Desmarca el checkbox 'CheckMod'.
            CheckMod.CheckState = CheckState.Unchecked;
            // Desmarca el checkbox 'CheckEli'.
            CheckEli.CheckState = CheckState.Unchecked;
            // Asigna el valor de la segunda celda de la fila actual de la grilla a 'textId'.
            textId.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString();
            // Asigna el valor de la tercera celda de la fila actual de la grilla a 'TextIngMod'.
            TextIngMod.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString();
        }

        // Este método se activa cuando cambia el estado del checkbox 'CheckIng' (Ingresar).
        private void CheckIng_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox 'CheckIng' está marcado.
            if (CheckIng.CheckState == CheckState.Checked)
            {
                // Desmarca los checkboxes 'CheckMod' y 'CheckEli'.
                CheckMod.CheckState = CheckState.Unchecked;
                CheckEli.CheckState = CheckState.Unchecked;
                // Cambia el texto de la etiqueta 'label7' a "Ingresar Región:".
                label7.Text = "Ingresar Región:";
                // Habilita el cuadro de texto 'TextIngMod'.
                TextIngMod.Enabled = true;
                // Limpia el contenido del cuadro de texto 'TextIngMod'.
                TextIngMod.Clear();
                // Limpia el contenido del cuadro de texto 'textId'.
                textId.Clear();
                // Hace visible el botón 'ButIng'.
                ButIng.Visible = true;
            }
            // Si el checkbox 'CheckIng' no está marcado.
            else
            {
                // Limpia el texto de la etiqueta 'label7'.
                label7.Text = "";
                // Oculta el botón 'ButIng'.
                ButIng.Visible = false;
            }
            // Llama al método 'Validar' para actualizar el estado de los botones.
            Validar();
        }

        // Este método se activa cuando cambia el estado del checkbox 'CheckMod' (Modificar).
        private void CheckMod_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox 'CheckMod' está marcado.
            if (CheckMod.CheckState == CheckState.Checked)
            {
                // Desmarca los checkboxes 'CheckIng' y 'CheckEli'.
                CheckIng.CheckState = CheckState.Unchecked;
                CheckEli.CheckState = CheckState.Unchecked;
                // Cambia el texto de la etiqueta 'label7' a "Actualizar Región:".
                label7.Text = "Actualizar Región:";
                // Habilita el cuadro de texto 'TextIngMod'.
                TextIngMod.Enabled = true;
                // Hace visible el botón 'ButMod'.
                ButMod.Visible = true;
            }
            // Si el checkbox 'CheckMod' no está marcado.
            else
            {
                // Limpia el texto de la etiqueta 'label7'.
                label7.Text = "";
                // Oculta el botón 'ButMod'.
                ButMod.Visible = false;
            }
            // Llama al método 'Validar' para actualizar el estado de los botones.
            Validar();
        }

        // Este método se activa cuando cambia el estado del checkbox 'CheckEli' (Eliminar).
        private void CheckEli_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox 'CheckEli' está marcado.
            if (CheckEli.CheckState == CheckState.Checked)
            {
                // Desmarca los checkboxes 'CheckIng' y 'CheckMod'.
                CheckIng.CheckState = CheckState.Unchecked;
                CheckMod.CheckState = CheckState.Unchecked;
                // Cambia el texto de la etiqueta 'label7' a "Eliminar Región:".
                label7.Text = "Eliminar Región:";
                // Deshabilita el cuadro de texto 'TextIngMod'.
                TextIngMod.Enabled = false;
                // Hace visible el botón 'ButEli'.
                ButEli.Visible = true;
            }
            // Si el checkbox 'CheckEli' no está marcado.
            else
            {
                // Limpia el texto de la etiqueta 'label7'.
                label7.Text = "";
                // Oculta el botón 'ButEli'.
                ButEli.Visible = false;
            }
            // Llama al método 'Validar' para actualizar el estado de los botones.
            Validar();
        }

        // Maneja tecla presionada en campo.
        private void TextIngMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla es un dígito.
            if (char.IsDigit(e.KeyChar))
            {
                // Bloquea entrada, muestra error.
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja cambio de texto en campo.
        private void TextIngMod_TextChanged(object sender, EventArgs e)
        {
            // Capitaliza texto, mueve cursor.
            TextIngMod.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextIngMod.Text);
            TextIngMod.SelectionStart = TextIngMod.Text.Length;
            // Llama a Validar.
            Validar();
        }

        // Maneja cambio en ComboBox de búsqueda.
        private void ComboBusReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llama a Validar.
            Validar();
        }

        // Al hacer clic en botón Ingresar.
        private void ButIng_Click(object sender, EventArgs e)
        {
            // Pide confirmación de la acción.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            // Asigna nombre de región.
            Ent.Nombre = TextIngMod.Text;
            // Si usuario confirma "Sí".
            if (res == DialogResult.Yes)
            {
                // Intenta ingresar la región.
                Respuesta<bool> resultado = NLocReg.Ingresar(Ent);

                // Si el ingreso fue exitoso.
                if (resultado.estado)
                {
                    // Muestra mensaje de éxito.
                    MessageBox.Show("Ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Simula clic en botón Limpiar.
                    ButLim.PerformClick();
                }
                // Si el ingreso falló.
                else
                {
                    // Muestra mensaje de error.
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario confirma "No".
            else if (res == DialogResult.No)
            {
                // Enfoca botón Volver.
                ButVol.Focus();
            }
            // Si usuario selecciona "Cancelar".
            else if (res == DialogResult.Cancel)
            {
                // Enfoca botón Salir.
                ButSal.Focus();
            }
            // Limpia filas de la grilla.
            Grilla.Rows.Clear();
            // Recarga datos en la grilla.
            CarDat();
        }

        // Al hacer clic en botón Modificar.
        private void ButMod_Click(object sender, EventArgs e)
        {
            // Pide confirmación de la acción.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            // Convierte ID y asigna.
            Ent.IdReg = Convert.ToInt32(textId.Text);
            // Asigna nombre de región.
            Ent.Nombre = TextIngMod.Text;
            // Si usuario confirma "Sí".
            if (res == DialogResult.Yes)
            {
                // Intenta actualizar la región.
                Respuesta<bool> resultado = NLocReg.Actualizar(Ent);
                // Si actualización fue correcta.
                if (resultado.estado)
                {
                    // Muestra mensaje de éxito.
                    MessageBox.Show("Actualización fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Simula clic en botón Limpiar.
                    ButLim.PerformClick();
                }
                // Si actualización falló.
                else
                {
                    // Muestra mensaje de error.
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario confirma "No".
            else if (res == DialogResult.No)
            {
                // Enfoca botón Volver.
                ButVol.Focus();
            }
            // Si usuario selecciona "Cancelar".
            else if (res == DialogResult.Cancel)
            {
                // Enfoca botón Salir.
                ButSal.Focus();
            }
            // Limpia filas de la grilla.
            Grilla.Rows.Clear();
            // Recarga datos en la grilla.
            CarDat();
        }
        // Al hacer clic en botón Eliminar.
        private void ButEli_Click(object sender, EventArgs e)
        {
            // Pregunta confirmación de acción.
            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            // Si usuario confirma "Sí".
            if (res == DialogResult.Yes)
            {
                // Declara variable para ID.
                int Id;
                // Intenta convertir texto a ID.
                if (int.TryParse(textId.Text, out Id))
                {
                    // Llama a método Eliminar.
                    Respuesta<bool> resultado = NLocReg.Eliminar(Id);
                    // Si la eliminación fue correcta.
                    if (resultado.estado)
                    {
                        // Muestra éxito de eliminación.
                        MessageBox.Show("La eliminación se realizó correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Simula clic en botón Limpiar.
                        ButLim.PerformClick();
                    }
                    // Si la eliminación falló.
                    else
                    {
                        // Muestra error de eliminación.
                        MessageBox.Show("No se pudo eliminar el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Si ID no es válido.
                else
                {
                    // Pide seleccionar registro válido.
                    MessageBox.Show("Seleccione un registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario selecciona "No".
            else if (res == DialogResult.No)
            {
                // Enfoca el botón Volver.
                ButVol.Focus();
            }
            // Si usuario selecciona "Cancelar".
            else if (res == DialogResult.Cancel)
            {
                // Enfoca el botón Salir.
                ButSal.Focus();
            }
            // Limpia todas las filas de la grilla.
            Grilla.Rows.Clear();
            // Recarga los datos de la grilla.
            CarDat();
        }

        // Al hacer clic en botón Limpiar.
        private void ButLim_Click(object sender, EventArgs e)
        {
            // Limpia campo de ID.
            textId.Clear();
            // Limpia campo de ingreso/modificación.
            TextIngMod.Clear();
            // Deshabilita campo de ingreso/modificación.
            TextIngMod.Enabled = false;
            // Limpia campo de búsqueda.
            TextBus.Text = "";
            // Asegura campo ingreso/modificación deshabilitado.
            TextIngMod.Enabled = false;
            // Restablece visibilidad de la grilla.
            ResetGrid();
            // Reinicia checkboxes de funciones.
            Check_funciones();
            // Carga datos en la grilla.
            CarDat();
            // Valida estado de botones.
            Validar();
        }

        private void ButVol_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual y vuelve al formulario anterior
        }

        private void ButSal_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra la aplicación
        }
    }
}


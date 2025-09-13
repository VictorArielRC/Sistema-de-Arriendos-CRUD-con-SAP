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


namespace Presentacion.Localidad
{
    public partial class PPro : Form
    {
        // Crea entidad Ubicación/Provincia.
        ELocPro Ent = new ELocPro();
        // Crea negocio Ubicación/Provincia.
        NLocPro Neg = new NLocPro();
        // Crea negocio Regiones.
        NLocReg NegReg = new NLocReg();
        public PPro()
        {
            InitializeComponent();
        }

        // Maneja el evento de carga del formulario PPro.
        private void PPro_Load(object sender, EventArgs e)
        {
            // Itera a través de cada columna en la grilla.
            foreach (DataGridViewColumn columna in Grilla.Columns)
            {
                // Si la columna es visible y no se llama "Selec".
                if (columna.Visible == true && columna.Name != "Selec")
                {
                    // Agrega un nuevo ítem al ComboBox de búsqueda.
                    ComboBusReg.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            // Establece la propiedad a mostrar en el ComboBox.
            ComboBusReg.DisplayMember = "Texto";
            // Establece el valor interno del ComboBox.
            ComboBusReg.ValueMember = "Valor";
            // Selecciona el primer ítem del ComboBox.
            ComboBusReg.SelectedIndex = 0;
            // Carga los datos en la grilla.
            CarDat();
            // Llena el ComboBox de regiones.
            LleComReg();
            ThemeManager.ApplyExecutiveTheme(this); // Aplica tema ejecutivo.
        }

        // Método para cargar datos en el control `Grilla` (probablemente un DataGridView).
        public void CarDat()
        {
            // Bloque `try-catch` para manejar posibles errores durante la operación.
            try
            {
                // Limpia todas las filas existentes en la `Grilla`.
                Grilla.Rows.Clear();
                // Obtiene una lista de objetos `ELocPro` desde la capa de negocio `NLocPro`.
                List<ELocPro> Listar = new NLocPro().Listar();
                // Itera sobre cada `item` (objeto `ELocPro`) en la lista obtenida.
                foreach (ELocPro item in Listar)
                {
                    // Agrega una nueva fila a la `Grilla` con los datos del `item`.
                    Grilla.Rows.Add(new object[] { "", item.IdPro, item.Nombre, item.IdReg, item.Reg.Nombre });
                }
            }
            // Captura cualquier excepción que ocurra dentro del bloque `try`.
            catch (Exception ex)
            {
                // Muestra un mensaje de error al usuario con el detalle de la excepción.
                MessageBox.Show(ex.Message);
            }
            // Deselecciona cualquier fila que esté actualmente seleccionada en la `Grilla`.
            Grilla.ClearSelection();
        }

        // Método para validar la entrada del usuario y controlar el estado de los botones.
        public void Validar()
        {
            // Comprueba si el campo de texto `TextIngMod` no está vacío después de quitar espacios.
            if (TextIngMod.Text.Trim() != "")
            {
                // Si `TextIngMod` y `ComboIngMod` coinciden con los valores de consulta.
                if ((TextIngMod.Text == textConPro.Text) && (ComboIngMod.Text == textConReg.Text))
                {
                    // Deshabilita el botón de Modificar.
                    ButMod.Enabled = false;
                    // Deshabilita el botón de Ingresar.
                    ButIng.Enabled = false;
                }
                // Si `TextIngMod` y `ComboIngMod` no coinciden con los valores de consulta.
                else
                {
                    // Habilita el botón de Modificar.
                    ButMod.Enabled = true;
                    // Habilita el botón de Ingresar.
                    ButIng.Enabled = true;
                }
            }
            // Si el campo de texto `TextIngMod` está vacío.
            else
            {
                // Deshabilita el botón de Ingresar.
                ButIng.Enabled = false;
                // Deshabilita el botón de Modificar.
                ButMod.Enabled = false;
                // Deshabilita el botón de Eliminar.
                ButEli.Enabled = false;
            }
        }

        // Método para cargar el ComboBox de Regiones.
        public void LleComReg()
        {
            // Establece la propiedad que se mostrará en el ComboBox (el "Nombre" de la región).
            ComboIngMod.DisplayMember = "Nombre";
            // Establece la propiedad que se usará como valor interno (el "IdReg" de la región).
            ComboIngMod.ValueMember = "IdReg";
            // Asigna los datos al ComboBox obteniéndolos desde la capa de negocio `NegReg`.
            ComboIngMod.DataSource = NegReg.Listar();
        }

        // Método para restablecer la visibilidad de todas las filas en la grilla.
        public void ResetGrid()
        {
            // Itera sobre cada fila en la `Grilla`.
            foreach (DataGridViewRow row in Grilla.Rows)
            {
                // Establece la propiedad `Visible` de la fila a `true` (visible).
                row.Visible = true;
            }
        }

        // Método para inicializar el estado de los checkboxes de función (Ingresar, Modificar, Eliminar).
        public void Check_funciones()
        {
            // Desmarca el checkbox de Ingresar.
            CheckIng.CheckState = CheckState.Unchecked;
            // Desmarca el checkbox de Modificar.
            CheckMod.CheckState = CheckState.Unchecked;
            // Desmarca el checkbox de Eliminar.
            CheckEli.CheckState = CheckState.Unchecked;
            // Habilita el checkbox de Ingresar.
            CheckIng.Enabled = true;
            // Deshabilita el checkbox de Modificar.
            CheckMod.Enabled = false;
            // Deshabilita el checkbox de Eliminar.
            CheckEli.Enabled = false;
        }

        // Manejador de evento para el clic en el botón de Búsqueda (`ButBus`).
        private void ButBus_Click(object sender, EventArgs e)
        {
            // Obtiene el nombre de la columna por la cual se va a filtrar, desde el ComboBox `ComboBusReg`.
            string columnaFiltro = ((Filtrar)ComboBusReg.SelectedItem).Valor.ToString();
            // Verifica si la `Grilla` contiene alguna fila.
            if (Grilla.Rows.Count > 0)
            {
                // Itera sobre cada fila en la `Grilla`.
                foreach (DataGridViewRow row in Grilla.Rows)
                {
                    // Comprueba si el valor de la celda en la `columnaFiltro` contiene el texto de búsqueda (ignorando mayúsculas/minúsculas y espacios).
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper()))
                        // Si hay coincidencia, hace la fila visible.
                        row.Visible = true;
                    else
                        // Si no hay coincidencia, oculta la fila.
                        row.Visible = false;
                }
            }
        }

        // Define el método para el evento de presionar una tecla en el cuadro de texto 'TextBus'.
        private void TextBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Comprueba si el carácter presionado es un dígito.
            if (char.IsDigit(e.KeyChar))
            {
                // Si es un dígito, indica que el evento ha sido manejado, lo que previene que el carácter se muestre.
                e.Handled = true;
                // Muestra un cuadro de mensaje de error al usuario.
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Define el método para el evento de cambio de texto en el cuadro de texto 'TextBus'.
        private void TextBus_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto del cuadro a formato de "Título" (la primera letra de cada palabra en mayúscula).
            TextBus.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextBus.Text);
            // Establece la posición del cursor al final del texto actual.
            TextBus.SelectionStart = TextBus.Text.Length;
            // Llama a un método llamado 'Validar', probablemente para realizar validaciones o actualizar la interfaz.
            Validar();
        }

        // Define el método para el evento de clic en el botón 'ButLimBus' (Botón Limpiar Búsqueda).
        private void ButLimBus_Click(object sender, EventArgs e)
        {
            // Limpia el contenido del cuadro de texto 'TextBus'.
            TextBus.Text = "";
            // Llama a un método llamado 'CarDat', que probablemente recarga los datos en una grilla.
            CarDat();
        }

        // Define el método para el evento de doble clic en la grilla de datos 'Grilla'.
        private void Grilla_DoubleClick(object sender, EventArgs e)
        {
            // Limpia el contenido del cuadro de texto 'textId'.
            textId.Clear();
            // Limpia el contenido del cuadro de texto 'TextIngMod'.
            TextIngMod.Clear();
            // Habilita el control 'CheckMod' (checkbox de Modificar).
            CheckMod.Enabled = true;
            // Habilita el control 'CheckEli' (checkbox de Eliminar).
            CheckEli.Enabled = true;
            // Desmarca el control 'CheckIng' (checkbox de Ingresar).
            CheckIng.CheckState = CheckState.Unchecked;
            // Deshabilita el control 'CheckIng'.
            CheckIng.Enabled = false;
            // Desmarca el control 'CheckMod'.
            CheckMod.CheckState = CheckState.Unchecked;
            // Desmarca el control 'CheckEli'.
            CheckEli.CheckState = CheckState.Unchecked;
            // Asigna el valor de la celda [1] de la fila actual de la grilla al cuadro de texto 'textId'.
            textId.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString();
            // Asigna el valor de la celda [2] de la fila actual de la grilla al cuadro de texto 'textConPro'.
            textConPro.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString();
            // Asigna el valor de la celda [2] de la fila actual de la grilla al cuadro de texto 'TextIngMod'.
            TextIngMod.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString();
            // Asigna el valor de la celda [4] de la fila actual de la grilla al cuadro de texto 'textConReg'.
            textConReg.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString();
            // Asigna el valor de la celda [4] de la fila actual de la grilla al cuadro combinado 'ComboIngMod'.
            ComboIngMod.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString();
            // Deshabilita el cuadro de texto 'TextIngMod'.
            TextIngMod.Enabled = false;
            // Deshabilita el cuadro combinado 'ComboIngMod'.
            ComboIngMod.Enabled = false;
        }

        // Define el método para el evento de cambio de estado del checkbox 'CheckIng' (Ingresar).
        private void CheckIng_CheckedChanged(object sender, EventArgs e)
        {
            // Comprueba si el checkbox 'CheckIng' está marcado.
            if (CheckIng.CheckState == CheckState.Checked)
            {
                // Desmarca el checkbox 'CheckMod'.
                CheckMod.CheckState = CheckState.Unchecked;
                // Desmarca el checkbox 'CheckEli'.
                CheckEli.CheckState = CheckState.Unchecked;
                // Cambia el texto de la etiqueta 'label7'.
                label7.Text = "Ingresar Región:";
                // Habilita el cuadro de texto 'TextIngMod'.
                TextIngMod.Enabled = true;
                // Habilita el cuadro combinado 'ComboIngMod'.
                ComboIngMod.Enabled = true;
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
            // Llama al método 'Validar'.
            Validar();
        }

        // Define el método para el evento de cambio de estado del checkbox 'CheckMod' (Modificar).
        private void CheckMod_CheckedChanged(object sender, EventArgs e)
        {
            // Comprueba si el checkbox 'CheckMod' está marcado.
            if (CheckMod.CheckState == CheckState.Checked)
            {
                // Desmarca el checkbox 'CheckIng'.
                CheckIng.CheckState = CheckState.Unchecked;
                // Desmarca el checkbox 'CheckEli'.
                CheckEli.CheckState = CheckState.Unchecked;
                // Cambia el texto de la etiqueta 'label7'.
                label7.Text = "Actualizar Región:";
                // Habilita el cuadro de texto 'TextIngMod'.
                TextIngMod.Enabled = true;
                // Habilita el cuadro combinado 'ComboIngMod'.
                ComboIngMod.Enabled = true;
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
            // Llama al método 'Validar'.
            Validar();
        }

        // Define el método para el evento de cambio de estado del checkbox 'CheckEli' (Eliminar).
        private void CheckEli_CheckedChanged(object sender, EventArgs e)
        {
            // Comprueba si el checkbox 'CheckEli' está marcado.
            if (CheckEli.CheckState == CheckState.Checked)
            {
                // Desmarca el checkbox 'CheckIng'.
                CheckIng.CheckState = CheckState.Unchecked;
                // Desmarca el checkbox 'CheckMod'.
                CheckMod.CheckState = CheckState.Unchecked;
                // Cambia el texto de la etiqueta 'label7'.
                label7.Text = "Eliminar Región:";
                // Deshabilita el cuadro de texto 'TextIngMod'.
                TextIngMod.Enabled = false;
                // Hace visible el botón 'ButEli'.
                ButEli.Visible = true;
                // Habilita el botón 'ButEli'.
                ButEli.Enabled = true;
            }
            // Si el checkbox 'CheckEli' no está marcado.
            else
            {
                // Limpia el texto de la etiqueta 'label7'.
                label7.Text = "";
                // Oculta el botón 'ButEli'.
                ButEli.Visible = false;
                // Deshabilita el botón 'ButEli'.
                ButEli.Enabled = false;
            }
        }

        // Define el método para el evento de cambio de selección en el cuadro combinado 'ComboIngMod'.
        private void ComboIngMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llama al método 'Validar'.
            Validar();
        }

        // Evento cuando tecla es presionada.
        private void TextIngMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si la tecla es un dígito.
            if (char.IsDigit(e.KeyChar))
            {
                // Bloquea entrada del dígito.
                e.Handled = true;
                // Muestra error: "Solo letras".
                MessageBox.Show("Solo se permiten letras.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento cuando texto cambia.
        private void TextIngMod_TextChanged(object sender, EventArgs e)
        {
            // Convierte texto a título (capitaliza).
            TextIngMod.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TextIngMod.Text);
            // Mueve cursor al final.
            TextIngMod.SelectionStart = TextIngMod.Text.Length;
            // Llama a función Validar.
            Validar();
        }

        // Define método para clic de ButIng.
        private void ButIng_Click(object sender, EventArgs e)
        {
            // Muestra cuadro confirmación acción.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            // Declara 'Mensaje', no se usa.
            string Mensaje = string.Empty;

            // Asigna nombre de texto 'Ent'.
            Ent.Nombre = TextIngMod.Text;

            // Asigna ID de combo 'Ent'.
            Ent.IdReg = Convert.ToInt32(ComboIngMod.SelectedValue);

            // Si usuario responde "Sí".
            if (res == DialogResult.Yes)
            {
                // Llama a 'Ingresar' con 'Ent'.
                Respuesta<bool> resultado = NLocPro.Ingresar(Ent);

                // Si ingreso fue exitoso.
                if (resultado.estado)
                {
                    // Muestra mensaje: "Ingreso correcto".
                    MessageBox.Show("Ingreso fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Simula clic botón 'ButLim'.
                    ButLim.PerformClick();
                }
                // Si ingreso no fue exitoso.
                else
                {
                    // Muestra mensaje: "Registro no válido".
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si usuario responde "No".
            else if (res == DialogResult.No)
            {
                // Pone foco en 'ButVol'.
                ButVol.Focus();
            }
            // Si usuario responde "Cancelar".
            else if (res == DialogResult.Cancel)
            {
                // Pone foco en 'ButSal'.
                ButSal.Focus();
            }

            // Limpia todas las filas de Grilla.
            Grilla.Rows.Clear();

            // Llama función para cargar datos.
            CarDat();
        }

        private void ButMod_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo de confirmación al usuario.
            // Pregunta "¿Está seguro de la acción a realizar?" con título "Sistema.", botones Sí/No/Cancelar y un ícono de advertencia.
            var res = MessageBox.Show("Esta seguro de la acción a realizar?", "Sistema.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            // Declara una variable string llamada Mensaje y la inicializa como vacía.
            string Mensaje = string.Empty;

            // Convierte el texto del control 'textId' a un entero y lo asigna a la propiedad 'IdPro' del objeto 'Ent'.
            Ent.IdPro = Convert.ToInt32(textId.Text);

            // Asigna el texto del control 'TextIngMod' a la propiedad 'Nombre' del objeto 'Ent'.
            Ent.Nombre = TextIngMod.Text;

            // Convierte el valor seleccionado del control 'ComboIngMod' a un entero y lo asigna a la propiedad 'IdReg' del objeto 'Ent'.
            Ent.IdReg = Convert.ToInt32(ComboIngMod.SelectedValue);

            // Comprueba si la respuesta del cuadro de diálogo fue "Sí".
            if (res == DialogResult.Yes)
            {
                // Llama al método 'Actualizar' del objeto 'NLocPro' con el objeto 'Ent' y guarda el resultado.
                Respuesta<bool> resultado = NLocPro.Actualizar(Ent);

                // Comprueba si la actualización fue exitosa (si la propiedad 'estado' del resultado es verdadera).
                if (resultado.estado)
                {
                    // Muestra un mensaje de éxito: "Actualización fue realizado correctamente".
                    MessageBox.Show("Actualización fue realizado correctamente", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Simula un clic en el botón 'ButLim' (limpiar).
                    ButLim.PerformClick();
                }
                // Si la actualización no fue exitosa.
                else
                {
                    // Muestra un mensaje de error: "Seleccione un registro válido".
                    MessageBox.Show("Seleccione un registro valido", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Si la respuesta del cuadro de diálogo fue "No".
            else if (res == DialogResult.No)
            {
                // Establece el foco en el botón 'ButVol' (volver).
                ButVol.Focus();
            }
            // Si la respuesta del cuadro de diálogo fue "Cancelar".
            else if (res == DialogResult.Cancel)
            {
                // Establece el foco en el botón 'ButSal' (salir).
                ButSal.Focus();
            }

            // Limpia todas las filas de la grilla de datos.
            Grilla.Rows.Clear();

            // Llama a la función 'CarDat' para recargar los datos en la grilla.
            CarDat();
        }

        private void ButEli_Click(object sender, EventArgs e) // evento que se ejecuta al hacer clic en el botón de eliminar
        {
            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // muestra un mensaje de confirmación antes de eliminar el registro
            if (res == DialogResult.Yes) // si se presiona sí
            {
                int Id; // declara una variable para almacenar el Id del registro a eliminar
                if (int.TryParse(textId.Text, out Id)) // intenta convertir el texto a entero
                {
                    Respuesta<bool> resultado = NLocPro.Eliminar(Id); // intenta eliminar el registro seleccionado
                    if (resultado.estado) // si se eliminó correctamente
                    {
                        MessageBox.Show("La eliminación se realizó correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // si se eliminó correctamente
                        ButLim.PerformClick();  // limpia los campos de texto
                    }
                    else // si no se pudo eliminar el registro
                    {
                        MessageBox.Show("No se pudo eliminar el registro", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning); // si no se pudo eliminar el registro
                    }
                }
                else
                // si no se puede convertir el texto a entero
                {
                    MessageBox.Show("Seleccione un registro válido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // si no se selecciona un registro válido
                }
            }
            else if (res == DialogResult.No) // si se presiona no
            {
                ButVol.Focus(); // si se presiona no, vuelve al formulario actual
            }
            else if (res == DialogResult.Cancel) // si se presiona cancelar
            {
                ButSal.Focus(); // cierra el formulario actual
            }
            Grilla.Rows.Clear(); // limpia la grilla
            CarDat(); // recarga la grilla
        }

        private void ButVol_Click(object sender, EventArgs e)
        {
            this.Close(); // cierra el formulario actual
        }

        private void ButLim_Click(object sender, EventArgs e)
        {
            textId.Clear(); // limpia el campo de texto de ingreso/modificación
            TextIngMod.Clear(); // limpia el campo de texto de ingreso/modificación
            textConPro.Clear(); // limpia el campo de texto de ingreso/modificación
            textConReg.Clear(); // limpia el campo de texto de ingreso/modificación
            TextIngMod.Enabled = false; // deshabilita el campo de texto de ingreso/modificación
            ComboIngMod.Enabled = false; // deshabilita el combo de ingreso/modificación
            ResetGrid(); // resetea la grilla
            Check_funciones();
            CarDat(); // recarga la grilla
            Validar(); // valida los botones de ingreso, modificación y eliminación
        }

        private void ButSal_Click(object sender, EventArgs e)
        {
            Application.Exit(); // sale del programa    
        }
    }
}

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
using System.ComponentModel;
// Accede a códigos de otra librería
using System.Data;
// Accede a códigos de otra librería
using System.Diagnostics.Eventing.Reader;
// Accede a códigos de otra librería
using System.Drawing;
// Accede a códigos de otra librería
using System.Linq;
// Accede a códigos de otra librería
using System.Text;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Presentacion.Productos
{
    public partial class PProd_Con : Form
    {
        EProd Ent = new EProd(); // Instancia de la entidad Producto.
        NProd Neg = new NProd(); // Instancia de la capa de negocio Producto.
                                 //public GenerarArr FormularioPadre; // Comentado: Referencia anterior a GenerarArr.
        private PProd_Car currentPProdCarInstance; // Instancia actual de PProd_Car.
        public PArrIng FormularioPadre; // Referencia al formulario padre PArrIng.

        public PProd_Con() // Constructor del formulario.
        {
            InitializeComponent(); // Inicializa los componentes.
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PProd_Con_Load(object sender, EventArgs e) // Evento al cargar el formulario.
        {
            if (FormularioPadre != null) // Si el formulario padre PArrIng está establecido.
            {
                ButCarProd.Visible = true; // Hace visible el botón "Cargar Producto".
                ButMod.Enabled = false;    // Deshabilita el botón "Modificar".
                ButEli.Enabled = false;    // Deshabilita el botón "Eliminar".
            }
            foreach (DataGridViewColumn columna in Grilla.Columns) // Itera sobre las columnas de la grilla.
            {
                if (columna.Visible == true && columna.Name != "Selec") // Si la columna es visible y no es "Selec".
                {
                    ComboBusReg.Items.Add(new Filtrar() { Valor = columna.Name, Texto = columna.HeaderText }); // Agrega columna al ComboBox de búsqueda.
                }
            }
            ComboBusReg.DisplayMember = "Texto"; // Establece la propiedad a mostrar en el ComboBox.
            ComboBusReg.ValueMember = "Valor";   // Establece el valor asociado en el ComboBox.
            ComboBusReg.SelectedIndex = 0;       // Selecciona el primer elemento por defecto.
            CarDat(); // Carga los datos en la grilla.
        }

        public void CarDat() // Carga los datos en la grilla.
        {
            try
            {
                Grilla.Rows.Clear(); // Limpia las filas existentes en la grilla.
                List<EProd> Listar = new NProd().Listar(); // Obtiene la lista de productos.
                foreach (EProd item in Listar) // Itera sobre cada producto.
                {
                    // Añade una nueva fila a la grilla con los datos del producto.
                    Grilla.Rows.Add(new object[] { "", item.IdProd, item.Nombre, item.FInc, item.CInc, item.CAct, item.CArr, item.TAct, item.VArr });
                }
                if (Grilla.Rows.Count > 1) // Si hay más de una fila (considerando la fila vacía inicial).
                {
                    Grilla.Rows[0].Visible = false; // Oculta la primera fila (fila vacía).
                }
            }
            catch (Exception ex) // Captura cualquier excepción.
            {
                MessageBox.Show(ex.Message); // Muestra el mensaje de error.
            }
            Grilla.ClearSelection(); // Deselecciona todas las celdas de la grilla.
        }

        public void ResetGrid() // Reinicia la visibilidad de las filas en la grilla.
        {
            foreach (DataGridViewRow row in Grilla.Rows) // Itera sobre cada fila de la grilla.
            {
                row.Visible = true; // Hace visible la fila.
            }
        }

        private void ButBus_Click(object sender, EventArgs e) // Evento clic en el botón Buscar.
        {
            string columnaFiltro = ((Filtrar)ComboBusReg.SelectedItem).Valor.ToString(); // Obtiene la columna seleccionada para filtrar.

            if (Grilla.Rows.Count > 0) // Si la grilla tiene filas.
            {
                foreach (DataGridViewRow row in Grilla.Rows) // Itera sobre cada fila de la grilla.
                {
                    // Compara el texto de la columna con el texto de búsqueda (ignorando mayúsculas/minúsculas y espacios).
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(TextBus.Text.Trim().ToUpper()))
                        row.Visible = true; // Hace visible la fila si coincide.
                    else
                        row.Visible = false; // Oculta la fila si no coincide.
                }
            }
        }

        public void Corroborar() // Corrobora la validez de la selección del producto.
        {
            // Verifica si el producto ya está cargado en alguno de los campos TextI.
            if ((TextBox1.Text.Trim() == TextI1.Text.Trim()) || (TextBox1.Text.Trim() == TextI2.Text.Trim()) || (TextBox1.Text.Trim() == TextI3.Text.Trim()) || (TextBox1.Text.Trim() == TextI4.Text.Trim()) || (TextBox1.Text.Trim() == TextI5.Text.Trim()) || (TextBox1.Text.Trim() == TextI6.Text.Trim()) || (TextBox1.Text.Trim() == TextI7.Text.Trim()) || (TextBox1.Text.Trim() == TextI8.Text.Trim()) || (TextBox1.Text.Trim() == TextI9.Text.Trim()) || (TextBox1.Text.Trim() == TextI10.Text.Trim()))
            {
                MessageBox.Show("Debe elegir un producto que no este cargado previamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra advertencia.
                ButCarProd.Enabled = false; // Deshabilita el botón "Cargar Producto".
            }
            else if ((TextI10.Text.Trim() != "")) // Si ya se han cargado 10 productos.
            {
                MessageBox.Show("No se puede cargar mas productos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra advertencia.
                ButCarProd.Enabled = false; // Deshabilita el botón "Cargar Producto".
            }
            else if ((textBox3.Text.Trim() == "0")) // Si el stock actual es cero.
            {
                MessageBox.Show("Debe elegir un producto que tenga Stock para Arrendar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra advertencia.
                ButCarProd.Enabled = false; // Deshabilita el botón "Cargar Producto".
            }
            else // Si todas las validaciones son correctas.
            {
                ButCarProd.Enabled = true; // Habilita el botón "Cargar Producto".
            }
        }

        private void Grilla_DoubleClick(object sender, EventArgs e) // Evento doble clic en la grilla.
        {
            ButMod.Enabled = true; // Habilita el botón "Modificar".
            ButEli.Enabled = true; // Habilita el botón "Eliminar".
            ButCarProd.Enabled = true; // Habilita el botón "Cargar Producto".
            TextBox1.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Asigna ID del producto seleccionado.
            textBox3.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Asigna stock actual del producto seleccionado.
            Corroborar(); // Corrobora la selección.
        }

        private void ButMod_Click(object sender, EventArgs e) // Evento clic en el botón Modificar.
        {
            PProd_Act pasar = new PProd_Act(); // Crea una nueva instancia del formulario de actualización.
            pasar.TextBox1.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Pasa ID.
            pasar.TextNomF.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Pasa Nombre (Final).
            pasar.TextNomI.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Pasa Nombre (Inicial).
            pasar.TextCIniF.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Pasa Cantidad Inicial (Final).
            pasar.TextCIniI.Text = this.Grilla.CurrentRow.Cells[4].Value.ToString(); // Pasa Cantidad Inicial (Inicial).
            pasar.TextCActF.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Pasa Cantidad Actual (Final).
            pasar.TextCActI.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Pasa Cantidad Actual (Inicial).
            pasar.TextCArrF.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Pasa Cantidad Arrendada (Final).
            pasar.TextCArrI.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Pasa Cantidad Arrendada (Inicial).
            pasar.TextTActF.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Pasa Total Actual (Final).
            pasar.TextTActI.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Pasa Total Actual (Inicial).
            pasar.TextVArrF.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Pasa Valor Arriendo (Final).
            pasar.TextVArrI.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Pasa Valor Arriendo (Inicial).
            pasar.LabelNom.Enabled = true; // Habilita Label de Nombre.
            pasar.LabelCanI.Enabled = true; // Habilita Label de Cantidad Inicial.
            pasar.LabeCAct.Enabled = true; // Habilita Label de Cantidad Actual.
            pasar.LabelCArr.Enabled = true; // Habilita Label de Cantidad Arrendada.
            pasar.LabelVArr.Enabled = true; // Habilita Label de Valor Arriendo.
            pasar.Validar(); // Llama al método de validación en el formulario de actualización.
            pasar.Show(); // Muestra el formulario de actualización.
            ButMod.Enabled = false; // Deshabilita el botón Modificar.
            ButEli.Enabled = false; // Deshabilita el botón Eliminar.
            ButCarProd.Enabled = false; // Deshabilita el botón Cargar Producto.
            this.Close(); // Cierra el formulario actual.
        }

        private void ButEli_Click(object sender, EventArgs e) // Evento clic en el botón Eliminar.
        {
            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); // Pide confirmación.
            if (res == DialogResult.Yes) // Si la respuesta es "Sí".
            {
                int Id; // Variable para almacenar el ID.
                if (int.TryParse(TextBox1.Text, out Id)) // Intenta convertir el ID a entero.
                {
                    Respuesta<bool> resultado = NProd.Eliminar(Id); // Intenta eliminar el producto.
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
            Grilla.Rows.Clear(); // Limpia las filas de la grilla.
            CarDat(); // Recarga los datos en la grilla.
        }

        private void ButCarProd_Click(object sender, EventArgs e) // Evento clic en el botón Cargar Producto.
        {
            if (Grilla.CurrentRow == null) // Si no hay ninguna fila seleccionada.
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista para cargar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra advertencia.
                return; // Sale del método.
            }
            if (currentPProdCarInstance != null && !currentPProdCarInstance.IsDisposed) // Si ya hay una instancia de PProd_Car abierta.
            {
                currentPProdCarInstance.Close(); // Cierra la instancia existente.
            }
            currentPProdCarInstance = new PProd_Car(); // Crea una nueva instancia de PProd_Car.
            currentPProdCarInstance.FormularioPadre = this.FormularioPadre; // Pasa la referencia del formulario padre PArrIng.
            currentPProdCarInstance.TextIPro.Text = this.Grilla.CurrentRow.Cells[1].Value.ToString(); // Pasa ID del producto.
            currentPProdCarInstance.TextNom.Text = this.Grilla.CurrentRow.Cells[2].Value.ToString(); // Pasa Nombre del producto.
            currentPProdCarInstance.TextCAct.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Pasa Cantidad Actual.
            currentPProdCarInstance.TeArrCan.Text = this.Grilla.CurrentRow.Cells[5].Value.ToString(); // Pasa Cantidad Actual (columna 5).
            currentPProdCarInstance.TextCArrA.Text = this.Grilla.CurrentRow.Cells[6].Value.ToString(); // Pasa Cantidad Arrendada (columna 6).
            currentPProdCarInstance.TextTAct.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Pasa Total Actual (columna 7).
            currentPProdCarInstance.TeTotCan.Text = this.Grilla.CurrentRow.Cells[7].Value.ToString(); // Pasa Total Actual (columna 7).
            currentPProdCarInstance.TextVArr.Text = this.Grilla.CurrentRow.Cells[8].Value.ToString(); // Pasa Valor de Arriendo.
            currentPProdCarInstance.Show(); // Muestra el formulario PProd_Car (manteniendo PProd_Con abierto).
            ButCarProd.Enabled = false; // Deshabilita el botón Cargar Producto.
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento clic en el botón Volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento clic en el botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }

        private void ButLimBus_Click(object sender, EventArgs e)
        {
            TextBus.Text = ""; // Limpia el textbox de búsqueda
            CarDat(); // Vuelve a cargar los datos
        }
    }
}

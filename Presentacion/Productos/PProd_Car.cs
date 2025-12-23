// Importa dependencias.
using Entidad;
// Importa dependencias.
using Negocio;
// Importa dependencias.
using Presentacion.ArriFinal; 
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
using System.Globalization;
// Importa dependencias.
using System.Linq;
// Importa dependencias.
using System.Text;
// Importa dependencias.
using System.Windows.Forms;



namespace Presentacion.Productos
{
    public partial class PProd_Car : Form
    {

        public Presentacion.ArriFinal.PArrIng FormularioPadre; // Referencia al formulario padre PArrIng.
        private NProd nProd = new NProd(); // Instancia de la capa de negocio Producto.

        public PProd_Car() // Constructor del formulario PProd_Car.
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
            TextNom.ReadOnly = true; // Hace el campo de nombre de solo lectura.
            TextVArr.ReadOnly = true; // Hace el campo de valor de arriendo de solo lectura.
            TextCArr.Text = "0"; // Establece la cantidad a arrendar inicialmente en "0".
            TextCArr.Focus(); // Pone el foco en el campo de cantidad a arrendar.
            ButAn.Enabled = false; // Deshabilita el botón "Añadir".
            butCal.Enabled = false; // Deshabilita el botón "Calcular".
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void PProd_Car_Load(object sender, EventArgs e) // Evento al cargar el formulario.
        {
            // No hay lógica implementada en este evento.
        }

        private void TextCArr_KeyPress(object sender, KeyPressEventArgs e) // Evento al presionar una tecla en el campo cantidad a arrendar.
        {
            if (char.IsLetter(e.KeyChar)) // Si la tecla presionada es una letra.
            {
                e.Handled = true; // Suprime la entrada de la tecla.
                MessageBox.Show("Solo se permiten numeros.", "Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
            }
        }

        public void HabBot() // Habilita o deshabilita los botones de cálculo y limpieza.
        {
            // Habilita los botones si todos los campos requeridos no están vacíos.
            if ((TextIPro.Text.Trim() != "") && (TextNom.Text.Trim() != "") && (TextCArr.Text.Trim() != "") && (TextCArrA.Text.Trim() != "") && (TextTAct.Text.Trim() != "") && (TextVArr.Text.Trim() != ""))
            {
                butCal.Enabled = true; // Habilita el botón "Calcular".
                butLim.Enabled = true; // Habilita el botón "Limpiar".
            }
            else // Si algún campo está vacío.
            {
                butCal.Enabled = false; // Deshabilita el botón "Calcular".
                butLim.Enabled = false; // Deshabilita el botón "Limpiar".
            }
        }

        private void TextCArr_TextChanged(object sender, EventArgs e) // Evento cuando cambia el texto en el campo cantidad a arrendar.
        {
            HabBot(); // Llama a la función para habilitar/deshabilitar botones.
                      // Lógica para el cálculo en tiempo real si el usuario cambia la cantidad.
            if (string.IsNullOrWhiteSpace(TextCArr.Text) || !int.TryParse(TextCArr.Text, out int cantidad)) // Si la cantidad es inválida o vacía.
            {
                TeTotCan.Text = "0"; // Reinicia el total a "0".
                ButAn.Enabled = false; // Deshabilita el botón "Añadir".
                butCal.Enabled = false; // Deshabilita el botón "Calcular".
                return; // Sale del método.
            }

            // Si el valor unitario no es vacío y es un número decimal válido.
            if (!string.IsNullOrWhiteSpace(TextVArr.Text) && decimal.TryParse(TextVArr.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valorUnitario))
            {
                decimal totalCalculado = cantidad * valorUnitario; // Calcula el total.
                TeTotCan.Text = totalCalculado.ToString("N0", CultureInfo.CurrentCulture); // Muestra el total formateado.
                butCal.Enabled = true; // Habilita el botón "Calcular".
            }
            else // Si el valor unitario es inválido.
            {
                TeTotCan.Text = "0"; // Reinicia el total a "0".
                ButAn.Enabled = false; // Deshabilita el botón "Añadir".
                butCal.Enabled = false; // Deshabilita el botón "Calcular".
            }
        }

        private void butLim_Click(object sender, EventArgs e) // Evento clic en el botón Limpiar.
        {
            LimpiarCamposPProdCarParaNuevoProducto(); // Limpia todos los campos del formulario.
            ButAn.Enabled = false; // Deshabilita el botón "Añadir".
            butCal.Enabled = false; // Deshabilita el botón "Calcular".
            TextCArr.Focus(); // Pone el foco en el campo de cantidad a arrendar.
        }

        private void butCal_Click(object sender, EventArgs e) // Evento clic en el botón Calcular.
        {
            if (TextCArr.Text.Trim() != "") // Si el campo de cantidad a arrendar no está vacío.
            {
                // Calcula el stock restante después de arrendar.
                Double resAct = double.Parse(TextTAct.Text) - double.Parse(TextCArr.Text);
                TextTAct.Text = resAct.ToString(); // Actualiza el campo de stock total actual.

                if (double.TryParse(TextTAct.Text, out double tActValue) && tActValue < 0) // Si el stock resultante es negativo.
                {
                    MessageBox.Show("Debe Ingresar una cantidad inferior a la cantidad actual", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
                    Double anular = double.Parse(TextTAct.Text) + double.Parse(TextCArr.Text); // Revierte el cálculo.
                    TextTAct.Text = anular.ToString(); // Restaura el stock total actual.
                    TextCArr.Text = ""; // Limpia la cantidad a arrendar.
                }
                else // Si la cantidad a arrendar es válida.
                {
                    Double Sumar = double.Parse(TextCArrA.Text) + double.Parse(TextCArr.Text); // Suma la cantidad arrendada actual con la nueva.
                    TextCArrF.Text = Sumar.ToString(); // Actualiza el campo de cantidad arrendada final.
                    Double Sumar2 = double.Parse(TextCArrA.Text) + double.Parse(TextCArr.Text); // Suma nuevamente (redundante, podría ser solo una variable).
                    TextCArrA.Text = Sumar2.ToString(); // Actualiza el campo de cantidad arrendada acumulada.
                    TextVArr.TabStop = true; // Habilita el tab en el valor de arriendo.
                    TextCAct.TabStop = false; // Deshabilita el tab en la cantidad actual.
                    ButAn.Enabled = true; // Habilita el botón "Añadir".
                }
            }
            else // Si el campo de cantidad a arrendar está vacío.
            {
                TextVArr.TabStop = false; // Deshabilita el tab en el valor de arriendo.
                TextCAct.TabStop = true; // Habilita el tab en la cantidad actual.
                ButAn.Enabled = false; // Deshabilita el botón "Añadir".
            }
            butCal.Enabled = false; // Deshabilita el botón "Calcular".
        }

        private void ButAn_Click(object sender, EventArgs e) // Evento clic en el botón Añadir.
        {
            int cantidadArrendar; // Cantidad del producto a arrendar en esta transacción.
            int stockOriginalProducto; // Stock actual del producto en la base de datos (o al cargar).
            decimal valorUnitarioProducto; // Valor unitario del producto.
            int idProducto; // ID del producto.
            string nombreProducto; // Nombre del producto.
            int cantidadArrendadaActual; // Cantidad ya registrada como arrendada para este producto (del campo TextCArrA).
            decimal valorTotalLinea; // Valor total de la línea de producto.

            // Validaciones de datos.
            if (TextIPro == null || string.IsNullOrWhiteSpace(TextIPro.Text) || !int.TryParse(TextIPro.Text, out idProducto)) // Valida ID de producto
            {
                MessageBox.Show("Error: No se pudo obtener el ID del producto (TextIPro vacío o inválido).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
                return; // Sale de la función
            }
            nombreProducto = TextNom.Text; // Obtiene el nombre del producto
            if (string.IsNullOrWhiteSpace(nombreProducto))
            { // Valida que el nombre no esté vacío
                MessageBox.Show("Error: El nombre del producto está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
                return; // Sale de la función
            }

            if (!int.TryParse(TextCArr.Text, out cantidadArrendar) || cantidadArrendar <= 0)
            { // Valida cantidad a arrendar
                MessageBox.Show("Ingrese una cantidad válida y positiva para añadir.", "Error de Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra mensaje de advertencia
                return; // Sale de la función
            }

            if (!int.TryParse(TextCAct.Text, out stockOriginalProducto))
            { // Valida stock disponible
                MessageBox.Show("Error al leer el stock disponible del producto. Contacte a soporte.", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
                return; // Sale de la función
            }

            if (cantidadArrendar > stockOriginalProducto)
            { // Compara cantidad con stock
                MessageBox.Show($"La cantidad a arrendar ({cantidadArrendar}) excede el stock disponible ({stockOriginalProducto}). Por favor, recalcule.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia de stock
                return; // Sale de la función
            }

            if (!decimal.TryParse(TextVArr.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out valorUnitarioProducto) || valorUnitarioProducto <= 0)
            { // Valida valor unitario
                MessageBox.Show("El valor unitario del producto no es válido. Contacte a soporte.", "Error de Valor", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
                return; // Sale de la función
            }

            valorTotalLinea = cantidadArrendar * valorUnitarioProducto; // Calcula el valor total de la línea.

            if (TextCArrA != null && !string.IsNullOrWhiteSpace(TextCArrA.Text) && int.TryParse(TextCArrA.Text, out cantidadArrendadaActual)) { /* OK */ } // Intenta obtener la cantidad ya arrendada.
            else
            { // Si no es válido
                cantidadArrendadaActual = 0; // Se asume 0
            }

            if (FormularioPadre != null) // Si la referencia al formulario padre existe.
            {
                try
                {
                    int slotIndex = FormularioPadre.contProductos; // Obtiene el índice del slot actual desde el formulario padre.

                    if (slotIndex > 10) // Si se excede el límite de 10 productos.
                    {
                        MessageBox.Show("No se pueden añadir más de 10 productos a la cotización. Utilice 'Borrar Último Producto'.", "Límite Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                        return; // Sale del método.
                    }

                    // Busca los controles (TextBoxes) en el formulario padre para asignar los datos del producto.
                    TextBox prodTextBox = FormularioPadre.Controls.Find($"TextProd{slotIndex}", true).FirstOrDefault() as TextBox; // Busca textbox de producto
                    TextBox cantTextBox = FormularioPadre.Controls.Find($"TextCan{slotIndex}", true).FirstOrDefault() as TextBox; // Busca textbox de cantidad
                    TextBox vuTextBox = FormularioPadre.Controls.Find($"TextVUn{slotIndex}", true).FirstOrDefault() as TextBox; // Busca textbox de valor unitario
                    TextBox vtTextBox = FormularioPadre.Controls.Find($"TextVTol{slotIndex}", true).FirstOrDefault() as TextBox; // Busca textbox de valor total
                    TextBox idProdTextBox = FormularioPadre.Controls.Find($"TextIdProd{slotIndex}", true).FirstOrDefault() as TextBox; // Busca textbox de ID producto

                    // Asigna los valores a los TextBoxes encontrados en el formulario padre.
                    if (prodTextBox != null) { prodTextBox.Text = nombreProducto; prodTextBox.ReadOnly = true; } // Asigna nombre; solo lectura
                    if (cantTextBox != null) { cantTextBox.Text = cantidadArrendar.ToString(); cantTextBox.ReadOnly = false; } // Asigna cantidad; editable
                    if (vuTextBox != null) { vuTextBox.Text = valorUnitarioProducto.ToString("N0", CultureInfo.InvariantCulture); vuTextBox.ReadOnly = true; } // Asigna valor unitario; solo lectura
                    if (vtTextBox != null) { vtTextBox.Text = valorTotalLinea.ToString("C", new CultureInfo("es-CL")); vtTextBox.ReadOnly = true; } // Asigna valor total; solo lectura
                    if (idProdTextBox != null) { idProdTextBox.Text = idProducto.ToString(); idProdTextBox.ReadOnly = true; } // Asigna ID; solo lectura

                    EProd productoParaActualizarStock = new EProd // Crea un objeto EProd para actualizar el stock.
                    {
                        IdProd = idProducto,
                        // Suma la cantidad ya arrendada con la nueva.
                        CArr = (cantidadArrendadaActual + cantidadArrendar).ToString(CultureInfo.InvariantCulture),
                        // Resta la cantidad arrendada del stock original.
                        TAct = (stockOriginalProducto - cantidadArrendar).ToString(CultureInfo.InvariantCulture)
                    };

                    var resp = NProd.Actualizar2(productoParaActualizarStock); // Intenta actualizar el stock en la base de datos.
                    bool resActualizacionStock = resp.estado;
                    if (!resActualizacionStock) // Si la actualización del stock falla.
                    {
                        MessageBox.Show("Advertencia: No se pudo actualizar el stock del producto en la base de datos. Continúe, pero revise el stock manualmente.", "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                    }

                    LimpiarCamposPProdCarParaNuevoProducto(); // Limpia los campos de este formulario (PProd_Car).
                    ButAn.Enabled = false;   // Deshabilita el botón "Añadir".
                    butCal.Enabled = false;  // Deshabilita el botón "Calcular".
                    TextCArr.Focus(); // Pone el foco en el campo de cantidad a arrendar para el siguiente producto.

                    FormularioPadre.MetodoNotificarAdicionProducto(); // Notifica al formulario padre (PArrIng) sobre la adición del producto.

                    ButAg.Visible = true; // Hace visible el botón "Agregar otro Producto".
                    ButTAg.Visible = true; // Hace visible el botón "Terminar Agregado".
                    ButAg.Enabled = true; // Habilita el botón "Agregar otro Producto".
                    ButTAg.Enabled = true; // Habilita el botón "Terminar Agregado".

                    MessageBox.Show("Producto añadido a la cotización. Puede modificar la cantidad, añadir otro producto o terminar.", "Producto Añadido", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de confirmación.

                }
                catch (Exception ex) // Captura cualquier excepción durante la transferencia de datos.
                {
                    MessageBox.Show($"Error GENERAL en la transferencia de datos a PArrIng: {ex.Message}\nVERIFIQUE LOS NOMBRES EXACTOS DE LOS CONTROLES Y SU EXISTENCIA EN PArrIng.Designer.cs.", "Error de Adición", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error detallado.
                }
            }
            else // Si la referencia al formulario padre no fue establecida.
            {
                MessageBox.Show("El formulario principal no fue establecido. No se pueden añadir los datos.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error.
            }
        }

        private void LimpiarCamposPProdCarParaNuevoProducto() // Limpia los campos del formulario PProd_Car.
        {
            TextCArr.Clear(); // Limpia la cantidad a arrendar.
            TextIPro.Clear(); // Limpia el ID del producto.
            TextNom.Clear(); // Limpia el nombre.
            TextCAct.Clear(); // Limpia la cantidad actual.
            TeTotCan.Clear(); // Limpia el total calculado.
            TextVArr.Clear(); // Limpia el valor de arriendo.
            TextCArrA.Clear(); // Limpia la cantidad arrendada acumulada.
            TextTAct.Clear(); // Limpia el stock total actual.
            TextCArrF.Clear(); // Limpia la cantidad arrendada final.
            TeArrCan.Clear(); // Limpia la cantidad arrendar.
        }

        private void ButVol_Click(object sender, EventArgs e) // Evento clic en el botón Volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ButSal_Click(object sender, EventArgs e) // Evento clic en el botón Salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }

        private void ButAg_Click(object sender, EventArgs e) // Evento clic en el botón "Agregar otro Producto".
        {
            Productos.PProd_Con ver = new Productos.PProd_Con(); // Crea la ventana de consulta
            ver.ButCarProd.Enabled = false; // Desactiva el botón de cargar
            this.Close(); // Cierra esta ventana
        }

        private void ButTAg_Click(object sender, EventArgs e) // Evento clic en el botón "Terminar Agregado".
        {
            PProd_Con ver = Application.OpenForms.OfType<PProd_Con>().FirstOrDefault(); // Busca la ventana abierta
            this.Close(); // Cierra esta ventana
            ver.Close(); // Cierra la otra ventana
        }
    }
}


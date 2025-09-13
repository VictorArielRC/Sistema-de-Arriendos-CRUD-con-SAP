// Accede a códigos de otra librería
using CrystalDecisions.ReportAppServer.Prompting;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using Presentacion.AAClases;
// Accede a códigos de otra librería
using Presentacion.Cliente; 
// Accede a códigos de otra librería
using Presentacion.Productos; 
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.ComponentModel;
// Accede a códigos de otra librería
using System.Data;
// Accede a códigos de otra librería
using System.Drawing;
// Accede a códigos de otra librería
using System.Globalization;
// Accede a códigos de otra librería
using System.Linq;
using System.Security.Cryptography;

// Accede a códigos de otra librería
using System.Text;
// Accede a códigos de otra librería
using System.Text.RegularExpressions;
// Accede a códigos de otra librería
using System.Threading.Tasks;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using static System.Net.Mime.MediaTypeNames;
// Accede a códigos de otra librería
using static System.Net.WebRequestMethods;
// Accede a códigos de otra librería
using Application = System.Windows.Forms.Application;

namespace Presentacion.ArriFinal
{
    public partial class PArrIng : Form
    {
        public int contProductos = 1; // Contador de productos en lista.

        EArr nuevaEntidadArr = new EArr(); // Nueva entidad para arriendo principal.
        EArrDet nuevaEntidadArrDet = new EArrDet(); // Nueva entidad para detalles arriendo.
        EArrVUn nuevaEntidadArrVUn = new EArrVUn(); // Nueva entidad para valor unitario.
        EArrPro nuevaEntidadArrPro = new EArrPro(); // Nueva entidad para productos arriendo.
        EProd entidadProducto = new EProd(); // Entidad para datos de producto.

        NArr logicaNegocioArr = new NArr(); // Lógica de negocio arriendo.
        NArrDet logicaNegocioArrDet = new NArrDet(); // Lógica de negocio detalles.
        NArrPro logicaNegocioArrPro = new NArrPro(); // Lógica de negocio productos.
        NArrVUn logicaNegocioArrVUn = new NArrVUn(); // Lógica de negocio valor unitario.
        NProd logicaNegocioProd = new NProd(); // Lógica de negocio producto.

        PArr_Imp Report = new PArr_Imp();

        // Creación de los campos de parámetros
        ParameterFields Parametros = new ParameterFields();
        ParameterField NomClie = new ParameterField();
        ParameterField Rut = new ParameterField();
        ParameterField Direccion = new ParameterField();
        ParameterField Comuna = new ParameterField();
        ParameterField Giro = new ParameterField();
        ParameterField Telefono = new ParameterField();
        ParameterField Fecha = new ParameterField();
        ParameterField IdArr = new ParameterField();

        // Creación de los valores discretos de los parámetros
        ParameterDiscreteValue CNomClie = new ParameterDiscreteValue();
        ParameterDiscreteValue CRut = new ParameterDiscreteValue();
        ParameterDiscreteValue CDireccion = new ParameterDiscreteValue();
        ParameterDiscreteValue CComuna = new ParameterDiscreteValue();
        ParameterDiscreteValue CGiro = new ParameterDiscreteValue();
        ParameterDiscreteValue CTelefono = new ParameterDiscreteValue();
        ParameterDiscreteValue CFecha = new ParameterDiscreteValue();
        ParameterDiscreteValue CIdArr = new ParameterDiscreteValue();

        // Creación de más campos de parámetros
        ParameterField C1 = new ParameterField();
        ParameterField C2 = new ParameterField();
        ParameterField C3 = new ParameterField();
        ParameterField C4 = new ParameterField();
        ParameterField C5 = new ParameterField();
        ParameterField C6 = new ParameterField();
        ParameterField C7 = new ParameterField();
        ParameterField C8 = new ParameterField();
        ParameterField C9 = new ParameterField();
        ParameterField C10 = new ParameterField();

        // Creación de los valores discretos de más parámetros
        ParameterDiscreteValue CC1 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC2 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC3 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC4 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC5 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC6 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC7 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC8 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC9 = new ParameterDiscreteValue();
        ParameterDiscreteValue CC10 = new ParameterDiscreteValue();

        // Creación de más campos de parámetros
        ParameterField P1 = new ParameterField();
        ParameterField P2 = new ParameterField();
        ParameterField P3 = new ParameterField();
        ParameterField P4 = new ParameterField();
        ParameterField P5 = new ParameterField();
        ParameterField P6 = new ParameterField();
        ParameterField P7 = new ParameterField();
        ParameterField P8 = new ParameterField();
        ParameterField P9 = new ParameterField();
        ParameterField P10 = new ParameterField();

        // Creación de los valores discretos de más parámetros
        ParameterDiscreteValue CP1 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP2 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP3 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP4 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP5 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP6 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP7 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP8 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP9 = new ParameterDiscreteValue();
        ParameterDiscreteValue CP10 = new ParameterDiscreteValue();

        // Creación de más campos de parámetros
        ParameterField U1 = new ParameterField();
        ParameterField U2 = new ParameterField();
        ParameterField U3 = new ParameterField();
        ParameterField U4 = new ParameterField();
        ParameterField U5 = new ParameterField();
        ParameterField U6 = new ParameterField();
        ParameterField U7 = new ParameterField();
        ParameterField U8 = new ParameterField();
        ParameterField U9 = new ParameterField();
        ParameterField U10 = new ParameterField();

        // Creación de los valores discretos de más parámetros
        ParameterDiscreteValue CU1 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU2 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU3 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU4 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU5 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU6 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU7 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU8 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU9 = new ParameterDiscreteValue();
        ParameterDiscreteValue CU10 = new ParameterDiscreteValue();

        // Creación de más campos de parámetros
        ParameterField T1 = new ParameterField();
        ParameterField T2 = new ParameterField();
        ParameterField T3 = new ParameterField();
        ParameterField T4 = new ParameterField();
        ParameterField T5 = new ParameterField();
        ParameterField T6 = new ParameterField();
        ParameterField T7 = new ParameterField();
        ParameterField T8 = new ParameterField();
        ParameterField T9 = new ParameterField();
        ParameterField T10 = new ParameterField();

        // Creación de los valores discretos de más parámetros
        ParameterDiscreteValue CT1 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT2 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT3 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT4 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT5 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT6 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT7 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT8 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT9 = new ParameterDiscreteValue();
        ParameterDiscreteValue CT10 = new ParameterDiscreteValue();

        // Creación de campos de parámetros adicionales
        ParameterField SubTotal = new ParameterField();
        ParameterField Descuento = new ParameterField();
        ParameterField Iva = new ParameterField();
        ParameterField Total = new ParameterField();

        // Creación de los valores discretos de los parámetros adicionales
        ParameterDiscreteValue CSubTotal = new ParameterDiscreteValue();
        ParameterDiscreteValue CDescuento = new ParameterDiscreteValue();
        ParameterDiscreteValue CIva = new ParameterDiscreteValue();
        ParameterDiscreteValue CTotal = new ParameterDiscreteValue();



        public PArrIng() // Constructor del formulario.
        {
            InitializeComponent(); // Inicializa componentes de interfaz.
            MetodoConfigurarInicioUI(); // Configura interfaz al iniciar.
        }

        public class DescuentoItem // Clase para representar descuentos.
        {
            public string Texto { get; set; } // Texto visible del descuento.
            public decimal Valor { get; set; } // Valor porcentual del descuento.
        }

        public void MetodoNotificarAdicionProducto() // Notifica producto añadido.
        {
            MetodoCalcularTotalGeneral(); // Recalcula totales de arriendo.
            BtnUltProdd.Enabled = true; // Habilita botón borrar último.
            contProductos++; // Incrementa contador de productos.

            if (contProductos > 10) // Si se excede límite.
            {
                BtnProdArr.Enabled = false; // Deshabilita botón buscar producto.
                MessageBox.Show("Se ha alcanzado el límite de 10 productos en la cotización.", "Límite Alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de límite.
            }
        }

        public List<int> MetodoObtenerIdsProductosCargados() // Obtiene IDs de productos.
        {
            List<int> ids = new List<int>(); // Crea lista para IDs.
            for (int i = 1; i < contProductos; i++) // Itera sobre productos ocupados.
            {
                TextBox idProdTextBox = this.Controls.Find($"TextIdProd{i}", true).FirstOrDefault() as TextBox; // Busca control ID producto.
                if (idProdTextBox != null && int.TryParse(idProdTextBox.Text, out int productId)) // Si existe y es válido.
                {
                    ids.Add(productId); // Añade ID a la lista.
                }
            }
            return ids; // Devuelve lista de IDs.
        }

        private void MetodoConfigurarInicioUI() // Configura interfaz al inicio.
        {
            TextNomCli.ReadOnly = true; // Campo nombre cliente solo lectura.
            TextRut.ReadOnly = true; // Campo Rut cliente solo lectura.
            TextDir.ReadOnly = true; // Campo dirección solo lectura.
            TextCom.ReadOnly = true; // Campo comuna solo lectura.
            TextGir.ReadOnly = true; // Campo giro solo lectura.
            TextTel.ReadOnly = true; // Campo teléfono solo lectura.
            TextFech.ReadOnly = true; // Campo fecha solo lectura.
            if (this.Controls.Find("TextIdCli", true).FirstOrDefault() is TextBox idCliTextBox) // Busca ID cliente.
            {
                idCliTextBox.ReadOnly = true; // Campo ID cliente solo lectura.
            }
            TextSubTo.ReadOnly = true; // Campo subtotal solo lectura.
            TextIVA.ReadOnly = true; // Campo IVA solo lectura.
            TxxtTotaLL.ReadOnly = true; // Campo total solo lectura.
            BtnCliArrIng.Enabled = true; // Habilita botón cliente.
            BtnProdArr.Enabled = false; // Deshabilita botón producto.
            BtnUltProdd.Enabled = false; // Deshabilita botón borrar último.
            MetodoLimpiarCamposProductosParaUI(); // Limpia campos de productos.
            MetodoCargarListaDescuentos(); // Carga descuentos en lista.
            TextFech.Text = DateTime.Now.ToShortDateString(); // Establece fecha actual.
        }

        private void MetodoLimpiarFormularioCompleto() // Limpia todo el formulario.
        {
            // --- Limpiar campos del cliente ---
            TextNomCli.Clear(); // Limpia nombre de cliente.
            TextRut.Clear(); // Limpia Rut de cliente.
            TextDir.Clear(); // Limpia dirección.
            TextCom.Clear(); // Limpia comuna.
            TextGir.Clear(); // Limpia giro.
            TextTel.Clear(); // Limpia teléfono.
            TextFech.Text = DateTime.Now.ToShortDateString(); // Restablece fecha actual.

            if (this.Controls.Find("TextIdCli", true).FirstOrDefault() is TextBox idCliTextBox) // Busca ID cliente.
            {
                idCliTextBox.Clear(); // Limpia ID de cliente.
            }

            // --- Limpiar campos de resumen ---
            TextSubTo.Text = "0"; // Establece subtotal a cero.
            if (ComboDes.Items.Count > 0) ComboDes.SelectedIndex = 0; // Selecciona primer descuento.
            TextIVA.Text = "0"; // Establece IVA a cero.
            TxxtTotaLL.Text = "0"; // Establece total a cero.

            // --- Limpiar todos los 10 sets de campos de producto ---
            MetodoLimpiarCamposProductosParaUI(); // Limpia campos de producto.

            // --- Restablecer el contador de productos ---
            contProductos = 1; // Reinicia contador de productos.

            // --- Reconfigurar el estado inicial de los botones ---
            BtnCliArrIng.Enabled = true; // Habilita botón cliente.
            BtnProdArr.Enabled = false; // Deshabilita botón producto.
            BtnUltProdd.Enabled = false; // Deshabilita botón borrar último.

            MetodoCalcularTotalGeneral(); // Recalcula total general.
        }

        private void MetodoLimpiarCamposProductosParaUI() // Limpia campos de productos UI.
        {
            // Desasociar eventos para evitar llamadas accidentales al limpiar
            for (int i = 1; i <= 10; i++) // Itera por 10 productos.
            {
                TextBox cantTextBox = this.Controls.Find($"TextCan{i}", true).FirstOrDefault() as TextBox; // Busca campo cantidad.
                if (cantTextBox != null) // Si el campo existe.
                {
                    cantTextBox.TextChanged -= ManejadorTextCanCambioTexto; // Desasocia evento TextChanged.
                }
            }

            // Limpiar y poner en solo lectura
            for (int i = 1; i <= 10; i++) // Itera por 10 productos.
            {
                TextBox prodTextBox = this.Controls.Find($"TextProd{i}", true).FirstOrDefault() as TextBox; // Busca campo producto.
                TextBox cantTextBox = this.Controls.Find($"TextCan{i}", true).FirstOrDefault() as TextBox; // Busca campo cantidad.
                TextBox vuTextBox = this.Controls.Find($"TextVUn{i}", true).FirstOrDefault() as TextBox; // Busca campo valor unitario.
                TextBox vtTextBox = this.Controls.Find($"TextVTol{i}", true).FirstOrDefault() as TextBox; // Busca campo valor total.
                TextBox idProdTextBox = this.Controls.Find($"TextIdProd{i}", true).FirstOrDefault() as TextBox; // Busca campo ID producto.

                if (prodTextBox != null) { prodTextBox.Clear(); prodTextBox.ReadOnly = true; } // Limpia y solo lectura.
                if (cantTextBox != null) { cantTextBox.Clear(); cantTextBox.ReadOnly = true; } // Limpia y solo lectura.
                if (vuTextBox != null) { vuTextBox.Clear(); vuTextBox.ReadOnly = true; } // Limpia y solo lectura.
                if (vtTextBox != null) { vtTextBox.Clear(); vtTextBox.ReadOnly = true; } // Limpia y solo lectura.
                if (idProdTextBox != null) { idProdTextBox.Clear(); idProdTextBox.ReadOnly = true; } // Limpia y solo lectura.
            }

            // Re-asociar eventos
            for (int i = 1; i <= 10; i++) // Itera por 10 productos.
            {
                TextBox cantTextBox = this.Controls.Find($"TextCan{i}", true).FirstOrDefault() as TextBox; // Busca campo cantidad.
                if (cantTextBox != null) // Si el campo existe.
                {
                    cantTextBox.TextChanged += ManejadorTextCanCambioTexto; // Reasocia evento TextChanged.
                }
            }
        }

        private void MetodoCargarListaDescuentos() // Carga descuentos en ComboBox.
        {
            var lista = new List<object> // Crea lista de objetos anónimos.
    {
        new { Texto = "0%", Valor = 0 }, // Descuento del 0%.
        new { Texto = "5%", Valor = 5 }, // Descuento del 5%.
        new { Texto = "10%", Valor = 10 }, // Descuento del 10%.
        new { Texto = "15%", Valor = 15 }, // Descuento del 15%.
        new { Texto = "20%", Valor = 20 }, // Descuento del 20%.
        new { Texto = "25%", Valor = 25 }, // Descuento del 25%.
        new { Texto = "30%", Valor = 30 }, // Descuento del 30%.
        new { Texto = "35%", Valor = 35 }, // Descuento del 35%.
        new { Texto = "40%", Valor = 40 }, // Descuento del 40%.
        new { Texto = "45%", Valor = 45 }, // Descuento del 45%.
        new { Texto = "50%", Valor = 50 }, // Descuento del 50%.
        new { Texto = "55%", Valor = 55 }, // Descuento del 55%.
        new { Texto = "60%", Valor = 60 }, // Descuento del 60%.
        new { Texto = "70%", Valor = 70 }, // Descuento del 70%.
        new { Texto = "75%", Valor = 75 }, // Descuento del 75%.
        new { Texto = "80%", Valor = 80 }, // Descuento del 80%.
        new { Texto = "85%", Valor = 85 }, // Descuento del 85%.
        new { Texto = "90%", Valor = 90 }, // Descuento del 90%.
        new { Texto = "95%", Valor = 95 }, // Descuento del 95%.
        new { Texto = "100%", Valor = 100 } // Descuento del 100%.
    };

            ComboDes.DataSource = lista; // Asigna lista como fuente.
            ComboDes.DisplayMember = "Texto"; // Muestra la propiedad Texto.
            ComboDes.ValueMember = "Valor"; // Usa la propiedad Valor.
            ComboDes.SelectedIndex = 0; // Selecciona el primer ítem.
        }

        private void MetodoCalcularTotalGeneral() // Calcula total de arriendo.
        {
            decimal subTotal = 0; // Inicializa subtotal.

            for (int i = 1; i <= 10; i++) // Itera por 10 productos.
            {
                TextBox vtTextBox = this.Controls.Find($"TextVTol{i}", true).FirstOrDefault() as TextBox; // Busca valor total.
                if (vtTextBox != null && !string.IsNullOrWhiteSpace(vtTextBox.Text)) // Si existe y tiene texto.
                {
                    string valorSinFormato = vtTextBox.Text.Replace("$", "").Replace(".", "").Replace("CLP", "").Trim(); // Limpia formato de texto.
                    if (decimal.TryParse(valorSinFormato, NumberStyles.Any, new CultureInfo("es-CL"), out decimal valorLinea)) // Intenta convertir a decimal.
                    {
                        subTotal += valorLinea; // Suma al subtotal.
                    }
                }
            }

            TextSubTo.Text = subTotal.ToString("N0", new CultureInfo("es-CL")); // Muestra subtotal formateado.

            decimal descuentoPorcentaje = 0; // Inicializa porcentaje descuento.
            if (ComboDes.SelectedValue != null) // Si hay valor seleccionado.
            {
                decimal.TryParse(ComboDes.SelectedValue.ToString(), out descuentoPorcentaje); // Convierte a decimal.
                descuentoPorcentaje /= 100m; // Convierte a porcentaje.
            }

            decimal montoDescuento = subTotal * descuentoPorcentaje; // Calcula monto descuento.
            decimal subTotalConDescuento = subTotal - montoDescuento; // Calcula subtotal con descuento.

            decimal ivaCalculado = subTotalConDescuento * 0.19m; // Calcula IVA (19%).
            TextIVA.Text = ivaCalculado.ToString("N0", new CultureInfo("es-CL")); // Muestra IVA formateado.

            decimal total = subTotalConDescuento + ivaCalculado; // Calcula total final.
            TxxtTotaLL.Text = total.ToString("C", new CultureInfo("es-CL")); // Muestra total formateado moneda.
        }

        private void PArrIng_Load(object sender, EventArgs e) // Evento al cargar formulario.
        {
            ThemeManager.ApplyExecutiveTheme(this); // Aplica tema ejecutivo.
        }

        private void ManejadorButCliClick(object sender, EventArgs e) // Maneja clic botón cliente.
        {
            using (PCli_Con formClientes = new PCli_Con()) // Crea formulario de clientes.
            {
                formClientes.FormularioPadre = (Presentacion.ArriFinal.PArrIng)this; // Asigna formulario padre.
                formClientes.ShowDialog(); // Muestra formulario modal.
                if (this.Controls.Find("TextIdCli", true).FirstOrDefault() is TextBox idCliTextBox && // Si encuentra ID cliente.
                    !string.IsNullOrWhiteSpace(idCliTextBox.Text) && idCliTextBox.Text != "0") // Y no está vacío o cero.
                {
                    BtnProdArr.Enabled = true; // Habilita botón producto.
                    tabControl1.SelectedTab = tabPage2; // Cambia a pestaña de productos.
                }
                else // Si no se seleccionó cliente.
                {
                    BtnProdArr.Enabled = false; // Deshabilita botón producto.
                    MessageBox.Show("No se seleccionó ningún cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                }
            }
        }

        private void ManejadorButProClick(object sender, EventArgs e) // Maneja clic botón producto.
        {
            if (contProductos > 10) // Si se excede límite.
            {
                MessageBox.Show("Ya se han añadido el máximo de 10 productos a la cotización.", "Límite de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje límite.
                BtnProdArr.Enabled = false; // Deshabilita botón buscar.
                return; // Sale del método.
            }

            PProd_Con formProductos = new PProd_Con(); // Crea formulario de productos.

            formProductos.FormularioPadre = (Presentacion.ArriFinal.PArrIng)this; // Asigna formulario padre.
            formProductos.Show(); // Muestra formulario productos.
        }

        private void ManejadorButUlProClick(object sender, EventArgs e) // Maneja clic borrar último.
        {
            TextBox firstProdTextBox = this.Controls.Find("TextProd1", true).FirstOrDefault() as TextBox; // Busca primer producto.
            if (contProductos == 1 && (firstProdTextBox == null || string.IsNullOrWhiteSpace(firstProdTextBox.Text))) // Si solo hay uno y está vacío.
            {
                MessageBox.Show("No hay productos para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje informativo.
                BtnUltProdd.Enabled = false; // Deshabilita botón borrar.
                return; // Sale del método.
            }

            TextBox cantToClear = this.Controls.Find($"TextCan{contProductos - 1}", true).FirstOrDefault() as TextBox; // Busca campo cantidad anterior.
            if (cantToClear != null) // Si el campo existe.
            {
                cantToClear.TextChanged -= ManejadorTextCanCambioTexto; // Desasocia evento TextChanged.
            }

            contProductos--; // Decrementa contador productos.

            TextBox prodTextBox = this.Controls.Find($"TextProd{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo producto.
            TextBox cantTextBox = this.Controls.Find($"TextCan{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo cantidad.
            TextBox vuTextBox = this.Controls.Find($"TextVUn{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo valor unitario.
            TextBox vtTextBox = this.Controls.Find($"TextVTol{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo valor total.
            TextBox idProdTextBox = this.Controls.Find($"TextIdProd{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo ID producto.

            if (prodTextBox != null) { prodTextBox.Clear(); prodTextBox.ReadOnly = true; } // Limpia y solo lectura.
            if (cantTextBox != null) { cantTextBox.Clear(); cantTextBox.ReadOnly = true; } // Limpia y solo lectura.
            if (vuTextBox != null) { vuTextBox.Clear(); vuTextBox.ReadOnly = true; } // Limpia y solo lectura.
            if (vtTextBox != null) { vtTextBox.Clear(); vtTextBox.ReadOnly = true; } // Limpia y solo lectura.
            if (idProdTextBox != null) { idProdTextBox.Clear(); idProdTextBox.ReadOnly = true; } // Limpia y solo lectura.

            MetodoCalcularTotalGeneral(); // Recalcula totales.

            BtnProdArr.Enabled = true; // Habilita botón producto.

            if (contProductos == 1 && (firstProdTextBox == null || string.IsNullOrWhiteSpace(firstProdTextBox.Text))) // Si solo queda uno vacío.
            {
                BtnUltProdd.Enabled = false; // Deshabilita botón borrar último.
            }
        }

        private void ManejadorButLimClick(object sender, EventArgs e) // Maneja clic botón limpiar.
        {
            MetodoLimpiarFormularioCompleto(); // Llama a limpiar formulario completo.
            MessageBox.Show("Formulario limpiado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra mensaje de limpieza.
        }

        private string MetodoFormatearImporte(string valor) // Formatea valor monetario.
        {
            if (string.IsNullOrWhiteSpace(valor)) // Si el valor es nulo o vacío.
                return "0.00"; // Retorna "0.00".

            valor = valor.Replace("CLP", "") // Elimina "CLP".
                            .Replace("$", "") // Elimina "$".
                            .Replace("Total:", "") // Elimina "Total:".
                            .Trim(); // Elimina espacios.

            string limpio = valor.Replace(".", "").Replace(",", "."); // Elimina puntos y cambia coma.

            if (Regex.IsMatch(limpio, @"^\d+(\.\d{1,2})?$")) // Si coincide con patrón numérico.
                return limpio; // Retorna valor limpio.
            else // Si no es numérico.
                return "0.00"; // Retorna "0.00".
        }

        private void ManejadorButIngClick(object sender, EventArgs e) // Maneja clic botón ingresar.
        {
            if (string.IsNullOrWhiteSpace(TextProd1.Text)) // Si el primer producto está vacío.
            {
                MessageBox.Show("Debe seleccionar al menos un producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                return; // Sale del método.
            }

            var res = MessageBox.Show("¿Está seguro de la acción a realizar?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question); // Confirma acción.
            if (res != DialogResult.Yes) // Si no es "Sí".
            {
                if (res == DialogResult.No) ButVol.Focus(); // Si es "No", enfoca volver.
                if (res == DialogResult.Cancel) ButSal.Focus(); // Si es "Cancelar", enfoca salir.
                return; // Sale del método.
            }

            // → 1. Construimos subcomponentes
            EArrDet arrDet = new EArrDet // Crea entidad de detalles.
            {
                DPr1 = TextProd1.Text, // Asigna texto producto 1.
                DPr2 = TextProd2.Text, // Asigna texto producto 2.
                DPr3 = TextProd3.Text, // Asigna texto producto 3.
                DPr4 = TextProd4.Text, // Asigna texto producto 4.
                DPr5 = TextProd5.Text, // Asigna texto producto 5.
                DPr6 = TextProd6.Text, // Asigna texto producto 6.
                DPr7 = TextProd7.Text, // Asigna texto producto 7.
                DPr8 = TextProd8.Text, // Asigna texto producto 8.
                DPr9 = TextProd9.Text, // Asigna texto producto 9.
                DPr10 = TextProd10.Text // Asigna texto producto 10.
            };

            EArrPro arrPro = new EArrPro // Crea entidad de IDs producto.
            {
                IdPprod1 = int.Parse(TextIdProd1.Text), // Asigna ID producto 1.
                IdPprod2 = int.TryParse(TextIdProd2.Text, out int id2) ? (int?)id2 : null, // Asigna ID producto 2.
                IdPprod3 = int.TryParse(TextIdProd3.Text, out int id3) ? (int?)id3 : null, // Asigna ID producto 3.
                IdPprod4 = int.TryParse(TextIdProd4.Text, out int id4) ? (int?)id4 : null, // Asigna ID producto 4.
                IdPprod5 = int.TryParse(TextIdProd5.Text, out int id5) ? (int?)id5 : null, // Asigna ID producto 5.
                IdPprod6 = int.TryParse(TextIdProd6.Text, out int id6) ? (int?)id6 : null, // Asigna ID producto 6.
                IdPprod7 = int.TryParse(TextIdProd7.Text, out int id7) ? (int?)id7 : null, // Asigna ID producto 7.
                IdPprod8 = int.TryParse(TextIdProd8.Text, out int id8) ? (int?)id8 : null, // Asigna ID producto 8.
                IdPprod9 = int.TryParse(TextIdProd9.Text, out int id9) ? (int?)id9 : null, // Asigna ID producto 9.
                IdPprod10 = int.TryParse(TextIdProd10.Text, out int id10) ? (int?)id10 : null // Asigna ID producto 10.
            };

            EArrVUn arrVUn = new EArrVUn // Crea entidad de valores unitarios.
            {
                VUn1 = TextVUn1.Text, // Asigna valor unitario 1.
                VUn2 = TextVUn2.Text, // Asigna valor unitario 2.
                VUn3 = TextVUn3.Text, // Asigna valor unitario 3.
                VUn4 = TextVUn4.Text, // Asigna valor unitario 4.
                VUn5 = TextVUn5.Text, // Asigna valor unitario 5.
                VUn6 = TextVUn6.Text, // Asigna valor unitario 6.
                VUn7 = TextVUn7.Text, // Asigna valor unitario 7.
                VUn8 = TextVUn8.Text, // Asigna valor unitario 8.
                VUn9 = TextVUn9.Text, // Asigna valor unitario 9.
                VUn10 = TextVUn10.Text // Asigna valor unitario 10.
            };

            // → 2. Insertamos cada entidad y validamos resultado
            var resDet = NArrDet.Ingresar(arrDet); // Ingresa detalles de arriendo.
            var resPro = NArrPro.Ingresar(arrPro); // Ingresa productos de arriendo.
            var resVUn = NArrVUn.Ingresar(arrVUn); // Ingresa valores unitarios.

            if (!resDet.estado || !resPro.estado || !resVUn.estado) // Si alguna inserción falla.
            {
                MessageBox.Show("Error al insertar Detalle/Productos/Unidades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
                return; // Sale del método.
            }

            // → 3. Obtener IDs insertados
            int idDet = logicaNegocioArrDet.ObtenerUltimoId(); // Obtiene último ID detalle.
            int idPro = logicaNegocioArrPro.ObtenerUltimoId(); // Obtiene último ID producto.
            int idVUn = logicaNegocioArrVUn.ObtenerUltimoId(); // Obtiene último ID valor unitario.

            // → 4. Construir entidad principal y llenar con IDs
            string subto = MetodoFormatearImporte(TextSubTo.Text); // Formatea subtotal.
            string descuento = MetodoFormatearImporte(ComboDes.SelectedValue?.ToString()); // Formatea descuento.
            string iva = MetodoFormatearImporte(TextIVA.Text); // Formatea IVA.
            string total = MetodoFormatearImporte(TxxtTotaLL.Text); // Formatea total.

            EArr cotizacion = new EArr // Crea entidad de cotización.
            {
                IdP_Cli = Convert.ToInt32(TextIdCli.Text), // Asigna ID cliente.
                Fech = TextFech.Text, // Asigna fecha.
                SubTo = subto, // Asigna subtotal.
                Descuento = descuento, // Asigna descuento.
                IVA = iva, // Asigna IVA.
                Total = total, // Asigna total.
                IdADet = idDet, // Asigna ID detalle.
                IdAPro = idPro, // Asigna ID producto.
                IdAVUn = idVUn // Asigna ID valor unitario.
            };

            var resultadoArr = NArr.Ingresar(cotizacion); // Ingresa cotización.
            if (resultadoArr.estado) // Si la inserción es exitosa.
            {
                MessageBox.Show("Ingreso realizado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra éxito.
                MetodoActualizarStockProductos(); // Actualiza stock de productos.
                
            }
            else // Si la inserción falla.
            {
                MessageBox.Show($"No se pudo ingresar la cotización.\n\n{resultadoArr.mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
            }
        }

        private void MetodoActualizarStockProductos() // Actualiza stock de productos.
        {
            // Diccionario: clave = ID producto, valor = (cantidad total arrendada, stock original)
            Dictionary<int, (int CantidadTotalArrendada, int StockOriginal)> productosParaActualizar = // Crea diccionario para actualizar.
                new Dictionary<int, (int, int)>(); // Define tipos de valores.

            // Recorrer hasta 10 filas de productos
            for (int i = 1; i <= 10; i++) // Itera por 10 productos.
            {
                string nombreIdProd = "TextIdProd" + i; // Nombre del campo ID producto.
                string nombreTextBoxCantidad = "TextCan" + i; // Nombre del campo cantidad.

                TextBox txtIdProd = Controls.Find(nombreIdProd, true).FirstOrDefault() as TextBox; // Busca campo ID producto.
                TextBox txtCantidad = Controls.Find(nombreTextBoxCantidad, true).FirstOrDefault() as TextBox; // Busca campo cantidad.

                if (txtIdProd != null && !string.IsNullOrWhiteSpace(txtIdProd.Text) && // Si ID producto existe y tiene texto.
                    txtCantidad != null && !string.IsNullOrWhiteSpace(txtCantidad.Text)) // Y cantidad existe y tiene texto.
                {
                    if (int.TryParse(txtIdProd.Text, out int idProducto) && // Convierte ID a entero.
                        int.TryParse(txtCantidad.Text, out int cantidadArrendada)) // Convierte cantidad a entero.
                    {
                        EProd productoDB = logicaNegocioProd.Listar().FirstOrDefault(p => p.IdProd == idProducto); // Busca producto en DB.
                        if (productoDB != null && int.TryParse(productoDB.TAct, out int stockOriginal)) // Si producto existe y stock es válido.
                        {
                            if (productosParaActualizar.ContainsKey(idProducto)) // Si el producto ya está en el diccionario.
                            {
                                var actual = productosParaActualizar[idProducto]; // Obtiene valor actual.
                                productosParaActualizar[idProducto] = // Actualiza cantidad y stock.
                                    (actual.CantidadTotalArrendada + cantidadArrendada, stockOriginal);
                            }
                            else // Si el producto no está en el diccionario.
                            {
                                productosParaActualizar.Add(idProducto, (cantidadArrendada, stockOriginal)); // Añade producto y cantidades.
                            }
                        }
                        else // Si no se pudo obtener stock.
                        {
                            MessageBox.Show($"Advertencia: No se pudo obtener el stock original para el producto ID {idProducto}.", "Advertencia de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                        }
                    }
                }
            }

            // Ahora aplicar los cambios
            foreach (var producto in productosParaActualizar) // Itera sobre productos a actualizar.
            {
                int id = producto.Key; // Obtiene ID del producto.
                int cantidadArrendada = producto.Value.CantidadTotalArrendada; // Obtiene cantidad arrendada.
                int stockOriginal = producto.Value.StockOriginal; // Obtiene stock original.

                try // Intenta actualizar.
                {
                    entidadProducto.IdProd = id; // Asigna ID producto.
                    entidadProducto.CArr = cantidadArrendada.ToString(); // Asigna cantidad arrendada.
                    entidadProducto.TAct = (stockOriginal - cantidadArrendada).ToString(); // Asigna stock disponible.

                    Respuesta<bool> resp = NProd.Actualizar2(entidadProducto); // Actualiza producto en negocio.

                    if (!resp.estado) // Si la actualización falla.
                    {
                        MessageBox.Show($"No se pudo actualizar el stock del producto {id}.\n{resp.mensaje}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia.
                    }
                }
                catch (Exception ex) // Captura cualquier error.
                {
                    MessageBox.Show($"Error al actualizar stock del producto {id}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error.
                }
            }
        }

        private void ManejadorComboDesCambioSeleccion(object sender, EventArgs e) // Maneja cambio descuento.
        {
            MetodoCalcularTotalGeneral(); // Recalcula totales de arriendo.
        }

        private void ManejadorTabControlCambioIndice(object sender, EventArgs e) // Maneja cambio de pestaña.
        {
            if (tabControl1.SelectedTab == tabPage1) // Si selecciona pestaña 1.
            {
                BtnCliArrIng.Enabled = true; // Habilita botón cliente.
                BtnProdArr.Enabled = false; // Deshabilita botón producto.
                BtnUltProdd.Enabled = false; // Deshabilita borrar último.
            }
            else if (tabControl1.SelectedTab == tabPage2) // Si selecciona pestaña 2.
            {
                BtnCliArrIng.Enabled = false; // Deshabilita botón cliente.
                TextBox idCliTextBox = this.Controls.Find("TextIdCli", true).FirstOrDefault() as TextBox; // Busca ID cliente.
                BtnProdArr.Enabled = (idCliTextBox != null && !string.IsNullOrWhiteSpace(idCliTextBox.Text) && idCliTextBox.Text != "0"); // Habilita botón producto.

                BtnUltProdd.Enabled = (contProductos > 1); // Habilita borrar si hay productos.
            }
        }

        private void ManejadorTextCanCambioTexto(object sender, EventArgs e) // Maneja cambio cantidad texto.
        {
            TextBox cantidadTextBox = sender as TextBox; // Obtiene el TextBox emisor.
            if (cantidadTextBox == null) return; // Si no es TextBox, sale.

            string name = cantidadTextBox.Name; // Obtiene nombre del TextBox.
            string indexStr = name.Replace("TextCan", ""); // Extrae el índice numérico.

            TextBox vuTextBox = this.Controls.Find($"TextVUn{indexStr}", true).FirstOrDefault() as TextBox; // Busca campo valor unitario.
            TextBox vtTextBox = this.Controls.Find($"TextVTol{indexStr}", true).FirstOrDefault() as TextBox; // Busca campo valor total.

            if (vuTextBox == null || vtTextBox == null) return; // Si faltan campos, sale.

            // Manejo de valores vacíos o no numéricos para evitar errores de Parse
            double cantidad = 0; // Inicializa cantidad.
            if (!string.IsNullOrWhiteSpace(cantidadTextBox.Text) && double.TryParse(cantidadTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedCantidad)) // Si es válido, parsea cantidad.
            {
                cantidad = parsedCantidad; // Asigna cantidad parseada.
            }

            double valorUnitario = 0; // Inicializa valor unitario.
            if (!string.IsNullOrWhiteSpace(vuTextBox.Text)) // Si el valor unitario tiene texto.
            {
                string cleanedVuText = vuTextBox.Text.Replace(".", "").Replace("$", "").Trim(); // Limpia formato de texto.
                if (double.TryParse(cleanedVuText, NumberStyles.Any, new CultureInfo("es-CL"), out double parsedValorUnitario)) // Intenta convertir a double.
                {
                    valorUnitario = parsedValorUnitario; // Asigna valor unitario parseado.
                }
            }

            double resultado = cantidad * valorUnitario; // Calcula el resultado.

            // Formatear el resultado como moneda chilena sin decimales
            vtTextBox.Text = resultado.ToString("C0", new CultureInfo("es-CL")); // Muestra valor total formateado.

            MetodoCalcularTotalGeneral(); // Recalcula totales.
        }

        private void ManejadorButVolClick(object sender, EventArgs e) // Maneja clic botón volver.
        {
            this.Close(); // Cierra el formulario actual.
        }

        private void ManejadorButSalClick(object sender, EventArgs e) // Maneja clic botón salir.
        {
            Application.Exit(); // Cierra toda la aplicación.
        }

        private void ButIng_Click(object sender, EventArgs e) // Evento vacío botón ingresar.
        {
            // No contiene lógica.
        }

        private void ButImp_Click(object sender, EventArgs e) // Evento vacío botón imprimir.
        {
            if (TextI2.Text == "1")
            {
                TextProd2.Text = "";
                TextCan2.Text = "";
                TextVUn2.Text = "";
            }

            if (TextI3.Text == "1")
            {
                TextProd3.Text = "";
                TextCan3.Text = "";
                TextVUn3.Text = "";
            }

            if (TextI4.Text == "1")
            {
                TextProd4.Text = "";
                TextCan4.Text = "";
                TextVUn4.Text = "";
            }

            if (TextI5.Text == "1")
            {
                TextProd5.Text = "";
                TextCan5.Text = "";
                TextVUn5.Text = "";
            }

            if (TextI6.Text == "1")
            {
                TextProd6.Text = "";
                TextCan6.Text = "";
                TextVUn6.Text = "";
            }

            if (TextI7.Text == "1")
            {
                TextProd7.Text = "";
                TextCan7.Text = "";
                TextVUn7.Text = "";
            }

            if (TextI8.Text == "1")
            {
                TextProd8.Text = "";
                TextCan8.Text = "";
                TextVUn8.Text = "";
            }

            if (TextI9.Text == "1")
            {
                TextProd9.Text = "";
                TextCan9.Text = "";
                TextVUn9.Text = "";
            }

            if (TextI10.Text == "1")
            {
                TextProd10.Text = "";
                TextCan10.Text = "";
                TextVUn10.Text = "";
            }


            // Configuración de los campos de parámetros
            IdArr.ParameterFieldName = "IdArr";
            NomClie.ParameterFieldName = "NomClie";
            Rut.ParameterFieldName = "Rut";
            Direccion.ParameterFieldName = "Direccion";
            Comuna.ParameterFieldName = "Comuna";
            Giro.ParameterFieldName = "Giro";
            Telefono.ParameterFieldName = "Telefono";
            Fecha.ParameterFieldName = "Fecha";

            C1.ParameterFieldName = "C1";
            C2.ParameterFieldName = "C2";
            C3.ParameterFieldName = "C3";
            C4.ParameterFieldName = "C4";
            C5.ParameterFieldName = "C5";
            C6.ParameterFieldName = "C6";
            C7.ParameterFieldName = "C7";
            C8.ParameterFieldName = "C8";
            C9.ParameterFieldName = "C9";
            C10.ParameterFieldName = "C10";

            P1.ParameterFieldName = "P1";
            P2.ParameterFieldName = "P2";
            P3.ParameterFieldName = "P3";
            P4.ParameterFieldName = "P4";
            P5.ParameterFieldName = "P5";
            P6.ParameterFieldName = "P6";
            P7.ParameterFieldName = "P7";
            P8.ParameterFieldName = "P8";
            P9.ParameterFieldName = "P9";
            P10.ParameterFieldName = "P10";

            U1.ParameterFieldName = "U1";
            U2.ParameterFieldName = "U2";
            U3.ParameterFieldName = "U3";
            U4.ParameterFieldName = "U4";
            U5.ParameterFieldName = "U5";
            U6.ParameterFieldName = "U6";
            U7.ParameterFieldName = "U7";
            U8.ParameterFieldName = "U8";
            U9.ParameterFieldName = "U9";
            U10.ParameterFieldName = "U10";

            T1.ParameterFieldName = "T1";
            T2.ParameterFieldName = "T2";
            T3.ParameterFieldName = "T3";
            T4.ParameterFieldName = "T4";
            T5.ParameterFieldName = "T5";
            T6.ParameterFieldName = "T6";
            T7.ParameterFieldName = "T7";
            T8.ParameterFieldName = "T8";
            T9.ParameterFieldName = "T9";
            T10.ParameterFieldName = "T10";

            SubTotal.ParameterFieldName = "SubTotal";
            Descuento.ParameterFieldName = "Descuento";
            Iva.ParameterFieldName = "Iva";
            Total.ParameterFieldName = "Total";

            // Asignación de valores a los campos de parámetros
            CNomClie.Value = this.TextNomCli.Text;
            CRut.Value = this.TextRut.Text;
            CDireccion.Value = this.TextDir.Text;
            CComuna.Value = this.TextCom.Text;
            CGiro.Value = this.TextGir.Text;
            CTelefono.Value = this.TextTel.Text;
            CFecha.Value = this.TextFech.Text;
            CIdArr.Value = this.textIdAD.Text;

            CC1.Value = this.TextCan1.Text;
            CC2.Value = this.TextCan2.Text;
            CC3.Value = this.TextCan3.Text;
            CC4.Value = this.TextCan4.Text;
            CC5.Value = this.TextCan5.Text;
            CC6.Value = this.TextCan6.Text;
            CC7.Value = this.TextCan7.Text;
            CC8.Value = this.TextCan8.Text;
            CC9.Value = this.TextCan9.Text;
            CC10.Value = this.TextCan10.Text;

            CP1.Value = this.TextProd1.Text;
            CP2.Value = this.TextProd2.Text;
            CP3.Value = this.TextProd3.Text;
            CP4.Value = this.TextProd4.Text;
            CP5.Value = this.TextProd5.Text;
            CP6.Value = this.TextProd6.Text;
            CP7.Value = this.TextProd7.Text;
            CP8.Value = this.TextProd8.Text;
            CP9.Value = this.TextProd9.Text;
            CP10.Value = this.TextProd10.Text;

            CU1.Value = this.TextVUn1.Text;
            CU2.Value = this.TextVUn2.Text;
            CU3.Value = this.TextVUn3.Text;
            CU4.Value = this.TextVUn4.Text;
            CU5.Value = this.TextVUn5.Text;
            CU6.Value = this.TextVUn6.Text;
            CU7.Value = this.TextVUn7.Text;
            CU8.Value = this.TextVUn8.Text;
            CU9.Value = this.TextVUn9.Text;
            CU10.Value = this.TextVUn10.Text;

            CT1.Value = this.TextVTol1.Text;
            CT2.Value = this.TextVTol2.Text;
            CT3.Value = this.TextVTol3.Text;
            CT4.Value = this.TextVTol4.Text;
            CT5.Value = this.TextVTol5.Text;
            CT6.Value = this.TextVTol6.Text;
            CT7.Value = this.TextVTol7.Text;
            CT8.Value = this.TextVTol8.Text;
            CT9.Value = this.TextVTol9.Text;
            CT10.Value = this.TextVTol10.Text;

            CSubTotal.Value = this.TextSubTo.Text;
            CDescuento.Value = this.TextDes.Text;
            CIva.Value = this.TextIVA.Text;
            CTotal.Value = this.TxxtTotaLL.Text;

            // Adición de valores a los campos de parámetros
            NomClie.CurrentValues.Add(CNomClie);
            Rut.CurrentValues.Add(CRut);
            Direccion.CurrentValues.Add(CDireccion);
            Comuna.CurrentValues.Add(CComuna);
            Giro.CurrentValues.Add(CGiro);
            Telefono.CurrentValues.Add(CTelefono);
            Fecha.CurrentValues.Add(CFecha);
            IdArr.CurrentValues.Add(CIdArr);

            C1.CurrentValues.Add(CC1);
            C2.CurrentValues.Add(CC2);
            C3.CurrentValues.Add(CC3);
            C4.CurrentValues.Add(CC4);
            C5.CurrentValues.Add(CC5);
            C6.CurrentValues.Add(CC6);
            C7.CurrentValues.Add(CC7);
            C8.CurrentValues.Add(CC8);
            C9.CurrentValues.Add(CC9);
            C10.CurrentValues.Add(CC10);

            P1.CurrentValues.Add(CP1);
            P2.CurrentValues.Add(CP2);
            P3.CurrentValues.Add(CP3);
            P4.CurrentValues.Add(CP4);
            P5.CurrentValues.Add(CP5);
            P6.CurrentValues.Add(CP6);
            P7.CurrentValues.Add(CP7);
            P8.CurrentValues.Add(CP8);
            P9.CurrentValues.Add(CP9);
            P10.CurrentValues.Add(CP10);

            U1.CurrentValues.Add(CU1);
            U2.CurrentValues.Add(CU2);
            U3.CurrentValues.Add(CU3);
            U4.CurrentValues.Add(CU4);
            U5.CurrentValues.Add(CU5);
            U6.CurrentValues.Add(CU6);
            U7.CurrentValues.Add(CU7);
            U8.CurrentValues.Add(CU8);
            U9.CurrentValues.Add(CU9);
            U10.CurrentValues.Add(CU10);

            T1.CurrentValues.Add(CT1);
            T2.CurrentValues.Add(CT2);
            T3.CurrentValues.Add(CT3);
            T4.CurrentValues.Add(CT4);
            T5.CurrentValues.Add(CT5);
            T6.CurrentValues.Add(CT6);
            T7.CurrentValues.Add(CT7);
            T8.CurrentValues.Add(CT8);
            T9.CurrentValues.Add(CT9);
            T10.CurrentValues.Add(CT10);

            SubTotal.CurrentValues.Add(CSubTotal);
            Descuento.CurrentValues.Add(CDescuento);
            Iva.CurrentValues.Add(CIva);
            Total.CurrentValues.Add(CTotal);

            // Agregar parámetros a la colección de parámetros
            Parametros.Add(IdArr);
            Parametros.Add(NomClie);
            Parametros.Add(Rut);
            Parametros.Add(Direccion);
            Parametros.Add(Comuna);
            Parametros.Add(Giro);
            Parametros.Add(Telefono);
            Parametros.Add(Fecha);

            Parametros.Add(C1);
            Parametros.Add(C2);
            Parametros.Add(C3);
            Parametros.Add(C4);
            Parametros.Add(C5);
            Parametros.Add(C6);
            Parametros.Add(C7);
            Parametros.Add(C8);
            Parametros.Add(C9);
            Parametros.Add(C10);

            Parametros.Add(P1);
            Parametros.Add(P2);
            Parametros.Add(P3);
            Parametros.Add(P4);
            Parametros.Add(P5);
            Parametros.Add(P6);
            Parametros.Add(P7);
            Parametros.Add(P8);
            Parametros.Add(P9);
            Parametros.Add(P10);

            Parametros.Add(U1);
            Parametros.Add(U2);
            Parametros.Add(U3);
            Parametros.Add(U4);
            Parametros.Add(U5);
            Parametros.Add(U6);
            Parametros.Add(U7);
            Parametros.Add(U8);
            Parametros.Add(U9);
            Parametros.Add(U10);

            Parametros.Add(T1);
            Parametros.Add(T2);
            Parametros.Add(T3);
            Parametros.Add(T4);
            Parametros.Add(T5);
            Parametros.Add(T6);
            Parametros.Add(T7);
            Parametros.Add(T8);
            Parametros.Add(T9);
            Parametros.Add(T10);

            Parametros.Add(SubTotal);
            Parametros.Add(Descuento);
            Parametros.Add(Iva);
            Parametros.Add(Total);


            // Asignación de la colección de parámetros al visor de informes
            Report.crystalReportViewer1.ParameterFieldInfo = Parametros;
            LlenarReporte();

            Report.ShowDialog();
            BtnCliArrIng.Enabled = true;
            BtnUltProdd.Enabled = true;
            ButLim.Enabled = true;
            BtnUltProdd.Enabled = true;
            //ButLim.PerformClick();
            ButImp.Enabled = false;
        }

        public void LlenarReporte()
        {

            // Creo una instancia de mi Reporte
            var info = new RArriendo();
            Report.crystalReportViewer1.ReportSource = info;
        }

        private void ComboDes_SelectedIndexChanged_1(object sender, EventArgs e) // Evento cambio selección descuento.
        {
            MetodoCalcularTotalGeneral(); // Recalcula totales.
        }

        private void TextIVA_TextChanged(object sender, EventArgs e) // Evento cambio texto IVA.
        {
            // No contiene lógica.
        }
    }
}
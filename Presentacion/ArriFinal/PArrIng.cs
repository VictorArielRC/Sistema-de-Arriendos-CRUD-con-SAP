// Importa dependencias.
using CrystalDecisions.Shared;
// Importa dependencias.
using CrystalDecisions.Web;

using Entidad;
// Importa dependencias.
using Negocio;
// Importa dependencias.
using Presentacion.AAClases;
// Importa dependencias.
using Presentacion.Cliente; 
// Importa dependencias.
using Presentacion.Productos; 
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
using System.Security.Cryptography;
// Importa dependencias.
using System.Text;
// Importa dependencias.
using System.Text.RegularExpressions;
// Importa dependencias.
using System.Threading.Tasks;
// Importa dependencias.
using System.Windows.Forms;
// Importa dependencias.
using static System.Net.Mime.MediaTypeNames;
// Importa dependencias.
using static System.Net.WebRequestMethods;
// Importa dependencias.
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

        PArr_Imp Report = new PArr_Imp(); // Instancia formulario reporte

        // Creación de los campos de parámetros.
        ParameterFields Parametros = new ParameterFields(); // Colección parámetros reporte
        ParameterField NomClie = new ParameterField(); // Parámetro nombre cliente
        ParameterField Rut = new ParameterField(); // Parámetro RUT cliente
        ParameterField Direccion = new ParameterField(); // Parámetro dirección cliente
        ParameterField Comuna = new ParameterField(); // Parámetro comuna cliente
        ParameterField Giro = new ParameterField(); // Parámetro giro cliente
        ParameterField Telefono = new ParameterField(); // Parámetro teléfono cliente
        ParameterField Fecha = new ParameterField(); // Parámetro fecha arriendo
        ParameterField IdArr = new ParameterField(); // Parámetro ID arriendo

        // Creación de los valores discretos de los parámetros.
        ParameterDiscreteValue CNomClie = new ParameterDiscreteValue(); // Valor nombre cliente
        ParameterDiscreteValue CRut = new ParameterDiscreteValue(); // Valor RUT cliente
        ParameterDiscreteValue CDireccion = new ParameterDiscreteValue(); // Valor dirección cliente
        ParameterDiscreteValue CComuna = new ParameterDiscreteValue(); // Valor comuna cliente
        ParameterDiscreteValue CGiro = new ParameterDiscreteValue(); // Valor giro cliente
        ParameterDiscreteValue CTelefono = new ParameterDiscreteValue(); // Valor teléfono cliente
        ParameterDiscreteValue CFecha = new ParameterDiscreteValue(); // Valor fecha arriendo
        ParameterDiscreteValue CIdArr = new ParameterDiscreteValue(); // Valor ID arriendo

        // Creación de más campos de parámetros.
        ParameterField C1 = new ParameterField(); // Parámetro cantidad producto 1
        ParameterField C2 = new ParameterField(); // Parámetro cantidad producto 2
        ParameterField C3 = new ParameterField(); // Parámetro cantidad producto 3
        ParameterField C4 = new ParameterField(); // Parámetro cantidad producto 4
        ParameterField C5 = new ParameterField(); // Parámetro cantidad producto 5
        ParameterField C6 = new ParameterField(); // Parámetro cantidad producto 6
        ParameterField C7 = new ParameterField(); // Parámetro cantidad producto 7
        ParameterField C8 = new ParameterField(); // Parámetro cantidad producto 8
        ParameterField C9 = new ParameterField(); // Parámetro cantidad producto 9
        ParameterField C10 = new ParameterField(); // Parámetro cantidad producto 10

        // Creación de los valores discretos de más parámetros.
        ParameterDiscreteValue CC1 = new ParameterDiscreteValue(); // Valor cantidad producto 1
        ParameterDiscreteValue CC2 = new ParameterDiscreteValue(); // Valor cantidad producto 2
        ParameterDiscreteValue CC3 = new ParameterDiscreteValue(); // Valor cantidad producto 3
        ParameterDiscreteValue CC4 = new ParameterDiscreteValue(); // Valor cantidad producto 4
        ParameterDiscreteValue CC5 = new ParameterDiscreteValue(); // Valor cantidad producto 5
        ParameterDiscreteValue CC6 = new ParameterDiscreteValue(); // Valor cantidad producto 6
        ParameterDiscreteValue CC7 = new ParameterDiscreteValue(); // Valor cantidad producto 7
        ParameterDiscreteValue CC8 = new ParameterDiscreteValue(); // Valor cantidad producto 8
        ParameterDiscreteValue CC9 = new ParameterDiscreteValue(); // Valor cantidad producto 9
        ParameterDiscreteValue CC10 = new ParameterDiscreteValue(); // Valor cantidad producto 10

        // Creación de más campos de parámetros.
        ParameterField P1 = new ParameterField(); // Parámetro nombre producto 1
        ParameterField P2 = new ParameterField(); // Parámetro nombre producto 2
        ParameterField P3 = new ParameterField(); // Parámetro nombre producto 3
        ParameterField P4 = new ParameterField(); // Parámetro nombre producto 4
        ParameterField P5 = new ParameterField(); // Parámetro nombre producto 5
        ParameterField P6 = new ParameterField(); // Parámetro nombre producto 6
        ParameterField P7 = new ParameterField(); // Parámetro nombre producto 7
        ParameterField P8 = new ParameterField(); // Parámetro nombre producto 8
        ParameterField P9 = new ParameterField(); // Parámetro nombre producto 9
        ParameterField P10 = new ParameterField(); // Parámetro nombre producto 10

        // Creación de los valores discretos de más parámetros.
        ParameterDiscreteValue CP1 = new ParameterDiscreteValue(); // Valor nombre producto 1
        ParameterDiscreteValue CP2 = new ParameterDiscreteValue(); // Valor nombre producto 2
        ParameterDiscreteValue CP3 = new ParameterDiscreteValue(); // Valor nombre producto 3
        ParameterDiscreteValue CP4 = new ParameterDiscreteValue(); // Valor nombre producto 4
        ParameterDiscreteValue CP5 = new ParameterDiscreteValue(); // Valor nombre producto 5
        ParameterDiscreteValue CP6 = new ParameterDiscreteValue(); // Valor nombre producto 6
        ParameterDiscreteValue CP7 = new ParameterDiscreteValue(); // Valor nombre producto 7
        ParameterDiscreteValue CP8 = new ParameterDiscreteValue(); // Valor nombre producto 8
        ParameterDiscreteValue CP9 = new ParameterDiscreteValue(); // Valor nombre producto 9
        ParameterDiscreteValue CP10 = new ParameterDiscreteValue(); // Valor nombre producto 10

        // Creación de más campos de parámetros.
        ParameterField U1 = new ParameterField(); // Parámetro valor unitario 1
        ParameterField U2 = new ParameterField(); // Parámetro valor unitario 2
        ParameterField U3 = new ParameterField(); // Parámetro valor unitario 3
        ParameterField U4 = new ParameterField(); // Parámetro valor unitario 4
        ParameterField U5 = new ParameterField(); // Parámetro valor unitario 5
        ParameterField U6 = new ParameterField(); // Parámetro valor unitario 6
        ParameterField U7 = new ParameterField(); // Parámetro valor unitario 7
        ParameterField U8 = new ParameterField(); // Parámetro valor unitario 8
        ParameterField U9 = new ParameterField(); // Parámetro valor unitario 9
        ParameterField U10 = new ParameterField(); // Parámetro valor unitario 10

        // Creación de los valores discretos de más parámetros.
        ParameterDiscreteValue CU1 = new ParameterDiscreteValue(); // Valor unitario producto 1
        ParameterDiscreteValue CU2 = new ParameterDiscreteValue(); // Valor unitario producto 2
        ParameterDiscreteValue CU3 = new ParameterDiscreteValue(); // Valor unitario producto 3
        ParameterDiscreteValue CU4 = new ParameterDiscreteValue(); // Valor unitario producto 4
        ParameterDiscreteValue CU5 = new ParameterDiscreteValue(); // Valor unitario producto 5
        ParameterDiscreteValue CU6 = new ParameterDiscreteValue(); // Valor unitario producto 6
        ParameterDiscreteValue CU7 = new ParameterDiscreteValue(); // Valor unitario producto 7
        ParameterDiscreteValue CU8 = new ParameterDiscreteValue(); // Valor unitario producto 8
        ParameterDiscreteValue CU9 = new ParameterDiscreteValue(); // Valor unitario producto 9
        ParameterDiscreteValue CU10 = new ParameterDiscreteValue(); // Valor unitario producto 10

        // Creación de más campos de parámetros.
        ParameterField T1 = new ParameterField(); // Parámetro total producto 1
        ParameterField T2 = new ParameterField(); // Parámetro total producto 2
        ParameterField T3 = new ParameterField(); // Parámetro total producto 3
        ParameterField T4 = new ParameterField(); // Parámetro total producto 4
        ParameterField T5 = new ParameterField(); // Parámetro total producto 5
        ParameterField T6 = new ParameterField(); // Parámetro total producto 6
        ParameterField T7 = new ParameterField(); // Parámetro total producto 7
        ParameterField T8 = new ParameterField(); // Parámetro total producto 8
        ParameterField T9 = new ParameterField(); // Parámetro total producto 9
        ParameterField T10 = new ParameterField(); // Parámetro total producto 10

        // Creación de los valores discretos de más parámetros.
        ParameterDiscreteValue CT1 = new ParameterDiscreteValue(); // Valor total producto 1
        ParameterDiscreteValue CT2 = new ParameterDiscreteValue(); // Valor total producto 2
        ParameterDiscreteValue CT3 = new ParameterDiscreteValue(); // Valor total producto 3
        ParameterDiscreteValue CT4 = new ParameterDiscreteValue(); // Valor total producto 4
        ParameterDiscreteValue CT5 = new ParameterDiscreteValue(); // Valor total producto 5
        ParameterDiscreteValue CT6 = new ParameterDiscreteValue(); // Valor total producto 6
        ParameterDiscreteValue CT7 = new ParameterDiscreteValue(); // Valor total producto 7
        ParameterDiscreteValue CT8 = new ParameterDiscreteValue(); // Valor total producto 8
        ParameterDiscreteValue CT9 = new ParameterDiscreteValue(); // Valor total producto 9
        ParameterDiscreteValue CT10 = new ParameterDiscreteValue(); // Valor total producto 10

        // Creación de campos de parámetros adicionales.
        ParameterField SubTotal = new ParameterField(); // Parámetro subtotal
        ParameterField Descuento = new ParameterField(); // Parámetro descuento
        ParameterField Iva = new ParameterField(); // Parámetro IVA
        ParameterField Total = new ParameterField(); // Parámetro total

        // Creación de los valores discretos de los parámetros adicionales.
        ParameterDiscreteValue CSubTotal = new ParameterDiscreteValue(); // Valor subtotal
        ParameterDiscreteValue CDescuento = new ParameterDiscreteValue(); // Valor descuento
        ParameterDiscreteValue CIva = new ParameterDiscreteValue(); // Valor IVA
        ParameterDiscreteValue CTotal = new ParameterDiscreteValue(); // Valor total

        public PArrIng() // Constructor del formulario
        {
            InitializeComponent(); // Inicializa componentes
          
        }

        public class DescuentoItem // Clase para items descuento
        {
            public string Texto { get; set; } // Texto visible descuento
            public decimal Valor { get; set; } // Valor porcentual descuento
        }

        public void MetodoNotificarAdicionProducto() // Notifica producto añadido
        {
            MetodoCalcularTotalGeneral(); // Recalcula totales
            BtnUltProdd.Enabled = true; // Habilita botón borrar
            contProductos++; // Incrementa contador

            if (contProductos > 10) // Si excede límite
            {
                BtnProdArr.Enabled = false; // Deshabilita botón producto
                MessageBox.Show("Límite de 10 productos alcanzado", "Límite", MessageBoxButtons.OK, MessageBoxIcon.Information); // Informa límite
            }
        }

        public List<int> MetodoObtenerIdsProductosCargados() // Obtiene IDs productos
        {
            List<int> ids = new List<int>(); // Crea lista IDs
            for (int i = 1; i < contProductos; i++) // Itera productos
            {
                TextBox idProdTextBox = this.Controls.Find($"TextIdProd{i}", true).FirstOrDefault() as TextBox; // Busca control ID
                if (idProdTextBox != null && int.TryParse(idProdTextBox.Text, out int productId)) // Si existe y válido
                {
                    ids.Add(productId); // Añade ID a lista
                }
            }
            return ids; // Retorna lista IDs
        }

        private void MetodoConfigurarInicioUI() // Configura interfaz inicial
        {
            TextNomCli.ReadOnly = true; // Nombre cliente solo lectura
            TextRut.ReadOnly = true; // RUT cliente solo lectura
            TextDir.ReadOnly = true; // Dirección solo lectura
            TextCom.ReadOnly = true; // Comuna solo lectura
            TextGir.ReadOnly = true; // Giro solo lectura
            TextTel.ReadOnly = true; // Teléfono solo lectura
            TextFech.ReadOnly = true; // Fecha solo lectura
            if (this.Controls.Find("TextIdCli", true).FirstOrDefault() is TextBox idCliTextBox) // Busca ID cliente
            {
                idCliTextBox.ReadOnly = true; // ID cliente solo lectura
            }
            TextSubTo.ReadOnly = true; // Subtotal solo lectura
            TextIVA.ReadOnly = true; // IVA solo lectura
            TxxtTotaLL.ReadOnly = true; // Total solo lectura
            BtnCliArrIng.Enabled = true; // Habilita botón cliente
            BtnProdArr.Enabled = false; // Deshabilita botón producto
            BtnUltProdd.Enabled = false; // Deshabilita botón borrar
            MetodoLimpiarCamposProductosParaUI(); // Limpia campos productos
            MetodoCargarListaDescuentos(); // Carga lista descuentos
            TextFech.Text = DateTime.Now.ToShortDateString(); // Establece fecha actual
        }

        private void MetodoLimpiarFormularioCompleto() // Limpia formulario completo
        {
            TextNomCli.Clear(); // Limpia nombre cliente
            TextRut.Clear(); // Limpia RUT cliente
            TextDir.Clear(); // Limpia dirección
            TextCom.Clear(); // Limpia comuna
            TextGir.Clear(); // Limpia giro
            TextTel.Clear(); // Limpia teléfono
            TextFech.Text = DateTime.Now.ToShortDateString(); // Restablece fecha

            if (this.Controls.Find("TextIdCli", true).FirstOrDefault() is TextBox idCliTextBox) // Busca ID cliente
            {
                idCliTextBox.Clear(); // Limpia ID cliente
            }

            TextSubTo.Text = "0"; // Establece subtotal cero
            if (ComboDes.Items.Count > 0) ComboDes.SelectedIndex = 0; // Selecciona primer descuento
            TextIVA.Text = "0"; // Establece IVA cero
            TxxtTotaLL.Text = "0"; // Establece total cero

            MetodoLimpiarCamposProductosParaUI(); // Limpia campos productos

            contProductos = 1; // Reinicia contador productos

            BtnCliArrIng.Enabled = true; // Habilita botón cliente
            BtnProdArr.Enabled = false; // Deshabilita botón producto
            BtnUltProdd.Enabled = false; // Deshabilita botón borrar

            MetodoCalcularTotalGeneral(); // Recalcula total general
        }

        private void MetodoLimpiarCamposProductosParaUI() // Limpia campos productos UI
        {
            for (int i = 1; i <= 10; i++) // Itera 10 productos
            {
                TextBox cantTextBox = this.Controls.Find($"TextCan{i}", true).FirstOrDefault() as TextBox; // Busca campo cantidad
                if (cantTextBox != null) // Si existe
                {
                    cantTextBox.TextChanged -= ManejadorTextCanCambioTexto; // Desasocia evento
                }
            }

            for (int i = 1; i <= 10; i++) // Itera 10 productos
            {
                TextBox prodTextBox = this.Controls.Find($"TextProd{i}", true).FirstOrDefault() as TextBox; // Busca campo producto
                TextBox cantTextBox = this.Controls.Find($"TextCan{i}", true).FirstOrDefault() as TextBox; // Busca campo cantidad
                TextBox vuTextBox = this.Controls.Find($"TextVUn{i}", true).FirstOrDefault() as TextBox; // Busca campo valor unitario
                TextBox vtTextBox = this.Controls.Find($"TextVTol{i}", true).FirstOrDefault() as TextBox; // Busca campo valor total
                TextBox idProdTextBox = this.Controls.Find($"TextIdProd{i}", true).FirstOrDefault() as TextBox; // Busca campo ID producto

                if (prodTextBox != null) { prodTextBox.Clear(); prodTextBox.ReadOnly = true; } // Limpia y solo lectura
                if (cantTextBox != null) { cantTextBox.Clear(); cantTextBox.ReadOnly = true; } // Limpia y solo lectura
                if (vuTextBox != null) { vuTextBox.Clear(); vuTextBox.ReadOnly = true; } // Limpia y solo lectura
                if (vtTextBox != null) { vtTextBox.Clear(); vtTextBox.ReadOnly = true; } // Limpia y solo lectura
                if (idProdTextBox != null) { idProdTextBox.Clear(); idProdTextBox.ReadOnly = true; } // Limpia y solo lectura
            }

            for (int i = 1; i <= 10; i++) // Itera 10 productos
            {
                TextBox cantTextBox = this.Controls.Find($"TextCan{i}", true).FirstOrDefault() as TextBox; // Busca campo cantidad
                if (cantTextBox != null) // Si existe
                {
                    cantTextBox.TextChanged += ManejadorTextCanCambioTexto; // Reasocia evento
                }
            }
        }

        private void MetodoCargarListaDescuentos() // Carga lista descuentos
        {
            var lista = new List<object> // Crea lista descuentos
{
    new { Texto = "0%", Valor = 0 }, // Descuento 0%
    new { Texto = "5%", Valor = 5 }, // Descuento 5%
    new { Texto = "10%", Valor = 10 }, // Descuento 10%
    new { Texto = "15%", Valor = 15 }, // Descuento 15%
    new { Texto = "20%", Valor = 20 }, // Descuento 20%
    new { Texto = "25%", Valor = 25 }, // Descuento 25%
    new { Texto = "30%", Valor = 30 }, // Descuento 30%
    new { Texto = "35%", Valor = 35 }, // Descuento 35%
    new { Texto = "40%", Valor = 40 }, // Descuento 40%
    new { Texto = "45%", Valor = 45 }, // Descuento 45%
    new { Texto = "50%", Valor = 50 }, // Descuento 50%
    new { Texto = "55%", Valor = 55 }, // Descuento 55%
    new { Texto = "60%", Valor = 60 }, // Descuento 60%
    new { Texto = "70%", Valor = 70 }, // Descuento 70%
    new { Texto = "75%", Valor = 75 }, // Descuento 75%
    new { Texto = "80%", Valor = 80 }, // Descuento 80%
    new { Texto = "85%", Valor = 85 }, // Descuento 85%
    new { Texto = "90%", Valor = 90 }, // Descuento 90%
    new { Texto = "95%", Valor = 95 }, // Descuento 95%
    new { Texto = "100%", Valor = 100 } // Descuento 100%
};

            ComboDes.DataSource = lista; // Asigna fuente datos
            ComboDes.DisplayMember = "Texto"; // Muestra texto
            ComboDes.ValueMember = "Valor"; // Usa valor
            ComboDes.SelectedIndex = 0; // Selecciona primer item
        }

        // Calcula total general del arriendo.
        private void MetodoCalcularTotalGeneral()
        {
            // Inicializa subtotal en cero.
            decimal subTotal = 0;

            // Itera sobre los 10 productos.
            for (int i = 1; i <= 10; i++)
            {
                // Busca campo de valor total.
                TextBox vtTextBox = this.Controls.Find($"TextVTol{i}", true).FirstOrDefault() as TextBox;
                // Si existe y tiene contenido.
                if (vtTextBox != null && !string.IsNullOrWhiteSpace(vtTextBox.Text))
                {
                    // Limpia formato de moneda chilena.
                    string valorSinFormato = vtTextBox.Text.Replace("$", "").Replace(".", "").Replace("CLP", "").Trim();
                    // Si convierte correctamente a decimal.
                    if (decimal.TryParse(valorSinFormato, NumberStyles.Any, new CultureInfo("es-CL"), out decimal valorLinea))
                    {
                        // Suma al subtotal general.
                        subTotal += valorLinea;
                    }
                }
            }

            // Muestra subtotal con formato chileno.
            TextSubTo.Text = subTotal.ToString("N0", new CultureInfo("es-CL"));

            // Inicializa descuento en cero.
            decimal descuentoPorcentaje = 0;

            // Valida que ComboBox tenga valor seleccionado.
            if (ComboDes.SelectedValue != null && ComboDes.SelectedIndex >= 0)
            {
                // Convierte valor seleccionado a decimal.
                if (decimal.TryParse(ComboDes.SelectedValue.ToString(), out decimal valorDescuento))
                {
                    // Convierte porcentaje a decimal.
                    descuentoPorcentaje = valorDescuento / 100m;
                }
            }

            // Calcula monto de descuento aplicado.
            decimal montoDescuento = subTotal * descuentoPorcentaje;
            // Calcula subtotal con descuento aplicado.
            decimal subTotalConDescuento = subTotal - montoDescuento;

            // Calcula IVA del 19 porciento.
            decimal ivaCalculado = subTotalConDescuento * 0.19m;
            // Muestra IVA con formato chileno.
            TextIVA.Text = ivaCalculado.ToString("N0", new CultureInfo("es-CL"));

            // Calcula total final con IVA.
            decimal total = subTotalConDescuento + ivaCalculado;
            // Muestra total con formato moneda.
            TxxtTotaLL.Text = total.ToString("C", new CultureInfo("es-CL"));
        }
        private void PArrIng_Load(object sender, EventArgs e) // Evento carga formulario
        {
            ThemeManager.ApplyExecutiveTheme(this); // Aplica tema ejecutivo
            MetodoConfigurarInicioUI();
        }

        private void ManejadorButCliClick(object sender, EventArgs e) // Click botón cliente
        {
            using (PCli_Con formClientes = new PCli_Con()) // Crea formulario clientes
            {
                formClientes.FormularioPadre = (Presentacion.ArriFinal.PArrIng)this; // Asigna formulario padre
                formClientes.ShowDialog(); // Muestra modal
                if (this.Controls.Find("TextIdCli", true).FirstOrDefault() is TextBox idCliTextBox && // Si encuentra ID cliente
                    !string.IsNullOrWhiteSpace(idCliTextBox.Text) && idCliTextBox.Text != "0") // Y no vacío o cero
                {
                    BtnProdArr.Enabled = true; // Habilita botón producto
                    tabControl1.SelectedTab = tabPage2; // Cambia a pestaña productos
                }
                else // Si no seleccionó cliente
                {
                    BtnProdArr.Enabled = false; // Deshabilita botón producto
                    MessageBox.Show("No se seleccionó cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia
                }
            }
        }

        private void ManejadorButProClick(object sender, EventArgs e) // Click botón producto
        {
            if (contProductos > 10) // Si excede límite
            {
                MessageBox.Show("Máximo 10 productos permitidos", "Límite", MessageBoxButtons.OK, MessageBoxIcon.Information); // Informa límite
                BtnProdArr.Enabled = false; // Deshabilita botón
                return; // Sale del método
            }

            PProd_Con formProductos = new PProd_Con(); // Crea formulario productos

            formProductos.FormularioPadre = (Presentacion.ArriFinal.PArrIng)this; // Asigna formulario padre
            formProductos.Show(); // Muestra formulario
        }

        private void ManejadorButUlProClick(object sender, EventArgs e) // Click botón borrar último
        {
            TextBox firstProdTextBox = this.Controls.Find("TextProd1", true).FirstOrDefault() as TextBox; // Busca primer producto
            if (contProductos == 1 && (firstProdTextBox == null || string.IsNullOrWhiteSpace(firstProdTextBox.Text))) // Si solo uno y vacío
            {
                MessageBox.Show("No hay productos para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Informa
                BtnUltProdd.Enabled = false; // Deshabilita botón
                return; // Sale del método
            }

            TextBox cantToClear = this.Controls.Find($"TextCan{contProductos - 1}", true).FirstOrDefault() as TextBox; // Busca campo cantidad anterior
            if (cantToClear != null) // Si existe
            {
                cantToClear.TextChanged -= ManejadorTextCanCambioTexto; // Desasocia evento
            }

            contProductos--; // Decrementa contador

            TextBox prodTextBox = this.Controls.Find($"TextProd{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo producto
            TextBox cantTextBox = this.Controls.Find($"TextCan{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo cantidad
            TextBox vuTextBox = this.Controls.Find($"TextVUn{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo valor unitario
            TextBox vtTextBox = this.Controls.Find($"TextVTol{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo valor total
            TextBox idProdTextBox = this.Controls.Find($"TextIdProd{contProductos}", true).FirstOrDefault() as TextBox; // Busca campo ID producto

            if (prodTextBox != null) { prodTextBox.Clear(); prodTextBox.ReadOnly = true; } // Limpia y solo lectura
            if (cantTextBox != null) { cantTextBox.Clear(); cantTextBox.ReadOnly = true; } // Limpia y solo lectura
            if (vuTextBox != null) { vuTextBox.Clear(); vuTextBox.ReadOnly = true; } // Limpia y solo lectura
            if (vtTextBox != null) { vtTextBox.Clear(); vtTextBox.ReadOnly = true; } // Limpia y solo lectura
            if (idProdTextBox != null) { idProdTextBox.Clear(); idProdTextBox.ReadOnly = true; } // Limpia y solo lectura

            MetodoCalcularTotalGeneral(); // Recalcula totales

            BtnProdArr.Enabled = true; // Habilita botón producto

            if (contProductos == 1 && (firstProdTextBox == null || string.IsNullOrWhiteSpace(firstProdTextBox.Text))) // Si solo queda uno vacío
            {
                BtnUltProdd.Enabled = false; // Deshabilita botón borrar
            }
        }

        private void ManejadorButLimClick(object sender, EventArgs e) // Click botón limpiar
        {
            MetodoLimpiarFormularioCompleto(); // Limpia formulario completo
            MessageBox.Show("Formulario limpiado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Informa limpieza
        }

        private string MetodoFormatearImporte(string valor) // Formatea valor monetario
        {
            if (string.IsNullOrWhiteSpace(valor)) // Si valor vacío
                return "0.00"; // Retorna 0.00

            valor = valor.Replace("CLP", "") // Elimina CLP
                            .Replace("$", "") // Elimina $
                            .Replace("Total:", "") // Elimina Total:
                            .Trim(); // Elimina espacios

            string limpio = valor.Replace(".", "").Replace(",", "."); // Elimina puntos, cambia coma

            if (Regex.IsMatch(limpio, @"^\d+(\.\d{1,2})?$")) // Si coincide patrón numérico
                return limpio; // Retorna valor limpio
            else // Si no es numérico
                return "0.00"; // Retorna 0.00
        }

        private void ManejadorButIngClick(object sender, EventArgs e) // Click botón ingresar
        {
            if (string.IsNullOrWhiteSpace(TextProd1.Text)) // Si primer producto vacío
            {
                MessageBox.Show("Seleccione al menos un producto", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia
                return; // Sale del método
            }

            var res = MessageBox.Show("¿Confirmar acción?", "Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question); // Confirma acción
            if (res != DialogResult.Yes) // Si no es Sí
            {
                if (res == DialogResult.No) ButVol.Focus(); // Si es No, enfoca volver
                if (res == DialogResult.Cancel) ButSal.Focus(); // Si es Cancelar, enfoca salir
                return; // Sale del método
            }

            EArrDet arrDet = new EArrDet // Crea entidad detalles
            {
                DPr1 = TextProd1.Text, // Asigna producto 1
                DPr2 = TextProd2.Text, // Asigna producto 2
                DPr3 = TextProd3.Text, // Asigna producto 3
                DPr4 = TextProd4.Text, // Asigna producto 4
                DPr5 = TextProd5.Text, // Asigna producto 5
                DPr6 = TextProd6.Text, // Asigna producto 6
                DPr7 = TextProd7.Text, // Asigna producto 7
                DPr8 = TextProd8.Text, // Asigna producto 8
                DPr9 = TextProd9.Text, // Asigna producto 9
                DPr10 = TextProd10.Text // Asigna producto 10
            };

            EArrPro arrPro = new EArrPro // Crea entidad IDs producto
            {
                IdPprod1 = int.Parse(TextIdProd1.Text), // Asigna ID producto 1
                IdPprod2 = int.TryParse(TextIdProd2.Text, out int id2) ? (int?)id2 : null, // Asigna ID producto 2
                IdPprod3 = int.TryParse(TextIdProd3.Text, out int id3) ? (int?)id3 : null, // Asigna ID producto 3
                IdPprod4 = int.TryParse(TextIdProd4.Text, out int id4) ? (int?)id4 : null, // Asigna ID producto 4
                IdPprod5 = int.TryParse(TextIdProd5.Text, out int id5) ? (int?)id5 : null, // Asigna ID producto 5
                IdPprod6 = int.TryParse(TextIdProd6.Text, out int id6) ? (int?)id6 : null, // Asigna ID producto 6
                IdPprod7 = int.TryParse(TextIdProd7.Text, out int id7) ? (int?)id7 : null, // Asigna ID producto 7
                IdPprod8 = int.TryParse(TextIdProd8.Text, out int id8) ? (int?)id8 : null, // Asigna ID producto 8
                IdPprod9 = int.TryParse(TextIdProd9.Text, out int id9) ? (int?)id9 : null, // Asigna ID producto 9
                IdPprod10 = int.TryParse(TextIdProd10.Text, out int id10) ? (int?)id10 : null // Asigna ID producto 10
            };

            EArrVUn arrVUn = new EArrVUn // Crea entidad valores unitarios
            {
                VUn1 = TextVUn1.Text, // Asigna valor unitario 1
                VUn2 = TextVUn2.Text, // Asigna valor unitario 2
                VUn3 = TextVUn3.Text, // Asigna valor unitario 3
                VUn4 = TextVUn4.Text, // Asigna valor unitario 4
                VUn5 = TextVUn5.Text, // Asigna valor unitario 5
                VUn6 = TextVUn6.Text, // Asigna valor unitario 6
                VUn7 = TextVUn7.Text, // Asigna valor unitario 7
                VUn8 = TextVUn8.Text, // Asigna valor unitario 8
                VUn9 = TextVUn9.Text, // Asigna valor unitario 9
                VUn10 = TextVUn10.Text // Asigna valor unitario 10
            };

            var resDet = NArrDet.Ingresar(arrDet); // Ingresa detalles
            var resPro = NArrPro.Ingresar(arrPro); // Ingresa productos
            var resVUn = NArrVUn.Ingresar(arrVUn); // Ingresa valores unitarios

            if (!resDet.estado || !resPro.estado || !resVUn.estado) // Si alguna falla
            {
                MessageBox.Show("Error al insertar datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error
                return; // Sale del método
            }

            int idDet = logicaNegocioArrDet.ObtenerUltimoId(); // Obtiene último ID detalle
            int idPro = logicaNegocioArrPro.ObtenerUltimoId(); // Obtiene último ID producto
            int idVUn = logicaNegocioArrVUn.ObtenerUltimoId(); // Obtiene último ID valor unitario
            TextIdADet.Text = idDet.ToString();
            TextIdAPro.Text = idPro.ToString();
            TextIdAVun.Text = idVUn.ToString();

            string subto = MetodoFormatearImporte(TextSubTo.Text); // Formatea subtotal
            string descuento = MetodoFormatearImporte(ComboDes.SelectedValue?.ToString()); // Formatea descuento
            string iva = MetodoFormatearImporte(TextIVA.Text); // Formatea IVA
            string total = MetodoFormatearImporte(TxxtTotaLL.Text); // Formatea total

            EArr cotizacion = new EArr // Crea entidad cotización
            {
                IdP_Cli = Convert.ToInt32(TextIdCli.Text), // Asigna ID cliente
                Fech = TextFech.Text, // Asigna fecha
                SubTo = subto, // Asigna subtotal
                Descuento = descuento, // Asigna descuento
                IVA = iva, // Asigna IVA
                Total = total, // Asigna total
                IdADet = idDet, // Asigna ID detalle
                IdAPro = idPro, // Asigna ID producto
                IdAVUn = idVUn // Asigna ID valor unitario
            };

            var resultadoArr = NArr.Ingresar(cotizacion); // Ingresa cotización
            if (resultadoArr.estado) // Si la inserción es exitosa
            {
                MessageBox.Show("Ingreso realizado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra éxito
                MetodoActualizarStockProductos(); // Actualiza stock de productos
                ButImp.Enabled = true; 

            }
            else // Si la inserción falla
            {
                MessageBox.Show($"No se pudo ingresar la cotización.\n\n{resultadoArr.mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra mensaje de error
            }
        }
        private void MetodoActualizarStockProductos() // Actualiza stock productos
        {
            Dictionary<int, (int CantidadTotalArrendada, int StockOriginal)> productosParaActualizar = // Diccionario productos
                new Dictionary<int, (int, int)>(); // Inicializa diccionario

            for (int i = 1; i <= 10; i++) // Itera 10 productos
            {
                string nombreIdProd = "TextIdProd" + i; // Nombre campo ID
                string nombreTextBoxCantidad = "TextCan" + i; // Nombre campo cantidad

                TextBox txtIdProd = Controls.Find(nombreIdProd, true).FirstOrDefault() as TextBox; // Busca campo ID
                TextBox txtCantidad = Controls.Find(nombreTextBoxCantidad, true).FirstOrDefault() as TextBox; // Busca campo cantidad

                if (txtIdProd != null && !string.IsNullOrWhiteSpace(txtIdProd.Text) && // Si ID existe
                    txtCantidad != null && !string.IsNullOrWhiteSpace(txtCantidad.Text)) // Y cantidad existe
                {
                    if (int.TryParse(txtIdProd.Text, out int idProducto) && // Convierte ID
                        int.TryParse(txtCantidad.Text, out int cantidadArrendada)) // Convierte cantidad
                    {
                        EProd productoDB = logicaNegocioProd.Listar().FirstOrDefault(p => p.IdProd == idProducto); // Busca producto
                        if (productoDB != null && int.TryParse(productoDB.TAct, out int stockOriginal)) // Si producto existe
                        {
                            if (productosParaActualizar.ContainsKey(idProducto)) // Si ya existe
                            {
                                var actual = productosParaActualizar[idProducto]; // Obtiene actual
                                productosParaActualizar[idProducto] = // Actualiza valores
                                    (actual.CantidadTotalArrendada + cantidadArrendada, stockOriginal);
                            }
                            else // Si no existe
                            {
                                productosParaActualizar.Add(idProducto, (cantidadArrendada, stockOriginal)); // Agrega nuevo
                            }
                        }
                        else // Si no encuentra producto
                        {
                            MessageBox.Show($"No se pudo obtener stock producto ID {idProducto}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra advertencia
                        }
                    }
                }
            }

            foreach (var producto in productosParaActualizar) // Itera productos
            {
                int id = producto.Key; // Obtiene ID
                int cantidadArrendada = producto.Value.CantidadTotalArrendada; // Obtiene cantidad
                int stockOriginal = producto.Value.StockOriginal; // Obtiene stock

                try // Intenta actualizar
                {
                    entidadProducto.IdProd = id; // Asigna ID
                    entidadProducto.CArr = cantidadArrendada.ToString(); // Asigna cantidad arrendada
                    entidadProducto.TAct = (stockOriginal - cantidadArrendada).ToString(); // Calcula nuevo stock

                    Respuesta<bool> resp = NProd.Actualizar2(entidadProducto); // Actualiza producto

                    if (!resp.estado) // Si falla
                    {
                        MessageBox.Show($"Error actualizando stock producto {id}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra error
                    }
                }
                catch (Exception ex) // Captura excepción
                {
                    MessageBox.Show($"Error actualizando stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error
                }
            }
        }

        private void ManejadorComboDesCambioSeleccion(object sender, EventArgs e) // Cambio selección descuento
        {
            MetodoCalcularTotalGeneral(); // Recalcula totales
        }

        private void ManejadorTabControlCambioIndice(object sender, EventArgs e) // Cambio pestaña
        {
            if (tabControl1.SelectedTab == tabPage1) // Si pestaña 1
            {
                BtnCliArrIng.Enabled = true; // Habilita cliente
                BtnProdArr.Enabled = false; // Deshabilita producto
                BtnUltProdd.Enabled = false; // Deshabilita borrar
            }
            else if (tabControl1.SelectedTab == tabPage2) // Si pestaña 2
            {
                BtnCliArrIng.Enabled = false; // Deshabilita cliente
                TextBox idCliTextBox = this.Controls.Find("TextIdCli", true).FirstOrDefault() as TextBox; // Busca ID cliente
                BtnProdArr.Enabled = (idCliTextBox != null && !string.IsNullOrWhiteSpace(idCliTextBox.Text) && idCliTextBox.Text != "0"); // Habilita producto

                BtnUltProdd.Enabled = (contProductos > 1); // Habilita borrar
            }
        }

        private void ManejadorTextCanCambioTexto(object sender, EventArgs e) // Cambio texto cantidad
        {
            TextBox cantidadTextBox = sender as TextBox; // Obtiene TextBox
            if (cantidadTextBox == null) return; // Si nulo sale

            string name = cantidadTextBox.Name; // Obtiene nombre
            string indexStr = name.Replace("TextCan", ""); // Extrae índice

            TextBox vuTextBox = this.Controls.Find($"TextVUn{indexStr}", true).FirstOrDefault() as TextBox; // Busca valor unitario
            TextBox vtTextBox = this.Controls.Find($"TextVTol{indexStr}", true).FirstOrDefault() as TextBox; // Busca valor total

            if (vuTextBox == null || vtTextBox == null) return; // Si nulos sale

            double cantidad = 0; // Inicializa cantidad
            if (!string.IsNullOrWhiteSpace(cantidadTextBox.Text) && double.TryParse(cantidadTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedCantidad)) // Parsea cantidad
            {
                cantidad = parsedCantidad; // Asigna cantidad
            }

            double valorUnitario = 0; // Inicializa valor
            if (!string.IsNullOrWhiteSpace(vuTextBox.Text)) // Si tiene texto
            {
                string cleanedVuText = vuTextBox.Text.Replace(".", "").Replace("$", "").Trim(); // Limpia texto
                if (double.TryParse(cleanedVuText, NumberStyles.Any, new CultureInfo("es-CL"), out double parsedValorUnitario)) // Parsea valor
                {
                    valorUnitario = parsedValorUnitario; // Asigna valor
                }
            }

            double resultado = cantidad * valorUnitario; // Calcula resultado
            vtTextBox.Text = resultado.ToString("C0", new CultureInfo("es-CL")); // Muestra formateado

            MetodoCalcularTotalGeneral(); // Recalcula totales
        }

        private void ManejadorButVolClick(object sender, EventArgs e) // Click botón volver
        {
            this.Close(); // Cierra formulario
        }

        private void ManejadorButSalClick(object sender, EventArgs e) // Click botón salir
        {
            Application.Exit(); // Cierra aplicación
        }

        private void ButIng_Click(object sender, EventArgs e) // Click botón ingresar
        {
            // Sin lógica.
        }

        private void ButImp_Click(object sender, EventArgs e) // Click botón imprimir
        {
            // Validaciones antes de generar el reporte.
            if (string.IsNullOrWhiteSpace(TextNomCli.Text))
            {
                MessageBox.Show("Debe ingresar y guardar la cotización antes de imprimir", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TextProd1.Text))
            {
                MessageBox.Show("Debe tener al menos un producto para imprimir", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (TextIdProd2.Text == "1") // Si indicador 2 activo
                {
                    TextProd2.Text = ""; // Limpia producto 2
                    TextCan2.Text = ""; // Limpia cantidad 2
                    TextVUn2.Text = ""; // Limpia valor 2
                }

                if (TextIdProd3.Text == "1") // Si indicador 3 activo
                {
                    TextProd3.Text = ""; // Limpia producto 3
                    TextCan3.Text = ""; // Limpia cantidad 3
                    TextVUn3.Text = ""; // Limpia valor 3
                }

                if (TextIdProd4.Text == "1") // Si indicador 4 activo
                {
                    TextProd4.Text = ""; // Limpia producto 4
                    TextCan4.Text = ""; // Limpia cantidad 4
                    TextVUn4.Text = ""; // Limpia valor 4
                }

                if (TextIdProd5.Text == "1") // Si indicador 5 activo
                {
                    TextProd5.Text = ""; // Limpia producto 5
                    TextCan5.Text = ""; // Limpia cantidad 5
                    TextVUn5.Text = ""; // Limpia valor 5
                }

                if (TextIdProd6.Text == "1") // Si indicador 6 activo
                {
                    TextProd6.Text = ""; // Limpia producto 6
                    TextCan6.Text = ""; // Limpia cantidad 6
                    TextVUn6.Text = ""; // Limpia valor 6
                }

                if (TextIdProd7.Text == "1") // Si indicador 7 activo
                {
                    TextProd7.Text = ""; // Limpia producto 7
                    TextCan7.Text = ""; // Limpia cantidad 7
                    TextVUn7.Text = ""; // Limpia valor 7
                }

                if (TextIdProd8.Text == "1") // Si indicador 8 activo
                {
                    TextProd8.Text = ""; // Limpia producto 8
                    TextCan8.Text = ""; // Limpia cantidad 8
                    TextVUn8.Text = ""; // Limpia valor 8
                }

                if (TextIdProd9.Text == "1") // Si indicador 9 activo
                {
                    TextProd9.Text = ""; // Limpia producto 9
                    TextCan9.Text = ""; // Limpia cantidad 9
                    TextVUn9.Text = ""; // Limpia valor 9
                }

                if (TextIdProd10.Text == "1") // Si indicador 10 activo
                {
                    TextProd10.Text = ""; // Limpia producto 10
                    TextCan10.Text = ""; // Limpia cantidad 10
                    TextVUn10.Text = ""; // Limpia valor 10
                }

                IdArr.ParameterFieldName = "IdArr"; // Asigna nombre parámetro
                NomClie.ParameterFieldName = "NomClie"; // Asigna nombre parámetro
                Rut.ParameterFieldName = "Rut"; // Asigna nombre parámetro
                Direccion.ParameterFieldName = "Direccion"; // Asigna nombre parámetro
                Comuna.ParameterFieldName = "Comuna"; // Asigna nombre parámetro
                Giro.ParameterFieldName = "Giro"; // Asigna nombre parámetro
                Telefono.ParameterFieldName = "Telefono"; // Asigna nombre parámetro
                Fecha.ParameterFieldName = "Fecha"; // Asigna nombre parámetro

                C1.ParameterFieldName = "C1"; // Asigna nombre parámetro
                C2.ParameterFieldName = "C2"; // Asigna nombre parámetro
                C3.ParameterFieldName = "C3"; // Asigna nombre parámetro
                C4.ParameterFieldName = "C4"; // Asigna nombre parámetro
                C5.ParameterFieldName = "C5"; // Asigna nombre parámetro
                C6.ParameterFieldName = "C6"; // Asigna nombre parámetro
                C7.ParameterFieldName = "C7"; // Asigna nombre parámetro
                C8.ParameterFieldName = "C8"; // Asigna nombre parámetro
                C9.ParameterFieldName = "C9"; // Asigna nombre parámetro
                C10.ParameterFieldName = "C10"; // Asigna nombre parámetro

                P1.ParameterFieldName = "P1"; // Asigna nombre parámetro
                P2.ParameterFieldName = "P2"; // Asigna nombre parámetro
                P3.ParameterFieldName = "P3"; // Asigna nombre parámetro
                P4.ParameterFieldName = "P4"; // Asigna nombre parámetro
                P5.ParameterFieldName = "P5"; // Asigna nombre parámetro
                P6.ParameterFieldName = "P6"; // Asigna nombre parámetro
                P7.ParameterFieldName = "P7"; // Asigna nombre parámetro
                P8.ParameterFieldName = "P8"; // Asigna nombre parámetro
                P9.ParameterFieldName = "P9"; // Asigna nombre parámetro
                P10.ParameterFieldName = "P10"; // Asigna nombre parámetro

                U1.ParameterFieldName = "U1"; // Asigna nombre parámetro
                U2.ParameterFieldName = "U2"; // Asigna nombre parámetro
                U3.ParameterFieldName = "U3"; // Asigna nombre parámetro
                U4.ParameterFieldName = "U4"; // Asigna nombre parámetro
                U5.ParameterFieldName = "U5"; // Asigna nombre parámetro
                U6.ParameterFieldName = "U6"; // Asigna nombre parámetro
                U7.ParameterFieldName = "U7"; // Asigna nombre parámetro
                U8.ParameterFieldName = "U8"; // Asigna nombre parámetro
                U9.ParameterFieldName = "U9"; // Asigna nombre parámetro
                U10.ParameterFieldName = "U10"; // Asigna nombre parámetro

                T1.ParameterFieldName = "T1"; // Asigna nombre parámetro
                T2.ParameterFieldName = "T2"; // Asigna nombre parámetro
                T3.ParameterFieldName = "T3"; // Asigna nombre parámetro
                T4.ParameterFieldName = "T4"; // Asigna nombre parámetro
                T5.ParameterFieldName = "T5"; // Asigna nombre parámetro
                T6.ParameterFieldName = "T6"; // Asigna nombre parámetro
                T7.ParameterFieldName = "T7"; // Asigna nombre parámetro
                T8.ParameterFieldName = "T8"; // Asigna nombre parámetro
                T9.ParameterFieldName = "T9"; // Asigna nombre parámetro
                T10.ParameterFieldName = "T10"; // Asigna nombre parámetro

                SubTotal.ParameterFieldName = "SubTotal"; // Asigna nombre parámetro
                Descuento.ParameterFieldName = "Descuento"; // Asigna nombre parámetro
                Iva.ParameterFieldName = "Iva"; // Asigna nombre parámetro
                Total.ParameterFieldName = "Total"; // Asigna nombre parámetro

                CNomClie.Value = this.TextNomCli.Text; // Asigna valor
                CRut.Value = this.TextRut.Text; // Asigna valor
                CDireccion.Value = this.TextDir.Text; // Asigna valor
                CComuna.Value = this.TextCom.Text; // Asigna valor
                CGiro.Value = this.TextGir.Text; // Asigna valor
                CTelefono.Value = this.TextTel.Text; // Asigna valor
                CFecha.Value = this.TextFech.Text; // Asigna valor
                CIdArr.Value = this.TextIdADet.Text; // Asigna valor

                CC1.Value = this.TextCan1.Text; // Asigna valor
                CC2.Value = this.TextCan2.Text; // Asigna valor
                CC3.Value = this.TextCan3.Text; // Asigna valor
                CC4.Value = this.TextCan4.Text; // Asigna valor
                CC5.Value = this.TextCan5.Text; // Asigna valor
                CC6.Value = this.TextCan6.Text; // Asigna valor
                CC7.Value = this.TextCan7.Text; // Asigna valor
                CC8.Value = this.TextCan8.Text; // Asigna valor
                CC9.Value = this.TextCan9.Text; // Asigna valor
                CC10.Value = this.TextCan10.Text; // Asigna valor

                CP1.Value = this.TextProd1.Text; // Asigna valor
                CP2.Value = this.TextProd2.Text; // Asigna valor
                CP3.Value = this.TextProd3.Text; // Asigna valor
                CP4.Value = this.TextProd4.Text; // Asigna valor
                CP5.Value = this.TextProd5.Text; // Asigna valor
                CP6.Value = this.TextProd6.Text; // Asigna valor
                CP7.Value = this.TextProd7.Text; // Asigna valor
                CP8.Value = this.TextProd8.Text; // Asigna valor
                CP9.Value = this.TextProd9.Text; // Asigna valor
                CP10.Value = this.TextProd10.Text; // Asigna valor

                CU1.Value = this.TextVUn1.Text; // Asigna valor
                CU2.Value = this.TextVUn2.Text; // Asigna valor
                CU3.Value = this.TextVUn3.Text; // Asigna valor
                CU4.Value = this.TextVUn4.Text; // Asigna valor
                CU5.Value = this.TextVUn5.Text; // Asigna valor
                CU6.Value = this.TextVUn6.Text; // Asigna valor
                CU7.Value = this.TextVUn7.Text; // Asigna valor
                CU8.Value = this.TextVUn8.Text; // Asigna valor
                CU9.Value = this.TextVUn9.Text; // Asigna valor
                CU10.Value = this.TextVUn10.Text; // Asigna valor

                CT1.Value = this.TextVTol1.Text; // Asigna valor
                CT2.Value = this.TextVTol2.Text; // Asigna valor
                CT3.Value = this.TextVTol3.Text; // Asigna valor
                CT4.Value = this.TextVTol4.Text; // Asigna valor
                CT5.Value = this.TextVTol5.Text; // Asigna valor
                CT6.Value = this.TextVTol6.Text; // Asigna valor
                CT7.Value = this.TextVTol7.Text; // Asigna valor
                CT8.Value = this.TextVTol8.Text; // Asigna valor
                CT9.Value = this.TextVTol9.Text; // Asigna valor
                CT10.Value = this.TextVTol10.Text; // Asigna valor

                CSubTotal.Value = this.TextSubTo.Text; // Asigna valor
                CDescuento.Value = this.ComboDes.Text; // Asigna valor
                CIva.Value = this.TextIVA.Text; // Asigna valor
                CTotal.Value = this.TxxtTotaLL.Text; // Asigna valor

                NomClie.CurrentValues.Add(CNomClie); // Agrega valor
                Rut.CurrentValues.Add(CRut); // Agrega valor
                Direccion.CurrentValues.Add(CDireccion); // Agrega valor
                Comuna.CurrentValues.Add(CComuna); // Agrega valor
                Giro.CurrentValues.Add(CGiro); // Agrega valor
                Telefono.CurrentValues.Add(CTelefono); // Agrega valor
                Fecha.CurrentValues.Add(CFecha); // Agrega valor
                IdArr.CurrentValues.Add(CIdArr); // Agrega valor

                C1.CurrentValues.Add(CC1); // Agrega valor
                C2.CurrentValues.Add(CC2); // Agrega valor
                C3.CurrentValues.Add(CC3); // Agrega valor
                C4.CurrentValues.Add(CC4); // Agrega valor
                C5.CurrentValues.Add(CC5); // Agrega valor
                C6.CurrentValues.Add(CC6); // Agrega valor
                C7.CurrentValues.Add(CC7); // Agrega valor
                C8.CurrentValues.Add(CC8); // Agrega valor
                C9.CurrentValues.Add(CC9); // Agrega valor
                C10.CurrentValues.Add(CC10); // Agrega valor

                P1.CurrentValues.Add(CP1); // Agrega valor
                P2.CurrentValues.Add(CP2); // Agrega valor
                P3.CurrentValues.Add(CP3); // Agrega valor
                P4.CurrentValues.Add(CP4); // Agrega valor
                P5.CurrentValues.Add(CP5); // Agrega valor
                P6.CurrentValues.Add(CP6); // Agrega valor
                P7.CurrentValues.Add(CP7); // Agrega valor
                P8.CurrentValues.Add(CP8); // Agrega valor
                P9.CurrentValues.Add(CP9); // Agrega valor
                P10.CurrentValues.Add(CP10); // Agrega valor

                U1.CurrentValues.Add(CU1); // Agrega valor
                U2.CurrentValues.Add(CU2); // Agrega valor
                U3.CurrentValues.Add(CU3); // Agrega valor
                U4.CurrentValues.Add(CU4); // Agrega valor
                U5.CurrentValues.Add(CU5); // Agrega valor
                U6.CurrentValues.Add(CU6); // Agrega valor
                U7.CurrentValues.Add(CU7); // Agrega valor
                U8.CurrentValues.Add(CU8); // Agrega valor
                U9.CurrentValues.Add(CU9); // Agrega valor
                U10.CurrentValues.Add(CU10); // Agrega valor

                T1.CurrentValues.Add(CT1); // Agrega valor
                T2.CurrentValues.Add(CT2); // Agrega valor
                T3.CurrentValues.Add(CT3); // Agrega valor
                T4.CurrentValues.Add(CT4); // Agrega valor
                T5.CurrentValues.Add(CT5); // Agrega valor
                T6.CurrentValues.Add(CT6); // Agrega valor
                T7.CurrentValues.Add(CT7); // Agrega valor
                T8.CurrentValues.Add(CT8); // Agrega valor
                T9.CurrentValues.Add(CT9); // Agrega valor
                T10.CurrentValues.Add(CT10); // Agrega valor

                SubTotal.CurrentValues.Add(CSubTotal); // Agrega valor
                Descuento.CurrentValues.Add(CDescuento); // Agrega valor
                Iva.CurrentValues.Add(CIva); // Agrega valor
                Total.CurrentValues.Add(CTotal); // Agrega valor

                Parametros.Add(IdArr); // Agrega parámetro
                Parametros.Add(NomClie); // Agrega parámetro
                Parametros.Add(Rut); // Agrega parámetro
                Parametros.Add(Direccion); // Agrega parámetro
                Parametros.Add(Comuna); // Agrega parámetro
                Parametros.Add(Giro); // Agrega parámetro
                Parametros.Add(Telefono); // Agrega parámetro
                Parametros.Add(Fecha); // Agrega parámetro

                Parametros.Add(C1); // Agrega parámetro
                Parametros.Add(C2); // Agrega parámetro
                Parametros.Add(C3); // Agrega parámetro
                Parametros.Add(C4); // Agrega parámetro
                Parametros.Add(C5); // Agrega parámetro
                Parametros.Add(C6); // Agrega parámetro
                Parametros.Add(C7); // Agrega parámetro
                Parametros.Add(C8); // Agrega parámetro
                Parametros.Add(C9); // Agrega parámetro
                Parametros.Add(C10); // Agrega parámetro

                Parametros.Add(P1); // Agrega parámetro
                Parametros.Add(P2); // Agrega parámetro
                Parametros.Add(P3); // Agrega parámetro
                Parametros.Add(P4); // Agrega parámetro
                Parametros.Add(P5); // Agrega parámetro
                Parametros.Add(P6); // Agrega parámetro
                Parametros.Add(P7); // Agrega parámetro
                Parametros.Add(P8); // Agrega parámetro
                Parametros.Add(P9); // Agrega parámetro
                Parametros.Add(P10); // Agrega parámetro

                Parametros.Add(U1); // Agrega parámetro
                Parametros.Add(U2); // Agrega parámetro
                Parametros.Add(U3); // Agrega parámetro
                Parametros.Add(U4); // Agrega parámetro
                Parametros.Add(U5); // Agrega parámetro
                Parametros.Add(U6); // Agrega parámetro
                Parametros.Add(U7); // Agrega parámetro
                Parametros.Add(U8); // Agrega parámetro
                Parametros.Add(U9); // Agrega parámetro
                Parametros.Add(U10); // Agrega parámetro

                Parametros.Add(T1); // Agrega parámetro
                Parametros.Add(T2); // Agrega parámetro
                Parametros.Add(T3); // Agrega parámetro
                Parametros.Add(T4); // Agrega parámetro
                Parametros.Add(T5); // Agrega parámetro
                Parametros.Add(T6); // Agrega parámetro
                Parametros.Add(T7); // Agrega parámetro
                Parametros.Add(T8); // Agrega parámetro
                Parametros.Add(T9); // Agrega parámetro
                Parametros.Add(T10); // Agrega parámetro

                Parametros.Add(SubTotal); // Agrega parámetro
                Parametros.Add(Descuento); // Agrega parámetro
                Parametros.Add(Iva); // Agrega parámetro
                Parametros.Add(Total); // Agrega parámetro

                Report.crystalReportViewer1.ParameterFieldInfo = Parametros; // Asigna parámetros
                LlenarReporte(); // Llena reporte

                Report.ShowDialog(); // Muestra reporte
                BtnCliArrIng.Enabled = true; // Habilita botón
                BtnUltProdd.Enabled = true; // Habilita botón
                ButLim.Enabled = true; // Habilita botón
                BtnUltProdd.Enabled = true; // Habilita botón
                ButImp.Enabled = true; // Mantener habilitado para reimprimir
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}\n\nDetalles: {ex.StackTrace}", "Error Crystal Report",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LlenarReporte() // Llena reporte
        {
            var info = new RArriendo(); // Crea instancia reporte
            Report.crystalReportViewer1.ReportSource = info; // Asigna fuente
        }

        private void ComboDes_SelectedIndexChanged_1(object sender, EventArgs e) // Cambio selección descuento
        {
            MetodoCalcularTotalGeneral(); // Recalcula totales
        }

        private void TextIVA_TextChanged(object sender, EventArgs e) // Cambio texto IVA
        {
            // Sin lógica.
        }
    }
}

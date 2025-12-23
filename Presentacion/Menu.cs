// Importa las entidades del sistema.
using Entidad;
// Importa la lógica de negocio.
using Negocio;
// Importa el espacio de arriendos.
using Presentacion.ArriFinal;
// Importa el espacio de clientes.
using Presentacion.Cliente;
// Importa el espacio de localidades.
using Presentacion.Localidad;
// Importa el espacio de productos.
using Presentacion.Productos;
// Importa el espacio de proveedores.
using Presentacion.Proveedor;
// Importa el espacio de usuarios.
using Presentacion.Usuarios;
// Importa funcionalidades básicas de .NET.
using System;
// Importa funcionalidades de dibujo gráfico.
using System.Drawing;
// Importa componentes de formularios Windows.
using System.Windows.Forms;
// Importa elementos de estilos visuales.
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Define el espacio de nombres.
namespace Presentacion
{
    // Clase del formulario menú principal.
    public partial class Menu : Form
    {
        // Almacena el menú actualmente seleccionado.
        private static ToolStripMenuItem MenuActivo = null;
        // Almacena el formulario actualmente mostrado.
        private static Form FormularioActivo = null;

        // Constructor del menú principal.
        public Menu()
        {
            // Inicializa los componentes del formulario.
            InitializeComponent();
        }

        // Evento al cargar el formulario.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Aplica el tema visual ejecutivo.
            ThemeManager.ApplyExecutiveTheme(this);
            // Configura permisos del usuario actual.
            ConfigurarPermisos();
        }

        // Configura visibilidad según permisos usuario.
        private void ConfigurarPermisos()
        {
            // Obtiene permisos del usuario actual.
            var permisos = Sesion.Permisos;

            // Controla visibilidad ingresar cliente.
            IngresarCli.Visible = permisos.ICliente == "SI";
            // Controla visibilidad eliminar cliente.
            EliminarCli.Visible = permisos.ECliente == "SI";

            // Controla visibilidad ingresar proveedor.
            IngresarProv.Visible = permisos.IProv == "SI";
            // Controla visibilidad eliminar proveedor.
            EliminarProv.Visible = permisos.EProv == "SI";

            // Controla visibilidad insertar producto.
            InsertarProd.Visible = permisos.IProductos == "SI";
            // Controla visibilidad eliminar producto.
            EliminarProd.Visible = permisos.EProductos == "SI";

            // Controla visibilidad ingresar usuario.
            Ingresar_Usu.Visible = permisos.IUsu == "SI";
            // Controla visibilidad eliminar usuario.
            Eliminar_Usu.Visible = permisos.EUsu == "SI";
        }

        // Abre formulario dentro del panel principal.
        private void AbrirFormulario(ToolStripMenuItem menu, Form formulario)
        {
            // Si existe un menú activo.
            if (MenuActivo != null)
            {
                // Restaura color blanco del menú.
                MenuActivo.BackColor = Color.White;
            }
            // Establece color gris al menú nuevo.
            menu.BackColor = Color.Silver;
            // Actualiza referencia del menú activo.
            MenuActivo = menu;
            // Si existe un formulario activo.
            if (FormularioActivo != null)
            {
                // Cierra el formulario activo actual.
                FormularioActivo.Close();
            }
            // Asigna el nuevo formulario activo.
            FormularioActivo = formulario;
            // Configura como formulario no principal.
            formulario.TopLevel = false;
            // Quita los bordes del formulario.
            formulario.FormBorderStyle = FormBorderStyle.None;
            // Acopla formulario al panel completo.
            formulario.Dock = DockStyle.Fill;
            // Establece fondo blanco al formulario.
            formulario.BackColor = Color.White;
            // Agrega formulario al panel principal.
            panel1.Controls.Add(formulario);
            // Muestra el formulario en pantalla.
            formulario.Show();
        }

        // Evento clic opción menú región.
        private void Región_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario región.
            PReg ver = new PReg();
            // Abre formulario de gestión región.
            AbrirFormulario((ToolStripMenuItem)sender, new PReg());
        }

        // Evento clic opción menú provincia.
        private void Provincia_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario provincia.
            PPro ver = new PPro();
            // Abre formulario de gestión provincia.
            AbrirFormulario((ToolStripMenuItem)sender, new PPro());
        }

        // Evento clic opción menú comuna.
        private void Comuna_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario comuna.
            PCom ver = new PCom();
            // Abre formulario de gestión comuna.
            AbrirFormulario((ToolStripMenuItem)sender, new PCom());
        }

        // Evento clic ingresar nuevo cliente.
        private void IngresarCli_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario ingreso.
            PCli_Ing ver = new PCli_Ing();
            // Abre formulario para ingresar cliente.
            AbrirFormulario((ToolStripMenuItem)sender, new PCli_Ing());
        }

        // Evento clic actualizar datos usuario.
        private void Actualizar_Usu_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario modificar.
            PUsua_Mod ver = new PUsua_Mod();
            // Abre formulario para actualizar usuario.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic eliminar usuario existente.
        private void Eliminar_Usu_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PUsua_Con ver = new PUsua_Con();
            // Habilita checkbox de eliminación.
            ver.CheckEli.Enabled = true;
            // Marca checkbox de eliminación activo.
            ver.CheckEli.Checked = true;
            // Muestra el botón de eliminar.
            ver.ButEli.Visible = true;
            // Abre formulario para eliminar usuario.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic ingresar nuevo proveedor.
        private void IngresarProv_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario ingreso.
            PProv_Ing ver = new PProv_Ing();
            // Abre formulario para ingresar proveedor.
            AbrirFormulario((ToolStripMenuItem)sender, new PProv_Ing());
        }

        // Evento clic actualizar datos proveedor.
        private void ActualizarProv_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PProv_Con ver = new PProv_Con();
            // Muestra el botón de modificar.
            ver.ButMod.Visible = true;
            // Abre formulario para actualizar proveedor.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic eliminar proveedor existente.
        private void EliminarProv_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PProv_Con ver = new PProv_Con();
            // Muestra el botón de eliminar.
            ver.ButEli.Visible = true;
            // Abre formulario para eliminar proveedor.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic insertar nuevo producto.
        private void InsertarProd_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario ingreso.
            PProd_Ing ver = new PProd_Ing();
            // Abre formulario para insertar producto.
            AbrirFormulario((ToolStripMenuItem)sender, new PProd_Ing());
        }

        // Evento clic actualizar datos producto.
        private void ActualizarProd_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PProd_Con ver = new PProd_Con();
            // Muestra el botón de modificar.
            ver.ButMod.Visible = true;
            // Abre formulario para actualizar producto.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic eliminar producto existente.
        private void EliminarProd_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PProd_Con ver = new PProd_Con();
            // Muestra el botón de eliminar.
            ver.ButEli.Visible = true;
            // Abre formulario para eliminar producto.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic generar nuevo arriendo.
        private void GenerarArr_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario arriendo.
            PArrIng ver = new PArrIng();
            // Abre formulario para generar arriendo.
            AbrirFormulario((ToolStripMenuItem)sender, new PArrIng());
        }

        // Evento clic salir de aplicación.
        private void Exit_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicación.
            Application.Exit();
        }

        // Evento clic ingresar nuevo usuario.
        private void Ingresar_Usu_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario ingreso.
            PUsua_Ing ver = new PUsua_Ing();
            // Abre formulario para ingresar usuario.
            AbrirFormulario((ToolStripMenuItem)sender, new PUsua_Ing());
        }

        // Evento clic actualizar datos cliente.
        private void ActualizarCli_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PCli_Con ver = new PCli_Con();
            // Muestra el botón de modificar.
            ver.ButMod.Visible = true;
            // Abre formulario para actualizar cliente.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }

        // Evento clic eliminar cliente existente.
        private void EliminarCli_Click(object sender, EventArgs e)
        {
            // Crea instancia del formulario consulta.
            PCli_Con ver = new PCli_Con();
            // Muestra el botón de eliminar.
            ver.ButEli.Visible = true;
            // Abre formulario para eliminar cliente.
            AbrirFormulario((ToolStripMenuItem)sender, ver);
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

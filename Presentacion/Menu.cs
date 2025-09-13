// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using Presentacion.ArriFinal;
// Accede a códigos de otra librería
using Presentacion.Cliente;
// Accede a códigos de otra librería
using Presentacion.Localidad;
// Accede a códigos de otra librería
using Presentacion.Productos;
// Accede a códigos de otra librería
using Presentacion.Proveedor;
// Accede a códigos de otra librería
using Presentacion.Usuarios;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Drawing;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Presentacion
{
    public partial class Menu : Form
    {
        private static ToolStripMenuItem MenuActivo = null; // Menú actualmente activo.
        private static Form FormularioActivo = null; // Formulario mostrado actualmente.

        public Menu() // Constructor del menú principal.
        {
            InitializeComponent(); // Inicializa los componentes.
        }

        private void Form1_Load(object sender, EventArgs e) // Evento al cargar formulario.
        {
            ThemeManager.ApplyExecutiveTheme(this); // Aplica el tema ejecutivo.
        }

        private void AbrirFormulario(ToolStripMenuItem menu, Form formulario) // Abre formulario en panel.
        {
            if (MenuActivo != null) // Si hay un menú activo.
            {
                MenuActivo.BackColor = Color.White; // Restaura color del menú.
            }
            menu.BackColor = Color.Silver; // Establece color del menú nuevo.
            MenuActivo = menu; // Actualiza el menú activo.
            if (FormularioActivo != null) // Si hay formulario activo.
            {
                FormularioActivo.Close(); // Cierra el formulario activo.
            }
            FormularioActivo = formulario; // Asigna el nuevo formulario.
            formulario.TopLevel = false; // No es ventana superior.
            formulario.FormBorderStyle = FormBorderStyle.None; // Quita borde del formulario.
            formulario.Dock = DockStyle.Fill; // Acopla formulario al panel.
            formulario.BackColor = Color.White; // Establece fondo blanco.
            panel1.Controls.Add(formulario); // Añade a controles del panel.
            formulario.Show(); // Muestra el formulario.
        }

        private void Región_Click(object sender, EventArgs e) // Clic en opción Región.
        {
            PReg ver = new PReg(); // Crea instancia de PReg.
            AbrirFormulario((ToolStripMenuItem)sender, new PReg()); // Abre formulario de Región.
        }

        private void Provincia_Click(object sender, EventArgs e) // Clic en opción Provincia.
        {
            PPro ver = new PPro(); // Crea instancia de PPro.
            AbrirFormulario((ToolStripMenuItem)sender, new PPro()); // Abre formulario de Provincia.
        }

        private void Comuna_Click(object sender, EventArgs e) // Clic en opción Comuna.
        {
            PCom ver = new PCom(); // Crea instancia de PCom.
            AbrirFormulario((ToolStripMenuItem)sender, new PCom()); // Abre formulario de Comuna.
        }

        private void IngresarCli_Click(object sender, EventArgs e) // Clic en Ingresar Cliente.
        {
            PCli_Ing ver = new PCli_Ing(); // Crea instancia de PCli_Ing.
            AbrirFormulario((ToolStripMenuItem)sender, new PCli_Ing()); // Abre formulario Ingresar Cliente.
        }

        private void ActualizarCli_Click(object sender, EventArgs e) // Clic en Actualizar Cliente.
        {
            PCli_Con ver = new PCli_Con(); // Crea instancia de PCli_Con.
            ver.ButMod.Visible = true; // Hace visible botón Modificar.
            AbrirFormulario((ToolStripMenuItem)sender, ver); // Abre formulario Actualizar Cliente.
        }

        private void EliminarCli_Click(object sender, EventArgs e) // Clic en Eliminar Cliente.
        {
            PCli_Con ver = new PCli_Con(); // Crea instancia de PCli_Con.
            ver.ButEli.Visible = true; // Hace visible botón Eliminar.
            AbrirFormulario((ToolStripMenuItem)sender, ver); // Abre formulario Eliminar Cliente.
        }

        private void IngresarProv_Click(object sender, EventArgs e) // Clic en Ingresar Proveedor.
        {
            PProv_Ing ver = new PProv_Ing(); // Crea instancia de PProv_Ing.
            AbrirFormulario((ToolStripMenuItem)sender, new PProv_Ing()); // Abre formulario Ingresar Proveedor.
        }

        private void ActualizarProv_Click(object sender, EventArgs e) // Clic en Actualizar Proveedor.
        {
            PProv_Con ver = new PProv_Con(); // Crea instancia de PProv_Con.
            ver.ButMod.Visible = true; // Hace visible botón Modificar.
            AbrirFormulario((ToolStripMenuItem)sender, ver); // Abre formulario Actualizar Proveedor.
        }

        private void EliminarProv_Click(object sender, EventArgs e) // Clic en Eliminar Proveedor.
        {
            PProv_Con ver = new PProv_Con(); // Crea instancia de PProv_Con.
            ver.ButEli.Visible = true; // Hace visible botón Eliminar.
            AbrirFormulario((ToolStripMenuItem)sender, ver); // Abre formulario Eliminar Proveedor.
        }

        private void InsertarProd_Click(object sender, EventArgs e) // Clic en Insertar Producto.
        {
            PProd_Ing ver = new PProd_Ing(); // Crea instancia de PProd_Ing.
            AbrirFormulario((ToolStripMenuItem)sender, new PProd_Ing()); // Abre formulario Insertar Producto.
        }

        private void ActualizarProd_Click(object sender, EventArgs e) // Clic en Actualizar Producto.
        {
            PProd_Con ver = new PProd_Con(); // Crea instancia de PProd_Con.
            ver.ButMod.Visible = true; // Hace visible botón Modificar.
            AbrirFormulario((ToolStripMenuItem)sender, ver); // Abre formulario Actualizar Producto.
        }

        private void EliminarProd_Click(object sender, EventArgs e) // Clic en Eliminar Producto.
        {
            PProd_Con ver = new PProd_Con(); // Crea instancia de PProd_Con.
            ver.ButEli.Visible = true; // Hace visible botón Eliminar.
            AbrirFormulario((ToolStripMenuItem)sender, ver); // Abre formulario Eliminar Producto.
        }

        private void GenerarArr_Click(object sender, EventArgs e) // Clic en Generar Arriendo.
        {
            PArrIng ver = new PArrIng(); // Crea instancia de PArrIng.
            AbrirFormulario((ToolStripMenuItem)sender, new PArrIng()); // Abre formulario Generar Arriendo.
        }

        private void Exit_Click(object sender, EventArgs e) // Clic en Salir.
        {
            Application.Exit(); // Cierra la aplicación.
        }

        private void Ingresar_Usu_Click(object sender, EventArgs e) // Clic en Ingresar Usuario.
        {
            PUsua_Ing ver = new PUsua_Ing(); // Crea instancia de PUsua_Ing.
            AbrirFormulario((ToolStripMenuItem)sender, new PUsua_Ing()); // Abre formulario Ingresar Usuario.
        }

        private void Actualizar_Usu_Click(object sender, EventArgs e) // Clic en Actualizar Usuario.
        {
            PUsua_Con ver = new PUsua_Con(); // Crea instancia de PUsua_Con.
            AbrirFormulario((ToolStripMenuItem)sender, new PUsua_Con()); // Abre formulario Actualizar Usuario.
        }

        private void Eliminar_Usu_Click(object sender, EventArgs e) // Clic en Eliminar Usuario.
        {
            PUsua_Con ver = new PUsua_Con(); // Crea instancia de PUsua_Con.
            AbrirFormulario((ToolStripMenuItem)sender, new PUsua_Con()); // Abre formulario Eliminar Usuario.
        }
    }
}

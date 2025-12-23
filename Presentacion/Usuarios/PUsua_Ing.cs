using Entidad; // Contiene las entidades del sistema
using Negocio; // Maneja la lógica de negocio
using System; // Funcionalidades básicas de .NET
using System.Windows.Forms; // Formularios Windows Forms

namespace Presentacion.Usuarios
{
    public partial class PUsua_Ing : Form // Formulario ingreso usuarios
    {
        public PUsua_Ing() // Inicializa el formulario
        {
            InitializeComponent(); // Carga componentes visuales
        }

        public void HabBotIng() // Habilita botones ingreso
        {
            if ((TextNom.Text.Trim() != "") || (TextPass.Text.Trim() != "") || (TextCon.Text.Trim() != "")) // Si hay texto
            {
                ButLim.Enabled = true; // Habilita botón limpiar
                if ((TextNom.Text.Trim() != "") && (TextPass.Text.Trim() != "") && (TextCon.Text.Trim() != "")) // Si todos llenos
                {
                    ButIng.Enabled = true; // Habilita botón ingresar
                }
                else // Si faltan campos
                {
                    ButIng.Enabled = false; // Deshabilita botón ingresar
                }
            }
            else // Si no hay texto
            {
                ButLim.Enabled = false; // Deshabilita botón limpiar
            }
        }

        private void Usua_Ing_Load(object sender, EventArgs e) // Al cargar formulario
        {
            // Método vacío para evento load.
        }

        private void TextNom_TextChanged(object sender, EventArgs e) // Cambio texto nombre
        {
            HabBotIng(); // Actualiza estado botones
        }

        private void TextPass_TextChanged(object sender, EventArgs e) // Cambio texto password
        {
            HabBotIng(); // Actualiza estado botones
        }

        private void CHBVPass_CheckedChanged(object sender, EventArgs e) // Cambio ver password
        {
            if (CHBVPass.CheckState == CheckState.Checked) // Si está checked
            {
                TextPass.PasswordChar = '\0'; // Muestra texto claro
            }
            else // Si no está checked
            {
                TextPass.PasswordChar = '*'; // Oculta texto con asteriscos
            }
        }

        private void TextCon_TextChanged(object sender, EventArgs e) // Cambio texto confirmar
        {
            HabBotIng(); // Actualiza estado botones
        }

        private void CHBCPass_CheckedChanged(object sender, EventArgs e) // Cambio ver confirmar
        {
            if (CHBCPass.CheckState == CheckState.Checked) // Si está checked
            {
                TextCon.PasswordChar = '\0'; // Muestra texto claro
            }
            else // Si no está checked
            {
                TextCon.PasswordChar = '*'; // Oculta texto con asteriscos
            }
        }

        private void ButIng_Click(object sender, EventArgs e) // Click botón ingresar
        {
            try // Intenta ejecutar
            {
                if (string.IsNullOrEmpty(TextNom.Text.Trim()) || string.IsNullOrEmpty(TextPass.Text.Trim())) // Si campos vacíos
                {
                    MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra error
                    return; // Sale del método
                }
                if (TextPass.Text.Trim() != TextCon.Text.Trim()) // Si passwords no coinciden
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra error
                    return; // Sale del método
                }
                EPermisos permisos = new EPermisos(); // Crea objeto permisos
                permisos.ILCom = ILCom.Checked ? "SI" : "NO"; // Inserta la comuna
                permisos.ALCom = ALCom.Checked ? "SI" : "NO"; // Actualiza la comuna
                permisos.ELCom = ELCom.Checked ? "SI" : "NO"; // Elimina la comuna
                permisos.ILPro = ILPro.Checked ? "SI" : "NO"; // Inserta la provincia
                permisos.ALPro = ALPro.Checked ? "SI" : "NO"; // Actualiza la provincia
                permisos.ELPro = ELPro.Checked ? "SI" : "NO"; // Elimina la provincia
                permisos.ILReg = ILReg.Checked ? "SI" : "NO"; // Inserta la región
                permisos.ALReg = ALReg.Checked ? "SI" : "NO"; // Actualiza la región
                permisos.ELReg = ELReg.Checked ? "SI" : "NO"; // Elimina la región
                permisos.ICliente = ICliente.Checked ? "SI" : "NO"; // Inserta el cliente
                permisos.ACliente = ACliente.Checked ? "SI" : "NO"; // Actualiza el cliente
                permisos.ECliente = ECliente.Checked ? "SI" : "NO"; // Elimina el cliente
                permisos.IProductos = IProductos.Checked ? "SI" : "NO"; // Inserta el producto
                permisos.AProductos = AProductos.Checked ? "SI" : "NO"; // Actualiza el producto
                permisos.EProductos = EProductos.Checked ? "SI" : "NO"; // Elimina el producto
                permisos.IProv = IProv.Checked ? "SI" : "NO"; // Inserta el proveedor
                permisos.AProv = AProv.Checked ? "SI" : "NO"; // Actualiza el proveedor
                permisos.EProv = EProv.Checked ? "SI" : "NO"; // Elimina el proveedor
                permisos.IUsu = IUsu.Checked ? "SI" : "NO"; // Inserta el usuario
                permisos.AUsu = AUsu.Checked ? "SI" : "NO"; // Actualiza el usuario
                permisos.EUsu = EUsu.Checked ? "SI" : "NO"; // Elimina el usuario
                var resultadoPermisos = NPermisos.Ingresar(permisos); // Ingresa permisos
                if (!resultadoPermisos.estado) // Si error permisos
                {
                    MessageBox.Show("Error al crear permisos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error
                    return; // Sale del método
                }
                NPermisos negocioPermisos = new NPermisos(); // Crea negocio permisos
                int idPermiso = negocioPermisos.ObtenerUltimoId(); // Obtiene último ID
                EUsuarios usuario = new EUsuarios(); // Crea objeto usuario
                usuario.Nombre = TextNom.Text.Trim(); // Asigna nombre
                usuario.Pass = TextPass.Text.Trim(); // Asigna password
                usuario.IdPer = idPermiso; // Asigna ID permiso
                var resultadoUsuario = NUsuarios.Ingresar(usuario); // Ingresa usuario
                if (resultadoUsuario.estado) // Si éxito
                {
                    MessageBox.Show("Usuario creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra éxito
                    LimpiarFormulario(); // Limpia formulario
                }
                else // Si error
                {
                    MessageBox.Show("Error al crear usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error
                }
            }
            catch (Exception ex) // Captura errores
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra error
            }
        }

        private void LimpiarFormulario() // Limpia todo el formulario
        {
            TextNom.Clear(); // Limpia texto nombre
            TextPass.Clear(); // Limpia texto password
            TextCon.Clear(); // Limpia texto confirmar

            ILCom.Checked = false; // Inserta la comuna
            ALCom.Checked = false; // Actualiza la comuna
            ELCom.Checked = false; // Elimina la comuna
            ILPro.Checked = false; // Inserta la provincia
            ALPro.Checked = false; // Actualiza la provincia
            ELPro.Checked = false; // Elimina la provincia
            ILReg.Checked = false; // Inserta la región
            ALReg.Checked = false; // Actualiza la región
            ELReg.Checked = false; // Elimina la región
            ICliente.Checked = false; // Inserta el cliente
            ACliente.Checked = false; // Actualiza el cliente
            ECliente.Checked = false; // Elimina el cliente
            IProductos.Checked = false; // Inserta el producto
            AProductos.Checked = false; // Actualiza el producto
            EProductos.Checked = false; // Elimina el producto
            IProv.Checked = false; // Inserta el proveedor
            AProv.Checked = false; // Actualiza el proveedor
            EProv.Checked = false; // Elimina el proveedor
            IUsu.Checked = false; // Inserta el usuario
            AUsu.Checked = false; // Actualiza el usuario
            EUsu.Checked = false; // Elimina el usuario
        }

        private void ButLim_Click(object sender, EventArgs e) // Click botón limpiar
        {
            TextNom.Text = ""; // Limpia texto nombre
            TextPass.Text = ""; // Limpia texto password
            TextCon.Text = ""; // Limpia texto confirmar
        }

        private void ButSal_Click(object sender, EventArgs e) // Click botón salir
        {
            Application.Exit(); // Cierra la aplicación
        }

        private void ADMCheck_CheckedChanged(object sender, EventArgs e) // Cambio check admin
        {
            bool esAdmin = ADMCheck.Checked; // Obtiene estado check

            ILCom.Checked = esAdmin; // Inserta la comuna
            ALCom.Checked = esAdmin; // Actualiza la comuna
            ELCom.Checked = esAdmin; // Elimina la comuna
            ILPro.Checked = esAdmin; // Inserta la provincia
            ALPro.Checked = esAdmin; // Actualiza la provincia
            ELPro.Checked = esAdmin; // Elimina la provincia
            ILReg.Checked = esAdmin; // Inserta la región
            ALReg.Checked = esAdmin; // Actualiza la región
            ELReg.Checked = esAdmin; // Elimina la región
            ICliente.Checked = esAdmin; // Inserta el cliente
            ACliente.Checked = esAdmin; // Actualiza el cliente
            ECliente.Checked = esAdmin; // Elimina el cliente
            IProductos.Checked = esAdmin; // Inserta el producto
            AProductos.Checked = esAdmin; // Actualiza el producto
            EProductos.Checked = esAdmin; // Elimina el producto
            IProv.Checked = esAdmin; // Inserta el proveedor
            AProv.Checked = esAdmin; // Actualiza el proveedor
            EProv.Checked = esAdmin; // Elimina el proveedor
            IUsu.Checked = esAdmin; // Inserta el usuario
            AUsu.Checked = esAdmin; // Actualiza el usuario
            EUsu.Checked = esAdmin; // Elimina el usuario
        }
    }
}

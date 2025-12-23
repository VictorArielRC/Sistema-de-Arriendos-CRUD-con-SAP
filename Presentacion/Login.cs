// Importa las entidades del sistema.
using Entidad;
// Importa la lógica de negocio.
using Negocio;
// Importa funcionalidades básicas de .NET.
using System;
// Importa componentes de formularios Windows.
using System.Windows.Forms;
// Importa el espacio de usuarios.
using Presentacion.Usuarios;
// Usa la clase Application de Windows.
using Application = System.Windows.Forms.Application;

// Define el espacio de nombres.
namespace Presentacion
{
    // Clase del formulario de inicio sesión.
    public partial class Login : Form
    {
        // Constructor del formulario Login.
        public Login()
        {
            // Inicializa los componentes del formulario.
            InitializeComponent();
        }

        // Habilita o deshabilita botón ingreso.
        public void HabBotIng()
        {
            // Si ambos campos tienen texto.
            if ((textBox1.Text.Trim() != "") && (textBox2.Text.Trim() != ""))
            {
                // Habilita el botón de ingreso.
                button1.Enabled = true;
                // Habilita el botón de limpiar.
                ButLim.Enabled = true;
            }
            // Si algún campo está vacío.
            else
            {
                // Deshabilita el botón de ingreso.
                button1.Enabled = false;
                // Deshabilita el botón de limpiar.
                ButLim.Enabled = false;
            }
        }

        // Evento al cargar el formulario.
        private void Login_Load(object sender, EventArgs e)
        {
            // Aplica estilos visuales al formulario.
            LoginVisualStyleManager.Apply(this);
        }

        // Evento cambio texto campo usuario.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Verifica estado de botones ingreso.
            HabBotIng();
        }

        // Evento cambio texto campo contraseña.
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Verifica estado de botones ingreso.
            HabBotIng();
        }

        // Evento cambio checkbox mostrar contraseña.
        private void CHBVPass_CheckedChanged(object sender, EventArgs e)
        {
            // Si checkbox está marcado.
            if (CHBVPass.CheckState == CheckState.Checked)
            {
                // Muestra el texto de contraseña.
                textBox2.PasswordChar = '\0';
            }
            // Si checkbox está desmarcado.
            else
            {
                // Oculta texto con asteriscos.
                textBox2.PasswordChar = '*';
            }
        }

        // Evento clic botón iniciar sesión.
        private void button1_Click(object sender, EventArgs e)
        {
            // Crea objeto entidad usuario.
            EUsuarios Ent = new EUsuarios
            {
                // Asigna nombre ingresado.
                Nombre = textBox1.Text,
                // Asigna contraseña ingresada.
                Pass = textBox2.Text
            };

            // Verifica credenciales del usuario.
            Respuesta<bool> resultado = NUsuarios.Verificar(Ent);

            // Si credenciales son correctas.
            if (resultado.estado)
            {
                // Guarda identificador de usuario sesión.
                Sesion.IdUsu = Ent.IdUsu;
                // Guarda nombre de usuario sesión.
                Sesion.NombreUsuario = Ent.Nombre;
                // Guarda identificador de permiso sesión.
                Sesion.IdPer = Ent.IdPer;

                // Carga permisos del usuario actual.
                Sesion.Permisos = NPermisos.ObtenerPorId(Ent.IdPer);

                // Muestra mensaje de bienvenida.
                MessageBox.Show("Bienvenido, el inicio de sesión ha sido EXITOSO");

                // Crea instancia del menú principal.
                Menu MP = new Menu();
                // Asigna nombre usuario a etiqueta.
                MP.labelUsua.Text = textBox1.Text;
                // Muestra el formulario menú principal.
                MP.Show();

                // Oculta el formulario de login.
                this.Hide();
            }
            // Si credenciales son incorrectas.
            else
            {
                // Muestra mensaje de error credenciales.
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        // Evento clic botón limpiar.
        private void ButLim_Click(object sender, EventArgs e)
        {
            // Limpia el campo de usuario.
            textBox1.Text = "";
            // Limpia el campo de contraseña.
            textBox2.Text = "";
        }

        // Evento clic botón salir.
        private void button2_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicación.
            Application.Exit();
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

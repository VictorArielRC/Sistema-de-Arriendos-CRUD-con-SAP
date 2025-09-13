// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using Negocio;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Windows.Forms;
// Accede a códigos de otra librería
using Application = System.Windows.Forms.Application;


namespace Presentacion
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        
        }
        // Habilita o deshabilita el botón de Ingreso.
        public void HabBotIng()
        {
            // Si ambos campos de texto no están vacíos.
            if ((textBox1.Text.Trim() != "") && (textBox2.Text.Trim() != ""))
            {
                // Habilita el botón 'button1'.
                button1.Enabled = true;
                ButLim.Enabled = true; // Habilita el botón de limpiar
            }
            // Si al menos uno de los campos está vacío.
            else
            {
                // Deshabilita el botón 'button1'.
                button1.Enabled = false;
                ButLim.Enabled = false; // Deshabilita el botón de limpiar
            }
        }

        // Este método se ejecuta cuando el formulario 'Login' se carga.
        private void Login_Load(object sender, EventArgs e)
        {

            LoginVisualStyleManager.Apply(this);
            //estilos visuales

        }

        // Este método se activa cuando el texto en 'textBox1' cambia.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Llama al método para habilitar o deshabilitar el botón de ingreso.
            HabBotIng();
        }

        // Este método se activa cuando el texto en 'textBox2' cambia.
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Llama al método para habilitar o deshabilitar el botón de ingreso.
            HabBotIng();
        }

        // Este método se activa cuando el estado del checkbox 'CHBVPass' cambia.
        private void CHBVPass_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox está marcado (mostrar contraseña).
            if (CHBVPass.CheckState == CheckState.Checked)
            {
                // Cambia el carácter de contraseña de 'textBox2' a nulo (hace visible el texto).
                textBox2.PasswordChar = '\0';
            }
            // Si el checkbox no está marcado (ocultar contraseña).
            else
            {
                // Cambia el carácter de contraseña de 'textBox2' a asterisco (oculta el texto).
                textBox2.PasswordChar = '*';
            }
        }

        // Este método se activa cuando se hace clic en 'button1' (botón de inicio de sesión).
        private void button1_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia de la entidad de usuario 'EUsua'.
            EUsua Ent = new EUsua
            {
                // Asigna el texto de 'textBox1' al nombre de usuario.
                Nombre = textBox1.Text,
                // Asigna el texto de 'textBox2' a la contraseña.
                Pass = textBox2.Text
            };

            // Llama a la capa de negocio 'NUsua' para verificar las credenciales.
            Respuesta<bool> resultado = NUsua.Verificar(Ent);

            // Si la verificación de inicio de sesión fue exitosa.
            if (resultado.estado)
            {
                // Muestra un mensaje de inicio de sesión exitoso.
                MessageBox.Show("Bienvenido el Inicio de sesion ha sido EXITOSO");
                // Crea una nueva instancia del formulario 'Menu'.
                Menu MP = new Menu();
                // Establece el texto de la etiqueta de usuario en el menú principal.
                MP.labelUsua.Text = textBox1.Text;
                // Muestra el formulario 'Menu'.
                MP.Show();
                // Oculta el formulario de inicio de sesión actual.
                this.Hide();
            }
            // Si la verificación de inicio de sesión falló.
            else
            {
                // Muestra un mensaje de error por credenciales incorrectas.
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        // Este método se activa cuando se hace clic en 'ButLim' (botón Limpiar).
        private void ButLim_Click(object sender, EventArgs e)
        {
            // Borra el texto de 'textBox1'.
            textBox1.Text = "";
            // Borra el texto de 'textBox2'.
            textBox2.Text = "";
        }

        // Este método se activa cuando se hace clic en 'button2' (botón Salir).
        private void button2_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación por completo.
            Application.Exit();
        }
    }
}
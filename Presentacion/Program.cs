// Accede a códigos de otra librería
using Presentacion.Usuarios;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.Linq;
// Accede a códigos de otra librería
using System.Windows.Forms;


namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilita estilos visuales
            Application.SetCompatibleTextRenderingDefault(false); // Deshabilita renderizado de texto
            Application.Run(new Login()); // Ejecuta el formulario de inicio
        }
    }
}

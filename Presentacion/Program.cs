// Importa dependencias.
using Presentacion.Usuarios;
// Importa dependencias.
using System;
// Importa dependencias.
using System.Collections.Generic;
// Importa dependencias.
using System.Linq;
// Importa dependencias.
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
            Application.EnableVisualStyles(); 
            // Habilita estilos visuales.
            Application.SetCompatibleTextRenderingDefault(false);
            // Deshabilita renderizado de texto.
            Application.Run(new Login()); 
            // Ejecuta el formulario de inicio.
        }
    }
}


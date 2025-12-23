// Importa funcionalidades básicas de .NET.
using System;
// Importa colecciones genéricas de datos.
using System.Collections.Generic;
// Importa consultas integradas de lenguaje.
using System.Linq;
// Importa codificación de texto y caracteres.
using System.Text;
// Importa programación asíncrona de tareas.
using System.Threading.Tasks;

// Define el espacio de nombres.
namespace Entidad
{
    // Clase de entidad usuarios sistema.
    public class EUsuarios
    {
        // Variable pública identificador de usuario.
        public int ValIdUsu;
        // Variable pública nombre de usuario.
        public String ValNombre;
        // Variable pública contraseña del usuario.
        public String ValPass;
        // Variable pública identificador de permiso.
        public int ValIdPer;

        // Propiedad pública identificador de usuario.
        public int IdUsu
        {
            // Obtiene el valor del identificador.
            get { return ValIdUsu; }
            // Asigna el valor del identificador.
            set { ValIdUsu = value; }
        }

        // Propiedad pública nombre de usuario.
        public String Nombre
        {
            // Obtiene el valor del nombre.
            get { return ValNombre; }
            // Asigna el valor del nombre.
            set { ValNombre = value; }
        }

        // Propiedad pública contraseña de usuario.
        public String Pass
        {
            // Obtiene el valor de contraseña.
            get { return ValPass; }
            // Asigna el valor de contraseña.
            set { ValPass = value; }
        }

        // Propiedad pública identificador de permiso.
        public int IdPer
        {
            // Obtiene el valor del permiso.
            get { return ValIdPer; }
            // Asigna el valor del permiso.
            set { ValIdPer = value; }
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

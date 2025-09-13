// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.Linq;
// Accede a códigos de otra librería
using System.Text;
// Accede a códigos de otra librería
using System.Threading.Tasks;


namespace Entidad
{
    public class EUsua
    {
        public int ValIdUsu; // Almacena identificador de usuario
        public String ValNombre; // Almacena nombre de usuario
        public String ValPass; // Almacena contraseña del usuario

        public int IdUsu // Propiedad para IdUsu
        {
            get { return ValIdUsu; } // Retorna el IdUsu
            set { ValIdUsu = value; } // Asigna un nuevo IdUsu
        }
        public String Nombre // Propiedad para Nombre
        {
            get { return ValNombre; } // Retorna el nombre
            set { ValNombre = value; } // Asigna un nuevo nombre
        }

        public String Pass // Propiedad para Pass
        {
            get { return ValPass; } // Retorna la contraseña
            set { ValPass = value; } // Asigna nueva contraseña
        }
    }
}
using System;
// Importa dependencias.

namespace Entidad
{
    public class ELocReg
    {
        public int ValIdReg; // Almacena identificador de región
        public String ValNombre; // Almacena nombre de la región

        public int IdReg // Propiedad para IdReg
        {
            get { return ValIdReg; } // Retorna el IdReg
            set { ValIdReg = value; } // Asigna un nuevo IdReg
        }

        public String Nombre // Propiedad para Nombre
        {
            get { return ValNombre; } // Retorna el nombre
            set { ValNombre = value; } // Asigna un nuevo nombre
        }
    }
}

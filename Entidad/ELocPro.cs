using System;
// Accede a códigos de otra librería

namespace Entidad
{
    public class ELocPro
    {
        public int ValIdPro; // Almacena identificador de provincia
        public String ValNombre; // Almacena nombre de la provincia
        public int ValIdReg; // Almacena identificador de región
        public ELocReg ValReg; // Objeto de la región

        public int IdPro // Propiedad para IdPro
        {
            get { return ValIdPro; } // Retorna el IdPro
            set { ValIdPro = value; } // Asigna un nuevo IdPro
        }

        public String Nombre // Propiedad para Nombre
        {
            get { return ValNombre; } // Retorna el nombre
            set { ValNombre = value; } // Asigna un nuevo nombre
        }

        public int IdReg // Propiedad para IdReg
        {
            get { return ValIdReg; } // Retorna el IdReg
            set { ValIdReg = value; } // Asigna un nuevo IdReg
        }

        public ELocReg Reg // Propiedad para Reg
        {
            get { return ValReg; } // Retorna la región
            set { ValReg = value; } // Asigna una nueva región
        }
    }
}
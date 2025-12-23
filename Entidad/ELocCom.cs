using System;
// Importa dependencias.


namespace Entidad
{
    public class ELocCom
    {
        public int ValIdCom; // Almacena identificador de comuna
        public String ValNombre; // Almacena nombre de la comuna
        public int ValIdPro; // Almacena identificador de provincia
        public ELocPro ValPro; // Objeto de provincia
        public int ValIdReg; // Almacena identificador de región
        public ELocReg ValReg; // Objeto de región

        public int IdCom // Propiedad para IdCom
        {
            get { return ValIdCom; } // Retorna el IdCom
            set { ValIdCom = value; } // Asigna un nuevo IdCom
        }
        public String Nombre // Propiedad para Nombre
        {
            get { return ValNombre; } // Retorna el nombre
            set { ValNombre = value; } // Asigna un nuevo nombre
        }
        public int IdPro // Propiedad para IdPro
        {
            get { return ValIdPro; } // Retorna el IdPro
            set { ValIdPro = value; } // Asigna un nuevo IdPro
        }

        public ELocPro Pro // Propiedad para Pro
        {
            get { return ValPro; } // Retorna la provincia
            set { ValPro = value; } // Asigna una nueva provincia
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

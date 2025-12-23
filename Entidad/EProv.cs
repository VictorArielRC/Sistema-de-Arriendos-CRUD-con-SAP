using System;
// Importa dependencias.

namespace Entidad
{
    public class EProv
    {
        public int ValIdProv; // Almacena identificador de proveedor
        public String ValNombre; // Almacena nombre del proveedor
        public String ValRut; // Almacena RUT del proveedor
        public int ValIdReg; // Almacena ID de región
        public ELocReg ValReg; // Objeto de región
        public int ValIdPro; // Almacena ID de provincia
        public ELocPro ValPro; // Objeto de provincia
        public int ValIdCom; // Almacena ID de comuna
        public ELocCom ValCom; // Objeto de comuna
        public String ValDireccion; // Almacena dirección del proveedor
        public String ValTel; // Almacena teléfono del proveedor
        public String ValEmail; // Almacena email del proveedor
        public String ValGiro; // Almacena giro del negocio
        public String ValDescr; // Almacena descripción del proveedor

        public int IdProv // Propiedad para IdProv
        {
            get { return ValIdProv; } // Retorna el IdProv
            set { ValIdProv = value; } // Asigna un nuevo IdProv
        }

        public String Nombre // Propiedad para Nombre
        {
            get { return ValNombre; } // Retorna el nombre
            set { ValNombre = value; } // Asigna un nuevo nombre
        }

        public String Rut // Propiedad para Rut
        {
            get { return ValRut; } // Retorna el RUT
            set { ValRut = value; } // Asigna un nuevo RUT
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
        public int IdCom // Propiedad para IdCom
        {
            get { return ValIdCom; } // Retorna el IdCom
            set { ValIdCom = value; } // Asigna un nuevo IdCom
        }

        public ELocCom Com // Propiedad para Com
        {
            get { return ValCom; } // Retorna la comuna
            set { ValCom = value; } // Asigna una nueva comuna
        }
        public String Direccion // Propiedad para Direccion
        {
            get { return ValDireccion; } // Retorna la dirección
            set { ValDireccion = value; } // Asigna una nueva dirección
        }

        public String Tel // Propiedad para Tel
        {
            get { return ValTel; } // Retorna el teléfono
            set { ValTel = value; } // Asigna un nuevo teléfono
        }

        public String Email // Propiedad para Email
        {
            get { return ValEmail; } // Retorna el email
            set { ValEmail = value; } // Asigna un nuevo email
        }

        public String Giro // Propiedad para Giro
        {
            get { return ValGiro; } // Retorna el giro
            set { ValGiro = value; } // Asigna un nuevo giro
        }

        public String Descr // Propiedad para Descr
        {
            get { return ValDescr; } // Retorna la descripción
            set { ValDescr = value; } // Asigna nueva descripción
        }
    }
}

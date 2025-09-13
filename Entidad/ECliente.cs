using System;
// Accede a códigos de otra librería

namespace Entidad
{
    public class ECliente
    {
        public int ValIdP_Cli; // Almacena identificador de cliente
        public String ValNombre; // Almacena nombre del cliente
        public String ValRut; // Almacena RUT del cliente
        public int ValIdReg; // Almacena ID de región
        public ELocReg ValReg; // Objeto de región
        public int ValIdPro; // Almacena ID de provincia
        public ELocPro ValPro; // Objeto de provincia
        public int ValIdCom; // Almacena ID de comuna
        public ELocCom ValCom; // Objeto de comuna
        public String ValDireccion; // Almacena dirección del cliente
        public String ValTel; // Almacena teléfono del cliente
        public String ValEmail; // Almacena email del cliente
        public String ValGiro; // Almacena giro del negocio

        public int IdP_Cli // Propiedad para IdP_Cli
        {
            get { return ValIdP_Cli; } // Retorna el IdP_Cli
            set { ValIdP_Cli = value; } // Asigna un nuevo IdP_Cli
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
    }
}
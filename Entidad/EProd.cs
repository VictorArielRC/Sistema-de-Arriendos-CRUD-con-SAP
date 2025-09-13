using System;
// Accede a códigos de otra librería

namespace Entidad
{
    public class EProd
    {
        public int ValIdProd; // Almacena identificador de producto
        public String ValNombre; // Almacena nombre de producto
        public String ValFInc; // Almacena fecha de inclusión
        public String ValCInc; // Almacena costo de inclusión
        public String ValCAct; // Almacena costo actual
        public String ValCArr; // Almacena costo de arriendo
        public String ValTAct; // Almacena tiempo de actividad
        public String ValVArr; // Almacena valor de arriendo

        public int IdProd // Propiedad para IdProd
        {
            get { return ValIdProd; } // Retorna el IdProd
            set { ValIdProd = value; } // Asigna un nuevo IdProd
        }

        public String Nombre // Propiedad para Nombre
        {
            get { return ValNombre; } // Retorna el nombre
            set { ValNombre = value; } // Asigna un nuevo nombre
        }

        public String FInc // Propiedad para FInc
        {
            get { return ValFInc; } // Retorna fecha de inclusión
            set { ValFInc = value; } // Asigna nueva fecha inclusión
        }

        public String CInc // Propiedad para CInc
        {
            get { return ValCInc; } // Retorna costo de inclusión
            set { ValCInc = value; } // Asigna nuevo costo inclusión
        }

        public String CAct // Propiedad para CAct
        {
            get { return ValCAct; } // Retorna costo actual
            set { ValCAct = value; } // Asigna nuevo costo actual
        }

        public String CArr // Propiedad para CArr
        {
            get { return ValCArr; } // Retorna costo de arriendo
            set { ValCArr = value; } // Asigna nuevo costo arriendo
        }

        public String TAct // Propiedad para TAct
        {
            get { return ValTAct; } // Retorna tiempo de actividad
            set { ValTAct = value; } // Asigna nuevo tiempo actividad
        }

        public String VArr // Propiedad para VArr
        {
            get { return ValVArr; } // Retorna valor de arriendo
            set { ValVArr = value; } // Asigna nuevo valor arriendo
        }
    }
}
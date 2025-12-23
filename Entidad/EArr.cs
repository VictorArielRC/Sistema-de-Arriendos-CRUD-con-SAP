using System;
// Se utiliza para organizar el código.
namespace Entidad
{
    public class EArr // La clase es accesible desde cualquier otra parte del código.
    {
        public int ValIdArr; // Almacena identificador de registro.
        public int ValIdP_Cli; // Almacena identificador de cliente.
        public ECliente ValP_Cli; // Objeto cliente asociado.
        public String ValFech; // Almacena valor de fecha.
        public int VAlIdAPro; // Almacena identificador de producto.
        public EArrPro ValAPro; // Objeto arreglo de productos.
        public int ValIdADet; // Almacena identificador de detalle.
        public EArrDet ValADet; // Objeto arreglo de detalles.
        public int ValIdAVUn; // Almacena identificador de venta.
        public EArrVUn ValAVUn; // Objeto arreglo de ventas.
        public String ValSubTo; // Almacena valor de subtotal.
        public String ValDescuento; // Almacena valor de descuento.
        public String ValIVA; // Almacena valor de IVA.
        public String ValTotal; // Almacena valor total.
        public EArrDet ValDet; // Objeto detalle.
        public EArrPro ValPro; // Objeto producto.
        public EArrVUn ValVUn; // Objeto venta unitaria.

        public int IdArr // Propiedad para IdArr.
        {
            get { return ValIdArr; } // Retorna el IdArr.
            set { ValIdArr = value; } // Asigna un nuevo IdArr.
        }
        public int IdP_Cli // Propiedad para IdP_Cli.
        {
            get { return ValIdP_Cli; } // Retorna el IdP_Cli.
            set { ValIdP_Cli = value; } // Asigna un nuevo IdP_Cli.
        }
        public ECliente P_Cli // Propiedad para P_Cli.
        {
            get { return ValP_Cli; } // Retorna el cliente.
            set { ValP_Cli = value; } // Asigna un nuevo cliente.
        }
        public String Fech // Propiedad para Fech.
        {
            get { return ValFech; } // Retorna la fecha.
            set { ValFech = value; } // Asigna una nueva fecha.
        }
        public int IdAPro // Propiedad para IdAPro.
        {
            get { return VAlIdAPro; } // Retorna el IdAPro.
            set { VAlIdAPro = value; } // Asigna un nuevo IdAPro.
        }
        public EArrPro APro // Propiedad para APro.
        {
            get { return ValAPro; } // Retorna el arreglo de productos.
            set { ValAPro = value; } // Asigna un nuevo arreglo.
        }
        public int IdADet // Propiedad para IdADet.
        {
            get { return ValIdADet; } // Retorna el IdADet.
            set { ValIdADet = value; } // Asigna un nuevo IdADet.
        }
        public EArrDet ADet // Propiedad para ADet.
        {
            get { return ValADet; } // Retorna el arreglo de detalles.
            set { ValADet = value; } // Asigna un nuevo arreglo.
        }
        public int IdAVUn // Propiedad para IdAVUn.
        {
            get { return ValIdAVUn; } // Retorna el IdAVUn.
            set { ValIdAVUn = value; } // Asigna un nuevo IdAVUn.
        }
        public EArrVUn AVUn // Propiedad para AVUn.
        {
            get { return ValAVUn; } // Retorna el arreglo de ventas.
            set { ValAVUn = value; } // Asigna un nuevo arreglo.
        }
        public String SubTo // Propiedad para SubTo.
        {
            get { return ValSubTo; } // Retorna el subtotal.
            set { ValSubTo = value; } // Asigna un nuevo subtotal.
        }
        public String Descuento // Propiedad para Descuento.
        {
            get { return ValDescuento; } // Retorna el descuento.
            set { ValDescuento = value; } // Asigna un nuevo descuento.
        }
        public String IVA // Propiedad para IVA.
        {
            get { return ValIVA; } // Retorna el IVA.
            set { ValIVA = value; } // Asigna un nuevo IVA.
        }
        public String Total // Propiedad para Total.
        {
            get { return ValTotal; } // Retorna el total.
            set { ValTotal = value; } // Asigna un nuevo total.
        }
        public EArrDet Det // Propiedad para Det.
        {
            get { return ValADet; } // Retorna el detalle.
            set { ValADet = value; } // Asigna un nuevo detalle.
        }
        public EArrPro Pro // Propiedad para Pro.
        {
            get { return ValPro; } // Retorna el producto.
            set { ValPro = value; } // Asigna un nuevo producto.
        }
        public EArrVUn VUn // Propiedad para VUn.
        {
            get { return ValVUn; } // Retorna la venta unitaria.
            set { ValVUn = value; } // Asigna nueva venta unitaria.
        }
    }
}

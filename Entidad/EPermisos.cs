// Importa funcionalidades básicas de .NET.
using System;

// Define el espacio de nombres.
namespace Entidad
{
    // Clase de entidad permisos usuarios.
    public class EPermisos
    {
        // Variable privada identificador de permiso.
        private int valIdPer;
        // Propiedad pública identificador de permiso.
        public int IdPer
        {
            // Obtiene el valor del identificador.
            get { return valIdPer; }
            // Asigna el valor del identificador.
            set { valIdPer = value; }
        }

        // Variable privada ingresar localidad comuna.
        private string valILCom;
        // Propiedad pública ingresar localidad comuna.
        public string ILCom
        {
            // Obtiene el valor de permiso.
            get { return valILCom; }
            // Asigna el valor de permiso.
            set { valILCom = value; }
        }

        // Variable privada actualizar localidad comuna.
        private string valALCom;
        // Propiedad pública actualizar localidad comuna.
        public string ALCom
        {
            // Obtiene el valor de permiso.
            get { return valALCom; }
            // Asigna el valor de permiso.
            set { valALCom = value; }
        }

        // Variable privada eliminar localidad comuna.
        private string valELCom;
        // Propiedad pública eliminar localidad comuna.
        public string ELCom
        {
            // Obtiene el valor de permiso.
            get { return valELCom; }
            // Asigna el valor de permiso.
            set { valELCom = value; }
        }

        // Variable privada ingresar localidad provincia.
        private string valILPro;
        // Propiedad pública ingresar localidad provincia.
        public string ILPro
        {
            // Obtiene el valor de permiso.
            get { return valILPro; }
            // Asigna el valor de permiso.
            set { valILPro = value; }
        }

        // Variable privada actualizar localidad provincia.
        private string valALPro;
        // Propiedad pública actualizar localidad provincia.
        public string ALPro
        {
            // Obtiene el valor de permiso.
            get { return valALPro; }
            // Asigna el valor de permiso.
            set { valALPro = value; }
        }

        // Variable privada eliminar localidad provincia.
        private string valELPro;
        // Propiedad pública eliminar localidad provincia.
        public string ELPro
        {
            // Obtiene el valor de permiso.
            get { return valELPro; }
            // Asigna el valor de permiso.
            set { valELPro = value; }
        }

        // Variable privada ingresar localidad región.
        private string valILReg;
        // Propiedad pública ingresar localidad región.
        public string ILReg
        {
            // Obtiene el valor de permiso.
            get { return valILReg; }
            // Asigna el valor de permiso.
            set { valILReg = value; }
        }

        // Variable privada actualizar localidad región.
        private string valALReg;
        // Propiedad pública actualizar localidad región.
        public string ALReg
        {
            // Obtiene el valor de permiso.
            get { return valALReg; }
            // Asigna el valor de permiso.
            set { valALReg = value; }
        }

        // Variable privada eliminar localidad región.
        private string valELReg;
        // Propiedad pública eliminar localidad región.
        public string ELReg
        {
            // Obtiene el valor de permiso.
            get { return valELReg; }
            // Asigna el valor de permiso.
            set { valELReg = value; }
        }

        // Variable privada ingresar cliente.
        private string valICliente;
        // Propiedad pública ingresar cliente.
        public string ICliente
        {
            // Obtiene el valor de permiso.
            get { return valICliente; }
            // Asigna el valor de permiso.
            set { valICliente = value; }
        }

        // Variable privada actualizar cliente.
        private string valACliente;
        // Propiedad pública actualizar cliente.
        public string ACliente
        {
            // Obtiene el valor de permiso.
            get { return valACliente; }
            // Asigna el valor de permiso.
            set { valACliente = value; }
        }

        // Variable privada eliminar cliente.
        private string valECliente;
        // Propiedad pública eliminar cliente.
        public string ECliente
        {
            // Obtiene el valor de permiso.
            get { return valECliente; }
            // Asigna el valor de permiso.
            set { valECliente = value; }
        }

        // Variable privada ingresar productos.
        private string valIProductos;
        // Propiedad pública ingresar productos.
        public string IProductos
        {
            // Obtiene el valor de permiso.
            get { return valIProductos; }
            // Asigna el valor de permiso.
            set { valIProductos = value; }
        }

        // Variable privada actualizar productos.
        private string valAProductos;
        // Propiedad pública actualizar productos.
        public string AProductos
        {
            // Obtiene el valor de permiso.
            get { return valAProductos; }
            // Asigna el valor de permiso.
            set { valAProductos = value; }
        }

        // Variable privada eliminar productos.
        private string valEProductos;
        // Propiedad pública eliminar productos.
        public string EProductos
        {
            // Obtiene el valor de permiso.
            get { return valEProductos; }
            // Asigna el valor de permiso.
            set { valEProductos = value; }
        }

        // Variable privada ingresar proveedor.
        private string valIProv;
        // Propiedad pública ingresar proveedor.
        public string IProv
        {
            // Obtiene el valor de permiso.
            get { return valIProv; }
            // Asigna el valor de permiso.
            set { valIProv = value; }
        }

        // Variable privada actualizar proveedor.
        private string valAProv;
        // Propiedad pública actualizar proveedor.
        public string AProv
        {
            // Obtiene el valor de permiso.
            get { return valAProv; }
            // Asigna el valor de permiso.
            set { valAProv = value; }
        }

        // Variable privada eliminar proveedor.
        private string valEProv;
        // Propiedad pública eliminar proveedor.
        public string EProv
        {
            // Obtiene el valor de permiso.
            get { return valEProv; }
            // Asigna el valor de permiso.
            set { valEProv = value; }
        }

        // Variable privada ingresar usuario.
        private string valIUsu;
        // Propiedad pública ingresar usuario.
        public string IUsu
        {
            // Obtiene el valor de permiso.
            get { return valIUsu; }
            // Asigna el valor de permiso.
            set { valIUsu = value; }
        }

        // Variable privada actualizar usuario.
        private string valAUsu;
        // Propiedad pública actualizar usuario.
        public string AUsu
        {
            // Obtiene el valor de permiso.
            get { return valAUsu; }
            // Asigna el valor de permiso.
            set { valAUsu = value; }
        }

        // Variable privada eliminar usuario.
        private string valEUsu;
        // Propiedad pública eliminar usuario.
        public string EUsu
        {
            // Obtiene el valor de permiso.
            get { return valEUsu; }
            // Asigna el valor de permiso.
            set { valEUsu = value; }
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

// Importa dependencias.
using Datos;
// Importa dependencias.
using Entidad;
// Importa dependencias.
using System.Collections.Generic;


namespace Negocio
{
    public class NProv
    {

        public List<EProv> Listar() // Lista todos los proveedores
        {
            return DProv.Instancia.Listar(); // Retorna lista de proveedores
        }

        public static Respuesta<bool> Ingresar(EProv obj) // Ingresa un nuevo proveedor
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProv.Instancia.Ingresar(obj); // Intenta ingresar proveedor
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Actualizar(EProv obj) // Actualiza un proveedor existente
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProv.Instancia.Actualizar(obj); // Intenta actualizar proveedor
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Eliminar(int Id) // Elimina un proveedor por ID
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProv.Instancia.Eliminar(Id); // Intenta eliminar proveedor
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }
    }
}


// Accede a códigos de otra librería
using Datos;
// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.Data;


namespace Negocio
{
    public class NProd
    {

        public List<EProd> Listar() // Lista todos los productos
        {
            return DProd.Instancia.Listar(); // Retorna lista de productos
        }

        public static Respuesta<bool> Actualizar2(EProd obj) // Actualiza un producto (versión 2)
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProd.Instancia.Actualizar2(obj); // Llama al método de actualización
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Ingresar(EProd obj) // Ingresa un nuevo producto
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProd.Instancia.Ingresar(obj); // Intenta ingresar producto
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Actualizar(EProd obj) // Actualiza un producto existente
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProd.Instancia.Actualizar(obj); // Intenta actualizar producto
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Eliminar(int Id) // Elimina un producto por ID
        {
            bool Respuesta = false; // Declara variable de respuesta
            Respuesta = DProd.Instancia.Eliminar(Id); // Intenta eliminar producto
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }
    }
}
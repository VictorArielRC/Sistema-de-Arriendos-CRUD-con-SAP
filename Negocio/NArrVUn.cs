// Accede a códigos de otra librería
using Datos;
// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using System.Collections.Generic;


namespace Negocio
{
    public class NArrVUn
    {
        public List<EArrVUn> Listar() // Lista de objetos
        {
            return DArrVUn.Instancia.Listar(); // Devuelve una lista de todos los objetos
        }
        public static Respuesta<bool> Ingresar(EArrVUn obj) // Inserta un nuevo objeto en la base de datos.
        {
            bool Respuesta = false; // almacena el resultado de la operación ( si es verdadera o falsa).
            Respuesta = DArrVUn.Instancia.Ingresar(obj); // Intenta insertar el objeto y guarda el resultado
            return new Respuesta<bool>() { estado = Respuesta }; // Devuelve un objeto que indica si la inserción fue exitosa.
        }
        public static Respuesta<bool> Actualizar(EArrVUn obj) // Actualiza un objeto existente en la base de datos.
        {
            bool Respuesta = false; // almacena el resultado de la operación
            Respuesta = DArrVUn.Instancia.Actualizar(obj); // Intenta actualizar el objeto y guarda el resultado
            return new Respuesta<bool>() { estado = Respuesta }; // Devuelve un objeto que indica si la actualización fue exitosa.
        }
        public static Respuesta<bool> Eliminar(int Id) // Elimina un objeto existente en la base de datos.
        {
            bool Respuesta = false; // almacena el resultado de la operación
            Respuesta = DArrVUn.Instancia.Eliminar(Id); // Intenta eliminar el objeto y guarda el resultado
            return new Respuesta<bool>() { estado = Respuesta }; // Devuelve un objeto que indica si la eliminación fue exitosa.
        }
        public int ObtenerUltimoId()
        {
            // Delegar la llamada al método correspondiente en la capa de datos
            return DArrVUn.Instancia.ObtenerUltimoId();
        }
    }
}

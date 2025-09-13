// Accede a códigos de otra librería
using Datos;
// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using System.Collections.Generic;



namespace Negocio
{
    public class NArrDet
    {
        public List<EArrDet> Listar() // Lista de objetos
        {
            return DArrDet.Instancia.Listar(); // Devuelve una lista de todos los objetos
        }
        public static Respuesta<bool> Ingresar(EArrDet obj) // Inserta un nuevo objeto en la base de datos.
        {
            bool Respuesta = false; // almacena el resultado de la operación ( si es verdadera o falsa).
            Respuesta = DArrDet.Instancia.Ingresar(obj); // Intenta insertar el objeto y guarda el resultado
            return new Respuesta<bool>() { estado = Respuesta }; // Devuelve un objeto que indica si la inserción fue exitosa.
        }
        public static Respuesta<bool> Actualizar(EArrDet obj) // Actualiza un objeto existente en la base de datos.
        {
            bool Respuesta = false; // almacena el resultado de la operación
            Respuesta = DArrDet.Instancia.Actualizar(obj); // Intenta actualizar el objeto y guarda el resultado
            return new Respuesta<bool>() { estado = Respuesta }; // Devuelve un objeto que indica si la actualización fue exitosa.
        }
        public static Respuesta<bool> Eliminar(int Id) // Elimina un objeto existente en la base de datos.
        {
            bool Respuesta = false; // almacena el resultado de la operación
            Respuesta = DArrDet.Instancia.Eliminar(Id); // Intenta eliminar el objeto y guarda el resultado
            return new Respuesta<bool>() { estado = Respuesta }; // Devuelve un objeto que indica si la eliminación fue exitosa.
        }
        public int ObtenerUltimoId()
        {
            // Delegar la llamada al método correspondiente en la capa de datos
            return DArrDet.Instancia.ObtenerUltimoId();
        }
    }
}

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
    public class NLocPro
    {

        public List<ELocPro> Listar() // Lista todas las provincias
        {
            return DLocPro.Instancia.Listar(); // Retorna lista de provincias
        }

        public DataTable Filtrar(int IdPro) // Filtra provincias por ID
        {
            return DLocPro.Instancia.Filtrar(IdPro); // Retorna tabla filtrada
        }

        public static Respuesta<bool> Ingresar(ELocPro obj) // Ingresa una nueva provincia
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocPro.Instancia.Ingresar(obj); // Intenta ingresar provincia
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Actualizar(ELocPro obj) // Actualiza una provincia existente
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocPro.Instancia.Actualizar(obj); // Intenta actualizar provincia
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Eliminar(int Id) // Elimina una provincia por ID
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocPro.Instancia.Eliminar(Id); // Intenta eliminar provincia
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }
    }
}
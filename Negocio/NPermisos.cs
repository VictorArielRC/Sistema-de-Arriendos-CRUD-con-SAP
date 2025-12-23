// Importa la capa de acceso datos.
using Datos;
// Importa las entidades del sistema.
using Entidad;
// Importa colecciones genéricas de datos.
using System.Collections.Generic;

// Define el espacio de nombres.
namespace Negocio
{
    // Clase de lógica negocio permisos.
    public class NPermisos
    {
        // Obtiene lista completa de permisos.
        public List<EPermisos> Listar()
        {
            // Retorna lista desde capa datos.
            return DPermisos.Instancia.Listar();
        }

        // Inserta nuevos permisos en sistema.
        public static Respuesta<bool> Ingresar(EPermisos obj)
        {
            // Ejecuta inserción en capa datos.
            bool respuesta = DPermisos.Instancia.Ingresar(obj);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = respuesta };
        }

        // Actualiza permisos existentes en sistema.
        public static Respuesta<bool> Actualizar(EPermisos obj)
        {
            // Ejecuta actualización en capa datos.
            bool respuesta = DPermisos.Instancia.Actualizar(obj);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = respuesta };
        }

        // Elimina permisos según su identificador.
        public static Respuesta<bool> Eliminar(int id)
        {
            // Ejecuta eliminación en capa datos.
            bool respuesta = DPermisos.Instancia.Eliminar(id);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = respuesta };
        }

        // Obtiene último identificador generado.
        public int ObtenerUltimoId()
        {
            // Retorna último identificador desde datos.
            return DPermisos.Instancia.ObtenerUltimoId();
        }

        // Obtiene permisos de un usuario específico.
        public EPermisos ObtenerPorUsuario(int idUsuario)
        {
            // Retorna permisos del usuario desde datos.
            return DPermisos.Instancia.ObtenerPorUsuario(idUsuario);
        }

        // Obtiene permisos por su identificador.
        public static EPermisos ObtenerPorId(int idPer)
        {
            // Retorna permisos desde capa datos.
            return DPermisos.ObtenerPorId(idPer);
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

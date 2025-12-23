// Importa la capa de acceso datos.
using Datos;
// Importa las entidades del sistema.
using Entidad;
// Importa colecciones genéricas de datos.
using System.Collections.Generic;
// Importa funcionalidades de datos tabulares.
using System.Data;

// Define el espacio de nombres.
namespace Negocio
{
    // Clase de lógica negocio usuarios.
    public class NUsuarios
    {
        // Obtiene lista completa de usuarios.
        public List<EUsuarios> Listar()
        {
            // Retorna lista desde capa datos.
            return DUsuarios.Instancia.Listar();
        }

        // Actualiza contraseña y permiso del usuario.
        public static Respuesta<bool> Actualizar2(EUsuarios obj)
        {
            // Inicializa variable de respuesta falsa.
            bool Respuesta = false;
            // Ejecuta actualización en capa datos.
            Respuesta = DUsuarios.Instancia.Actualizar2(obj);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = Respuesta };
        }

        // Inserta nuevo usuario en sistema.
        public static Respuesta<bool> Ingresar(EUsuarios obj)
        {
            // Inicializa variable de respuesta falsa.
            bool Respuesta = false;
            // Ejecuta inserción en capa datos.
            Respuesta = DUsuarios.Instancia.Insertar(obj);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = Respuesta };
        }

        // Actualiza nombre del usuario existente.
        public static Respuesta<bool> Actualizar(EUsuarios obj)
        {
            // Inicializa variable de respuesta falsa.
            bool Respuesta = false;
            // Ejecuta actualización en capa datos.
            Respuesta = DUsuarios.Instancia.Actualizar(obj);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = Respuesta };
        }

        // Elimina usuario según su identificador.
        public static Respuesta<bool> Eliminar(int Id)
        {
            // Inicializa variable de respuesta falsa.
            bool Respuesta = false;
            // Ejecuta eliminación en capa datos.
            Respuesta = DUsuarios.Instancia.Eliminar(Id);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = Respuesta };
        }

        // Verifica credenciales de inicio sesión.
        public static Respuesta<bool> Verificar(EUsuarios obj)
        {
            // Ejecuta verificación en capa datos.
            bool Respuesta = DUsuarios.Instancia.Verificar(obj);
            // Retorna respuesta encapsulada en objeto.
            return new Respuesta<bool>() { estado = Respuesta };
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

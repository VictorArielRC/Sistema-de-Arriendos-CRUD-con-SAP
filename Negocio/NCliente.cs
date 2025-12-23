// Importa dependencias.
using Datos;
// Importa dependencias.
using Entidad;
// Importa dependencias.
using System.Collections.Generic;


namespace Negocio
{
    public class NCliente
    {
        public List<ECliente> Listar() // Lista todos los clientes
        {
            return DCliente.Instancia.Listar(); // Retorna lista de clientes
        }

        public bool Buscar(ECliente obj) // Busca un cliente
        {
            return DCliente.Instancia.Buscar(obj); // Retorna resultado de búsqueda
        }

        public static Respuesta<bool> Ingresar(ECliente obj) // Ingresa un nuevo cliente
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DCliente.Instancia.Ingresar(obj); // Intenta ingresar cliente
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Actualizar(ECliente obj) // Actualiza un cliente existente
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DCliente.Instancia.Actualizar(obj); // Intenta actualizar cliente
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Eliminar(int Id) // Elimina un cliente por ID
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DCliente.Instancia.Eliminar(Id); // Intenta eliminar cliente
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }
        public int ObtenerUltimoId() // Obtiene el último ID de cliente
        {
            // Delegar la llamada al método correspondiente en la capa de datos.
            return DCliente.Instancia.ObtenerUltimoId(); // Retorna el último ID
        }
    }
}

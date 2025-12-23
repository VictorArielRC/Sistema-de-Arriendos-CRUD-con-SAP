// Importa dependencias.
using Datos;
// Importa dependencias.
using Entidad;
// Importa dependencias.
using System.Collections.Generic;
// Importa dependencias.
using System.Data;


namespace Negocio
{
    public class NLocCom
    {

        public List<ELocCom> Listar() // Lista todas las comunas
        {
            return DLocCom.Instancia.Listar(); // Retorna lista de comunas
        }

        public DataTable Filtrar(int IdCom) // Filtra comunas por ID
        {
            return DLocCom.Instancia.Filtrar(IdCom); // Retorna tabla filtrada
        }

        public static Respuesta<bool> Ingresar(ELocCom obj) // Ingresa una nueva comuna
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocCom.Instancia.Ingresar(obj); // Intenta ingresar comuna
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Actualizar(ELocCom obj) // Actualiza una comuna existente
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocCom.Instancia.Actualizar(obj); // Intenta actualizar comuna
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Eliminar(int Id) // Elimina una comuna por ID
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocCom.Instancia.Eliminar(Id); // Intenta eliminar comuna
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }
    }
}

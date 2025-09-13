// Accede a códigos de otra librería
using Datos;
// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using System.Collections.Generic;


namespace Negocio
{
    public class NLocReg
    {
        public List<ELocReg> Listar() // Lista todas las regiones
        {
            return DLocReg.Instancia.Listar(); // Retorna lista de regiones
        }

        public static Respuesta<bool> Ingresar(ELocReg obj) // Ingresa una nueva región
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocReg.Instancia.Ingresar(obj); // Intenta ingresar región
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Actualizar(ELocReg obj) // Actualiza una región existente
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocReg.Instancia.Actualizar(obj); // Intenta actualizar región
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }

        public static Respuesta<bool> Eliminar(int Id) // Elimina una región por ID
        {
            bool Respuesta = false; // Variable para la respuesta
            Respuesta = DLocReg.Instancia.Eliminar(Id); // Intenta eliminar región
            return new Respuesta<bool>() { estado = Respuesta }; // Retorna si fue exitoso
        }
    }
}
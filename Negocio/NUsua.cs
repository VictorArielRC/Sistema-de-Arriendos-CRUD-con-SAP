// Accede a códigos de otra librería
using Datos;
// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using System.Collections.Generic;


namespace Negocio
{
    public class NUsua
    {
        //private NUsua Datos = new NUsua();

        public static Respuesta<bool> Insertar(EUsua obj) // Inserta un nuevo usuario
        {
            bool respuesta = DUsua.Instancia.Insertar(obj); // Intenta insertar el usuario
            return new Respuesta<bool>() { estado = respuesta, valor = respuesta ? "Usuario insertado correctamente" : "Error al insertar usuario" }; // Retorna estado y mensaje
        }

        public static Respuesta<bool> Verificar(EUsua obj) // Verifica credenciales de usuario
        {
            bool respuesta = DUsua.Instancia.Verificar(obj); // Verifica usuario y contraseña
            return new Respuesta<bool>() { estado = respuesta, valor = respuesta ? "Inicio de sesión exitoso" : "Usuario o contraseña incorrectos" }; // Retorna estado y mensaje
        }

        public List<EUsua> Listar() // Lista todos los usuarios
        {
            return DUsua.Instancia.Listar(); // Retorna lista de usuarios
        }
    }
}

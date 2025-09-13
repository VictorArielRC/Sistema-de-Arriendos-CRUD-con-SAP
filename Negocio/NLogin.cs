using Datos;
// Accede a códigos de otra librería

namespace Negocio
{
    public class NLogin
    {
        private DLogin Datos = new DLogin(); // Instancia la capa de datos

        public int IngSig(string Nombre, string Pass) // Ingresa y obtiene ID de usuario
        {
            // Aquí llamas al método correspondiente en la capa de Datos (DLogin)
            return DLogin.Instancia.IngSig(Nombre, Pass); // Retorna el ID de usuario
        }
    }
}

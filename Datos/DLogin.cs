// Importa dependencias.
using System;
// Importa dependencias.
using System.Data;
// Importa dependencias.
using System.Data.SqlClient;


namespace Datos
{
    public class DLogin
    {
        private Conexion Cn = new Conexion(); // Instancia de la clase Conexión.

        public static DLogin _instancia = null; // Campo estático para la instancia Singleton.

        // Propiedad estática para obtener la instancia única de la clase DLogin (Patrón Singleton).
        public static DLogin Instancia
        {
            get
            {
                // Verifica si la instancia es nula; si lo es, crea una nueva.
                if (_instancia == null)
                {
                    _instancia = new DLogin();
                }
                return _instancia; // Devuelve la instancia existente o recién creada.
            }
        }

        // Método para intentar iniciar sesión con nombre de usuario y contraseña.
        public int IngSig(string Nombre, string Pass)
        {
            int Respuesta = 0; // Variable para almacenar el ID del usuario (0 si falla).

            // Utiliza una conexión SQL de forma segura para garantizar que se cierre correctamente.
            using (SqlConnection connection = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar posibles excepciones durante la operación de base de datos.
                {
                    // Crea un comando SQL para ejecutar el procedimiento almacenado "IngSig".
                    SqlCommand command = new SqlCommand("IngSig", connection);
                    // Añade el parámetro "Nombre" con el valor proporcionado.
                    command.Parameters.AddWithValue("Nombre", Nombre);
                    // Añade el parámetro "Pass" con el valor proporcionado.
                    command.Parameters.AddWithValue("Pass", Pass);
                    // Añade un parámetro de salida "IdUsu" de tipo entero para obtener el ID del usuario.
                    command.Parameters.Add("IdUsu", SqlDbType.Int).Direction = ParameterDirection.Output;
                    // Especifica que el comando es un procedimiento almacenado.
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open(); // Abre la conexión a la base de datos.

                    command.ExecuteNonQuery(); // Ejecuta el comando que no devuelve filas directamente.

                    // Obtiene el valor del parámetro de salida "IdUsu" y lo convierte a entero.
                    Respuesta = Convert.ToInt32(command.Parameters["IdUsu"].Value);

                }
                catch (Exception) // Si ocurre una excepción (ej. error de conexión, procedimiento almacenado).
                {
                    Respuesta = 0; // Si hay un error, la respuesta es 0 (indicando fallo).
                }
            }
            return Respuesta; // Devuelve el ID del usuario (o 0 si el inicio de sesión falló).
        }
    }
}


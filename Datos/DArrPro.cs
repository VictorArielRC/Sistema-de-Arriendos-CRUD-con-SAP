// Importa dependencias.
using Entidad;
// Importa dependencias.
using System;
// Importa dependencias.
using System.Collections.Generic;
// Importa dependencias.
using System.Data;
// Importa dependencias.
using System.Data.SqlClient;
// Importa dependencias.
using System.Linq;
// Importa dependencias.
using System.Text;
// Importa dependencias.
using System.Threading.Tasks;



namespace Datos
{
    public class DArrPro
    {
        // Conexión a base de datos encapsulada.
        private Conexion Cn = new Conexion();

        // Instancia estática del patrón Singleton.
        public static DArrPro _instancia = null;

        // Propiedad Singleton con inicialización controlada.
        public static DArrPro Instancia
        {
            get
            {
                // Crea instancia si no existe.
                if (_instancia == null)
                {
                    _instancia = new DArrPro(); // Nueva instancia Singleton
                }
                return _instancia; // Devuelve instancia existente o nueva
            }
        }

        public List<EArrPro> Listar()
        {
            List<EArrPro> Lis = new List<EArrPro>(); // Lista que almacenará los resultados obtenidos

            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex)) // Establece y gestiona la conexión a la base de datos
            {
                // Prepara el comando para ejecutar el procedimiento almacenado.
                SqlCommand cmd = new SqlCommand("Bus_Arr_Pro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure; // Indica que se trata de un procedimiento almacenado

                try // Intenta abrir la conexión, ejecutar el SP y recorrer los datos
                {
                    oConexion.Open(); // Abre la conexión con la base de datos

                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta el SP y obtiene un lector de resultados

                    while (dr.Read()) // Recorre cada fila devuelta por el procedimiento
                    {
                        Lis.Add(new EArrPro()
                        {
                            // Convierte el valor del campo "IdAPro" desde object a string, luego a entero de 32 bits.
                            IdAPro = Convert.ToInt32(dr["IdAPro"].ToString()),

                            IdPprod1 = Convert.ToInt32(dr["IdP_Prod1"].ToString()),  // Convierte "IdP_Prod1" de object → string → int
                            IdPprod2 = Convert.ToInt32(dr["IdP_Prod2"].ToString()),  // Convierte "IdP_Prod2" de object → string → int
                            IdPprod3 = Convert.ToInt32(dr["IdP_Prod3"].ToString()),  // Convierte "IdP_Prod3" de object → string → int
                            IdPprod4 = Convert.ToInt32(dr["IdP_Prod4"].ToString()),  // Convierte "IdP_Prod4" de object → string → int
                            IdPprod5 = Convert.ToInt32(dr["IdP_Prod5"].ToString()),  // Convierte "IdP_Prod5" de object → string → int
                            IdPprod6 = Convert.ToInt32(dr["IdP_Prod6"].ToString()),  // Convierte "IdP_Prod6" de object → string → int
                            IdPprod7 = Convert.ToInt32(dr["IdP_Prod7"].ToString()),  // Convierte "IdP_Prod7" de object → string → int
                            IdPprod8 = Convert.ToInt32(dr["IdP_Prod8"].ToString()),  // Convierte "IdP_Prod8" de object → string → int
                            IdPprod9 = Convert.ToInt32(dr["IdP_Prod9"].ToString()),  // Convierte "IdP_Prod9" de object → string → int
                            IdPprod10 = Convert.ToInt32(dr["IdP_Prod10"].ToString()) // Convierte "IdP_Prod10" de object → string → int
                        });

                    }
                    dr.Close(); // Cierra el lector de datos después de procesar todas las filas correctamente

                    return Lis; // Devuelve la lista de resultados construida con los registros leídos

                }
                catch (Exception) // Captura cualquier excepción que pueda producirse durante la ejecución del SP o lectura de datos
                {
                    Lis = null; // Si ocurre un error, se asigna null para indicar que la operación falló
                    return Lis; // Devuelve null como respuesta ante la excepción
                }
            }
        }
        public bool Ingresar(EArrPro obj)
        {
            bool Respuesta = true; // Variable que representa el estado de éxito de la operación. Se inicializa en true.

            // Bloque using que gestiona automáticamente la apertura y liberación de la conexión SqlConnection.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque que encapsula la ejecución segura del procedimiento, manejando excepciones si las hay

                {
                    // Crea un nuevo comando SQL para ejecutar el procedimiento almacenado "Ing_Arr_Pro".
                    SqlCommand cmd = new SqlCommand("Ing_Arr_Pro", Con);
                    cmd.CommandType = CommandType.StoredProcedure; // Especifica que se trata de un procedimiento almacenado

                    // Agrega un valor al parámetro "IdP_Prod1" requerido por el procedimiento.
                    cmd.Parameters.AddWithValue("IdP_Prod1", obj.IdPprod1);
                    // Agrega un valor al parámetro "IdP_Prod2".
                    cmd.Parameters.AddWithValue("IdP_Prod2", obj.IdPprod2);
                    // Agrega un valor al parámetro "IdP_Prod3".
                    cmd.Parameters.AddWithValue("IdP_Prod3", obj.IdPprod3);
                    // Agrega un valor al parámetro "IdP_Prod4".
                    cmd.Parameters.AddWithValue("IdP_Prod4", obj.IdPprod4);
                    // Agrega un valor al parámetro "IdP_Prod5".
                    cmd.Parameters.AddWithValue("IdP_Prod5", obj.IdPprod5);
                    // Agrega un valor al parámetro "IdP_Prod6".
                    cmd.Parameters.AddWithValue("IdP_Prod6", obj.IdPprod6);
                    // Agrega un valor al parámetro "IdP_Prod7".
                    cmd.Parameters.AddWithValue("IdP_Prod7", obj.IdPprod7);
                    // Agrega un valor al parámetro "IdP_Prod8".
                    cmd.Parameters.AddWithValue("IdP_Prod8", obj.IdPprod8);
                    // Agrega un valor al parámetro "IdP_Prod9".
                    cmd.Parameters.AddWithValue("IdP_Prod9", obj.IdPprod9);
                    // Agrega un valor al parámetro "IdP_Prod10".
                    cmd.Parameters.AddWithValue("IdP_Prod10", obj.IdPprod10);

                    Con.Open(); // Abre la conexión a la base de datos

                    cmd.ExecuteNonQuery(); // Ejecuta el procedimiento sin retorno de datos (INSERT, UPDATE o DELETE)

                    Respuesta = true; // Marca la operación como exitosa si no hubo excepción

                }
                catch (Exception) // Captura cualquier excepción producida durante la ejecución del bloque try
                {
                    Respuesta = false; // Si ocurre un error, marca la operación como fallida asignando false
                }
            }
            return Respuesta; // Devuelve el resultado final: true si fue exitosa, false si hubo error
        }
        public bool Actualizar(EArrPro obj)
        {
            bool Respuesta = true;
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try
                {
                    // Crea un nuevo comando SQL para ejecutar el procedimiento almacenado "Act_Arr_Det".
                    // (Nota: asegúrate de que el nombre del SP sea correcto para actualizar productos de arriendo).
                    SqlCommand cmd = new SqlCommand("Act_Arr_Det", Con);

                    // Agrega un valor al parámetro "IdAPro" que identifica el registro a actualizar.
                    cmd.Parameters.AddWithValue("IdAPro", obj.IdAPro);

                    // Agrega un valor al parámetro "IdP_Prod1" correspondiente al primer producto.
                    cmd.Parameters.AddWithValue("IdP_Prod1", obj.IdPprod1);
                    // Agrega un valor al parámetro "IdP_Prod2" correspondiente al segundo producto.
                    cmd.Parameters.AddWithValue("IdP_Prod2", obj.IdPprod2);
                    // Agrega un valor al parámetro "IdP_Prod3".
                    cmd.Parameters.AddWithValue("IdP_Prod3", obj.IdPprod3);
                    // Agrega un valor al parámetro "IdP_Prod4".
                    cmd.Parameters.AddWithValue("IdP_Prod4", obj.IdPprod4);
                    // Agrega un valor al parámetro "IdP_Prod5".
                    cmd.Parameters.AddWithValue("IdP_Prod5", obj.IdPprod5);
                    // Agrega un valor al parámetro "IdP_Prod6".
                    cmd.Parameters.AddWithValue("IdP_Prod6", obj.IdPprod6);
                    // Agrega un valor al parámetro "IdP_Prod7".
                    cmd.Parameters.AddWithValue("IdP_Prod7", obj.IdPprod7);
                    // Agrega un valor al parámetro "IdP_Prod8".
                    cmd.Parameters.AddWithValue("IdP_Prod8", obj.IdPprod8);
                    // Agrega un valor al parámetro "IdP_Prod9".
                    cmd.Parameters.AddWithValue("IdP_Prod9", obj.IdPprod9);
                    // Agrega un valor al parámetro "IdP_Prod10".
                    cmd.Parameters.AddWithValue("IdP_Prod10", obj.IdPprod10);

                    // Abre la conexión a la base de datos para ejecutar la instrucción.
                    Con.Open();

                    // Ejecuta el procedimiento almacenado sin esperar resultados (por ejemplo: UPDATE).
                    cmd.ExecuteNonQuery();

                    // Marca la operación como exitosa al no generarse excepciones.
                    Respuesta = true;
                }
                catch (Exception) // Captura cualquier excepción que ocurra durante la ejecución del bloque try
                {
                    Respuesta = false; // Si ocurre un error, marca la respuesta como false indicando fallo en la operación
                }
            }
            return Respuesta; // Devuelve true si se ejecutó correctamente o false si hubo excepción

        }
        // Método que elimina un registro en la tabla de productos asociados al arriendo usando el SP "Eli_Arr_Pro".
        public bool Eliminar(int Id)
        {
            bool Respuesta = true; // Variable que indica si la operación fue exitosa (true por defecto)

            // Bloque using que garantiza la correcta liberación de recursos de la conexión.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Intenta ejecutar la eliminación en la base de datos
                {
                    // Crea un comando SQL para ejecutar el procedimiento almacenado "Eli_Arr_Pro".
                    SqlCommand cmd = new SqlCommand("Eli_Arr_Pro", Con);

                    // Agrega un valor al parámetro "IdAPro" que identifica el registro a eliminar.
                    cmd.Parameters.AddWithValue("IdAPro", Id);

                    cmd.CommandType = CommandType.StoredProcedure; // Indica que se trata de un procedimiento almacenado

                    Con.Open(); // Abre la conexión a la base de datos

                    cmd.ExecuteNonQuery(); // Ejecuta el procedimiento que elimina el registro (sin retorno de datos)
                }
                catch (Exception) // Captura cualquier excepción que pueda producirse durante la ejecución
                {
                    Respuesta = false; // Si ocurre una excepción, marca la operación como fallida
                }
            }

            return Respuesta; // Devuelve true si se eliminó correctamente, false si hubo error
        }

        // Método que obtiene el último ID insertado en la tabla de productos asociados al arriendo usando el SP "Ult_Arr_Pro".
        public int ObtenerUltimoId()
        {
            int ultimoId = 0; // Variable que almacenará el valor devuelto por el SP

            try // Inicia el bloque de manejo de errores
            {
                // Bloque using que asegura la correcta liberación de la conexión SQL.
                using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Conexión a la base de datos
                {
                    Con.Open(); // Abre la conexión con la base de datos

                    // Crea el comando para ejecutar el procedimiento almacenado "Ult_Arr_Pro".
                    SqlCommand cmd = new SqlCommand("Ult_Arr_Pro", Con);
                    cmd.CommandType = CommandType.StoredProcedure; // Indica que se trata de un procedimiento almacenado

                    // Ejecuta el SP que devuelve un único valor (último ID insertado).
                    object resultado = cmd.ExecuteScalar();

                    // Verifica que el resultado no sea null ni DBNull antes de convertirlo.
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        // Convierte el valor recibido (de tipo object) a cadena con .ToString().
                        // Y luego a entero de 32 bits usando Convert.ToInt32.
                        ultimoId = Convert.ToInt32(resultado);
                    }
                }
            }
            catch (Exception ex) // Captura cualquier excepción ocurrida durante el proceso
            {
                // Imprime el mensaje de error en la consola (opcional para depuración local).
                Console.WriteLine($"Error en capa de datos: {ex.Message}");

                throw; // Relanza la excepción para que sea manejada en un nivel superior
            }

            return ultimoId; // Devuelve el último ID obtenido desde la base de datos
        }

    }

}

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


// Gestión datos.
namespace Datos
{
    public class DArrDet
    {
        // Instancia privada para manejar conexiones a la base de datos.
        private Conexion Cn = new Conexion();

        // Campo estático que almacena la única instancia de la clase DArrDet (Singleton).
        public static DArrDet _instancia = null;

        // Propiedad pública que expone la instancia del Singleton.
        public static DArrDet Instancia
        {
            get
            {
                // Si no existe una instancia, se crea.
                if (_instancia == null)
                {
                    _instancia = new DArrDet();
                }
                return _instancia; // Devuelve la instancia única
            }
        }

        // Método que obtiene una lista de registros desde la base de datos usando el SP "Bus_Arr_Det".
        // Método que lista todos los registros de detalle de arriendo utilizando el procedimiento almacenado "Bus_Arr_Det".
        public List<EArrDet> Listar()
        {
            // Crea la lista donde se almacenarán los objetos EArrDet obtenidos de la base de datos.
            List<EArrDet> Lis = new List<EArrDet>();

            // Bloque using que garantiza la correcta liberación de recursos del objeto SqlConnection.
            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex))
            {
                // Crea el comando que ejecutará el procedimiento almacenado "Bus_Arr_Det".
                SqlCommand cmd = new SqlCommand("Bus_Arr_Det", oConexion);
                cmd.CommandType = CommandType.StoredProcedure; // Indica que se trata de un SP

                try // Intenta abrir la conexión, ejecutar el comando y leer los resultados
                {
                    oConexion.Open(); // Abre la conexión con la base de datos

                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta el SP y obtiene los resultados en un lector de datos

                    while (dr.Read()) // Recorre cada fila del resultado devuelto
                    {
                        // Agrega un nuevo objeto EArrDet a la lista, mapeando cada campo del lector.
                        Lis.Add(new EArrDet()
                        {
                            IdADet = Convert.ToInt32(dr["IdADet"].ToString()), // Convierte el valor del campo "IdADet" a cadena, luego a entero de 32 bits

                            DPr1 = dr["DPr1"].ToString(),   // Convierte el valor del campo "DPr1" a cadena
                            DPr2 = dr["DPr2"].ToString(),   // Convierte el valor del campo "DPr2" a cadena
                            DPr3 = dr["DPr3"].ToString(),   // Convierte el valor del campo "DPr3" a cadena
                            DPr4 = dr["DPr4"].ToString(),   // Convierte el valor del campo "DPr4" a cadena
                            DPr5 = dr["DPr5"].ToString(),   // Convierte el valor del campo "DPr5" a cadena
                            DPr6 = dr["DPr6"].ToString(),   // Convierte el valor del campo "DPr6" a cadena
                            DPr7 = dr["DPr7"].ToString(),   // Convierte el valor del campo "DPr7" a cadena
                            DPr8 = dr["DPr8"].ToString(),   // Convierte el valor del campo "DPr8" a cadena
                            DPr9 = dr["DPr9"].ToString(),   // Convierte el valor del campo "DPr9" a cadena
                            DPr10 = dr["DPr10"].ToString(), // Convierte el valor del campo "DPr10" a cadena
                        });

                    }

                    dr.Close(); // Cierra el lector de datos después de finalizar la lectura

                    return Lis; // Devuelve la lista poblada de objetos EArrDet
                }
                catch (Exception) // Captura cualquier excepción que ocurra durante la operación
                {
                    Lis = null; // Si ocurre un error, se asigna null a la lista
                    return Lis; // Devuelve null como indicador de fallo
                }
            }
        }


        public bool Ingresar(EArrDet obj)
        {
            bool Respuesta = true; // Variable que indica si la operación fue exitosa (inicialmente true)

            // Bloque using que garantiza la liberación de recursos al finalizar.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Intenta ejecutar la inserción en la base de datos
                {
                    // Prepara el comando para ejecutar el procedimiento almacenado "Ing_Arr_Det".
                    SqlCommand cmd = new SqlCommand("Ing_Arr_Det", Con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega un valor al parámetro "DPr1".
                    cmd.Parameters.AddWithValue("DPr1", obj.DPr1);
                    // Agrega un valor al parámetro "DPr2".
                    cmd.Parameters.AddWithValue("DPr2", obj.DPr2);
                    // Agrega un valor al parámetro "DPr3".
                    cmd.Parameters.AddWithValue("DPr3", obj.DPr3);
                    // Agrega un valor al parámetro "DPr4".
                    cmd.Parameters.AddWithValue("DPr4", obj.DPr4);
                    // Agrega un valor al parámetro "DPr5".
                    cmd.Parameters.AddWithValue("DPr5", obj.DPr5);
                    // Agrega un valor al parámetro "DPr6".
                    cmd.Parameters.AddWithValue("DPr6", obj.DPr6);
                    // Agrega un valor al parámetro "DPr7".
                    cmd.Parameters.AddWithValue("DPr7", obj.DPr7);
                    // Agrega un valor al parámetro "DPr8".
                    cmd.Parameters.AddWithValue("DPr8", obj.DPr8);
                    // Agrega un valor al parámetro "DPr9".
                    cmd.Parameters.AddWithValue("DPr9", obj.DPr9);
                    // Agrega un valor al parámetro "DPr10".
                    cmd.Parameters.AddWithValue("DPr10", obj.DPr10);

                    Con.Open(); // Abre la conexión a la base de datos

                    cmd.ExecuteNonQuery(); // Ejecuta el procedimiento almacenado sin retorno de resultados

                    Respuesta = true; // Asigna true si la operación se ejecutó sin errores
                }
                catch (Exception) // Captura cualquier excepción que ocurra durante la ejecución
                {
                    Respuesta = false; // Marca la operación como fallida
                }
            }

            return Respuesta; // Devuelve true si fue exitosa, false si hubo error
        }


        public bool Actualizar(EArrDet obj)
        {
            bool Respuesta = true; // Variable que indica si la operación fue exitosa (inicialmente true)

            // Crea un contexto de conexión que se liberará automáticamente al finalizar el bloque.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque que captura posibles errores durante la ejecución del procedimiento
                {
                    // Prepara el comando SQL para ejecutar el procedimiento almacenado "Act_Arr_Det".
                    SqlCommand cmd = new SqlCommand("Act_Arr_Det", Con);

                    // Agrega un valor al parámetro "IdADet" con el identificador del detalle a actualizar.
                    cmd.Parameters.AddWithValue("IdADet", obj.IdADet);
                    // Agrega un valor al parámetro "DPr1" con el nuevo contenido.
                    cmd.Parameters.AddWithValue("DPr1", obj.DPr1);
                    // Agrega un valor al parámetro "DPr2".
                    cmd.Parameters.AddWithValue("DPr2", obj.DPr2);
                    // Agrega un valor al parámetro "DPr3".
                    cmd.Parameters.AddWithValue("DPr3", obj.DPr3);
                    // Agrega un valor al parámetro "DPr4".
                    cmd.Parameters.AddWithValue("DPr4", obj.DPr4);
                    // Agrega un valor al parámetro "DPr5".
                    cmd.Parameters.AddWithValue("DPr5", obj.DPr5);
                    // Agrega un valor al parámetro "DPr6".
                    cmd.Parameters.AddWithValue("DPr6", obj.DPr6);
                    // Agrega un valor al parámetro "DPr7".
                    cmd.Parameters.AddWithValue("DPr7", obj.DPr7);
                    // Agrega un valor al parámetro "DPr8".
                    cmd.Parameters.AddWithValue("DPr8", obj.DPr8);
                    // Agrega un valor al parámetro "DPr9".
                    cmd.Parameters.AddWithValue("DPr9", obj.DPr9);
                    // Agrega un valor al parámetro "DPr10".
                    cmd.Parameters.AddWithValue("DPr10", obj.DPr10);

                    Con.Open(); // Abre la conexión a la base de datos

                    cmd.ExecuteNonQuery(); // Ejecuta el procedimiento almacenado sin retornar resultados

                    Respuesta = true; // Asigna true si todo fue exitoso
                }
                catch (Exception) // Captura cualquier excepción producida durante la ejecución
                {
                    Respuesta = false; // Marca la operación como fallida en caso de excepción
                }
            }

            return Respuesta; // Devuelve true si fue exitoso, false si hubo error
        }


        // Método que elimina un registro usando el SP "Eli_Arr_Det".
        public bool Eliminar(int Id)
        {
            bool Respuesta = true; // Variable que indica si la operación fue exitosa

            // Usa un bloque using para asegurar la correcta liberación de recursos de la conexión.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Intenta ejecutar la eliminación en la base de datos
                {
                    // Prepara el comando para ejecutar el procedimiento almacenado "Eli_Arr_Det".
                    SqlCommand cmd = new SqlCommand("Eli_Arr_Det", Con);

                    // Agrega un valor al parámetro "IdADet" que se utilizará en el SP.
                    cmd.Parameters.AddWithValue("IdADet", Id);

                    Con.Open(); // Abre la conexión con la base de datos
                    cmd.ExecuteNonQuery(); // Ejecuta el procedimiento que elimina el registro

                    Respuesta = true; // Si no hay excepciones, la operación fue exitosa
                }
                catch (Exception) // Captura cualquier error durante la ejecución
                {
                    Respuesta = false; // Marca la operación como fallida
                }
            }

            return Respuesta; // Devuelve true si la operación fue exitosa, o false si hubo error
        }


        // Método que obtiene el último ID insertado usando el SP "Ult_Arr_Det".
        public int ObtenerUltimoId()
        {
            int ultimoId = 0; // Variable que almacenará el valor obtenido

            try
            {
                using (SqlConnection Con = new SqlConnection(Conexion.Conex))
                {
                    Con.Open(); // Abre la conexión

                    SqlCommand cmd = new SqlCommand("Ult_Arr_Det", Con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    object resultado = cmd.ExecuteScalar(); // Ejecuta el SP que devuelve un valor escalar

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ultimoId = Convert.ToInt32(resultado); // Convierte el valor obtenido a entero de 32 bits
                    }
                }
            }
            catch (Exception ex)
            // Captura excepciones.
            {
                // Relanza la excepción sin modificar para que sea manejada en un nivel superior.
                throw;
            }

            return ultimoId; // Devuelve el ID obtenido
        }
    }
}

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
    public class DArr
    {
        // Instancia privada de la clase Conexion para manejar las conexiones a la base de datos.
        private Conexion Cn = new Conexion();

        // Campo estático que contiene la única instancia de DArr (patrón Singleton).
        public static DArr _instancia = null;

        // Propiedad para acceder a la instancia única de DArr.
        public static DArr Instancia
        {
            get
            {
                // Si no existe una instancia, se crea.
                if (_instancia == null)
                {
                    _instancia = new DArr();
                }
                return _instancia; // Devuelve la instancia
            }
        }
        // Método que obtiene una lista de registros desde el procedimiento almacenado "Bus_Arr".
        public List<EArr> Listar()
        {
            List<EArr> Lis = new List<EArr>(); // Lista de objetos EArr que se devolverá

            // Crea y gestiona automáticamente la conexión con la base de datos (se libera al finalizar el bloque).
            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex))
            {
                SqlCommand cmd = new SqlCommand("Bus_Arr", oConexion); // Comando SQL asociado al SP
                cmd.CommandType = CommandType.StoredProcedure; // Se indica que se usará un procedimiento almacenado

                try // Bloque que contiene el código que puede lanzar excepciones
                {
                    oConexion.Open(); // Abre la conexión con la base de datos
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta el SP y obtiene los resultados

                    while (dr.Read()) // Itera sobre cada fila del resultado
                    {
                        // Agrega un nuevo objeto EArr a la lista, mapeando los campos del lector.
                        Lis.Add(new EArr()
                        {
                            IdArr = Convert.ToInt32(dr["IdArr"].ToString()),           // Convierte el valor a entero de 32 bits
                            IdP_Cli = Convert.ToInt32(dr["IdP_Cli"].ToString()),       // Convierte el valor a entero
                            Fech = dr["Fech"].ToString(),                              // Asigna la fecha como cadena
                            IdAPro = Convert.ToInt32(dr["IdAPro"].ToString()),         // Convierte el valor a entero
                            IdADet = Convert.ToInt32(dr["IdADet"].ToString()),         // Convierte el valor a entero
                            IdAVUn = Convert.ToInt32(dr["IdAVUn"].ToString()),         // Convierte el valor a entero
                            SubTo = dr["SubTo"].ToString(),                            // Asigna el Subtotal como cadena
                            Descuento = dr["Descuento"].ToString(),                    // Asigna el Descuento como cadena
                            IVA = dr["IVA"].ToString(),                                // Asigna el IVA como cadena
                            Total = dr["Total"].ToString(),                            // Asigna el Total como cadena
                        });
                    }

                    dr.Close(); // Cierra el SqlDataReader después de leer todos los datos
                    return Lis; // Devuelve la lista poblada
                }
                catch (Exception) // Captura cualquier excepción que ocurra en el bloque try
                {
                    Lis = null; // Asigna null a la lista si ocurre un error
                    return Lis; // Devuelve null como indicador de fallo
                }
            }
        }
        // Método que inserta un nuevo registro en la base de datos.
        public bool Ingresar(EArr obj)
        {
            bool Respuesta = true; // Indicador de éxito de la operación (inicialmente verdadero)

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Gestiona la conexión automáticamente
            {
                try // Bloque para ejecutar el SP con control de errores
                {
                    SqlCommand cmd = new SqlCommand("Ing_Arr", Con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdP_Cli", obj.IdP_Cli);       // Agrega un valor
                    cmd.Parameters.AddWithValue("Fech", obj.Fech);             // Agrega un valor
                    cmd.Parameters.AddWithValue("IdAPro", obj.IdAPro);         // Agrega un valor
                    cmd.Parameters.AddWithValue("IdADet", obj.IdADet);         // Agrega un valor
                    cmd.Parameters.AddWithValue("IdAVUn", obj.IdAVUn);         // Agrega un valor
                    cmd.Parameters.AddWithValue("SubTo", obj.SubTo);           // Agrega un valor
                    cmd.Parameters.AddWithValue("Descuento", obj.Descuento);   // Agrega un valor
                    cmd.Parameters.AddWithValue("IVA", obj.IVA);               // Agrega un valor
                    cmd.Parameters.AddWithValue("Total", obj.Total);           // Agrega un valor

                    Con.Open(); // Abre la conexión a la base de datos
                    cmd.ExecuteNonQuery(); // Ejecuta el SP que no retorna resultados
                    Respuesta = true; // Asigna true si no hubo errores
                }
                catch (Exception) // Captura errores de ejecución o de base de datos
                {
                    Respuesta = false; // Marca como fallo la operación
                }
            }

            return Respuesta; // Devuelve el resultado de la operación (true o false)
        }
        public bool Actualizar(EArr obj)
        {
            bool Respuesta = true; // Inicializa el indicador de éxito

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Crea y gestiona la conexión
            {
                try // Intenta realizar la operación de actualización
                {
                    SqlCommand cmd = new SqlCommand("Act_Arr", Con);

                    cmd.Parameters.AddWithValue("IdArr", obj.IdArr);             // Agrega un valor
                    cmd.Parameters.AddWithValue("IdP_Cli", obj.IdP_Cli);         // Agrega un valor
                    cmd.Parameters.AddWithValue("Fech", obj.Fech);               // Agrega un valor
                    cmd.Parameters.AddWithValue("IdAPro", obj.IdAPro);           // Agrega un valor
                    cmd.Parameters.AddWithValue("IdADet", obj.IdADet);           // Agrega un valor
                    cmd.Parameters.AddWithValue("IdAVUn", obj.IdAVUn);           // Agrega un valor
                    cmd.Parameters.AddWithValue("SubTo", obj.SubTo);             // Agrega un valor
                    cmd.Parameters.AddWithValue("Descuento", obj.Descuento);     // Agrega un valor
                    cmd.Parameters.AddWithValue("IVA", obj.IVA);                 // Agrega un valor
                    cmd.Parameters.AddWithValue("Total", obj.Total);             // Agrega un valor

                    Con.Open(); // Abre la conexión con la base de datos
                    cmd.ExecuteNonQuery(); // Ejecuta el SP sin resultados de retorno
                    Respuesta = true; // Marca operación como exitosa
                }
                catch (Exception) // Captura excepciones y evita que el sistema colapse
                {
                    Respuesta = false; // Marca la operación como fallida
                }
            }

            return Respuesta; // Devuelve el estado de la operación
        }
        // Método que elimina registros relacionados al ID especificado.
        public bool Eliminar(int Id)
        {
            bool Respuesta = true; // Variable que indica si se eliminó correctamente

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre y gestiona la conexión automáticamente
            {
                try // Intenta ejecutar la operación de eliminación
                {
                    SqlCommand cmd = new SqlCommand("Eli_Arr_Total", Con);

                    cmd.Parameters.AddWithValue("IdADet", Id); // Agrega un valor
                    cmd.Parameters.AddWithValue("IdAPro", Id); // Agrega un valor
                    cmd.Parameters.AddWithValue("IdAVUn", Id); // Agrega un valor
                    cmd.Parameters.AddWithValue("IdArr", Id);  // Agrega un valor

                    Con.Open(); // Abre la conexión con la base de datos
                    cmd.ExecuteNonQuery(); // Ejecuta el SP que elimina los registros
                    Respuesta = true; // Operación exitosa
                }
                catch (Exception) // Captura errores de conexión, ejecución o SP
                {
                    Respuesta = false; // Operación fallida
                }
            }

            return Respuesta; // Devuelve el estado final de la operación
        }
        // Método que obtiene el último ID insertado en la tabla correspondiente.
        public int ObtenerUltimoId()
        {
            int ultimoId = 0; // Inicializa la variable que almacenará el último ID

            try // Intenta ejecutar el SP y leer el resultado
            {
                using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Crea y gestiona la conexión automáticamente
                {
                    Con.Open(); // Abre la conexión con la base de datos

                    SqlCommand cmd = new SqlCommand("Ult_Arr", Con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    object resultado = cmd.ExecuteScalar(); // Ejecuta el SP que retorna un único valor escalar

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ultimoId = Convert.ToInt32(resultado); // Convierte el valor obtenido a entero de 32 bits
                    }
                }
            }
            catch (Exception ex) // Captura cualquier excepción durante la ejecución
            {
                // Lanza la excepción con contexto para facilitar el rastreo de errores.
                throw new Exception("Error al obtener el último ID desde 'Ult_Arr': " + ex.Message, ex);
            }

            return ultimoId; // Devuelve el ID resultante
        }
    }
}

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
using System.Text;


namespace Datos
{
    public class DLocReg
    {
        private Conexion Cn = new Conexion(); // Instancia de la clase de conexión.

        public static DLocReg _instancia = null; // Instancia estática privada de la clase.

        // Propiedad estática para obtener la instancia única de DLocReg (Singleton pattern).
        public static DLocReg Instancia
        {
            get
            {
                // Si la instancia es nula, crea una nueva.
                if (_instancia == null)
                {
                    _instancia = new DLocReg();
                }
                return _instancia; // Retorna la instancia existente o la recién creada.
            }
        }

        // Método para listar todas las regiones.
        public List<ELocReg> Listar()
        {
            List<ELocReg> Lis = new List<ELocReg>(); // Crea una lista para almacenar las regiones.
                                                     // Utiliza una conexión SQL de forma segura (using statement).
            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex))
            {
                // Crea un comando SQL para llamar al procedimiento almacenado "Bus_LReg".
                SqlCommand cmd = new SqlCommand("Bus_LReg", oConexion);
                cmd.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado.
                try // Bloque para manejar posibles excepciones durante la operación de base de datos.
                {
                    oConexion.Open(); // Abre la conexión a la base de datos.
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos.
                    while (dr.Read()) // Itera sobre cada fila devuelta por el lector de datos.
                    {
                        // Añade una nueva entidad ELocReg a la lista con los datos de la fila actual.
                        Lis.Add(new ELocReg()
                        {
                            IdReg = Convert.ToInt32(dr["IdReg"]), // Convierte el valor de "IdReg" a entero.
                            Nombre = dr["Nombre"].ToString(), // Obtiene el valor de "Nombre" como cadena.
                        });
                    }
                    dr.Close(); // Cierra el lector de datos.
                    return Lis; // Retorna la lista de regiones.
                }
                catch (Exception) // Si ocurre una excepción.
                {
                    Lis = null; // Establece la lista como nula.
                    return Lis; // Retorna nulo, indicando que hubo un error.
                }
            }
        }

        // Método para ingresar una nueva región.
        public bool Ingresar(ELocReg obj)
        {
            bool Respuesta = true; // Variable para almacenar el resultado de la operación (inicialmente true).
                                   // Utiliza una conexión SQL de forma segura.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar posibles excepciones.
                {
                    // Crea un comando SQL para el procedimiento almacenado "Ing_LReg".
                    SqlCommand cmd = new SqlCommand("Ing_LReg", Con);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Añade el parámetro "Nombre" con el valor de la entidad.
                                                                       // Añade un parámetro de salida "Resultado" de tipo Bit.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Especifica que es un procedimiento almacenado.
                    Con.Open(); // Abre la conexión a la base de datos.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando que no devuelve filas.
                                           // Obtiene el valor del parámetro de salida "Resultado" y lo convierte a booleano.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception) // Si ocurre una excepción.
                {
                    Respuesta = false; // Establece la respuesta como falsa.
                }
            }
            return Respuesta; // Retorna el resultado de la operación.
        }

        // Método para actualizar una región existente.
        public bool Actualizar(ELocReg obj)
        {
            bool Respuesta = true; // Variable para almacenar el resultado de la operación (inicialmente true).
                                   // Utiliza una conexión SQL de forma segura.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar posibles excepciones.
                {
                    // Crea un comando SQL para el procedimiento almacenado "Act_LReg".
                    SqlCommand cmd = new SqlCommand("Act_LReg", Con);
                    cmd.Parameters.AddWithValue("IdReg", obj.IdReg); // Añade el parámetro "IdReg".
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Añade el parámetro "Nombre".
                                                                       // Añade un parámetro de salida "Resultado".
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Especifica que es un procedimiento almacenado.
                    Con.Open(); // Abre la conexión a la base de datos.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                                           // Obtiene el valor del parámetro de salida "Resultado" y lo convierte a booleano.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception) // Si ocurre una excepción.
                {
                    Respuesta = false; // Establece la respuesta como falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }

        // Método para eliminar una región por su ID.
        public bool Eliminar(int Id)
        {
            bool Respuesta = true; // Variable para almacenar el resultado (inicialmente true).
                                   // Utiliza una conexión SQL de forma segura.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar posibles excepciones.
                {
                    // Crea un comando SQL para el procedimiento almacenado "Eli_LReg".
                    SqlCommand cmd = new SqlCommand("Eli_LReg", Con);
                    cmd.Parameters.AddWithValue("IdReg", Id); // Añade el parámetro "IdReg" con el ID a eliminar.
                                                              // Añade un parámetro de salida "Resultado".
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Especifica que es un procedimiento almacenado.
                    Con.Open(); // Abre la conexión a la base de datos.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                                           // Obtiene el valor del parámetro de salida "Resultado" y lo convierte a booleano.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception) // Si ocurre una excepción.
                {
                    Respuesta = false; // Establece la respuesta como falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }
    }
}


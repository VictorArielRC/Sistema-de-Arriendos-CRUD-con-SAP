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


namespace Datos
{
    public class DLocPro
    {
        private Conexion Cn = new Conexion(); // Instancia de la conexión.

        public static DLocPro _instancia = null; // Instancia estática privada.

        // Propiedad estática para obtener la instancia única.
        public static DLocPro Instancia
        {
            get
            {
                // Crea instancia si es nula.
                if (_instancia == null)
                {
                    _instancia = new DLocPro();
                }
                return _instancia; // Retorna la instancia existente.
            }
        }

        // Lista todas las provincias.
        public List<ELocPro> Listar()
        {
            List<ELocPro> Lis = new List<ELocPro>(); // Nueva lista de provincias.
                                                     // Usa una conexión SQL.
            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex))
            {
                // Comando para procedimiento almacenado.
                SqlCommand cmd = new SqlCommand("Bus_LPro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                try // Intenta ejecutar la operación.
                {
                    oConexion.Open(); // Abre la conexión.
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta y lee datos.
                    while (dr.Read()) // Mientras haya registros.
                    {
                        // Añade nueva provincia a la lista.
                        Lis.Add(new ELocPro()
                        {
                            IdPro = Convert.ToInt32(dr["IdPro"].ToString()), // Obtiene ID provincia.
                            Nombre = dr["Nombre"].ToString(), // Obtiene nombre provincia.
                            IdReg = Convert.ToInt32(dr["IdReg"].ToString()), // Obtiene ID región.
                            Reg = new ELocReg() { Nombre = dr["NombreRegion"].ToString() }, // Crea objeto Región.
                        });
                    }
                    dr.Close(); // Cierra el lector.
                    return Lis; // Retorna la lista.
                }
                catch (Exception) // Captura cualquier error.
                {
                    Lis = null; // Lista es nula.
                    return Lis; // Retorna nulo.
                }
            }
        }

        // Filtra provincias por ID.
        public DataTable Filtrar(int Id)
        {
            DataTable dt = new DataTable(); // Nueva tabla de datos.
            List<Parametro> parametros = new List<Parametro>(); // Lista de parámetros.
            try // Intenta ejecutar la operación.
            {
                parametros.Add(new Parametro("@Id", Id)); // Añade el parámetro ID.
                                                          // Usa una conexión SQL.
                using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
                {
                    // Comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Fil_Id_LPro", conexion);
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    foreach (var parametro in parametros) // Para cada parámetro.
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor); // Añade parámetro.
                    }
                    // Usa un adaptador de datos.
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt); // Llena la tabla.
                    }
                }
                return dt; // Retorna la tabla.
            }
            catch (Exception ex) // Captura cualquier error.
            {
                throw ex; // Relanza la excepción.
            }
        }

        // Ingresa una nueva provincia.
        public bool Ingresar(ELocPro obj)
        {
            bool Respuesta = true; // Respuesta inicial verdadera.
                                   // Usa una conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Intenta ejecutar la operación.
                {
                    // Comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Ing_LPro", Con);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Añade nombre.
                    cmd.Parameters.AddWithValue("IdReg", obj.IdReg); // Añade ID región.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida.
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    Con.Open(); // Abre la conexión.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtiene resultado.
                }
                catch (Exception) // Captura cualquier error.
                {
                    Respuesta = false; // Respuesta es falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }

        // Actualiza una provincia existente.
        public bool Actualizar(ELocPro obj)
        {
            bool Respuesta = true; // Respuesta inicial verdadera.
                                   // Usa una conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Intenta ejecutar la operación.
                {
                    // Comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Act_LPro", Con);
                    cmd.Parameters.AddWithValue("IdPro", obj.IdPro); // Añade ID provincia.
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Añade nombre.
                    cmd.Parameters.AddWithValue("IdReg", obj.IdReg); // Añade ID región.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida.
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    Con.Open(); // Abre la conexión.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtiene resultado.
                }
                catch (Exception) // Captura cualquier error.
                {
                    Respuesta = false; // Respuesta es falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }

        // Elimina una provincia por su ID.
        public bool Eliminar(int IdPro)
        {
            bool Respuesta = true; // Respuesta inicial verdadera.
                                   // Usa una conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Intenta ejecutar la operación.
                {
                    // Comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Eli_LPro", Con);
                    cmd.Parameters.AddWithValue("IdPro", IdPro); // Añade ID provincia.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida.
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    Con.Open(); // Abre la conexión.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtiene resultado.
                }
                catch (Exception) // Captura cualquier error.
                {
                    Respuesta = false; // Respuesta es falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }
    }
}


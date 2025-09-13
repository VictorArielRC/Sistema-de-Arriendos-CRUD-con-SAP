// Accede a códigos de otra librería
using Entidad;
// Accede a códigos de otra librería
using System;
// Accede a códigos de otra librería
using System.Collections.Generic;
// Accede a códigos de otra librería
using System.Data;
// Accede a códigos de otra librería
using System.Data.SqlClient;


namespace Datos
{
    public class DLocCom
    {
        private Conexion Cn = new Conexion(); // Instancia de la clase Conexión.

        public static DLocCom _instancia = null; // Instancia estática de la clase.

        // Propiedad estática para obtener la instancia única.
        public static DLocCom Instancia
        {
            get
            {
                // Si no hay instancia, crea una nueva.
                if (_instancia == null)
                {
                    _instancia = new DLocCom();
                }
                return _instancia; // Retorna la instancia existente.
            }
        }

        // Lista todas las comunas.
        public List<ELocCom> Listar()
        {
            // Crea una nueva lista de comunas.
            List<ELocCom> Lis = new List<ELocCom>();
            // Usa una conexión SQL.
            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex))
            {
                // Crea un comando para el procedimiento almacenado.
                SqlCommand cmd = new SqlCommand("Bus_LCom", oConexion);
                cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                try // Bloque para manejar errores.
                {
                    oConexion.Open(); // Abre la conexión.
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta y lee los datos.
                    while (dr.Read()) // Mientras haya filas para leer.
                    {
                        // Añade una nueva comuna a la lista.
                        Lis.Add(new ELocCom()
                        {
                            IdCom = Convert.ToInt32(dr["IdCom"].ToString()), // Convierte ID de comuna.
                            Nombre = dr["Nombre"].ToString(), // Obtiene el nombre.
                            IdPro = Convert.ToInt32(dr["IdPro"].ToString()), // Convierte ID de provincia.
                            Pro = new ELocPro() { Nombre = dr["NombreProvincia"].ToString() }, // Crea objeto Provincia.
                            IdReg = Convert.ToInt32(dr["IdReg"].ToString()), // Convierte ID de región.
                            Reg = new ELocReg() { Nombre = dr["NombreRegion"].ToString() }, // Crea objeto Región.
                        });
                    }
                    dr.Close(); // Cierra el lector de datos.
                    return Lis; // Retorna la lista de comunas.
                }
                catch (Exception) // Captura cualquier excepción.
                {
                    Lis = null; // Establece la lista como nula.
                    return Lis; // Retorna nulo en caso de error.
                }
            }
        }

        // Filtra comunas por ID.
        public DataTable Filtrar(int Id)
        {
            DataTable dt = new DataTable(); // Crea una nueva tabla de datos.
            List<Parametro> parametros = new List<Parametro>(); // Crea una lista de parámetros.
            try // Bloque para manejar errores.
            {
                parametros.Add(new Parametro("@Id", Id)); // Añade el parámetro ID.
                                                          // Usa una conexión SQL.
                using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
                {
                    // Crea un comando para el procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Fil_Id_LCom", conexion);
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    foreach (var parametro in parametros) // Para cada parámetro.
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor); // Añade el parámetro al comando.
                    }
                    // Usa un adaptador de datos SQL.
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt); // Llena la tabla de datos.
                    }
                }
                return dt; // Retorna la tabla de datos.
            }
            catch (Exception ex) // Captura cualquier excepción.
            {
                throw ex; // Relanza la excepción.
            }
        }

        // Ingresa una nueva comuna.
        public bool Ingresar(ELocCom obj)
        {
            bool Respuesta = true; // Asume respuesta verdadera.
                                   // Usa una conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar errores.
                {
                    // Crea un comando para el procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Ing_LCom", Con);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Añade parámetro Nombre.
                    cmd.Parameters.AddWithValue("IdPro", obj.IdPro); // Añade parámetro IdPro.
                                                                     // Añade parámetro de salida 'Resultado'.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    Con.Open(); // Abre la conexión.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                                           // Obtiene respuesta del parámetro de salida.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception) // Captura cualquier excepción.
                {
                    Respuesta = false; // Si hay error, la respuesta es falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }

        // Actualiza una comuna existente.
        public bool Actualizar(ELocCom obj)
        {
            bool Respuesta = true; // Asume respuesta verdadera.
                                   // Usa una conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar errores.
                {
                    // Crea un comando para el procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Act_LCom", Con);
                    cmd.Parameters.AddWithValue("IdCom", obj.IdCom); // Añade parámetro IdCom.
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Añade parámetro Nombre.
                    cmd.Parameters.AddWithValue("IdPro", obj.IdPro); // Añade parámetro IdPro.
                                                                     // Añade parámetro de salida 'Resultado'.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    Con.Open(); // Abre la conexión.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                                           // Obtiene respuesta del parámetro de salida.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception) // Captura cualquier excepción.
                {
                    Respuesta = false; // Si hay error, la respuesta es falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }

        // Elimina una comuna por su ID.
        public bool Eliminar(int IdCom)
        {
            bool Respuesta = true; // Asume respuesta verdadera.
                                   // Usa una conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                try // Bloque para manejar errores.
                {
                    // Crea un comando para el procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Eli_LCom", Con);
                    cmd.Parameters.AddWithValue("IdCom", IdCom); // Añade parámetro IdCom.
                                                                 // Añade parámetro de salida 'Resultado'.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure; // Define tipo de comando.
                    Con.Open(); // Abre la conexión.
                    cmd.ExecuteNonQuery(); // Ejecuta el comando.
                                           // Obtiene respuesta del parámetro de salida.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception) // Captura cualquier excepción.
                {
                    Respuesta = false; // Si hay error, la respuesta es falsa.
                }
            }
            return Respuesta; // Retorna el resultado.
        }
    }
}
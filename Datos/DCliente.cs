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
    public class DCliente
    {
        private Conexion Cn = new Conexion(); // Instancia de conexión a DB

        public static DCliente _instancia = null; // Instancia única de clase

        public static DCliente Instancia // Acceso a instancia singleton
        {
            get
            {
                if (_instancia == null) // Si no existe, la crea
                {
                    _instancia = new DCliente(); // Crea nueva instancia
                }
                return _instancia; // Devuelve la instancia
            }
        }


        public List<ECliente> Listar() // Lista todos los clientes
        {
            List<ECliente> Lis = new List<ECliente>(); // Crea lista vacía

            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                SqlCommand cmd = new SqlCommand("Bus_Cliente", oConexion); // Llama SP de búsqueda
                cmd.CommandType = CommandType.StoredProcedure; // Usa tipo procedimiento

                try // Intenta operación
                {
                    oConexion.Open(); // Abre conexión a DB
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta lectura de datos

                    while (dr.Read()) // Mientras haya filas
                    {
                        Lis.Add(new ECliente() // Agrega cliente a lista
                        {
                            IdP_Cli = Convert.ToInt32(dr["IdP_Cli"].ToString()), // Asigna valor
                            Nombre = dr["Nombre"].ToString(), // Asigna valor
                            Rut = dr["Rut"].ToString(), // Asigna valor
                            IdReg = Convert.ToInt32(dr["IdReg"].ToString()), // Asigna valor
                            Reg = new ELocReg() { Nombre = dr["NombreRegion"].ToString() }, // Asigna valor
                            IdPro = Convert.ToInt32(dr["IdPro"].ToString()), // Asigna valor
                            Pro = new ELocPro() { Nombre = dr["NombreProvincia"].ToString() }, // Asigna valor
                            IdCom = Convert.ToInt32(dr["IdCom"].ToString()), // Asigna valor
                            Com = new ELocCom() { Nombre = dr["NombreComuna"].ToString() }, // Asigna valor
                            Direccion = dr["Direccion"].ToString(), // Asigna valor
                            Tel = dr["Tel"].ToString(), // Asigna valor
                            Email = dr["Email"].ToString(), // Asigna valor
                            Giro = dr["Giro"].ToString(), // Asigna valor
                        });
                    }

                    dr.Close(); // Cierra lector de datos
                    return Lis; // Devuelve lista final
                }
                catch (Exception) // Manejo de error
                {
                    Lis = null; // Asigna lista nula
                    return Lis; // Devuelve lista nula
                }
            }
        }
        public bool Buscar(ECliente obj) // Busca cliente por RUT
        {
            bool Respuesta = true; // Valor por defecto

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                try // Intenta ejecutar operación
                {
                    SqlCommand cmd = new SqlCommand("Bus_Rut_Cliente", Con); // Llama SP de búsqueda

                    cmd.Parameters.AddWithValue("Rut", obj.Rut); // Asigna valor al parámetro
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida

                    cmd.CommandType = CommandType.StoredProcedure; // Usa tipo procedimiento
                    Con.Open(); // Abre conexión a DB
                    cmd.ExecuteNonQuery(); // Ejecuta sin devolver datos

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Lee resultado final
                }
                catch (Exception) // Manejo de error
                {
                    Respuesta = false; // Marca como fallido
                }
            }

            return Respuesta; // Devuelve resultado final
        }


        public bool Ingresar(ECliente obj) // Inserta cliente en DB
        {
            bool Respuesta = true; // Valor por defecto

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                try // Intenta operación
                {
                    SqlCommand cmd = new SqlCommand("Ing_Cliente", Con); // Llama SP de inserción

                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Rut", obj.Rut); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("IdCom", obj.IdCom); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Tel", obj.Tel); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Email", obj.Email); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Giro", obj.Giro); // Asigna valor al parámetro

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida
                    cmd.CommandType = CommandType.StoredProcedure; // Usa tipo procedimiento

                    Con.Open(); // Abre conexión a DB
                    cmd.ExecuteNonQuery(); // Ejecuta sin devolver datos

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Lee resultado final
                }
                catch (Exception) // Manejo de error
                {
                    Respuesta = false; // Marca como fallido
                }
            }

            return Respuesta; // Devuelve resultado final
        }

        public bool Actualizar(ECliente obj) // Actualiza cliente en la DB
        {
            bool Respuesta = true; // Valor por defecto

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                try // Intenta ejecutar operación
                {
                    SqlCommand cmd = new SqlCommand("Act_Cliente", Con); // Llama SP de actualización

                    cmd.Parameters.AddWithValue("IdP_Cli", obj.IdP_Cli); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Rut", obj.Rut); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("IdCom", obj.IdCom); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Tel", obj.Tel); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Email", obj.Email); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("Giro", obj.Giro); // Asigna valor al parámetro

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida

                    cmd.CommandType = CommandType.StoredProcedure; // Usa tipo procedimiento
                    Con.Open(); // Abre conexión a DB
                    cmd.ExecuteNonQuery(); // Ejecuta sin devolver datos

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Lee resultado final
                }
                catch (Exception) // Manejo de error
                {
                    Respuesta = false; // Marca como fallido
                }
            }

            return Respuesta; // Devuelve resultado final
        }


        public bool Eliminar(int Id)
        {
            // Asume respuesta verdadera inicialmente.
            bool Respuesta = true;
            // Usa una nueva conexión SQL.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                // Bloque try-catch para errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Eli_Cliente", Con);
                    // Añade parámetro de ID de cliente.
                    cmd.Parameters.AddWithValue("IdP_Cli", Id);
                    // Añade parámetro de salida 'Resultado'.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Define tipo de comando como procedimiento almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Abre la conexión a la base de datos.
                    Con.Open();
                    // Ejecuta el comando.
                    cmd.ExecuteNonQuery();
                    // Obtiene respuesta del parámetro de salida.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                // Captura cualquier excepción.
                catch (Exception)
                {
                    // Si hay error, la respuesta es falsa.
                    Respuesta = false;
                }
            }
            // Retorna el resultado de la operación.
            return Respuesta;
        }

        public int ObtenerUltimoId()
        {
            // Inicializa último ID en cero.
            int ultimoId = 0;

            // Bloque try-catch para manejar errores.
            try
            {
                // Usa una nueva conexión SQL.
                using (SqlConnection Con = new SqlConnection(Conexion.Conex))
                {
                    // Abre la conexión a la base de datos.
                    Con.Open();

                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Ult_Cliente", Con);
                    // Define tipo de comando como procedimiento almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuta el comando y obtiene el resultado.
                    object resultado = cmd.ExecuteScalar();

                    // Si el resultado no es nulo o DBNull.
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        // Convierte y asigna el último ID.
                        ultimoId = Convert.ToInt32(resultado);
                    }
                }
            }
            // Captura cualquier excepción.
            catch (Exception ex)
            {
                // Imprime el error en la consola.
                Console.WriteLine($"Error en capa de datos: {ex.Message}");
                // Opcional: relanza la excepción.
                throw;
            }

            // Retorna el último ID obtenido.
            return ultimoId;
        }

    }
}

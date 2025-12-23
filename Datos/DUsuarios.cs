// Importa la capa de acceso datos.
using Datos;
// Importa las entidades del sistema.
using Entidad;
// Importa funcionalidades básicas de .NET.
using System;
// Importa colecciones genéricas de datos.
using System.Collections.Generic;
// Importa funcionalidades de datos tabulares.
using System.Data;
// Importa cliente de base SQL Server.
using System.Data.SqlClient;
// Importa funcionalidades de criptografía segura.
using System.Security.Cryptography;
// Importa codificación de texto y caracteres.
using System.Text;

// Define el espacio de nombres.
namespace Datos
{
    // Clase de acceso datos usuarios.
    public class DUsuarios
    {
        // Crea objeto de conexión base datos.
        private Conexion Cn = new Conexion();

        // Variable estática instancia única singleton.
        public static DUsuarios _instancia = null;

        // Propiedad para obtener instancia única.
        public static DUsuarios Instancia
        {
            // Método obtener valor de instancia.
            get
            {
                // Si instancia no existe aún.
                if (_instancia == null)
                {
                    // Crea nueva instancia de clase.
                    _instancia = new DUsuarios();
                }
                // Retorna la instancia única existente.
                return _instancia;
            }
        }

        // Obtiene lista completa de usuarios.
        public List<EUsuarios> Listar()
        {
            // Crea lista vacía de usuarios.
            List<EUsuarios> Lis = new List<EUsuarios>();
            // Abre conexión con base datos.
            using (SqlConnection con = new SqlConnection(Conexion.Conex))
            {
                // Crea comando para procedimiento almacenado.
                SqlCommand cmd = new SqlCommand("Bus_Usua", con);
                // Define tipo de comando almacenado.
                cmd.CommandType = CommandType.StoredProcedure;
                // Inicia bloque de control errores.
                try
                {
                    // Abre la conexión base datos.
                    con.Open();
                    // Ejecuta comando y obtiene lector.
                    SqlDataReader dr = cmd.ExecuteReader();
                    // Recorre cada registro del lector.
                    while (dr.Read())
                    {
                        // Agrega nuevo usuario a lista.
                        Lis.Add(new EUsuarios()
                        {
                            // Asigna identificador de usuario.
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            // Asigna nombre del usuario.
                            Nombre = dr["Nombre"].ToString(),
                            // Asigna identificador de permiso.
                            IdPer = Convert.ToInt32(dr["IdPer"]),
                            // Oculta contraseña con texto genérico.
                            Pass = "Pass"
                        });
                    }
                    // Cierra el lector de datos.
                    dr.Close();
                    // Retorna lista completa de usuarios.
                    return Lis;
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Retorna lista actual en caso error.
                    return Lis;
                }
            }
        }

        // Inserta nuevo usuario en base datos.
        public bool Insertar(EUsuarios obj)
        {
            // Inicializa respuesta como falsa.
            bool respuesta = false;
            // Abre conexión con base datos.
            using (SqlConnection con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Ing_Usua", con);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Agrega parámetro nombre de usuario.
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    // Agrega parámetro contraseña de usuario.
                    cmd.Parameters.AddWithValue("Pass", obj.Pass);
                    // Agrega parámetro identificador de permiso.
                    cmd.Parameters.AddWithValue("IdPer", obj.IdPer);
                    // Abre la conexión base datos.
                    con.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();
                    // Establece respuesta como verdadera.
                    respuesta = true;
                }
                // Captura cualquier error ocurrido.
                catch (Exception ex)
                {
                    // Establece respuesta como falsa.
                    respuesta = false;
                }
            }
            // Retorna el resultado de inserción.
            return respuesta;
        }

        // Actualiza nombre y contraseña del usuario.
        public bool Actualizar(EUsuarios obj)
        {
            // Inicializa respuesta como verdadera.
            bool Respuesta = true;
            // Abre conexión con base datos.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Act_Usua", Con);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Agrega parámetro identificador de usuario.
                    cmd.Parameters.AddWithValue("@IdUsu", obj.IdUsu);
                    // Agrega parámetro nombre de usuario.
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    // Agrega parámetro contraseña de usuario.
                    cmd.Parameters.AddWithValue("@Pass", obj.Pass);
                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Abre la conexión base datos.
                    Con.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();
                    // Convierte parámetro salida a booleano.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    Respuesta = false;
                }
            }
            // Retorna el resultado de actualización.
            return Respuesta;
        }

        // Actualiza nombre contraseña y permiso usuario.
        public bool Actualizar2(EUsuarios obj)
        {
            // Inicializa respuesta como verdadera.
            bool Respuesta = true;
            // Abre conexión con base datos.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Act_Usua2", Con);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Agrega parámetro identificador de usuario.
                    cmd.Parameters.AddWithValue("@IdUsu", obj.IdUsu);
                    // Agrega parámetro nombre de usuario.
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    // Agrega parámetro contraseña o valor nulo.
                    cmd.Parameters.AddWithValue("@Pass", obj.Pass ?? (object)DBNull.Value);
                    // Agrega parámetro identificador de permiso.
                    cmd.Parameters.AddWithValue("@IdPer", obj.IdPer);
                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Abre la conexión base datos.
                    Con.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();
                    // Convierte parámetro salida a booleano.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    Respuesta = false;
                }
            }
            // Retorna el resultado de actualización.
            return Respuesta;
        }

        // Verifica credenciales de inicio sesión.
        public bool Verificar(EUsuarios obj)
        {
            // Inicializa respuesta como falsa.
            bool respuesta = false;
            // Abre conexión con base datos.
            using (SqlConnection con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("IngSis", con);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Agrega parámetro nombre de usuario.
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    // Agrega parámetro contraseña de usuario.
                    cmd.Parameters.AddWithValue("@Pass", obj.Pass);
                    // Abre la conexión base datos.
                    con.Open();
                    // Ejecuta comando y obtiene lector.
                    SqlDataReader dr = cmd.ExecuteReader();
                    // Si encuentra usuario con credenciales.
                    if (dr.Read())
                    {
                        // Carga identificador del usuario encontrado.
                        obj.IdUsu = Convert.ToInt32(dr["IdUsu"]);
                        // Carga nombre del usuario encontrado.
                        obj.Nombre = dr["Nombre"].ToString();
                        // Asigna permiso o cero si nulo.
                        obj.IdPer = dr["IdPer"] is DBNull ? 0 : Convert.ToInt32(dr["IdPer"]);

                        // Establece verificación como exitosa.
                        respuesta = true;
                    }
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece verificación como fallida.
                    respuesta = false;
                }
            }
            // Retorna resultado de la verificación.
            return respuesta;
        }

        // Elimina usuario según su identificador.
        public bool Eliminar(int Id)
        {
            // Inicializa respuesta como verdadera.
            bool Respuesta = true;
            // Abre conexión con base datos.
            using (SqlConnection Con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Eli_Usua", Con);
                    // Agrega parámetro identificador de usuario.
                    cmd.Parameters.AddWithValue("IdUsu", Id);
                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Abre la conexión base datos.
                    Con.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();
                    // Convierte parámetro salida a booleano.
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    Respuesta = false;
                }
            }
            // Retorna el resultado de eliminación.
            return Respuesta;
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

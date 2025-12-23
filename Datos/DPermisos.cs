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

// Define el espacio de nombres.
namespace Datos
{
    // Clase de acceso datos permisos.
    public class DPermisos
    {
        // Crea objeto de conexión base datos.
        private Conexion Cn = new Conexion();

        // Variable estática instancia única singleton.
        public static DPermisos _instancia = null;

        // Propiedad para obtener instancia única.
        public static DPermisos Instancia
        {
            // Método obtener valor de instancia.
            get
            {
                // Si instancia no existe aún.
                if (_instancia == null)
                {
                    // Crea nueva instancia de clase.
                    _instancia = new DPermisos();
                }
                // Retorna la instancia única existente.
                return _instancia;
            }
        }

        // Obtiene lista completa de permisos.
        public List<EPermisos> Listar()
        {
            // Crea lista vacía de permisos.
            List<EPermisos> lista = new List<EPermisos>();

            // Abre conexión con base datos.
            using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
            {
                // Crea comando para procedimiento almacenado.
                SqlCommand cmd = new SqlCommand("Bus_Per", conexion);
                // Define tipo de comando almacenado.
                cmd.CommandType = CommandType.StoredProcedure;

                // Inicia bloque de control errores.
                try
                {
                    // Abre la conexión base datos.
                    conexion.Open();
                    // Ejecuta comando y obtiene lector.
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Recorre cada registro del lector.
                    while (dr.Read())
                    {
                        // Agrega nuevo permiso a lista.
                        lista.Add(new EPermisos()
                        {
                            // Asigna identificador de permiso.
                            IdPer = Convert.ToInt32(dr["IdPer"]),
                            // Asigna permiso ingresar localidad comuna.
                            ILCom = dr["ILCom"].ToString(),
                            // Asigna permiso actualizar localidad comuna.
                            ALCom = dr["ALCom"].ToString(),
                            // Asigna permiso eliminar localidad comuna.
                            ELCom = dr["ELCom"].ToString(),
                            // Asigna permiso ingresar localidad provincia.
                            ILPro = dr["ILPro"].ToString(),
                            // Asigna permiso actualizar localidad provincia.
                            ALPro = dr["ALPro"].ToString(),
                            // Asigna permiso eliminar localidad provincia.
                            ELPro = dr["ELPro"].ToString(),
                            // Asigna permiso ingresar localidad región.
                            ILReg = dr["ILReg"].ToString(),
                            // Asigna permiso actualizar localidad región.
                            ALReg = dr["ALReg"].ToString(),
                            // Asigna permiso eliminar localidad región.
                            ELReg = dr["ELReg"].ToString(),
                            // Asigna permiso ingresar cliente.
                            ICliente = dr["ICliente"].ToString(),
                            // Asigna permiso actualizar cliente.
                            ACliente = dr["ACliente"].ToString(),
                            // Asigna permiso eliminar cliente.
                            ECliente = dr["ECliente"].ToString(),
                            // Asigna permiso ingresar productos.
                            IProductos = dr["IProductos"].ToString(),
                            // Asigna permiso actualizar productos.
                            AProductos = dr["AProductos"].ToString(),
                            // Asigna permiso eliminar productos.
                            EProductos = dr["EProductos"].ToString(),
                            // Asigna permiso ingresar proveedor.
                            IProv = dr["IProv"].ToString(),
                            // Asigna permiso actualizar proveedor.
                            AProv = dr["AProv"].ToString(),
                            // Asigna permiso eliminar proveedor.
                            EProv = dr["EProv"].ToString(),
                            // Asigna permiso ingresar usuario.
                            IUsu = dr["IUsu"].ToString(),
                            // Asigna permiso actualizar usuario.
                            AUsu = dr["AUsu"].ToString(),
                            // Asigna permiso eliminar usuario.
                            EUsu = dr["EUsu"].ToString()
                        });
                    }

                    // Cierra el lector de datos.
                    dr.Close();
                    // Retorna lista completa de permisos.
                    return lista;
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Retorna lista vacía por error.
                    return new List<EPermisos>();
                }
            }
        }

        // Busca permiso específico por identificador.
        public bool Buscar(EPermisos obj)
        {
            // Inicializa respuesta como verdadera.
            bool respuesta = true;

            // Abre conexión con base datos.
            using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Bus_Per", conexion);
                    // Agrega parámetro identificador de permiso.
                    cmd.Parameters.AddWithValue("IdPer", obj.IdPer);
                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abre la conexión base datos.
                    conexion.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();

                    // Convierte parámetro salida a booleano.
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    respuesta = false;
                }
            }

            // Retorna el resultado de búsqueda.
            return respuesta;
        }

        // Inserta nuevos permisos en base datos.
        public bool Ingresar(EPermisos obj)
        {
            // Inicializa respuesta como verdadera.
            bool respuesta = true;

            // Abre conexión con base datos.
            using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Ing_Per", conexion);

                    // Agrega parámetro ingresar localidad comuna.
                    cmd.Parameters.AddWithValue("ILCom", obj.ILCom);
                    // Agrega parámetro actualizar localidad comuna.
                    cmd.Parameters.AddWithValue("ALCom", obj.ALCom);
                    // Agrega parámetro eliminar localidad comuna.
                    cmd.Parameters.AddWithValue("ELCom", obj.ELCom);
                    // Agrega parámetro ingresar localidad provincia.
                    cmd.Parameters.AddWithValue("ILPro", obj.ILPro);
                    // Agrega parámetro actualizar localidad provincia.
                    cmd.Parameters.AddWithValue("ALPro", obj.ALPro);
                    // Agrega parámetro eliminar localidad provincia.
                    cmd.Parameters.AddWithValue("ELPro", obj.ELPro);
                    // Agrega parámetro ingresar localidad región.
                    cmd.Parameters.AddWithValue("ILReg", obj.ILReg);
                    // Agrega parámetro actualizar localidad región.
                    cmd.Parameters.AddWithValue("ALReg", obj.ALReg);
                    // Agrega parámetro eliminar localidad región.
                    cmd.Parameters.AddWithValue("ELReg", obj.ELReg);
                    // Agrega parámetro ingresar cliente.
                    cmd.Parameters.AddWithValue("ICliente", obj.ICliente);
                    // Agrega parámetro actualizar cliente.
                    cmd.Parameters.AddWithValue("ACliente", obj.ACliente);
                    // Agrega parámetro eliminar cliente.
                    cmd.Parameters.AddWithValue("ECliente", obj.ECliente);
                    // Agrega parámetro ingresar productos.
                    cmd.Parameters.AddWithValue("IProductos", obj.IProductos);
                    // Agrega parámetro actualizar productos.
                    cmd.Parameters.AddWithValue("AProductos", obj.AProductos);
                    // Agrega parámetro eliminar productos.
                    cmd.Parameters.AddWithValue("EProductos", obj.EProductos);
                    // Agrega parámetro ingresar proveedor.
                    cmd.Parameters.AddWithValue("IProv", obj.IProv);
                    // Agrega parámetro actualizar proveedor.
                    cmd.Parameters.AddWithValue("AProv", obj.AProv);
                    // Agrega parámetro eliminar proveedor.
                    cmd.Parameters.AddWithValue("EProv", obj.EProv);
                    // Agrega parámetro ingresar usuario.
                    cmd.Parameters.AddWithValue("IUsu", obj.IUsu);
                    // Agrega parámetro actualizar usuario.
                    cmd.Parameters.AddWithValue("AUsu", obj.AUsu);
                    // Agrega parámetro eliminar usuario.
                    cmd.Parameters.AddWithValue("EUsu", obj.EUsu);

                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abre la conexión base datos.
                    conexion.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();

                    // Convierte parámetro salida a booleano.
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    respuesta = false;
                }
            }

            // Retorna el resultado de inserción.
            return respuesta;
        }

        // Actualiza permisos existentes en base datos.
        public bool Actualizar(EPermisos obj)
        {
            // Inicializa respuesta como verdadera.
            bool respuesta = true;
            // Abre conexión con base datos.
            using (SqlConnection con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Act_Per", con);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Agrega parámetro identificador de permiso.
                    cmd.Parameters.AddWithValue("@IdPer", obj.IdPer);
                    // Agrega parámetro ingresar localidad comuna.
                    cmd.Parameters.AddWithValue("@ILCom", obj.ILCom);
                    // Agrega parámetro actualizar localidad comuna.
                    cmd.Parameters.AddWithValue("@ALCom", obj.ALCom);
                    // Agrega parámetro eliminar localidad comuna.
                    cmd.Parameters.AddWithValue("@ELCom", obj.ELCom);
                    // Agrega parámetro ingresar localidad provincia.
                    cmd.Parameters.AddWithValue("@ILPro", obj.ILPro);
                    // Agrega parámetro actualizar localidad provincia.
                    cmd.Parameters.AddWithValue("@ALPro", obj.ALPro);
                    // Agrega parámetro eliminar localidad provincia.
                    cmd.Parameters.AddWithValue("@ELPro", obj.ELPro);
                    // Agrega parámetro ingresar localidad región.
                    cmd.Parameters.AddWithValue("@ILReg", obj.ILReg);
                    // Agrega parámetro actualizar localidad región.
                    cmd.Parameters.AddWithValue("@ALReg", obj.ALReg);
                    // Agrega parámetro eliminar localidad región.
                    cmd.Parameters.AddWithValue("@ELReg", obj.ELReg);
                    // Agrega parámetro ingresar cliente.
                    cmd.Parameters.AddWithValue("@ICliente", obj.ICliente);
                    // Agrega parámetro actualizar cliente.
                    cmd.Parameters.AddWithValue("@ACliente", obj.ACliente);
                    // Agrega parámetro eliminar cliente.
                    cmd.Parameters.AddWithValue("@ECliente", obj.ECliente);
                    // Agrega parámetro ingresar productos.
                    cmd.Parameters.AddWithValue("@IProductos", obj.IProductos);
                    // Agrega parámetro actualizar productos.
                    cmd.Parameters.AddWithValue("@AProductos", obj.AProductos);
                    // Agrega parámetro eliminar productos.
                    cmd.Parameters.AddWithValue("@EProductos", obj.EProductos);
                    // Agrega parámetro ingresar proveedor.
                    cmd.Parameters.AddWithValue("@IProv", obj.IProv);
                    // Agrega parámetro actualizar proveedor.
                    cmd.Parameters.AddWithValue("@AProv", obj.AProv);
                    // Agrega parámetro eliminar proveedor.
                    cmd.Parameters.AddWithValue("@EProv", obj.EProv);
                    // Agrega parámetro ingresar usuario.
                    cmd.Parameters.AddWithValue("@IUsu", obj.IUsu);
                    // Agrega parámetro actualizar usuario.
                    cmd.Parameters.AddWithValue("@AUsu", obj.AUsu);
                    // Agrega parámetro eliminar usuario.
                    cmd.Parameters.AddWithValue("@EUsu", obj.EUsu);
                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Abre la conexión base datos.
                    con.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();
                    // Convierte parámetro salida a booleano.
                    respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    respuesta = false;
                }
            }
            // Retorna el resultado de actualización.
            return respuesta;
        }

        // Elimina permisos según su identificador.
        public bool Eliminar(int id)
        {
            // Inicializa respuesta como verdadera.
            bool respuesta = true;

            // Abre conexión con base datos.
            using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Eli_Per", conexion);
                    // Agrega parámetro identificador de permiso.
                    cmd.Parameters.AddWithValue("IdPer", id);
                    // Agrega parámetro de salida resultado.
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abre la conexión base datos.
                    conexion.Open();
                    // Ejecuta el comando sin retornar datos.
                    cmd.ExecuteNonQuery();

                    // Convierte parámetro salida a booleano.
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece respuesta como falsa.
                    respuesta = false;
                }
            }

            // Retorna el resultado de eliminación.
            return respuesta;
        }

        // Obtiene último identificador generado.
        public int ObtenerUltimoId()
        {
            // Inicializa variable identificador en cero.
            int ultimoId = 0;

            // Inicia bloque de control errores.
            try
            {
                // Abre conexión con base datos.
                using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
                {
                    // Abre la conexión base datos.
                    conexion.Open();
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Ult_Per", conexion);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuta comando y obtiene resultado.
                    object resultado = cmd.ExecuteScalar();

                    // Si resultado no es nulo.
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        // Convierte resultado a número entero.
                        ultimoId = Convert.ToInt32(resultado);
                    }
                }
            }
            // Captura cualquier error ocurrido.
            catch (Exception ex)
            {
                // Muestra mensaje de error en consola.
                Console.WriteLine($"Error en capa de datos: {ex.Message}");
                // Lanza excepción para nivel superior.
                throw;
            }

            // Retorna el último identificador obtenido.
            return ultimoId;
        }

        // Obtiene permisos de usuario específico.
        public EPermisos ObtenerPorUsuario(int idUsuario)
        {
            // Inicializa variable permisos en nulo.
            EPermisos permisos = null;

            // Abre conexión con base datos.
            using (SqlConnection conexion = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando para procedimiento almacenado.
                    SqlCommand cmd = new SqlCommand("Bus_PerPorUsuario", conexion);
                    // Agrega parámetro identificador de usuario.
                    cmd.Parameters.AddWithValue("IdUsu", idUsuario);
                    // Define tipo de comando almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abre la conexión base datos.
                    conexion.Open();
                    // Ejecuta comando y obtiene lector.
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Si encuentra registro de permisos.
                    if (dr.Read())
                    {
                        // Crea nuevo objeto de permisos.
                        permisos = new EPermisos()
                        {
                            // Asigna identificador de permiso.
                            IdPer = Convert.ToInt32(dr["IdPer"]),
                            // Asigna permiso ingresar localidad comuna.
                            ILCom = dr["ILCom"].ToString(),
                            // Asigna permiso actualizar localidad comuna.
                            ALCom = dr["ALCom"].ToString(),
                            // Asigna permiso eliminar localidad comuna.
                            ELCom = dr["ELCom"].ToString(),
                            // Asigna permiso ingresar localidad provincia.
                            ILPro = dr["ILPro"].ToString(),
                            // Asigna permiso actualizar localidad provincia.
                            ALPro = dr["ALPro"].ToString(),
                            // Asigna permiso eliminar localidad provincia.
                            ELPro = dr["ELPro"].ToString(),
                            // Asigna permiso ingresar localidad región.
                            ILReg = dr["ILReg"].ToString(),
                            // Asigna permiso actualizar localidad región.
                            ALReg = dr["ALReg"].ToString(),
                            // Asigna permiso eliminar localidad región.
                            ELReg = dr["ELReg"].ToString(),
                            // Asigna permiso ingresar cliente.
                            ICliente = dr["ICliente"].ToString(),
                            // Asigna permiso actualizar cliente.
                            ACliente = dr["ACliente"].ToString(),
                            // Asigna permiso eliminar cliente.
                            ECliente = dr["ECliente"].ToString(),
                            // Asigna permiso ingresar productos.
                            IProductos = dr["IProductos"].ToString(),
                            // Asigna permiso actualizar productos.
                            AProductos = dr["AProductos"].ToString(),
                            // Asigna permiso eliminar productos.
                            EProductos = dr["EProductos"].ToString(),
                            // Asigna permiso ingresar proveedor.
                            IProv = dr["IProv"].ToString(),
                            // Asigna permiso actualizar proveedor.
                            AProv = dr["AProv"].ToString(),
                            // Asigna permiso eliminar proveedor.
                            EProv = dr["EProv"].ToString(),
                            // Asigna permiso ingresar usuario.
                            IUsu = dr["IUsu"].ToString(),
                            // Asigna permiso actualizar usuario.
                            AUsu = dr["AUsu"].ToString(),
                            // Asigna permiso eliminar usuario.
                            EUsu = dr["EUsu"].ToString()
                        };
                    }

                    // Cierra el lector de datos.
                    dr.Close();
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece permisos como nulo.
                    permisos = null;
                }
            }

            // Retorna permisos obtenidos o nulo.
            return permisos;
        }

        // Obtiene permisos por su identificador.
        public static EPermisos ObtenerPorId(int idPer)
        {
            // Crea nuevo objeto de permisos.
            EPermisos permisos = new EPermisos();
            // Abre conexión con base datos.
            using (SqlConnection con = new SqlConnection(Conexion.Conex))
            {
                // Inicia bloque de control errores.
                try
                {
                    // Crea comando con consulta SQL directa.
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Permisos WHERE IdPer = @IdPer", con);
                    // Agrega parámetro identificador de permiso.
                    cmd.Parameters.AddWithValue("@IdPer", idPer);
                    // Abre la conexión base datos.
                    con.Open();
                    // Ejecuta comando y obtiene lector.
                    SqlDataReader dr = cmd.ExecuteReader();
                    // Si encuentra registro de permisos.
                    if (dr.Read())
                    {
                        // Asigna identificador de permiso.
                        permisos.IdPer = Convert.ToInt32(dr["IdPer"]);
                        // Asigna permiso ingresar localidad comuna.
                        permisos.ILCom = dr["ILCom"].ToString();
                        // Asigna permiso actualizar localidad comuna.
                        permisos.ALCom = dr["ALCom"].ToString();
                        // Asigna permiso eliminar localidad comuna.
                        permisos.ELCom = dr["ELCom"].ToString();
                        // Asigna permiso ingresar localidad provincia.
                        permisos.ILPro = dr["ILPro"].ToString();
                        // Asigna permiso actualizar localidad provincia.
                        permisos.ALPro = dr["ALPro"].ToString();
                        // Asigna permiso eliminar localidad provincia.
                        permisos.ELPro = dr["ELPro"].ToString();
                        // Asigna permiso ingresar localidad región.
                        permisos.ILReg = dr["ILReg"].ToString();
                        // Asigna permiso actualizar localidad región.
                        permisos.ALReg = dr["ALReg"].ToString();
                        // Asigna permiso eliminar localidad región.
                        permisos.ELReg = dr["ELReg"].ToString();
                        // Asigna permiso ingresar cliente.
                        permisos.ICliente = dr["ICliente"].ToString();
                        // Asigna permiso actualizar cliente.
                        permisos.ACliente = dr["ACliente"].ToString();
                        // Asigna permiso eliminar cliente.
                        permisos.ECliente = dr["ECliente"].ToString();
                        // Asigna permiso ingresar productos.
                        permisos.IProductos = dr["IProductos"].ToString();
                        // Asigna permiso actualizar productos.
                        permisos.AProductos = dr["AProductos"].ToString();
                        // Asigna permiso eliminar productos.
                        permisos.EProductos = dr["EProductos"].ToString();
                        // Asigna permiso ingresar proveedor.
                        permisos.IProv = dr["IProv"].ToString();
                        // Asigna permiso actualizar proveedor.
                        permisos.AProv = dr["AProv"].ToString();
                        // Asigna permiso eliminar proveedor.
                        permisos.EProv = dr["EProv"].ToString();
                        // Asigna permiso ingresar usuario.
                        permisos.IUsu = dr["IUsu"].ToString();
                        // Asigna permiso actualizar usuario.
                        permisos.AUsu = dr["AUsu"].ToString();
                        // Asigna permiso eliminar usuario.
                        permisos.EUsu = dr["EUsu"].ToString();
                    }
                }
                // Captura cualquier error ocurrido.
                catch (Exception)
                {
                    // Establece permisos como nulo.
                    permisos = null;
                }
            }
            // Retorna permisos obtenidos o nulo.
            return permisos;
        }
    }
    // Cierra la clase.
}
// Cierra el namespace.

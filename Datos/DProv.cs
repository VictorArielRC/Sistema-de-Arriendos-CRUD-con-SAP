// Importa dependencias.
using System;
// Importa dependencias.
using System.Collections.Generic;
// Importa dependencias.
using System.Data;
// Importa dependencias.
using System.Data.SqlClient;
// Importa dependencias.
using Entidad;


namespace Datos
{
    public class DProv
    {
        private Conexion Cn = new Conexion(); // Instancia privada de conexión

        public static DProv _instancia = null; // Instancia única de la clase

        public static DProv Instancia // Propiedad estática para obtener instancia
        {
            get // Obtener la instancia de DProv
            {
                if (_instancia == null) // Si la instancia no existe
                {
                    _instancia = new DProv(); // Crear nueva instancia DProv
                }
                return _instancia; // Devolver la instancia existente
            }
        }

        public List<EProv> Listar() // Lista todos los proveedores
        {
            List<EProv> Lis = new List<EProv>(); // Inicializa lista de proveedores
            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                SqlCommand cmd = new SqlCommand("Bus_Prov", oConexion); // Comando SQL para buscar
                cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                try // Iniciar bloque de manejo de errores
                {
                    oConexion.Open(); // Abre la conexión a la base
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta comando y obtiene datos
                    while (dr.Read()) // Lee cada fila de resultados
                    {
                        Lis.Add(new EProv() // Añade nuevo proveedor a lista
                        {
                            IdProv = Convert.ToInt32(dr["IdProv"].ToString()), // Obtiene Id de proveedor
                            Nombre = dr["Nombre"].ToString(), // Obtiene nombre de proveedor
                            Rut = dr["Rut"].ToString(), // Obtiene RUT de proveedor
                            IdReg = Convert.ToInt32(dr["IdReg"].ToString()), // Obtiene Id de región
                            Reg = new ELocReg() { Nombre = dr["NombreRegion"].ToString() }, // Obtiene nombre de región
                            IdPro = Convert.ToInt32(dr["IdPro"].ToString()), // Obtiene Id de provincia
                            Pro = new ELocPro() { Nombre = dr["NombreProvincia"].ToString() }, // Obtiene nombre de provincia
                            IdCom = Convert.ToInt32(dr["IdCom"].ToString()), // Obtiene Id de comuna
                            Com = new ELocCom() { Nombre = dr["NombreComuna"].ToString() }, // Obtiene nombre de comuna
                            Direccion = dr["Direccion"].ToString(), // Obtiene dirección de proveedor
                            Tel = dr["Tel"].ToString(), // Obtiene teléfono de proveedor
                            Email = dr["Email"].ToString(), // Obtiene email de proveedor
                            Giro = dr["Giro"].ToString(), // Obtiene giro de proveedor
                            Descr = dr["Descr"].ToString(), // Obtiene descripción de proveedor
                        });
                    }
                    dr.Close(); // Cierra el lector de datos
                    return Lis; // Retorna la lista de proveedores
                }
                catch (Exception) // Captura cualquier excepción
                {
                    Lis = null; // Establece lista a nula
                    return Lis; // Retorna lista nula en error
                }
            }
        }

        public bool Ingresar(EProv obj) // Inserta nuevo proveedor en DB
        {
            bool Respuesta = true; // Inicializa respuesta como verdadera
            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("Ing_Prov", Con); // Comando SQL para insertar
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Agrega parámetro: nombre
                    cmd.Parameters.AddWithValue("Rut", obj.Rut); // Agrega parámetro: RUT
                    cmd.Parameters.AddWithValue("IdCom", obj.IdCom); // Agrega parámetro: Id Comuna
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion); // Agrega parámetro: dirección
                    cmd.Parameters.AddWithValue("Tel", obj.Tel); // Agrega parámetro: teléfono
                    cmd.Parameters.AddWithValue("Email", obj.Email); // Agrega parámetro: email
                    cmd.Parameters.AddWithValue("Giro", obj.Giro); // Agrega parámetro: giro
                    cmd.Parameters.AddWithValue("Descr", obj.Descr); // Agrega parámetro: descripción
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida: resultado booleano
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                    Con.Open(); // Abre la conexión a la base
                    cmd.ExecuteNonQuery(); // Ejecuta comando, sin consulta
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtiene resultado de salida
                }
                catch (Exception) // Captura cualquier excepción
                {
                    Respuesta = false; // Establece respuesta como falsa
                }
            }
            return Respuesta; // Retorna si la inserción fue exitosa
        }

        public bool Actualizar(EProv obj) // Actualiza proveedor en la DB
        {
            bool Respuesta = true; // Inicializa respuesta como verdadera
            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("Act_Prov", Con); // Comando SQL para actualizar
                    cmd.Parameters.AddWithValue("IdProv", obj.IdProv); // Agrega parámetro: Id Proveedor
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Agrega parámetro: nombre
                    cmd.Parameters.AddWithValue("Rut", obj.Rut); // Agrega parámetro: RUT
                    cmd.Parameters.AddWithValue("IdCom", obj.IdCom); // Agrega parámetro: Id Comuna
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion); // Agrega parámetro: dirección
                    cmd.Parameters.AddWithValue("Tel", obj.Tel); // Agrega parámetro: teléfono
                    cmd.Parameters.AddWithValue("Email", obj.Email); // Agrega parámetro: email
                    cmd.Parameters.AddWithValue("Giro", obj.Giro); // Agrega parámetro: giro
                    cmd.Parameters.AddWithValue("Descr", obj.Descr); // Agrega parámetro: descripción
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida: resultado booleano
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                    Con.Open(); // Abre la conexión a la base
                    cmd.ExecuteNonQuery(); // Ejecuta comando, sin consulta
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtiene resultado de salida
                }
                catch (Exception) // Captura cualquier excepción
                {
                    Respuesta = false; // Establece respuesta como falsa
                }
            }
            return Respuesta; // Retorna si actualización fue exitosa
        }

        public bool Eliminar(int Id) // Elimina proveedor de la DB
        {
            bool Respuesta = true; // Inicializa respuesta como verdadera
            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("Eli_Prov", Con); // Comando SQL para eliminar
                    cmd.Parameters.AddWithValue("IdProv", Id); // Agrega parámetro: Id Proveedor
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // Parámetro de salida: resultado booleano
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                    Con.Open(); // Abre la conexión a la base
                    cmd.ExecuteNonQuery(); // Ejecuta comando, sin consulta
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtiene resultado de salida
                }
                catch (Exception) // Captura cualquier excepción
                {
                    Respuesta = false; // Establece respuesta como falsa
                }
            }
            return Respuesta; // Retorna si la eliminación fue exitosa
        }
    }
}

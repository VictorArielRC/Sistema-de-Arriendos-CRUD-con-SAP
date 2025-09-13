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
// Accede a códigos de otra librería
using System.Linq;
// Accede a códigos de otra librería
using System.Text;
// Accede a códigos de otra librería
using System.Threading.Tasks;


// Gestión datos
namespace Datos
{
    public class DArrVUn
    {
        private Conexion Cn = new Conexion(); // Instancia de conexión a DB

        public static DArrVUn _instancia = null; // Instancia única de clase

        public static DArrVUn Instancia // Acceso a instancia singleton
        {
            get
            {
                if (_instancia == null) // Si no existe, la crea
                {
                    _instancia = new DArrVUn(); // Crea nueva instancia
                }
                return _instancia; // Devuelve la instancia
            }
        }
        public List<EArrVUn> Listar() // Lista datos desde DB
        {
            List<EArrVUn> Lis = new List<EArrVUn>(); // Crea nueva lista

            using (SqlConnection oConexion = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                SqlCommand cmd = new SqlCommand("Bus_Arr_Pro", oConexion); // Define SP a ejecutar
                cmd.CommandType = CommandType.StoredProcedure; // Tipo comando SP

                try
                    //abre bloque de codigo try
                {
                    oConexion.Open(); // Abre conexión
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta y lee datos

                    while (dr.Read()) // Mientras haya datos
                    {
                        Lis.Add(new EArrVUn() // Agrega nuevo objeto a lista
                        {
                            IdAVUn = Convert.ToInt32(dr["IdAVUn"].ToString()), // Asigna valor
                            VUn1 = dr["VUn1"].ToString(), // Asigna valor
                            VUn2 = dr["VUn2"].ToString(), // Asigna valor
                            VUn3 = dr["VUn3"].ToString(), // Asigna valor
                            VUn4 = dr["VUn4"].ToString(), // Asigna valor
                            VUn5 = dr["VUn5"].ToString(), // Asigna valor
                            VUn6 = dr["VUn6"].ToString(), // Asigna valor
                            VUn7 = dr["VUn7"].ToString(), // Asigna valor
                            VUn8 = dr["VUn8"].ToString(), // Asigna valor
                            VUn9 = dr["VUn9"].ToString(), // Asigna valor
                            VUn10 = dr["VUn10"].ToString(), // Asigna valor
                        });
                    }
                    dr.Close(); // Cierra lector de datos
                    return Lis; // Devuelve lista final
                }
                catch (Exception) // Si ocurre un error
                {
                    Lis = null; // Asigna null a la lista
                    return Lis; // Devuelve lista vacía
                }
            }
        }
        public bool Ingresar(EArrVUn obj)
        {
            bool Respuesta = true; // Valor por defecto

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                try // Intenta ejecutar operación

                {
                    SqlCommand cmd = new SqlCommand("Ing_Arr_VUn", Con); // Llama SP de inserción
                    cmd.CommandType = CommandType.StoredProcedure; // Usa tipo procedimiento

                    cmd.Parameters.AddWithValue("VUn1", obj.VUn1); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn2", obj.VUn2); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn3", obj.VUn3); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn4", obj.VUn4); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn5", obj.VUn5); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn6", obj.VUn6); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn7", obj.VUn7); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn8", obj.VUn8); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn9", obj.VUn9); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn10", obj.VUn10); // Asigna valor al parámetro

                    Con.Open(); // Abre conexión a DB
                    cmd.ExecuteNonQuery(); // Ejecuta sin devolver datos
                    Respuesta = true; // Marca operación exitosa
                }
                catch (Exception) // Manejo de error
                {
                    Respuesta = false; // Marca como fallido
                }
            }
            return Respuesta; // Devuelve resultado final

        }
        public bool Actualizar(EArrVUn obj)
        {
            bool Respuesta = true; // Valor por defecto

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL

            {
                try
                    //abre bloque de codigo try
                {
                    SqlCommand cmd = new SqlCommand("Act_Arr_VUn", Con); // Llama SP de actualización

                    cmd.Parameters.AddWithValue("IdAVUn", obj.IdAVUn); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn1", obj.VUn1); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn2", obj.VUn2); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn3", obj.VUn3); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn4", obj.VUn4); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn5", obj.VUn5); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn6", obj.VUn6); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn7", obj.VUn7); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn8", obj.VUn8); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn9", obj.VUn9); // Asigna valor al parámetro
                    cmd.Parameters.AddWithValue("VUn10", obj.VUn10); // Asigna valor al parámetro
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
            return Respuesta; // Devuelve respuesta final

        }
        public bool Eliminar(int Id)
        {
            bool Respuesta = true; // Valor por defecto

            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Eli_Arr_VUn", Con); // Llama SP de eliminación

                    cmd.Parameters.AddWithValue("IdAVUn", Id); // Asigna valor al parámetro
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

            return Respuesta; // Devuelve respuesta final

        }
        public int ObtenerUltimoId()
        {
            int ultimoId = 0; // Inicializa valor por defecto

            try
            {
                using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Abre conexión SQL
                {
                    Con.Open(); // Abre conexión a DB
                    SqlCommand cmd = new SqlCommand("Ult_Arr_VUn", Con); // Llama SP de último ID
                    cmd.CommandType = CommandType.StoredProcedure; // Usa tipo procedimiento

                    object resultado = cmd.ExecuteScalar(); // Ejecuta y obtiene único valor

                    if (resultado != null && resultado != DBNull.Value) // Verifica si hay valor
                    {
                        ultimoId = Convert.ToInt32(resultado); // Asigna valor convertido
                    }
                }
            }
            catch (Exception ex) // Manejo de error
            {
                throw; // Relanza excepción
            }

            return ultimoId; // Devuelve último ID

        }
    }
}
// Accede a códigos de otra librería
using Datos;
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
using System.Security.Cryptography;
// Accede a códigos de otra librería
using System.Text;


namespace Datos
{
    public class DUsua
    {
        private Conexion Cn = new Conexion(); // Instancia privada de conexión

        public static DUsua _instancia = null; // Instancia única de la clase

        public static DUsua Instancia // Propiedad estática para obtener instancia
        {
            get // Obtener la instancia de DUsua
            {
                if (_instancia == null) // Si la instancia no existe
                {
                    _instancia = new DUsua(); // Crear nueva instancia DUsua
                }
                return _instancia; // Devolver la instancia existente
            }
        }

        public List<EUsua> Listar() // Lista todos los usuarios
        {
            List<EUsua> Lis = new List<EUsua>(); // Inicializa lista de usuarios
            using (SqlConnection con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                SqlCommand cmd = new SqlCommand("Bus_Usua", con); // Comando SQL para buscar
                cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                try // Iniciar bloque de manejo de errores
                {
                    con.Open(); // Abre la conexión a la base
                    SqlDataReader dr = cmd.ExecuteReader(); // Ejecuta comando y obtiene datos
                    while (dr.Read()) // Lee cada fila de resultados
                    {
                        Lis.Add(new EUsua() // Añade nuevo usuario a lista
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]), // Obtiene Id de usuario
                            Nombre = dr["Nombre"].ToString(), // Obtiene nombre de usuario
                            Pass = dr["Pass"].ToString(), // Obtiene contraseña de usuario
                        });
                    }
                    dr.Close(); // Cierra el lector de datos
                    return Lis; // Retorna la lista de usuarios
                }
                catch (Exception) // Captura cualquier excepción
                {
                    Lis = null; // Establece lista a nula
                    return Lis; // Retorna lista nula en error
                }
            }
        }
        public bool Insertar(EUsua obj) // Inserta nuevo usuario en DB
        {
            bool respuesta = false; // Inicializa respuesta como falsa
            using (SqlConnection con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("Ing_Usua", con); // Comando SQL para insertar
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Agrega parámetro: nombre
                    cmd.Parameters.AddWithValue("Pass", obj.Pass); // Agrega parámetro: contraseña

                    con.Open(); // Abre la conexión a la base
                    cmd.ExecuteNonQuery(); // Ejecuta comando, sin consulta
                    respuesta = true; // Establece respuesta como verdadera
                }
                catch (Exception ex) // Captura cualquier excepción
                {
                    respuesta = false; // Establece respuesta como falsa
                }
            }
            return respuesta; // Retorna si la inserción fue exitosa
        }
        public bool Actualizar(EUsua obj) // Actualiza usuario en la DB
        {
            bool Respuesta = true; // Inicializa respuesta como verdadera
            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("Act_Usua", Con); // Comando SQL para actualizar
                    cmd.Parameters.AddWithValue("IdUsu", obj.IdUsu); // Agrega parámetro: Id Usuario
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre); // Agrega parámetro: nombre
                    cmd.Parameters.AddWithValue("Pass", obj.Pass); // Agrega parámetro: contraseña
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
        public bool Actualizar2(EUsua obj) // Actualiza contraseña de usuario
        {
            bool Respuesta = true; // Inicializa respuesta como verdadera
            using (SqlConnection Con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("Act_Usua2", Con); // Comando SQL para actualizar
                    cmd.Parameters.AddWithValue("IdUsu", obj.IdUsu); // Agrega parámetro: Id Usuario
                    cmd.Parameters.AddWithValue("Pass", obj.Pass); // Agrega parámetro: contraseña
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
        public bool Verificar(EUsua obj) // Verifica credenciales de usuario
        {
            bool respuesta = false; // Inicializa respuesta como falsa
            using (SqlConnection con = new SqlConnection(Conexion.Conex)) // Establece conexión a base datos
            {
                try // Iniciar bloque de manejo de errores
                {
                    SqlCommand cmd = new SqlCommand("IngSis", con); // Comando SQL para verificar
                    cmd.CommandType = CommandType.StoredProcedure; // Tipo de comando: procedimiento almacenado
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre); // Agrega parámetro: nombre de usuario
                    cmd.Parameters.AddWithValue("@Pass", obj.Pass); // Agrega parámetro: contraseña

                    con.Open(); // Abre la conexión a la base
                    SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta comando y obtiene datos
                    if (reader.Read()) // Si hay datos leídos
                    {
                        respuesta = reader.GetInt32(0) == 1; // Verifica si el resultado es 1
                    }
                }
                catch (Exception ex) // Captura cualquier excepción
                {
                    // Manejar la excepción (log, re-throw, etc.)
                    respuesta = false; // Establece respuesta como falsa
                }
            }
            return respuesta; // Retorna si la verificación fue exitosa
        }

    }
}

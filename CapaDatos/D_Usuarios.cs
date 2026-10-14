using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Usuarios
    {
        // Cadena de conexión a la base de datos
        private static readonly string conn_string = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        // Método para insertar usuario
        public void InsertUsuario(E_Usuarios e_Usuario)
        {
            using (SqlConnection conexion = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("SP_INSERTARUSUARIO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE", e_Usuario.Nombre);
                    cmd.Parameters.AddWithValue("@APELLIDO", e_Usuario.Apellido);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", e_Usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@TIPOUSUARIO", e_Usuario.TipoUsuario);
                    cmd.Parameters.AddWithValue("@USERPASSWORD", e_Usuario.Password);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar usuario
        public void UpdateUsuario(E_Usuarios e_Usuario)
        {
            using (SqlConnection conexion = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ACTUALIZARUSUARIO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUSUARIO", e_Usuario.CodUsuario);
                    cmd.Parameters.AddWithValue("@NOMBRE", e_Usuario.Nombre);
                    cmd.Parameters.AddWithValue("@APELLIDO", e_Usuario.Apellido);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", e_Usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@TIPOUSUARIO", e_Usuario.TipoUsuario);
                    cmd.Parameters.AddWithValue("@USERPASSWORD", e_Usuario.Password);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar usuario
        public void DeleteUsuario(string codUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUSUARIO", codUsuario);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Listar usuarios por nombre
        public List<E_Usuarios> ListarUsPorNombre(string buscar)
        {
            List<E_Usuarios> listar = new List<E_Usuarios>();

            using (SqlConnection conexion = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("SP_BUSCARUSUARIOPPORNOMBRE", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BUSCAR", buscar);

                    conexion.Open();
                    using (SqlDataReader leerFilas = cmd.ExecuteReader())
                    {
                        while (leerFilas.Read())
                        {
                            listar.Add(new E_Usuarios
                            {
                                IdUsuario = leerFilas.GetInt32(0),
                                CodUsuario = leerFilas.GetString(1),
                                Nombre = leerFilas.GetString(2),
                                Apellido = leerFilas.GetString(3),
                                FechaNacimiento = leerFilas.GetDateTime(4),
                                TipoUsuario = leerFilas.GetString(5),
                                Password = leerFilas.GetString(6),
                            });
                        }
                    }
                }
            }

            return listar;
        }

        // Listar usuarios por código
        public List<E_Usuarios> ListarUsPorCodigo(string buscar)
        {
            List<E_Usuarios> listar = new List<E_Usuarios>();

            using (SqlConnection conexion = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand("SP_BUSCARUSUARIO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUSUARIO", buscar);

                    conexion.Open();
                    using (SqlDataReader leerFilas = cmd.ExecuteReader())
                    {
                        while (leerFilas.Read())
                        {
                            listar.Add(new E_Usuarios
                            {
                                IdUsuario = leerFilas.GetInt32(0),
                                CodUsuario = leerFilas.GetString(1),
                                Nombre = leerFilas.GetString(2),
                                Apellido = leerFilas.GetString(3),
                                FechaNacimiento = leerFilas.GetDateTime(4),
                                TipoUsuario = leerFilas.GetString(5),
                                Password = leerFilas.GetString(6),
                            });
                        }
                    }
                }
            }

            return listar;
        }

        // Autenticar usuario
        public E_Usuarios UsuarioLogin(string codigoUsuario, string userPassword)
        {
            E_Usuarios e_Usuarios = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_LOGIN", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CODUSUARIO", codigoUsuario);
                        cmd.Parameters.AddWithValue("@USERPASSWORD", userPassword);

                        conexion.Open();
                        using (SqlDataReader leerFilas = cmd.ExecuteReader())
                        {
                            if (leerFilas.Read())
                            {
                                e_Usuarios = new E_Usuarios
                                {
                                    IdUsuario = leerFilas.GetInt32(0),
                                    CodUsuario = leerFilas.GetString(1),
                                    Nombre = leerFilas.GetString(2),
                                    Apellido = leerFilas.GetString(3),
                                    FechaNacimiento = leerFilas.GetDateTime(4),
                                    TipoUsuario = leerFilas.GetString(5),
                                    Password = leerFilas.GetString(6),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error en la consola o interfaz de usuario
                Console.WriteLine("Error: " + ex.Message);
                // O lanzar la excepción para manejarla en un nivel superior
                throw;
            }

            return e_Usuarios;
        }
    }
}

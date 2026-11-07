
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Datos
{
    public class D_Usuario : D_Conexion
    {
        public static E_Usuario Login(string strUsuario, string strPassword)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("sp_ValidarLoginHash", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Corregido: Sin la arroba, usando el guion bajo tal cual está en MySQL
                        cmd.Parameters.AddWithValue("_dsUsuario", strUsuario);
                        cmd.Parameters.AddWithValue("_dsPassword", strPassword);

                        using (MySqlDataReader fReader = cmd.ExecuteReader())
                        {
                            E_Usuario usuario = new E_Usuario();

                            while (fReader.Read())
                            {
                                // Corregido: Leyendo la columna 'id' correctamente
                                usuario.id = fReader.GetInt32("id");
                                usuario.dsUsuario = fReader.GetString("dsUsuario");
                            }

                            return usuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            // Si el while no se ejecuta, significa que el usuario o contraseña son incorrectos
            return null;
        }

        public static E_Usuario ObtenerPorNombre(string strUsuario)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (MySqlCommand cmd =
                    new MySqlCommand("sp_ObtenerUsuarioPorNombre", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_usuario", strUsuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            E_Usuario usuario = new E_Usuario();

                            usuario.id = reader.GetInt32("id");
                            usuario.dsUsuario = reader.GetString("dsUsuario");
                            usuario.dsPassword = (byte[])reader["dsPassword"];
                            usuario.dsEstado = Convert.ToChar(
                                reader["dsEstado"]);

                            return usuario;
                        }

                        return null;
                    }
                }
            }
        }

    }
}

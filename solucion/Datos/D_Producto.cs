
using System;
using System.Collections.Generic;
using System.Data;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class D_Producto : D_Conexion
    {
        public static List<E_Producto> ListarProductos()
        {
            List<E_Producto> lista = new List<E_Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (MySqlCommand cmd =
                    new MySqlCommand("sp_ListarProductos", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            E_Producto producto = new E_Producto();

                            producto.id = Convert.ToInt32(reader["id"]);
                            producto.nombre = reader["nombre"].ToString();
                            producto.precio = Convert.ToDecimal(reader["precio"]);
                            producto.cantidad = Convert.ToInt32(reader["cantidad"]);
                            producto.gama = reader["gama"].ToString();

                            producto.imagen =
                                reader["imagen"] == DBNull.Value
                                ? null
                                : (byte[])reader["imagen"];

                            lista.Add(producto);
                        }
                    }
                }
            }

            return lista;
        }
    }
}


using System.Collections.Generic;
using Datos;
using Entidades;

namespace Negocio
{
    public class N_Producto
    {
        public static List<E_Producto> ListarProductos()
        {
            return D_Producto.ListarProductos();
        }
    }
}
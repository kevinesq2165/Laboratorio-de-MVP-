using Entidades;
using Negocio;
using Presentacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Presentadores
{
    public class P_Login
    {
        private readonly ILoginView vista;

        public P_Login(ILoginView vista)
        {
            this.vista = vista;
        }

        public void IniciarSesion()
        {
            E_Usuario usuario = N_Usuario.Login(
                vista.Usuario,
                vista.Password
            );

            if (usuario != null && usuario.id > 0)
            {
                vista.MostrarBienvenida(usuario.dsUsuario);
            }
            else
            {
                vista.MostrarErrorLogin();
            }
        }
    }
}

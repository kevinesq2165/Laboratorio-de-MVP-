using System;
using Entidades;
using Datos;
using Negocio.Interfaces;

namespace Negocio
{
    public class N_Usuario
    {
        public static E_Usuario Login(string strUsuario, string strPassword)
        {
            if (string.IsNullOrWhiteSpace(strUsuario) ||
                string.IsNullOrEmpty(strPassword))
            {
                return null;
            }

            // Buscar el usuario en la base de datos
            E_Usuario usuario = D_Usuario.ObtenerPorNombre(strUsuario);

            if (usuario == null || usuario.id <= 0)
            {
                return null;
            }

            // Crear los servicios de hash
            IHashService generador = new GenerarHashService();

            IVerificarHashService verificador =
                new VerificarHashService(generador);

            // Comprobar la contraseña
            bool passwordCorrecto = verificador.VerificarHash(
                strPassword,
                usuario.dsPassword
            );

            if (!passwordCorrecto)
            {
                return null;
            }

            return usuario;
        }
    }
}
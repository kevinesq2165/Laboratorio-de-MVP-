using System;
using Negocio.Interfaces;

namespace Negocio
{
    public class VerificarHashService : IVerificarHashService
    {
        private readonly IHashService generador;

        public VerificarHashService(IHashService generador)
        {
            this.generador = generador;
        }

        public bool VerificarHash(string password, byte[] hashAlmacenado)
        {
            if (password == null || hashAlmacenado == null)
                return false;

            byte[] hashCalculado = generador.GenerarHash(password);

            if (hashCalculado.Length != hashAlmacenado.Length)
                return false;

            int diferencia = 0;

            for (int i = 0; i < hashCalculado.Length; i++)
            {
                diferencia |= hashCalculado[i] ^ hashAlmacenado[i];
            }

            return diferencia == 0;
        }
    }
}

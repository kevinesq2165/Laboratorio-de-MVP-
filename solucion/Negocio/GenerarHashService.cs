using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GenerarHashService : IHashService
    {
        public byte[] GenerarHash(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                return sha512.ComputeHash(bytes);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IVerificarHashService
    {
        bool VerificarHash(string password, byte[] hashAlmacenado);
    }
}

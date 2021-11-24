using System.Collections.Generic;
using SoftwareFactory.Core;

namespace SoftwareFactory.Core.Ado
{
    public interface IAdo
    {
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerCliente();
    }
}
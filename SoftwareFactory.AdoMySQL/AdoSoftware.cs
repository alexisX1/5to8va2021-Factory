using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;

namespace SoftwareFactory.AdoMySQL
{
    public class AdoSoftwareFactory:IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapCliente MapCliente { get; set; }
        public AdoSoftwareFactory(AdoAGBD ado)
        {
            Ado = ado;
            MapCliente = new MapCliente(Ado);
        }
        public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(Cliente);
        public List<Cliente> ObtenerClientes() => MapCliente.ObtenerClientes();
    }
}
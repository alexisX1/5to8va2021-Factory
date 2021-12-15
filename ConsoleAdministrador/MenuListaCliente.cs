using System;
using System.Collections.Generic;
using SoftwareFactory.Core;

namespace ConsoleAdministrador.Menu
{
    public class MenuListaCliente: MenuLista<Cliente>
    {
        public string Nombre { get; internal set; }

        public override void imprimirElemento(Cliente cliente) => Console.WriteLine($"RazonSocial: {cliente.RazonSocial} - Cuit: {cliente.Cuit} ");
        public override List<Cliente> obtenerlista() =>  Program.Ado.obtenerCliente();
        }
    }
}
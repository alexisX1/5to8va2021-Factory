using System;
using System.Collections.Generic;
using SoftwareFactory.Core;

namespace ConsoleAdministrador
{
    public class MenuListaCliente: MenuLista<Cliente>
    {
        public string Nombre { get; internal set; }

        public override void imprimirElemento(Cliente cliente) => Console.WriteLine($"RazonSocial: {cliente.RazonSocial} - Cuit: {cliente.Cuit} ");
        public override List<Cliente> obtenerlista()
        {
        return  Program.Ado.obtenerCliente();
        }

        internal static object seleccionarElemento()
        {
            throw new NotImplementedException();
        }
    }
}
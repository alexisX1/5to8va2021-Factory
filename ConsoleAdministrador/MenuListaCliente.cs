using System;
using System.Collections.Generic;
using SoftwareFactory.Core;
using et12.edu.ar.MenuesConsola;


namespace ConsoleAdministrador.Menu
{
    public class MenuListaCliente: MenuListador<Cliente>
    {

        public override void imprimirElemento (Cliente cliente)
        {
            Console.WriteLine($"RazonSocial: {cliente.RazonSocial} - Cuit: {cliente.Cuit} ");
        }
        public override List<Cliente> obtenerlista() =>  Program.Ado.obtenerCliente();

        public override List<Cliente> obtenerLista()
        {
            throw new NotImplementedException();
        }
    }
}
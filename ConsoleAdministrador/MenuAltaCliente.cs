using System;
using SoftwareFactory.Core;
using et12.edu.ar.MenuesConsola;


namespace ConsoleAdministrador.Menu
{
    public class MenuAltaCliente : MenuComponente
    {
        public MenuAltaCliente(string nombre, MenuListaCliente menuListaCliente) : base(nombre)
        {
            this.Nombre = "Alta Cliente";
        }

        private Cliente cliente { get; set; }

        public override void mostrar()
        {
            base.mostrar();

            var cuit = Convert.ToInt32(prompt("Ingrese Cuit"));
            var razonSocial = prompt("Ingrese RazonSocial: ");

            cliente = new Cliente
            {
                Cuit = cuit,
                RazonSocial = razonSocial
            };

            try
            {
                Program.Ado.AltaCliente(cliente);
                Console.WriteLine("Cliente dado de alta con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo dar de alta el Cliente: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}

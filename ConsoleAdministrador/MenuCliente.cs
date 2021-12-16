using System;
using SoftwareFactory.Core;
using et12.edu.ar.MenuesConsola;


namespace ConsoleAdministrador.Menu
{
    public class MenuCliente : MenuComponente
    {
        public MenuCliente(string nombre, MenuListaCliente menuListaCliente) : base(nombre)
        {
        }

        private MenuListaCliente MenuListaCliente { get; set; }
        private Cliente Cliente { get; set; }
        
        public override void mostrar()
        {
            base.mostrar();

            var Cuit = Convert.ToInt32(prompt("Ingrese Cuit"));
            var RazonSocial = ReadrazonSocial("Ingrese RazonSocial: ");
            var cliente = MenuListaCliente.seleccionarElemento();

            cliente= new Cliente
            {
                Cuit = Cuit,
                RazonSocial = (string)RazonSocial
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

        private object ReadrazonSocial(string v)
        {
            throw new NotImplementedException();
        }
    }
}

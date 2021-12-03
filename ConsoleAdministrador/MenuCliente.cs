using System;
using SoftwareFactory.Core;
using et12.edu.ar.MenuesConsola;


namespace ConsoleAdministrador
{
    public class MenuCliente : MenuComponente
    {   
        private MenuListaCliente MenuListaCliente { get; set; }
        private Cliente Cliente { get; set; }
        
        public override void mostrar()
        {
            base.mostrar();

            var Cuit = Convert.ToInt32(prompt("Ingrese Cuit"));
            var RazonSocial = ReadRazonSocial("Ingrese RazonSocial: ");
            var cliente = MenuListaCliente.seleccionarElemento();

            cliente= new Cliente
            {
                Cuit = Cuit,
                RazonSocial = (string)RazonSocial
            };

            try
            {
                Adocliente.ADO.agregarCliente(cliente);
                Console.WriteLine("Producto dado de alta con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo dar de alta el Cliente: {e.Message}");
            }
            Console.ReadKey();
        }

        private object ReadRazonSocial(string v)
        {
            throw new NotImplementedException();
        }
    }
}

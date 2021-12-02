using System;
using SoftwareFactory.Core;


namespace ConsoleAdministrador.menu
{
    public class MenuCliente: MenuComponente
    {
        public MenuAltaCliente()
        {
            Nombre = "Alta Cliente";
        }
    }
    public override void mostrar()
        {
            base.mostrar();
            Cliente = new Cliente(Cliente);
            do
            {
                agregarCliente();
            }
            while (preguntaCerrada("¿Desea agregar otro Cliente?"));

            try
            {
                AdoCajero.ADO.AgregarCliente(Cliente);
                Console.Write("Cliente agregado con exito");                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hubo un error: {e.Message} - {e.InnerException.Message}");
            }
        }

            procesarCliente();

            Console.ReadKey();
        }
}
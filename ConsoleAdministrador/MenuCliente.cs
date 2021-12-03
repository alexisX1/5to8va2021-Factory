using System;
using SoftwareFactory.Core;


namespace ConsoleAdministrador.menu
{
    public class MenuCliente : MenuComponente
    {
        public MenuCliente(object adocliente, Cliente cliente)
        {
            this.Adocliente = adocliente;
            this.cliente = cliente;

        }
        public object Adocliente { get; private set; }
        private Cliente cliente { get; set; }

        public override void mostrar()
        {
            base.mostrar();

            var Cuit = Convert.ToInt32(prompt("Ingrese Cuit"));
            var RazonSocial = RazonSocial("Ingrese RazonSocial: ");

            try
            {
                cliente = Adocliente.ADO.AgregarCliente(Cuit, RazonSocial);
                if (cliente is null)
                {
                    Console.WriteLine("Cuit o RazonSocial incorrecta");
                    Console.ReadKey();
                }
                else
                {
                    instanciarMenuesPara(cliente: Cliente);
                    PrincipalUsuario.mostrar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo iniciar sesion debido a un error: {e.Message}");
                Console.ReadKey();
            }
        }

        private void instanciarMenuesPara(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        private bool prompt(string v)
        {
            throw new NotImplementedException();
        }
    }

}

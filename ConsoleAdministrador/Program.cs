using ConsoleAdministrador.Menu;
using SoftwareFactory.Core.Ado;

namespace ConsoleAdministrador
{
    class Program
    {
        public static IAdo Ado { get; private set;}
        static void Main(string[] args, string nombre)
        {
            var menuListaCliente = new MenuListaCliente() { Nombre = "Listado de Cliente"};
            var menuCliente = new MenuCliente("Menu Cliente", menuListaCliente);

            menuCliente.mostrar();    
        }
    }
}
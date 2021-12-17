using ConsoleAdministrador.Menu;
using SoftwareFactory.Core.Ado;
using et12.edu.ar.MenuesConsola;

namespace ConsoleAdministrador
{
    class Program
    {
        public static IAdo Ado { get; private set;}
        static void Main (string[] args)
        {
            var menuListaCliente = new MenuListaCliente() { Nombre = "Listado de Cliente"};
            var menuAltaCliente = new MenuAltaCliente("Menu Cliente", menuListaCliente);
            var menuCliente = new MenuCompuesto("Menu Cliente", menuAltaCliente, menuListaCliente);

            menuCliente.mostrar();    
        }
    }
}

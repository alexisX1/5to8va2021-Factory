using ConsoleAdministrador.Menu;
using SoftwareFactory.Core.Ado;
using et12.edu.ar.MenuesConsola;
using et12.edu.ar.AGBD.Ado;
using SoftwareFactory.AdoMySQL;

namespace ConsoleAdministrador
{
    class Program
    {
        public static IAdo Ado { get; private set;}
        static void Main (string[] args)
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
            Ado = new AdoSoftwareFactory(adoAGBD);

            var menuListaCliente = new MenuListaCliente() { Nombre = "Listado de Cliente"};
            var menuAltaCliente = new MenuAltaCliente("Menu Cliente", menuListaCliente);
            var menuCliente = new MenuCompuesto("Menu Cliente", menuAltaCliente, menuListaCliente);

            menuCliente.mostrar();    
        }
    }
}

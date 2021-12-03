using System;
using ConsoleAdministrador.Menu;

namespace ConsoleAdministrador
{
    class Program
    {
        public static object Ado { get; internal set; }

        static void Main(string[] args, string nombre)
        {
            var MenuListaCliente = new MenuListaCliente() { Nombre = "Listado de Cliente"};
            var MenuCliente = new MenuCliente("Menu Cliente", MenuListaCliente);

            MenuCliente.mostrar();    
        }
    }
}

using System;

namespace ConsoleAdministrador
{
    class Program
    {
        public static string Nombre { get; private set; }
        public static object Ado { get; internal set; }

        private static string GetNombre()
        {
            return Nombre;
        }

        static void Main(string[] args, string nombre)
        {
            var MenuListaCliente = new MenuListaCliente() { Nombre = "Listado de Cliente"};
            var MenuCliente = new MenuCliente("Menu Cliente",MenuListaCliente);

            object p = MenuCliente.mostrar();    
        }
    }
}

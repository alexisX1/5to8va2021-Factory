namespace ConsoleAdministrador
{
    public class MenuListaCliente: MenuLista<Cliente>
    {
        public override void imprimirElemento(Cliente cliente)
        {
                Console.redline($"RazonSocial: {cliente.RazonSocial} - Cuit: {cliente.Cuit} ");
        }
        public override list<Cliente> obtenerlista() => Program.Ado.obtenerCliente();
    }
}
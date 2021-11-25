using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;

namespace SoftwareFactory.AdoMySQL.Mapeadores
{
    public class MapCliente: Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente()
            {
                Id = Convert.ToByte(fila["idCliente"]),
                Nombre = fila["Cliente"].ToString()
            };

        public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametroSalida("unCuit")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.INT)
            SetValor(cliente.Cuit)
            .AgregarParametro();

            BP.CrearParametro("unRazonSocial")
            .SetTipoVarchar(50)
            .SetValor(cliente.RazonSocial)
            .AgregarParametro();
        }

        public List<Cliente> ObtenerCliente() => ColeccionDesdeTabla();
    }
}
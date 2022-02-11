using System;
using System.Collections.Generic;
using SoftwareFactory.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;

namespace SoftwareFactory.AdoMySQL.Mapeadores
{
    public class MapCliente: Mapeador<Cliente>
    {

        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, cliente);


        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametro("unCuit")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(cliente.Cuit)
                .AgregarParametro();

            BP.CrearParametro("unRazonSocial")
                .SetTipoVarchar(50)
                .SetValor(cliente.RazonSocial)
                .AgregarParametro();
        }

        public Cliente ClientePorId(byte id)
        {
            SetComandoSP("ClientePorId");

            BP.CrearParametro("unCuit")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
              .SetValor(id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }

 
        public List<Cliente> ObtenerCliente() => ColeccionDesdeTabla();

        public override Cliente ObjetoDesdeFila(DataRow fila) =>new Cliente()

        {

             Cuit = Convert.ToByte(fila["Cuit"]),
             RazonSocial= fila["Razonsocial"].ToString()
        };

    }

}
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

        internal List<Cliente> ObtenerClientes()
        {
            throw new NotImplementedException();
        }

        public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, postAltaCliente, cliente);

        private void postAltaCliente(Cliente obj)
        {
            throw new NotImplementedException();
        }

        private void EjecutarComandoCon(string v, Action<Cliente> configurarAltaCliente, object postAltaCliente, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametroSalida("unCuit")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(cliente.Cuit)
                .AgregarParametro();

            BP.CrearParametro("unRazonSocial")
                .SetTipoVarchar(50)
                .SetValor(cliente.RazonSocial)
                .AgregarParametro();
        }

        private new object SetComandoSP(string v)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerCliente() => ColeccionDesdeTabla();

        private new List<Cliente> ColeccionDesdeTabla()
        {
            throw new NotImplementedException();
        }

        public override Cliente ObjetoDesdeFila(DataRow fila)
        {
            throw new NotImplementedException();
        }
    }

}
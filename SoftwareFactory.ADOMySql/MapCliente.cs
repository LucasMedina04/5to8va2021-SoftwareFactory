using System;
using System.Collections.Generic;
using SoftwareFactory.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;

namespace SoftwareFactory.ADOMySql
{
    public class MapCliente: Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente
            (
                cuit : Convert.ToInt32(fila["cuit"]),
                razonSocial : fila["razonSocial"].ToString()
            );
        
        public void AltaCliente(Cliente cliente)
            => EjecutarComandoCon("AltaCliente", ConfigurarAltaCliente, cliente);
        
        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("AltaCliente");

            BP.CrearParametro("uncuit")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
              .SetValor(cliente.cuit)
              .AgregarParametro();
            
            BP.CrearParametro("unarazonSocial")
              .SetTipoVarchar(50)
              .SetValor(cliente.razonSocial)
              .AgregarParametro();
        }

        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
}
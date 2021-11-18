using System.Collections.Generic;
using SoftwareFactory.Core;
using et12.edu.ar.AGBD.Ado;

namespace SoftwareFactory.ADOMySql
{
    public class AdoSoftwareFactory
    {
        public AdoAGBD Ado { get; set; }
        public MapCliente MapCliente { get; set; }
        public AdoSoftwareFactory(AdoAGBD ado)
        {
            Ado = ado;
            MapCliente = new MapCliente(ado);
        }
        public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(cliente);
        public List<Cliente> ObtenerClientes() => MapCliente.ObtenerClientes();
    }
}

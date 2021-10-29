using System;
using Xunit;
using SoftwareFactory.Core;

namespace SoftwareFactory.Test
{
    public class TestCliente
    {
        public Cliente Cliente { get; set; }
        
        public TestCliente()
        {
            Cliente = new Cliente(1000, "Et12");
        }
        [Fact]
        public void AsignacionCliente()
        {
            Assert.Equal((uint)1000, Cliente.CUIT);
            Assert.Equal("Et12", Cliente.RazonSocial);
        }
    }
}

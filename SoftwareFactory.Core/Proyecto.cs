using System;

namespace SoftwareFactory.Core
{
    public class Proyecto
    {
        public uint Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Descripcion { get; set; }
        public double Presupuesto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
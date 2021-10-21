using System;

namespace SoftwareFactory.Core
{
    public class Tarea
    {
        public uint Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
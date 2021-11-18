namespace SoftwareFactory.Core
{
    public class Requerimiento
    {
        public uint Id { get; set; }
        public Proyecto Proyecto { get; set; }
        public Tecnologia Tecnologia { get; set; }
        public string Descripcion { get; set; }
        public ushort Complejidad { get; set;}
    }
}
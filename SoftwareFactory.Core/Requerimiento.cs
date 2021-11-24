namespace SoftwareFactory.Core
{
    public class Requerimiento
    {
        public int idRequerimiento { get; set; }
        public short idProyecto { get; set; }
        public sbyte idTecnologia { get; set; }
        public string descripscion { get; set; }
        public byte complejidad { get; set; }
    }
}
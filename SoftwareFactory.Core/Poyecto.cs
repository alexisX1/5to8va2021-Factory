using System;

namespace SoftwareFactory.Core
{
    public class Poyectocs
    {
        public short idProyecto { get; set; }
        public int Cuit { get; set; }
        public string Descripscion { get; set; }
        public decimal Presupuesto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
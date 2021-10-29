using System;

namespace Proyecto.Core
{
    public class Tarea
    {
        public Requerimiento Requerimiento { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

    }
}
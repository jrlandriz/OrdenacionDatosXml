using System;

namespace OrdenacionDatosXml.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Coche { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public int FechaAlta { get; set; }
    }
}
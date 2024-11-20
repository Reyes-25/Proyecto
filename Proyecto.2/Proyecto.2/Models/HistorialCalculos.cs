using System;

namespace Proyecto._2.Models
{
    public class HistorialCalculos
    {
        public int Id { get; set; } // Identificador único
        public string Operacion { get; set; } // Operación matemática (ej. "2+2")
        public double Resultado { get; set; } // Resultado de la operación
        public DateTime FechaRegistro { get; set; } // Fecha del cálculo
        public TimeSpan HoraRegistro { get; set; } // Hora del cálculo
    }
}
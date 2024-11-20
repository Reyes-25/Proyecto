using System;

namespace Proyecto._2.Models
{
    public class HistorialCalculos
    {
        public int Id { get; set; } // Identificador �nico
        public string Operacion { get; set; } // Operaci�n matem�tica (ej. "2+2")
        public double Resultado { get; set; } // Resultado de la operaci�n
        public DateTime FechaRegistro { get; set; } // Fecha del c�lculo
        public TimeSpan HoraRegistro { get; set; } // Hora del c�lculo
    }
}
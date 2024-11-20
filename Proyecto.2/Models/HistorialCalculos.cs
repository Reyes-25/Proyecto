using System;

namespace Proyecto._2.Models
{
    public class HistorialCalculos
    {
        public int Id { get; set; } 
        public string Operacion { get; set; } 
        public double Resultado { get; set; } 
        public DateTime FechaRegistro { get; set; } 
        public TimeSpan HoraRegistro { get; set; } 
    }
}
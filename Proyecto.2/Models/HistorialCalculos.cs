using System;

namespace Proyecto._2.Models
{
    public class HistorialCalculos
    {
        public int Id { get; set; }
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
        public string Operacion { get; set; }
        public string OperacionText { get; set; }
        public int Resultado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

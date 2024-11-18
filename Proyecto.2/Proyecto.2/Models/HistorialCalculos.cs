namespace Proyecto._2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HistorialCalculos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Operacion { get; set; }

        public double Resultado { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }

        public TimeSpan HoraRegistro { get; set; }
    }
}

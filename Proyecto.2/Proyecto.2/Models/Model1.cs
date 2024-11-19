using System.Data.Entity;

namespace Proyecto._2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1() : base("name=Model1")
        {
        }

        public virtual DbSet<HistorialCalculos> HistorialCalculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistorialCalculos>()
                .Property(e => e.HoraRegistro)
                .HasPrecision(0);
        }
    }
}

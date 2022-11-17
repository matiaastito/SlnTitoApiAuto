using Microsoft.EntityFrameworkCore;
using WSAuto.Models;

namespace WSAuto.Data
{
    public class DBAutoContext : DbContext
    {
        public DBAutoContext() { }

        public DBAutoContext(DbContextOptions<DBAutoContext> options) : base(options) { }

        public virtual DbSet <Auto> Autos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Auto>().ToTable("Vehiculo");

            modelBuilder.Entity<Auto>().Property(e => e.Marca).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Auto>().Property(e => e.Modelo).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Auto>().Property(e => e.Color).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Auto>().Property(e => e.Precio).IsRequired().HasColumnType("money");

        }

    }
}

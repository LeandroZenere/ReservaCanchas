using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Web.Models;

namespace Web.Repos
{
    public partial class ReservaCanchaContext : DbContext
    {
        public ReservaCanchaContext()
        {
        }

        public ReservaCanchaContext(DbContextOptions<ReservaCanchaContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Cancha> Cancha { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("name=conexion");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            //modelBuilder.Entity<Pedido>().Property(t => t.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<PedidoItem>().Property(t => t.Id).ValueGeneratedOnAdd();

            //modelBuilder.Entity<Funcion>().Property(t => t.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<FuncionTarifa>().Property(t => t.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Estado>().HasData(
            //    new Estado { Id = 1, Nombre = "Reservada" },
            //    new Estado { Id = 2, Nombre = "Disponible" }
            //);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

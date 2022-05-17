using ApiUtopiaAWSAMH.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Data
{
    public class ContextUtopia : DbContext
    {
        public ContextUtopia(DbContextOptions<ContextUtopia> options) : base(options) { }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

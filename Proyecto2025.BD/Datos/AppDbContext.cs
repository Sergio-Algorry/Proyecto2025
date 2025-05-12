using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pais>  Paises { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí puedes configurar tus entidades y relaciones
        }
    }
}

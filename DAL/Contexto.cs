using Microsoft.EntityFrameworkCore;
using P2_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<TipoTarea> TipoTarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\P2-AP1-Jefferson-20190267.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea
            {
                TipoId = 1,
                TipoTareaa = "Analisis"
 
            }) ;
            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea
            {
                TipoId = 2,
                TipoTareaa = "Diseño"

            });
            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea
            {
                TipoId = 3,
                TipoTareaa = "Programacion"

            });
            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea
            {
                TipoId = 4,
                TipoTareaa = "Prueba"

            });
        }
    }
}

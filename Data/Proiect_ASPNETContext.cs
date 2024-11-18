using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.NET.Models;

namespace Proiect_ASP.NET.Data
{
    public class Proiect_ASPNETContext : DbContext
    {
        public Proiect_ASPNETContext(DbContextOptions<Proiect_ASPNETContext> options)
            : base(options)
        {
        }

        // DbSet pentru ClasaFitness
        public DbSet<Proiect_ASP.NET.Models.ClasaFitness> ClasaFitness { get; set; } = default!;

        // DbSet pentru Instructor
        public DbSet<Proiect_ASP.NET.Models.Instructor> Instructor { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurează relația dintre ClasaFitness și Instructor
            modelBuilder.Entity<Proiect_ASP.NET.Models.ClasaFitness>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorID)
                .OnDelete(DeleteBehavior.SetNull); // Permite InstructorID să fie null
        }

        public DbSet<CategorieFitness> CategoriiFitness { get; set; }
        public DbSet<ClasaCategorieFitness> ClaseCategoriiFitness { get; set; }

        public DbSet<Proiect_ASP.NET.Models.Utilizator> Utilizator { get; set; } = default!;
    }
}

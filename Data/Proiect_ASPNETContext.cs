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

        // DbSet pentru CategorieFitness
        public DbSet<CategorieFitness> CategoriiFitness { get; set; }

        // DbSet pentru ClasaCategorieFitness
        public DbSet<ClasaCategorieFitness> ClaseCategoriiFitness { get; set; }

        // DbSet pentru Utilizator
        public DbSet<Proiect_ASP.NET.Models.Utilizator> Utilizator { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurează relația dintre ClasaFitness și Instructor
            modelBuilder.Entity<Proiect_ASP.NET.Models.ClasaFitness>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorID)
                .OnDelete(DeleteBehavior.SetNull); // Permite InstructorID să fie null

            // Seed data
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { ID = 1, Nume = "Ana Popescu", Specializare = "Aerobic" },
                new Instructor { ID = 2, Nume = "Ion Ionescu", Specializare = "Yoga" }
            );

            modelBuilder.Entity<ClasaFitness>().HasData(
                new ClasaFitness
                {
                    ID = 1,
                    NumeClasa = "Zumba",
                    Orar = "Luni 18:00",
                    Capacitate = 15,
                    Data = DateTime.Now.AddDays(1),
                    InstructorID = 1
                },
                new ClasaFitness
                {
                    ID = 2,
                    NumeClasa = "Pilates",
                    Orar = "Marti 19:00",
                    Capacitate = 20,
                    Data = DateTime.Now.AddDays(2),
                    InstructorID = 2
                }
            );

            modelBuilder.Entity<CategorieFitness>().HasData(
                new CategorieFitness { ID = 3, NumeCategorie = "Cardio" },
                new CategorieFitness { ID = 4, NumeCategorie = "Stretching" }
            );

            modelBuilder.Entity<ClasaCategorieFitness>().HasData(
                new ClasaCategorieFitness { ID = 1, ClasaFitnessID = 1, CategorieFitnessID = 3 },
                new ClasaCategorieFitness { ID = 2, ClasaFitnessID = 2, CategorieFitnessID = 4 }
            );
        }
    }
}

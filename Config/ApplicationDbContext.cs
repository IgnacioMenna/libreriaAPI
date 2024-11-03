using libreriaAPI.Models.Libro;
using libreriaAPI.Models.Autor;
using libreriaAPI.Models.Role;
using libreriaAPI.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using libreriaAPI.Models.Genero;
using libreriaAPI.Models.Resena;

namespace libreriaAPI.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<Libro>().HasData(
                new Libro
                {
                    Id = 1,
                    Titulo = "ewewe",
                    Subtitulo = "Coggggrolla",
                    Descripcion = "A",
                    CantidadPaginas = 500,
                    AutorId = 1,
                    Fecha = new DateTime(2022, 5, 4),
                    GeneroId = 3
                },
                new Libro
                {
                    Id = 2,
                    Titulo = "hthty",
                    Subtitulo = "jjjjjj",
                    Descripcion = "tica",
                    CantidadPaginas = 490,
                    AutorId = 1,
                    Fecha = new DateTime(2024, 7, 14),
                    GeneroId = 2
                },
                new Libro
                {
                    Id = 3,
                    Titulo = "grgrg",
                    Subtitulo = "klkklkl",
                    Descripcion = "Autica",
                    CantidadPaginas = 450,
                    AutorId = 1,
                    Fecha = new DateTime(2020, 9, 4),
                    GeneroId = 1
                }
            );

            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "Juan" },
                new Autor { Id = 2, Nombre = "Jose" },
                new Autor { Id = 3, Nombre = "Ramon" },
                new Autor { Id = 4, Nombre = "Javier" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },
                new Role { Id = 3, Name = "Mod" }
            );

            modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity<RoleUsers>(
                l => l.HasOne<Role>().WithMany().HasForeignKey(e => e.RoleId),
                r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId)
            );

            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nombre = "Accion" },
                new Genero { Id = 2, Nombre = "Ciencia" },
                new Genero { Id = 3, Nombre = "Data" }
            );

            modelBuilder.Entity<Resena>().HasData(
                new Resena { Id = 1, Puntuacion = 3, Comentario = "Admin", LibroId = 3 },
                new Resena { Id = 2, Puntuacion = 4, Comentario = "Bien", LibroId = 2},
                new Resena { Id = 3, Puntuacion = 1, Comentario = "Mal", LibroId = 1 }
            );
        }
    }
}

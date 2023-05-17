using Library.DataAccess.Data.Repository;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using Library.DataAccess;

namespace Library.Test
{
    public class ConfigDBInMemory
    {
        LibraryDBContext db;
        WorkContainer workContainer;

        [OneTimeSetUp]
        public WorkContainer Setup()
        {
            db = GetMemoryContext();
            db.Database.EnsureDeleted();
            workContainer = new WorkContainer(db);

            SeedDataBase();

            return workContainer;
        }


        public LibraryDBContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<LibraryDBContext>()
            .UseInMemoryDatabase(databaseName: "LibraryDB")
            .Options;
            return new LibraryDBContext(options);
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Database.EnsureDeleted();
        }

        public void SeedDataBase()
        {
            var autores = new List<Autore>()
            {
                new Autore()
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellidos = "Apostol"
                },
                new Autore()
                {
                    Id = 2,
                    Nombre = "Moises",
                    Apellidos = "Israelita"
                },
                new Autore()
                {
                    Id = 3,
                    Nombre = "David",
                    Apellidos = "Rey"
                },
                new Autore()
                {
                    Id = 4,
                    Nombre = "John Ronald",
                    Apellidos = "Reuel Tolkien"
                }
            };

            foreach (Autore autor in autores)
            {
                db.Autores.Add(autor);
                db.SaveChanges();
            }


            var editoriales = new List<Editoriale>()
            {
                new Editoriale()
                {
                    Id = 1,
                    Nombre = "Editorial Vida",
                    Sede = "Colombia"
                },
                new Editoriale()
                {
                    Id = 2,
                    Nombre = "George Allen & Unwin HarperCollins",
                    Sede = "Reino de Gran Bretaña"
                }
            };

            foreach (Editoriale editorial in editoriales)
            {
                db.Editoriales.Add(editorial);
                db.SaveChanges();
            }

            var books = new List<Libro>() 
            {
                 new Libro()
                 {
                     Isbn = 1,
                     Titulo = "Biblia Reina valera 1960",
                     Sipnosis = "La Biblia comienza con el relato de la creación, y termina con la profecía de la nueva creación. Nos cuenta primero de Adán y Eva en el huerto de Edén, y al final nos cuenta de la nueva Jerusalén y el reino eterno.",
                     NPaginas = "1740",
                     EditorialId = 1
                 },
                 new Libro()
                 {
                     Isbn = 2,
                     Titulo = "El Señor de los Anillos",
                     Sipnosis = "Tres Anillos para los Reyes Elfos bajo el cielo. Siete para los Señores Enanos en casas de piedra. Nueve para los Hombres Mortales condenados a morir. Uno para el Señor Oscuro, sobre el trono oscuro en la Tierra de Mordor donde se extienden las Sombras",
                     NPaginas = "576",
                     EditorialId = 2
                 }
            };

            foreach (Libro libro in books)
            {
                db.Libros.Add(libro);
                db.SaveChanges();
            }

            var autores_con_libros = new List<AutoresHasLibro>() 
            {
               new AutoresHasLibro()
               {
                 AutoresId = 1,
                 LibroIsbn = 1
               },
               new AutoresHasLibro()
               {
                 AutoresId = 2,
                 LibroIsbn = 1
               },
               new AutoresHasLibro()
               {
                 AutoresId = 3,
                 LibroIsbn = 1
               },
               new AutoresHasLibro()
               {
                 AutoresId = 4,
                 LibroIsbn = 2
               }
            };

            foreach (AutoresHasLibro item in autores_con_libros)
            {
                db.AutoresHasLibros.Add(item);
                db.SaveChanges();
            }

        }
    }
}

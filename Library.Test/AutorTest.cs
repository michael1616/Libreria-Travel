using Library.DataAccess.Data.Repository;
using Library.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Library.Test
{
    public class AutorTest
    {
        WorkContainer AutorRepo;

        [OneTimeSetUp]
        public void Setup()
        {
            ConfigDBInMemory config = new ConfigDBInMemory();
            AutorRepo = config.Setup();
        }


        [Test]
        public void VerificarAutorPorIdSiEsNotNullYEsJonh()
        {
            var autor = AutorRepo.Author.GetById(4);

            Assert.IsNotNull(autor);
            Assert.IsTrue(autor.Nombre == "John Ronald");
        }

        [Test]
        public void VerificarQueExistanAutores()
        {
            var listadoAutores = AutorRepo.Author.GetAll().ToList();

            Assert.IsNotNull(listadoAutores);
            Assert.IsTrue(listadoAutores.Count() > 0);
        }
    }
}
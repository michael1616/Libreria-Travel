using Library.DataAccess.Data.Repository.IRepository;
using Library.Models;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IWorkContainer _workContainer;

        /// <summary>
        /// Se inyecta la unidad de trabajo
        /// </summary>
        /// <param name="workContainer"></param>
        public BookController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
        }

        /// <summary>
        /// Retorna la vista con los libros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Libro> bookList = _workContainer.Book.GetAll();
            return View(bookList);
        }

        /// <summary>
        /// Retorna la vista con el detalle del libro
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Información del libro</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            Libro book = _workContainer.Book.GetFirstOrDefault(filter: a => a.Isbn == id, includeProperties: "Editorial");

            if (book == null)
            {
                return NotFound();
            }

            BookViewModel bookVM = new BookViewModel()
            {
                Book = book,
                Autores = _workContainer.Author.GetAuthorsByISBNBook(id)
            };

            return View(bookVM);
        }

    }
}

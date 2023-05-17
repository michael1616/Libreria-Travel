using Library.Models;
using System.Collections.Generic;

namespace Library.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Interface Autores Repository
    /// </summary>
    public interface IAutoresRepository : IRepository<Autore>
    {
        /// <summary>
        /// Obtiene los autores por el ISBN del libro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Autore> GetAuthorsByISBNBook(int id);
    }
}

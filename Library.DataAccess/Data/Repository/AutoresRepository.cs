using Library.DataAccess.Data.Repository.IRepository;
using Library.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.DataAccess.Data.Repository
{
    /// <summary>
    /// Autores repositorio se implementa la interface
    /// </summary>
    public class AutoresRepository : Repository<Autore>, IAutoresRepository
    {
        private readonly LibraryDBContext _db;

        /// <summary>
        /// Se inicializa la conexion a db
        /// </summary>
        /// <param name="db">contexto</param>
        public AutoresRepository(LibraryDBContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Obtiene los autores por el id ejecutando un sp
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Autores</returns>
        public List<Autore> GetAuthorsByISBNBook(int id)
        {
            SqlParameter param = new SqlParameter 
            {
                ParameterName = "@book_ISBN", 
                Value = id, 
                DbType = DbType.Int32 
            }
            ;
            List<Autore> AuthoresByBook = _db.Autores.FromSqlRaw("EXEC sp_getAuthorsByBook @book_ISBN", param).ToList();

            return AuthoresByBook;
        }
    }
}

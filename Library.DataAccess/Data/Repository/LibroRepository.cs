using Library.Models;

namespace Library.DataAccess.Data.Repository
{
    /// <summary>
    /// LibroRepository hereda los metodos del repositorio generico
    /// </summary>
    public class LibroRepository : Repository<Libro>
    {
        private readonly LibraryDBContext _db;

        /// <summary>
        /// Se inicializa la conexion a db
        /// </summary>
        /// <param name="db">contexto</param>
        public LibroRepository(LibraryDBContext db) : base(db)
        {
            _db = db;
        }
    }
}

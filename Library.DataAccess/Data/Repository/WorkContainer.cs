using Library.DataAccess.Data.Repository.IRepository;

namespace Library.DataAccess.Data.Repository
{
    /// <summary>
    /// Implementa la interface de la unidad de trabajo,
    /// contiene todos los rpositorios
    /// </summary>
    public class WorkContainer : IWorkContainer
    {
        private readonly LibraryDBContext _db;

        public LibroRepository Book { get; set; }

        public IAutoresRepository Author { get; set; }

        /// <summary>
        /// Se inizcializa y se pasa el mismo contexto a todos
        /// los repositorios
        /// </summary>
        /// <param name="db"></param>
        public WorkContainer(LibraryDBContext db)
        {
            _db = db;
            Book = new LibroRepository(_db);
            Author = new AutoresRepository(_db);
        }

        /// <summary>
        /// Guardar
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }

        /// <summary>
        /// Cerrar
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

using System;

namespace Library.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Interface de la unidad de trabajo
    /// </summary>
    public interface IWorkContainer : IDisposable
    {
        /// <summary>
        /// Repositorio de autor
        /// </summary>
        public IAutoresRepository Author { get; set; }

        /// <summary>
        /// Repositorio de libro
        /// </summary>
        public LibroRepository Book { get; set; }

        /// <summary>
        /// Guardar
        /// </summary>
        void Save();
    }
}

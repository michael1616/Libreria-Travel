using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    /// Interface Repositorio generico
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene por el id
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>Entidad</returns>
        T GetById(int id);

        /// <summary>
        /// Obtiene todos los registros de la identidad
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="orderBy">Ordenamiento</param>
        /// <param name="includeProperties">Propiedades a incluir</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        /// <summary>
        /// Obtiene una entidad segun el filtro
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="includeProperties">Propiedades a incluir</param>
        /// <returns>Entidad</returns>
        T GetFirstOrDefault(
             Expression<Func<T, bool>> filter = null,
             string includeProperties = null
            );

        /// <summary>
        /// Agrega una entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        void Add(T entity);

        /// <summary>
        /// Remueve una entidad por el id
        /// </summary>
        /// <param name="id">Id</param>
        void Remove(int id);

        /// <summary>
        /// Remueve una entidad passando la entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        void Remove(T entity);
    }
}

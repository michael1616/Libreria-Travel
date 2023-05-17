using Library.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.DataAccess.Data.Repository
{
    /// <summary>
    /// Se implementa la interface del repositorio generico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        /// <summary>
        /// Se inicializa el contexto y la entidad a trabajar
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// Agrega la entidad
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Obtiene un listado de una entidad
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="orderBy">Ordenamiento</param>
        /// <param name="includeProperties">propiedades a incluir por ,</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            //Si hay filtro
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Include properties separte by semicolon
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            //Si hay ordnamiento
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            //Retorna la consulta
            return query;
        }

        /// <summary>
        /// Obtiene una entidad por el id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Entidad</returns>
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Obtiene una entidad con criterios
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="includeProperties">propiedades a incluir</param>
        /// <returns>Entidad</returns>
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            //Si hay filtro
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Include properties separte by semicolon
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Elimina por le id
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Remove(int id)
        {
            T EntityToRemove = dbSet.Find(id);
            dbSet.Remove(EntityToRemove);
        }

        /// <summary>
        /// Elimina pasando la entidad
        /// </summary>
        /// <param name="entity">Entidad</param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}

using CodeShare.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CodeShare.Data
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        ICodeShareEntities _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(ICodeShareEntities context)
        {
            _context = context;
            _dbSet = _context.GetSet<TEntity>();
        }

        public PagedResult<TEntity> SearchPaged(Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy, int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            var query = CreateQuery(filter, orderBy, includeProperties);

            var items = query.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            var total = query.Count();

            return new PagedResult<TEntity>(items, total);
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = CreateQuery(filter, orderBy, includeProperties);

            return query.ToList();
        }

        private IQueryable<TEntity> CreateQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_context.GetState(entity) == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.SetModified(entity);
        }

        public int Count()
        {
            return _dbSet.Count();
        }
    }
}
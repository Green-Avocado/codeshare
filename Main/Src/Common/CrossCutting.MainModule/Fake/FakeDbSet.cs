using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CrossCutting.MainModule.Fake
{
    public class FakeDbSet<T> : DbSet<T>, IQueryable where T : class
    {
        private List<T> _entities;

        public FakeDbSet() : base()
        {
            _entities = new List<T>();
        }

        public override T Add(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            _entities.Remove(entity);
            return entity;
        }

        public Type ElementType
        {
            get { return _entities.AsQueryable().ElementType; }
        }

        public Expression Expression
        {
            get { return _entities.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _entities.AsQueryable().Provider; }
        }

        public IEnumerator GetEnumerator()
        {
            return _entities.GetEnumerator();
        }
    }
}
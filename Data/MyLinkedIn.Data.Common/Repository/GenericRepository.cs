using System;
using System.Data.Entity;
using System.Linq;

namespace MyLinkedIn.Data.Common.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.context = context;
            set = this.context.Set<T>();
        }

        protected IDbSet<T> Set
        {
            get { return set; }
        }
        
        public IQueryable<T> All()
        {
            return set;
        }

        public T Find(object id)
        {
            return set.Find(id);
        }

        public virtual void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public T Delete(object id)
        {
            var entity = Find(id);

            if (entity != null)
            {
                Delete(entity);
            }
            return entity;
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = context.Entry(entity);
            if (entry.State == EntityState.Deleted)
            {
                set.Attach(entity);
            }
            entry.State = state;
        }
    }
}

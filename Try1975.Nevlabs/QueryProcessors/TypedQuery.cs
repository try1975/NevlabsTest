using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Try1975.Nevlabs.Entities;

namespace Try1975.Nevlabs.QueryProcessors
{
    public abstract class TypedQuery<T, TK> : ITypedQuery<T, TK> where T : class, IEntity<TK>
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _entities;

        protected TypedQuery(DbContext db)
        {
            _db = db;
            _entities = _db.Set<T>();
        }

        public virtual IQueryable<T> GetEntities()
        {
            return _entities.AsNoTracking();
        }

        public virtual T GetEntity(TK id)
        {
            var entity = _entities.Find(id);
            return entity;
        }

        public async Task<T> GetEntityAsync(TK id)
        {
            return await _entities.FindAsync(id);
        }

        public T InsertEntity(T entity)
        {
            _db.Set<T>().Add(entity);
            SaveChanges();
            return entity;
        }

        public T UpdateEntity(T entity)
        {
            _db.Set<T>().AddOrUpdate(entity);
            SaveChanges();
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            try
            {
                _db.Set<T>().Attach(entity);
                _db.Set<T>().Remove(entity);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public DbContext GetDbContext()
        {
            return _db;
        }

        private void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
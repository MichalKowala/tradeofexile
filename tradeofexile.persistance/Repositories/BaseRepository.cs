using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.models.EntityItems;

namespace tradeofexile.persistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly TradeOfExileDbContext _dbContext;
        public BaseRepository(TradeOfExileDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = GetById(id);
            _dbContext.Remove(record);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public IQueryable<T> GetAll(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsQueryable();
        }
        public bool Exists(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Any(predicate);
        }
        
        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Guid Id)
        {
            var record = GetById(Id);
            Update(record);
        }
        public T GetRecentlyCreated()
        {
            var record = _dbContext.Set<T>().OrderByDescending(x => x.DateCreated).FirstOrDefault();
            return record;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using tradeofexile.models.EntityItems;
using System.Linq.Expressions;

namespace tradeofexile.application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void Update(Guid Id);
        T GetById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<T, bool> predicate);
        bool Exists(Func<T, bool> predicate);
        T GetRecentlyCreated();
        public IQueryable<T> GetAllWithChildrenAndFilter(Func<T,bool>predicate, params Expression<Func<T, object>>[] childrens);
        public IQueryable<T> GetAllWithChildren(params Expression<Func<T, object>>[] childrens);

    }
}

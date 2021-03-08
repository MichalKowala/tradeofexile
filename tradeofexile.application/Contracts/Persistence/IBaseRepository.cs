using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using tradeofexile.models.EntityItems;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Medicine.Entities.Base;

namespace Medicine.Repository.Base
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWithPagging(int pageIndex, int pageSize);
        T GetById(string id);
        void DeleteById(string id);
        void DeleteRangeByIds(IEnumerable<string> ids);
        void DeleteByItem(T entity);
        void DeleteRangeByItems(IEnumerable<T> entities);
        void DeleteFromDatabaseById(string id);
        void DeleteFromDatabaseByItem(T entity);
        void DeleteRangeFromDatabaseByIds(IEnumerable<string> ids);
        void DeleteRangeFromDatabaseByItems(IEnumerable<T> entities);
    }
}

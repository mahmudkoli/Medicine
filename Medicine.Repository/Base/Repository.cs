using Medicine.Common;
using Medicine.Entities.Base;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private MedicineDbContext _context;
        public Repository(MedicineDbContext context)
        {
            this._context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Update(entity);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().Where(c => !c.IsDeleted).OrderByDescending(x => x.CreatedAt);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetWithPagging(int pageIndex, int pageSize)
        {
            return _context.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public virtual T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public void DeleteById(string id)
        {
            T entity = GetById(id);
            DeleteByItem(entity);
        }

        public void DeleteRangeByIds(IEnumerable<string> ids)
        {
            foreach (string id in ids)
            {
                DeleteById(id);
            }
        }

        public void DeleteByItem(T entity)
        {
            entity.IsDeleted = true;
        }

        public void DeleteRangeByItems(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                DeleteByItem(entity);
            }
        }

        public void DeleteFromDatabaseById(string id)
        {
            T entity = GetById(id);
            DeleteFromDatabaseByItem(entity);
        }

        public void DeleteFromDatabaseByItem(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRangeFromDatabaseByIds(IEnumerable<string> ids)
        {
            foreach (string id in ids)
            {
                DeleteFromDatabaseById(id);
            }
        }

        public void DeleteRangeFromDatabaseByItems(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                DeleteFromDatabaseByItem(entity);
            }
        }
    }
}

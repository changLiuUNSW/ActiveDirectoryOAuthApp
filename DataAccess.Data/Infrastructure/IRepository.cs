using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Data.Infrastructure
{
    public interface IRepository<T>
    {
        void Update(T data);
        void Delete(T entity);
        IQueryable<T> Query(Expression<Func<T, bool>> query);
        IEnumerable<T> GetAll();
    }
}

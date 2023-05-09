using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()   
    {
        T Get(Expression<Func<T, bool>> filter,params Expression<Func<T, object>>[] includes);
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        void Add(T entity);
        void Delete(T entity); 
        
        void Update(T entity);

        void Patch(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

    }
}

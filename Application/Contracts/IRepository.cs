using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface  IRepository<T> where T : BaseModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      List<Expression<Func<T, object>>> includes = null,
                                      bool disableTracking = true);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> SoftDeleteAsync(T entity);
    }
}

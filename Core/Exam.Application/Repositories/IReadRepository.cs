using Exam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByNumberAsync(long number,params Expression<Func<T, object>>[] includes);
    }
}

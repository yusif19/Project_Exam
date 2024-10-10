using Exam.Application.Repositories;
using Exam.Domain.Entities.Base;
using Exam.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        public async Task<IQueryable<T>> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query =Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(long id, params Expression<Func<T, object>>[] includes)
        {

            var query = Table.AsQueryable();
            if (includes!=null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public Task<T> GetByNumberAsync(long number, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
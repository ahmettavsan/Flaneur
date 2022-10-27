using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskEtkinlik.Core.Repositories;

namespace TaskEtkinlik.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbset;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbset = _appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
           await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
    }
}

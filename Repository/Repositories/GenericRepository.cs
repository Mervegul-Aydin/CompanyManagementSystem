using CompanyManagementSystem.Core.Repositories;
using CompanyManagementSystem.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementSystem.Core.Models;

namespace CompanyManagementSystem.Repository.Repositories
{
    public class GenericRepository<T>: IGenericRepository <T> where T : class 
    { 
        protected readonly AppDbContexts.AppDbContext.AppDbContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContexts.AppDbContext.AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entites)
        {
            await _dbSet.AddRangeAsync(entites);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.AnyAsync(expression);

        }

        public IQueryable<T> GetAll()
        {
           return _dbSet.AsNoTracking().AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

     
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            _dbSet.RemoveRange(entites);
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

       
    }
}

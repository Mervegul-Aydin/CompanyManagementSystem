using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);  // ıd göre data dön  // where(x=x.id>10).OrderBy.TolistAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);  
        
        IQueryable<T> GetAll();

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entites);

        void Update(T entity);

        void Remove (T entity); 

        void RemoveRange (IEnumerable<T> entites);
        Task GetByIdAsync();
    }
}

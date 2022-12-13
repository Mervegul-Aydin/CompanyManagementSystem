using CompanyManagementSystem.Core.UnitOfWorks;
using CompanyManagementSystem.Core.Repositories;
using CompanyManagementSystem.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Repository.UnitOfWorks
{
    public class UnitOfWork : IGenericUnitOfWork
    {
        private readonly AppDbContexts.AppDbContext.AppDbContext _context;

        public UnitOfWork(AppDbContexts.AppDbContext.AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }

}

using System;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly AppDBContext _context; 

        public UnitOfWork(AppDBContext context)
		{
            _context = context; 
		}

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}


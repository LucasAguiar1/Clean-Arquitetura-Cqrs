using System;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDBContext Context;

        public BaseRepository(AppDBContext context)
        {
            Context = context;
        }
        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        public void Delete (T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                // Se a entidade estiver desanexada, anexe-a ao contexto antes de excluí-la
                Context.Attach(entity);
            }

            // Remova a entidade do contexto
            Context.Remove(entity);
        }
    }
}


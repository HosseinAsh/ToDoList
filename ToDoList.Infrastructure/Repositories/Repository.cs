using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Abstractions;

namespace ToDoList.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(task => task.Id == id, cancellationToken);
        }
        public void Add(T entity)
        {
            DbContext.Add(entity);
        }
        public void Update(T entity)
        {
            DbContext.Update(entity);
        }
        public void Delete(T entity)
        {
            DbContext.Remove(entity);
        }

    }
}

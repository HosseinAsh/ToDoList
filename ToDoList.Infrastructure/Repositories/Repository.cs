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
        public async Task<Guid> Add(T entity)
        {
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<T>()
                .ToListAsync();
        }
        public async Task Update(T entity)
        {
            DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
        }


    }
}

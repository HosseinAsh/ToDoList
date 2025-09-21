using ToDoList.Domain.ToDoList;

namespace ToDoList.Infrastructure.Repositories
{
    internal sealed class ToDoListRepository : Repository<Domain.ToDoList.ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task GeneratePDF(Domain.ToDoList.ToDoList entity)
        {
            // implementation code for generate pdf.
        }
    }
}

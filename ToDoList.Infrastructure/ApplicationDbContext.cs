using Microsoft.EntityFrameworkCore;

namespace ToDoList.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.ToDoList.ToDoList> ToDoLists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}

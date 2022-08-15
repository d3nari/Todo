using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Configurations;

namespace Todo.Infrastructure
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}

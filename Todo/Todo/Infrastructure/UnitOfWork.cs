using Todo.Application;

namespace Todo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _dbContext;

        public UnitOfWork(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

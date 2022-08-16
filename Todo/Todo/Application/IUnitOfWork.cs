namespace Todo.Application
{
    public interface IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken = default);
    }
}

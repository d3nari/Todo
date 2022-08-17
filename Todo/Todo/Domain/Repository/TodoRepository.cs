using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure;

namespace Todo.Domain.Repository;

public interface ITodoRepository
{
    void Add( Entity.Todo item );
    Task<List<Entity.Todo>> GetTodos();
    Task UpdateTodo(Entity.Todo item, int Id);
    Task<Entity.Todo> GetById(int id);
    Task DeleteTodo(int Id);
}

public class TodoRepository : ITodoRepository
{
    /// <summary>
    /// Не очень хорошо, здесь должен быть ConcurrentList, чтобы избежать проблем с многопоточностью
    /// </summary>
    private static readonly List<Entity.Todo> _todos = new();

    private readonly TodoDbContext _dbContext;

    public TodoRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static int _index => _todos.Count + 1;

    public void Add( Entity.Todo item )
     {
        if ( item is null )
        {
            throw new ArgumentNullException( nameof( item ) );
        }
        _dbContext.Add( item );
    }


    public async Task<Entity.Todo> GetById(int id)
    {
        return await _dbContext.Set<Entity.Todo>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<Entity.Todo>> GetTodos()
    {
        return await _dbContext.Set<Entity.Todo>().ToListAsync();
    }

    public async Task UpdateTodo(Entity.Todo item, int id)
    {
        Entity.Todo Todo = await _dbContext.Set<Entity.Todo>().FirstOrDefaultAsync(t => t.Id == id);
        Todo.UpdateTodo(id, item.Body, item.ExecutionDate);
    }

    public async Task DeleteTodo(int id)
    {
        Entity.Todo Todo = await _dbContext.Set<Entity.Todo>().FirstOrDefaultAsync(t => t.Id == id);
        _dbContext.Remove(Todo);
    }
}

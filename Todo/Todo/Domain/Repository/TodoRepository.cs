namespace Todo.Domain.Repository;

public interface ITodoRepository
{
    void Add( Entity.Todo item );
    List<Entity.Todo> GetTodos();
    void UpdateTodo( Entity.Todo item, int Id );
    Entity.Todo GetTodo( int Id );
    void DeleteTodo( int Id );
}

public class TodoRepository : ITodoRepository
{
    /// <summary>
    /// Не очень хорошо, здесь должен быть ConcurrentList, чтобы избежать проблем с многопоточностью
    /// </summary>
    private static readonly List<Entity.Todo> _todos = new();

    private static int _index => _todos.Count + 1;

    public void Add( Entity.Todo item )
     {
        if ( item is null )
        {
            throw new ArgumentNullException( nameof( item ) );
        }

        item.SetId( _index );
        _todos.Add( item );
    }

    public List<Entity.Todo> GetTodos()
    {
        return _todos;
    }

    public void UpdateTodo(Entity.Todo item, int Id)
    {
        _todos[Id].UpdateTodo(Id, item.Body, item.ExecutionDate);
    }

    public Entity.Todo GetTodo(int Id)
    {
        return _todos[Id];
    }

    public void DeleteTodo(int Id)
    {
        // check if id is in range
        _todos.RemoveAt(Id);
    }
}

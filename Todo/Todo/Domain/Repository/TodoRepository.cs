namespace Todo.Domain.Repository;

public interface ITodoRepository
{
    void Add( Entity.Todo item );
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
}

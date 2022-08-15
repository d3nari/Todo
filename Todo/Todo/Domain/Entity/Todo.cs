namespace Todo.Domain.Entity;

public class Todo
{
    public int Id { get; private set; }

    /// <summary>
    /// Тело заметки
    /// </summary>
    public string Body { get; private set; }

    /// <summary>
    /// Дата, когда запланировано закрыть заметку
    /// </summary>
    public DateTime ExecutionDate { get; private set; }

    public Todo( string body, DateTime executionDate )
    {
        SetBody( body );
        SetExecutionDate( executionDate );
    }

    public void UpdateTodo(int Id, string body, DateTime executionDate)
    {
        SetId( Id );
        SetBody(body);
        SetExecutionDate(executionDate);
    }

    public void SetBody( string body )
    {
        if ( string.IsNullOrEmpty( body ) )
        {
            throw new ArgumentException( null, nameof( body ) );
        }

        Body = body;
    }

    public void SetExecutionDate( DateTime executionDate )
    {
        if ( executionDate < DateTime.UtcNow )
        {
            throw new ArgumentException( "ExecutionDate can't be in past", nameof( executionDate ) );
        }

        ExecutionDate = executionDate;
    }

    public void SetId( int id )
    {
        if ( id <= 0 )
        {
            throw new ArgumentOutOfRangeException( nameof( id ) );
        }

        Id = id;
    }
}

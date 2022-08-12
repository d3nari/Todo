namespace Todo.Dtos;

public class TodoDto
{
    public int Id { get; set; }

    /// <summary>
    /// Описание того что нужно сделать
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Запланированная дата выполнения
    /// </summary>
    public DateTime ExecutionDate { get; set; }
}

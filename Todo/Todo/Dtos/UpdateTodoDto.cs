namespace Todo.Dtos;

public class UpdateTodoDto
{
    public int Id { get; set; }
    public string Body { get; set; }
    public DateTime ExecutionDate { get; set; }
}
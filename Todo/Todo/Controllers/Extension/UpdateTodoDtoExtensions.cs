using Todo.Dtos;

namespace Todo.Controllers.Extension;

/// <summary>
/// Методы расширения. Расширяют класс не изменяя его
/// </summary>
public static class UpdateTodoDtoExtensions
{
    public static Domain.Entity.Todo ToEntity( this UpdateTodoDto dto )
    {
        Domain.Entity.Todo entity = new(dto.Body, dto.ExecutionDate );
        return entity;
    }
}

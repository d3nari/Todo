using Todo.Dtos;

namespace Todo.Controllers.Extension;

/// <summary>
/// Методы расширения. Расширяют класс не изменяя его
/// </summary>
public static class CreateTodoDtoExtensions
{
    public static Domain.Entity.Todo ToEntity( this CreateTodoDto dto )
    {
        Domain.Entity.Todo entity = new( dto.Body, dto.ExecutionDate );
        return entity;
    }
}

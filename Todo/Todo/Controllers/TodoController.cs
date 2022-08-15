using Microsoft.AspNetCore.Mvc;
using Todo.Controllers.Extension;
using Todo.Domain.Repository;
using Todo.Dtos;

namespace Todo.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _todoRepository;

    public TodoController( ITodoRepository todoRepository )
    {
        _todoRepository = todoRepository ?? throw new ArgumentNullException( nameof( todoRepository ) );
    }

    // get all todos
    [HttpGet]
    public List<Domain.Entity.Todo> GetAllTodos()
    {
        return _todoRepository.GetTodos();
    }

    // get todo by id
    [HttpGet( "{id}" )]
    public Domain.Entity.Todo GetById( int id )
    {
        return _todoRepository.GetTodo(id);
    }

    // create todo
    [HttpPost]
    public IActionResult Create( [FromBody] CreateTodoDto createTodoDto )
    {
        _todoRepository.Add(createTodoDto.ToEntity());
        return Ok();
    }

    // update todo
    [HttpPut]
    public IActionResult Update( [FromBody] UpdateTodoDto updateTodoDto )
    {
        // обновляем todo
        _todoRepository.UpdateTodo(updateTodoDto.ToEntity(), updateTodoDto.Id);
        return Ok();
    }

    // delete todo
    [HttpDelete( "{id}" )]
    public IActionResult DeleteById( [FromRoute] int id )
    {
        _todoRepository.DeleteTodo(id);
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Todo.Application;
using Todo.Controllers.Extension;
using Todo.Domain.Repository;
using Todo.Dtos;

namespace Todo.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _todoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TodoController( ITodoRepository todoRepository, IUnitOfWork unitOfWork )
    {
        _todoRepository = todoRepository ?? throw new ArgumentNullException( nameof( todoRepository ) );
        _unitOfWork = unitOfWork;
    }

    // get all todos
    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
        List<Domain.Entity.Todo> todoList = await _todoRepository.GetTodos();
        return Ok(todoList);
    }

    // get todo by id
    [HttpGet( "{id}" )]
    public async Task<IActionResult> GetById( int id )
    {
        Domain.Entity.Todo todo = await _todoRepository.GetById( id );
        if (todo is null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    // create todo
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoDto createTodoDto)
    {
        _todoRepository.Add(createTodoDto.ToEntity());
        await _unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task DeleteById([FromRoute] int id)
    {
        await _todoRepository.DeleteTodo(id);
        await _unitOfWork.CommitAsync();
    }

    // update todo
    [HttpPut]
    public async Task Update([FromBody] UpdateTodoDto updateTodoDto)
    {
        // обновляем todo
        await _todoRepository.UpdateTodo(updateTodoDto.ToEntity(), updateTodoDto.Id);
        await _unitOfWork.CommitAsync();
    }

}

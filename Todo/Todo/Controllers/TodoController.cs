using Microsoft.AspNetCore.Mvc;
using Todo.Dtos;

namespace Todo.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TodoController : ControllerBase
{
    // get all todos
    [HttpGet]
    public List<TodoDto> GetAllTodos()
    {
        List<TodoDto> testData = new()
        {
            new TodoDto()
            {
                Id = 1,
                Body = "Полить цветы на другой квартире",
                ExecutionDate = DateTime.Now.AddDays( 2 ).Date,
            }
        };

        return testData;
    }

    // get todo by id
    [HttpGet( "{id:noZeroes}" )]
    public TodoDto GetById( int id )
    {
        return new TodoDto()
        {
            Id = id,
            Body = "Пройти допоминовую детоксикацию",
            ExecutionDate = DateTime.Now.AddDays( 3 ).Date
        };
    }

    // create todo
    [HttpPost]
    public IActionResult Create( [FromBody] CreateTodoDto createTodoDto )
    {
        // создаем todo
        return Ok();
    }

    // update todo
    [HttpPut]
    public IActionResult Update( [FromBody] UpdateTodoDto updateTodoDto )
    {
        // обновляем todo
        return BadRequest();
    }

    // delete todo
    [HttpDelete( "{id:noZeroes}" )]
    public IActionResult DeleteById( [FromRoute] int id )
    {
        return NotFound();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FirstProjectAPI.Controller;

[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service)
    {
        _service = service;
    }
    
    [HttpGet("/todo")]
    public List<Todo> GetAll()
    {
        return _service.GetAll();
    }
    
    [HttpPost("/todo")]
    public void Create([FromBody] Todo todo)
    {
        _service.Create(todo);
    }
    
}
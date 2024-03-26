using Microsoft.AspNetCore.Mvc;
using ToDoProject.Data.Dtos;
using ToDoProject.Models;
using ToDoProject.Services;

namespace ToDoProject.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ToDoService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ToDoController(ToDoService service, IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public CreatedAtActionResult CreateToDo([FromBody] CreateToDoDto createToDoDto)
    {
        ToDoModel todo = _service.CreateToDo(createToDoDto);

        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }
    
    
    [HttpGet]
    public IEnumerable<object> GetToDos([FromQuery] int skip = 0, int take = 10)
    {
        IHeaderDictionary headers = _httpContextAccessor.HttpContext!.Request.Headers;
        return _service.GetToDos(headers["plataforma"]!, skip, take);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return _service.GetToDoById(id);
    }
}
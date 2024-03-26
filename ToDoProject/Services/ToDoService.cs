using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Data;
using ToDoProject.Data.Dtos;
using ToDoProject.Models;
using ToDoProject.Services.Interfaces;

namespace ToDoProject.Services;

public class ToDoService : IToDoService
{
    private ToDoContext _context;
    private IMapper _mapper;

    public ToDoService(ToDoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ToDoModel CreateToDo(CreateToDoDto dto)
    {
        ToDoModel todo = _mapper.Map<ToDoModel>(dto);
        todo.StatusEnum = 0;
        todo.DataAbertura = DateTime.Now;
        _context.Add(todo);
        _context.SaveChanges();

        return todo;
    }

    public IActionResult GetToDoById(int id)
    {
        ToDoModel toDo = _context.ToDos.Find(id);
        if (toDo == null)
        {
            return new NotFoundResult();
        }

        ReadToDoDto dto = _mapper.Map<ReadToDoDto>(toDo);
        return new OkObjectResult(dto);
    }


    public IEnumerable<object> GetToDos(string plataforma, int skip, int take)
    {
        if (plataforma == "mobile")
        {
            return _context.ToDos.Select(todo => new { todo.Descricao, todo.StatusEnum }).Skip(skip).Take(take);
        }
        
        return _mapper.Map<List<ReadToDoDto>>(_context.ToDos).Skip(skip).Take(take);
    }
    
    
}
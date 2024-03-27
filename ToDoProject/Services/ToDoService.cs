using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoProject.Data;
using ToDoProject.Data.Dtos;
using ToDoProject.Enums;
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
        if (toDo == null) return new NotFoundResult();

        ReadToDoDto dto = _mapper.Map<ReadToDoDto>(toDo);
        return new OkObjectResult(dto);
    }
    
    public IEnumerable<object> GetToDos(string plataforma, int skip, int take, PrioridadeEnum prioridade, StatusEnum status)
    {
        IEnumerable<ToDoModel> models = _context.ToDos.Where(todo => todo.StatusEnum == status || todo.PrioridadeEnum == prioridade).Skip(skip).Take(take);

        if (plataforma.ToLower().Equals("mobile"))
        {
            return models.Select(todo => new { todo.Descricao, todo.StatusEnum });
        }
        else
        {
            return models;
        }
    }

    public IActionResult UpdateById(int id, UpdateToDoDto dto)
    {
        ToDoModel model = _context.ToDos.FirstOrDefault(todo => todo.Id == id);
        if (model == null) return new NotFoundResult();

        _mapper.Map(dto, model);
        _context.SaveChanges();

        return new NoContentResult();
    }

    public IActionResult UpdateTodoStatus(int id)
    {
        ToDoModel model = _context.ToDos.FirstOrDefault(todo => todo.Id == id);
        if (model == null) return new NotFoundResult();

        model.StatusEnum = model.StatusEnum == StatusEnum.Concluída ? StatusEnum.Pendente : StatusEnum.Concluída;
        _context.SaveChanges();

        return new NoContentResult();
    }

    public IActionResult DeleteToDo(int id)
    {
        ToDoModel model = _context.ToDos.Find(id);
        if (model == null) return new NotFoundResult();

        _context.Remove(model);
        _context.SaveChanges();
        return new NoContentResult();
    }
}
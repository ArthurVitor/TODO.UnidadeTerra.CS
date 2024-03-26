using Microsoft.AspNetCore.Mvc;
using ToDoProject.Data.Dtos;
using ToDoProject.Models;

namespace ToDoProject.Services.Interfaces;

public interface IToDoService
{
    IEnumerable<Object> GetToDos(string plataforma, int skip, int take);

    ToDoModel CreateToDo(CreateToDoDto dto);

    IActionResult GetToDoById(int id);
}
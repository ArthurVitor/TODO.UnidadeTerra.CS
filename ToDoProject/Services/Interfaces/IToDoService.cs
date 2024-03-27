using Microsoft.AspNetCore.Mvc;
using ToDoProject.Data.Dtos;
using ToDoProject.Enums;
using ToDoProject.Models;

namespace ToDoProject.Services.Interfaces;

public interface IToDoService
{
    IEnumerable<object> GetToDos(string plataforma, int skip, int take, PrioridadeEnum prioridade, StatusEnum status);

    ToDoModel CreateToDo(CreateToDoDto dto);

    IActionResult GetToDoById(int id);

    IActionResult UpdateById(int id, UpdateToDoDto dto);

    IActionResult UpdateTodoStatus(int id);

    IActionResult DeleteToDo(int id);
}
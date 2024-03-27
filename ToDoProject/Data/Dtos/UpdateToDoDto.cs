using System.ComponentModel.DataAnnotations;
using ToDoProject.Enums;

namespace ToDoProject.Data.Dtos;

public class UpdateToDoDto
{
    [Required(ErrorMessage = "É necessário preencher esse campo")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "É necessário preencher esse campo")]
    public PrioridadeEnum PrioridadeEnum { get; set; }
}
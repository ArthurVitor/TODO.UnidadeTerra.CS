using System.ComponentModel.DataAnnotations;
using ToDoProject.Enums;

namespace ToDoProject.Data.Dtos;

public class CreateToDoDto
{
    [Required(ErrorMessage = "É necessário preencher esse campo")]
    public string Descricao { get; set; }
    
    public PrioridadeEnum PrioridadeEnum { get; set; }
}
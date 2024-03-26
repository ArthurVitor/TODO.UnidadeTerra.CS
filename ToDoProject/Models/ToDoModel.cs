using System.ComponentModel.DataAnnotations;
using ToDoProject.Enums;

namespace ToDoProject.Models;

public class ToDoModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "É necessário preencher esse campo")]
    public string Descricao { get; set; }
    
    public DateTime DataAbertura { get; set; }
    
    public PrioridadeEnum PrioridadeEnum { get; set; }
    
    public StatusEnum StatusEnum { get; set; }
}
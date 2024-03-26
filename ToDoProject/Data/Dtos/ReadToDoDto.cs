using ToDoProject.Enums;

namespace ToDoProject.Data.Dtos;

public class ReadToDoDto
{
    public int Id { get; set; }
    
    public string Descricao { get; set; }
    
    public DateTime DataAbertura { get; set; }
    
    public PrioridadeEnum PrioridadeEnum { get; set; }
    
    public StatusEnum StatusEnum { get; set; }
}
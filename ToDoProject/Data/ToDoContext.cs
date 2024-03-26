using Microsoft.EntityFrameworkCore;
using ToDoProject.Models;

namespace ToDoProject.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> opts) : base(opts)
    {
        
    }
    
    public DbSet<ToDoModel> ToDos { get; set; }
}
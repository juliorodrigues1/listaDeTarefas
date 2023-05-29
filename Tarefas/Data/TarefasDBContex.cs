using Microsoft.EntityFrameworkCore;
using Tarefas.Models;

namespace Tarefas.Data;

public class TarefasDBContex : DbContext
{
    public TarefasDBContex(DbContextOptions<TarefasDBContex> options) : base(options) { }
    
    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
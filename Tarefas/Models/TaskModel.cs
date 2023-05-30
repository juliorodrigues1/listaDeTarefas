using Tarefas.Enums;

namespace Tarefas.Models;

public class TaskModel
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public StatusTask status { get; set; }
    public int? userId { get; set; }
    
    public virtual UserModel? user { get; set; }
}
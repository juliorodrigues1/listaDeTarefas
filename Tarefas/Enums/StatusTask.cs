using System.ComponentModel;

namespace Tarefas.Enums;

public enum StatusTask
{
    [Description("A fazer")]
    AFazer = 1,
    [Description("Em andamento")]
    EMAndamento = 2,
    [Description("Concluido")]
    Concluido = 3
}
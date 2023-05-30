using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;
using Tarefas.Repositories.Interfaces;

namespace Tarefas.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TarefasDBContex _dbContex;
    public TaskRepository(TarefasDBContex tarefasDbContex)
    {
        _dbContex = tarefasDbContex;
    }

    public async Task<List<TaskModel>> findAll()
    {
        return await _dbContex.Tasks
            .Include(x => x.user)
            .ToListAsync();

    }

    public async Task<TaskModel> findById(int id)
    {
        return await _dbContex.Tasks
            .Include(x => x.user)
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<TaskModel> create(TaskModel task)
    {
        await _dbContex.Tasks.AddAsync(task);
        await _dbContex.SaveChangesAsync();

        return task;
    }

    public async Task<TaskModel> update(TaskModel task, int id)
    {
        TaskModel taskById = await findById(id);

        if (taskById == null)
        {
            throw new Exception($"Tarefa para o ID:${id} não foi encontrado!");
        }

        taskById.name = task.name;
        taskById.description = task.description;
        taskById.status = task.status;
        taskById.userId = task.userId;

        _dbContex.Tasks.Update(taskById);
        await _dbContex.SaveChangesAsync();

        return taskById;
    }

    public async Task<bool> delete(int id)
    {
        TaskModel taskById = await findById(id);

        if (taskById == null)
        {
            throw new Exception($"tarefa para o ID:${id} não foi encontrado!");
        }

        _dbContex.Tasks.Remove(taskById);
        await _dbContex.SaveChangesAsync();

        return true;
    }
}
using Tarefas.Models;

namespace Tarefas.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskModel>> findAll();
    Task<TaskModel> findById(int id);
    Task<TaskModel> create(TaskModel task);
    Task<TaskModel> update(TaskModel task, int id);
    Task<bool> delete(int id);
}
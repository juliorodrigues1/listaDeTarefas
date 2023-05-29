using Tarefas.Models;

namespace Tarefas.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> findAll();
    Task<UserModel> findById(int id);
    Task<UserModel> create(UserModel user);
    Task<UserModel> update(UserModel user, int id);
    Task<bool> delete(int id);
}
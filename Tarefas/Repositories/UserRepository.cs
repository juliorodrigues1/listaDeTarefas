using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Models;
using Tarefas.Repositories.Interfaces;

namespace Tarefas.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TarefasDBContex _dbContex;
    public UserRepository(TarefasDBContex tarefasDbContex)
    {
        _dbContex = tarefasDbContex;
    }

    public async Task<List<UserModel>> findAll()
    {
        return await _dbContex.Users.ToListAsync();

    }

    public async Task<UserModel> findById(int id)
    {
        return await _dbContex.Users.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<UserModel> create(UserModel user)
    {
        await _dbContex.Users.AddAsync(user);
        await _dbContex.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> update(UserModel user, int id)
    {
        UserModel userById = await findById(id);

        if (userById == null)
        {
            throw new Exception($"Usuário para o ID:${id} não foi encontrado!");
        }

        userById.name = user.name;
        userById.email = user.email;

        _dbContex.Users.Update(userById);
        await _dbContex.SaveChangesAsync();

        return userById;
    }

    public async Task<bool> delete(int id)
    {
        UserModel userById = await findById(id);

        if (userById == null)
        {
            throw new Exception($"Usuário para o ID:${id} não foi encontrado!");
        }

        _dbContex.Users.Remove(userById);
        await _dbContex.SaveChangesAsync();

        return true;
    }
}
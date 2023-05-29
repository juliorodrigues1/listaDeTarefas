using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Repositories.Interfaces;

namespace Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> findAll()
        {
            List<UserModel> users = await _userRepository.findAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> findById(int id)
        {
            UserModel user = await _userRepository.findById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> create([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.create(userModel);

            return Ok(user);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> update([FromBody] UserModel userModel, int id)
        {
            userModel.id = id;
            UserModel user = await _userRepository.update(userModel, id);

            return Ok(user);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> delete(int id)
        {
            bool delete = await _userRepository.delete(id);

            return Ok(delete);
        }
    }
}


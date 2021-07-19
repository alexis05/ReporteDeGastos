using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using GastosAPI.Core;
using GastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GastosAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserBody user)
        {
            User newUser = new User(user.FirstName, user.LastName, user.Id);
            var id = await _userRepository.Create(newUser);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userRepository.Get(id);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userRepository.Get();

            return new JsonResult(result);
        }
    }

    [DataContract(Name = "UserBody")]
    public class UserBody
    {
        [DataMember(Name = "firstName", IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName", IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(Name = "id", IsRequired = true)]
        public int Id { get; set; }
    }
}

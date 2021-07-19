using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using GastosAPI.Core;
using GastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GastosAPI.Controllers
{
    
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountRepository;
        private readonly IUser _userRepository;

        public AccountController(IAccount accountRepository, IUser userRepository)
        {
            this._accountRepository = accountRepository;
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountBody accountBody)
        {
            var user = await _userRepository.Get(accountBody.Id);
            if (user.Id == accountBody.Id)
            {
                Account newAccount = new Account(user.Uuid.ToString());
                var id = await _accountRepository.Create(newAccount);
                return new JsonResult(id.ToString());

            }
            return new JsonResult(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _accountRepository.Get(id);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _accountRepository.Get();

            return new JsonResult(result);
        }
    }

    [DataContract(Name = "AccountBody")]
    public class AccountBody
    {
        [DataMember(Name = "id", IsRequired = true)]
        public int Id { get; set; }
    }
    

}

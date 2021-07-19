using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using GastosAPI.Core;
using GastosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GastosAPI.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _transaction;

        public TransactionController(ITransaction transaction)
        {
            this._transaction = transaction;
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionBody transactionBody)
        {
            
            Transaction transaction = new Transaction(transactionBody.Description, ); 
            Account newUser = new User(user.FirstName, user.LastName, user.Id, Core.Account.Position.None);
            var id = await _transaction.Create(newUser);

            return new JsonResult(id.ToString());
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await _transaction.Get(id);

            return new JsonResult(car);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _transaction.Get();

            return new JsonResult(cars);
        }
        */

    }

    [DataContract(Name = "TransactionBody")]
    public class TransactionBody
    {
        [DataMember(Name = "description", IsRequired = true)]
        public string Description { get; set; }
        [DataMember(Name = "lastName", IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(Name = "id", IsRequired = true)]
        public int Id { get; set; }
    }
}

using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using GastosAPI.Core;
using GastosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionBody transactionBody)
        {
            
            Transaction newTransaction = new Transaction(transactionBody.Description, transactionBody.Account, transactionBody.Amount); 
            var id = await _transaction.Create(newTransaction);

            return new JsonResult(id.ToString());
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ObjectId id)
        {
            var result = await _transaction.Get(id);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _transaction.Get();

            return new JsonResult(result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterTransactions([FromBody] TransactionFilterBody transactionFilterBody)
        {

            DateTime toDate = DateTime.ParseExact(transactionFilterBody.To, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime fromDate = DateTime.ParseExact(transactionFilterBody.From, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            var result = await _transaction.Get();

            result = result.Where(x => x.date.Date >= fromDate && x.date.Date <= toDate);
            return new JsonResult(result);
        }


    }

    [DataContract(Name = "TransactionBody")]
    public class TransactionBody
    {
        [DataMember(Name = "description", IsRequired = true)]
        public string Description { get; set; }
        [DataMember(Name = "account", IsRequired = true)]
        public string Account { get; set; }
        [DataMember(Name = "amount", IsRequired = true)]
        public decimal Amount { get; set; }
    }

    [DataContract(Name = "TransactionFilterBody")]
    public class TransactionFilterBody
    {
        [DataMember(Name = "to", IsRequired = true)]
        public string To { get; set; }
        [DataMember(Name = "from", IsRequired = true)]
        public string From { get; set; }
    }
}

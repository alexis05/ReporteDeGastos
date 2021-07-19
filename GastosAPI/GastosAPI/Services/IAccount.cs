using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GastosAPI.Core;
using MongoDB.Bson;

namespace GastosAPI.Services
{
    public interface IAccount
    {
        // Create
        Task<string> Create(Account account);

        // Read
        Task<Account> Get(string id);
        Task<IEnumerable<Account>> Get();

        //Update
        Task<bool> Update(string id, Account account);

        //Delete
        Task<bool> Delete(string id);
    }
}

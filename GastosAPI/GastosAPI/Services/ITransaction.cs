using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GastosAPI.Core;
using MongoDB.Bson;

namespace GastosAPI.Services
{
    public interface ITransaction
    {
        // Create
        Task<ObjectId> Create(Transaction transaction);

        // Read
        Task<Transaction> Get(ObjectId id);
        Task<IEnumerable<Transaction>> Get();

        //Update
        Task<bool> Update(ObjectId objectId, Transaction transaction);

        //Delete
        Task<bool> Delete(ObjectId objectId);
    }
}

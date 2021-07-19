using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GastosAPI.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GastosAPI.Services
{
    public class TransactionRepository : ITransaction
    {
        private readonly IMongoCollection<Transaction> _transaction;

        public TransactionRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Baru");
            var collection = database.GetCollection<Transaction>(nameof(Transaction));

            _transaction = collection;
        }

        public async Task<ObjectId> Create(Transaction transaction)
        {
            await _transaction.InsertOneAsync(transaction);

            return transaction.Uuid;
        }

        public Task<bool> Delete(ObjectId objectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> Get(ObjectId id)
        {
            var filter = Builders<Transaction>.Filter.Eq(u => u.Uuid, id);
            var result = await _transaction.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Transaction>> Get()
        {
            var result = await _transaction.Find(_ => true).ToListAsync();

            return result;
        }

        public Task<IEnumerable<Transaction>> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ObjectId objectId, Transaction transaction)
        {
            throw new NotImplementedException();
        }

    }
}

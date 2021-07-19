using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GastosAPI.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GastosAPI.Services
{
    public class AccountRepository : IAccount
    {
        private readonly IMongoCollection<Account> _account;

        public AccountRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Baru");
            var collection = database.GetCollection<Account>(nameof(Account));

            _account = collection;
        }

        public async Task<string> Create(Account account)
        {
            await _account.InsertOneAsync(account);
            return account.account;
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> Get()
        {
            var result = await _account.Find(_ => true).ToListAsync();

            return result;
        }

        public async Task<Account> Get(string id)
        {
            var filter = Builders<Account>.Filter.Eq(u => u.account, id);
            var result = await _account.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public Task<IEnumerable<Account>> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, Account account)
        {
            throw new NotImplementedException();
        }

    }
}

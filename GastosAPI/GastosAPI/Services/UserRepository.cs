using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GastosAPI.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GastosAPI.Services
{
    public class UserRepository : IUser
    {
        private readonly IMongoCollection<User> _user;

        public UserRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Baru");
            var collection = database.GetCollection<User>(nameof(User));

            _user = collection;
        }

        public async Task<ObjectId> Create(User user)
        {
            await _user.InsertOneAsync(user);
            return user.Uuid;
        }

        public Task<bool> Delete(ObjectId objectId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(int id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            var user = await _user.Find(filter).FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var user = await _user.Find(_ => true).ToListAsync();

            return user;
        }

        public Task<IEnumerable<User>> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ObjectId objectId, User user)
        {
            throw new NotImplementedException();
        }
    }
}

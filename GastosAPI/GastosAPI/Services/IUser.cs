using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GastosAPI.Core;
using MongoDB.Bson;

namespace GastosAPI.Services
{
    public interface IUser
    {
        // Create
        Task<ObjectId> Create(User user);

        // Read
        Task<User> Get(int id);
        Task<IEnumerable<User>> Get();
        Task<IEnumerable<User>> GetById();

        //Update
        Task<bool> Update(ObjectId objectId, User user);

        //Delete
        Task<bool> Delete(ObjectId objectId);
    }
}

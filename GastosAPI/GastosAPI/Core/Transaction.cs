using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GastosAPI.Core
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Uuid { get; set; }

        public string description { get; set; }
        public string account { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }

        internal Transaction(string description, string account, decimal total)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description is required");
            if (account == null) throw new Exception("Account cannot be null");
            if (total <= 0) throw new Exception("The amount must be greater than 0.");

            this.description = description;
            this.account = account;
            this.total = total;
            this.date = DateTime.Now;
        }

    }
}

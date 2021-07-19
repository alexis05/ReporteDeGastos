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

        public string description;
        public Account account;
        public DateTime date;
        public decimal total;

        internal Transaction(string description, Account account, decimal total)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description is required");
            if (account == null) throw new Exception("Account cannot be null");
            if (total <= 0) throw new Exception("The amount must be greater than 0.");

            this.description = description;
            this.account = account;
            this.total = total;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public Account Account
        {
            get
            {
                return this.account;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public decimal Total
        {
            get
            {
                return this.total;
            }
        }


    }
}

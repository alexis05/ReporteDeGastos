using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GastosAPI.Core
{

    public class User
    {
        public enum Position
        {
            None,
            Accounting,
            HumanResources,
            Technology
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Uuid { get; set; }
        public int Id { get; set; }
        public string first_name;
        public string last_name;
        public Position position = Position.None;
        public DateTime created;

        internal User(string first_name, string last_name, int id)
        {
            if (string.IsNullOrWhiteSpace(first_name)) throw new Exception("The first name is required.");
            if (string.IsNullOrWhiteSpace(last_name)) throw new Exception("The last name is required.");
            if (id <= 0 ) throw new Exception("The ID is required.");

            this.first_name = first_name;
            this.last_name = last_name;
            this.Id = id;
            this.position = Position.None;
            this.created = DateTime.Now;
        }

        public string FirstName
        {
            get
            {
                return this.first_name;
            }
        }

        public string LastName
        {
            get
            {
                return this.last_name;
            }
        }

        public string FullName
        {
            get
            {
                return $"{this.first_name } {this.last_name}";
            }
        }

        public DateTime Created
        {
            get
            {
                return this.created;
            }
        }

        internal void ChangeFirstName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("The first name is required.");

            this.first_name = name;
        }

        internal void ChangeLastName(string last_name)
        {
            if (string.IsNullOrWhiteSpace(last_name)) throw new Exception("The last name is required.");

            this.last_name = last_name;
        }

        internal void ChangePosition(Position position)
        {
            this.position = position;
        }
    }
}

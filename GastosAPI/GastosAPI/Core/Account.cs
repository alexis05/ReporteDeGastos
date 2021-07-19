using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GastosAPI.Core
{
    public class Account
    {
        public string user { get; set; }
        public string account { get; set; }

        internal Account(string user)
        {
            this.user = user;
            this.account = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString();
        }
    }
}

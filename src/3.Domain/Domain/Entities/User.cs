
using System.Collections.Generic;
using MongoDB.Bson;

namespace Domain.Entities
{
    public class User : Base
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public ICollection<CashIn> CashIns { get; private set; }
        public ICollection<CashOut> CashOuts { get; private set; }

        public User(ObjectId id, string email, string password, string name, ICollection<CashIn> cashIns, ICollection<CashOut> cashOuts)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            CashIns = cashIns;
            CashOuts = cashOuts;
        }

        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}

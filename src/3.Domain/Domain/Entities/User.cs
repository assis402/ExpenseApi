using System;
using System.Collections.Generic;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class User : Base
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public UserRole Role { get; private set; }
        private ICollection<CashIn> _cashIns;
        public ICollection<CashIn> CashIns
        {
            get { return _cashIns ?? (_cashIns = new List<CashIn>()); }
            private set { _cashIns = value; }
        }
        private ICollection<CashOut> _cashOuts;
        public ICollection<CashOut> CashOuts
        {
            get { return _cashOuts ?? (_cashOuts = new List<CashOut>()); }
            private set { _cashOuts = value; }
        }
        
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

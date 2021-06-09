using System;
using MongoDB.Bson;

namespace Domain.Entities
{
    public class CashIn : Base
    {
        public string Description { get; private set; }
        public int Month { get; private set; }
        public double Value { get; private set; }

        public CashIn(string id, string description, int month, double value, DateTime creationDate)
        {
            Id = ObjectId.Parse(id);
            Description = description;
            Month = month;
            Value = value;
            CreationDate = creationDate; 
        }

        public CashIn(string description, int month, double value, DateTime creationDate)
        {
            Description = description;
            Month = month;
            Value = value;
            CreationDate = creationDate;
        }

        public void SetId(){
            Id = ObjectId.GenerateNewId();
        }

        public void Update(CashIn changedCashIn)
        {
            Description = changedCashIn.Description;
            Value = changedCashIn.Value;
        }
    }
}

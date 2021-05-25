using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class CashIn
    {
        [BsonId]
        public ObjectId? Id { get; set; }
        public string Description { get; private set; }
        public int Month { get; private set; }
        public double Value { get; private set; }
        
        public CashIn(ObjectId id, string description, int month, double value)
        {
            Id = id;
            Description = description;
            Month = month;
            Value = value;
        }

        public CashIn(string description, int month, double value)
        {
            Description = description;
            Month = month;
            Value = value;
        }
    }
}

using MongoDB.Bson;

namespace Domain.Entities
{
    public class CashOut : Base
    {
        public string Description { get; private set; }
        public int Month { get; private set; }
        public double Value { get; set; }

        public CashOut(ObjectId id, string description, int month, double value)
        {
            Id = id;
            Description = description;
            Month = month;
            Value = value;
        }

        public CashOut(string description, int month, double value)
        {
            Description = description;
            Month = month;
            Value = value;
        }
    }
}

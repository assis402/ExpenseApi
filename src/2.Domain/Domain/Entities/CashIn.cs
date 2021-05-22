namespace Domain.Entities
{
    public class CashIn
    {
        public string Description { get; private set; }
        public int Month { get; private set; }
        public double Value { get; private set; }
        public CashIn(string description, int month, double value)
        {
            Description = description;
            Month = month;
            Value = value;
        }
    }
}

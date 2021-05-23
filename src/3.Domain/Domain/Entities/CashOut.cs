namespace Domain.Entities
{
    public class CashOut
    {
        public string Description { get; private set; }
        public int Month { get; private set; }
        public double Value { get; private set; }
        public CashOut(string description, int month, double value)
        {
            Description = description;
            Month = month;
            Value = value;
        }
    }
}

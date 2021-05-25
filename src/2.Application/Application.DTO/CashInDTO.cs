namespace Application.DTO
{
    public class CashInDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public double Value { get; set; }

        public CashInDTO()
        {
        }
    }
}

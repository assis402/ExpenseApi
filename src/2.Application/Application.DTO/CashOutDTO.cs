using System;

namespace Application.DTO
{
    public class CashOutDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public double Value { get; set; }
        public DateTime CreationDate { get; set; }

        public CashOutDTO()
        {
        }
    }
}

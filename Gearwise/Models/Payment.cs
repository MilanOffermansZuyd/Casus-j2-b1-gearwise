namespace Gearwise.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int Count { get; set; }
    }
}

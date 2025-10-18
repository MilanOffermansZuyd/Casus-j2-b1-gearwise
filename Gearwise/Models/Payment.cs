namespace Gearwise.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int Count { get; set; }

        public Payment(int id, PaymentOption paymentOption, int count)
        {
            Id = id;
            PaymentOption = paymentOption;
            Count = count;
        }
    }
}

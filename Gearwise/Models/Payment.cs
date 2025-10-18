namespace Gearwise.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int PaymentOptionId { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int Count { get; set; }

        public Payment() { }

        public Payment(int paymentId, int paymentOptionId, int count)
        {
            PaymentId = paymentId;
            PaymentOptionId = paymentOptionId;
            Count = count;
        }
    }
}

namespace Gearwise.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int Count { get; set; }

        public Payment(int paymentId, PaymentOption paymentOption, int count)
        {
            PaymentId = paymentId;
            PaymentOption = paymentOption;
            Count = count;
        }
    }
}

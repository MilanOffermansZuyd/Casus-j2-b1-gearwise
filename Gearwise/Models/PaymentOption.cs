namespace Gearwise.Models
{
    public class PaymentOption
    {
        public int PaymentOptionId { get; set; }
        public string Name { get; set; }

        public PaymentOption() { }
        public PaymentOption(int paymentOptionid, string name)
        {
            PaymentOptionId = paymentOptionid;
            Name = name;
        }
    }
}

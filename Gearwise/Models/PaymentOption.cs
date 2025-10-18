namespace Gearwise.Models
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PaymentOption(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

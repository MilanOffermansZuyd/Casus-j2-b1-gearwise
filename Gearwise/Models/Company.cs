namespace Gearwise.Models
{
    public class Company : User
    {
        public string CompanyName { get; set; }
        public string KvKNumber { get; set; }

        public Company(int id, string firstName, string lastName, string email, string password, int? phone, RoleStates roleState, string companyName, string kvkNumber):
            base(id, firstName, lastName, email, password, phone, roleState)
        {
            CompanyName = companyName;
            KvKNumber = kvkNumber;
        }
    }
}

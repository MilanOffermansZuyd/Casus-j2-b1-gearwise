using Gearwise.Models.Enums;

namespace Gearwise.Models
{
    public class Secretary : User
    {
        public Secretary(int id, string firstName, string lastName, string email, string password, int? phone)
            : base(id, firstName, lastName, email, password, phone, RoleStates.Secretary)
        {
        }
    }
}

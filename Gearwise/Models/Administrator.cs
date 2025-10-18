using Gearwise.Models.Enums;

namespace Gearwise.Models
{
    public class Administrator : User
    {
        public Administrator(int id, string firstName, string lastName, string email, string password, int? phone)
            : base(id, firstName, lastName, email, password, phone, RoleStates.Admin)
        {
        }
    }
}

using Gearwise.Models.Enums;

namespace Gearwise.Models
{
    public class Individual : User
    {
        public Individual(int id, string firstName, string lastName, string email, string password, int? phone, RoleStates roleState)
            : base(id, firstName, lastName, email, password, phone, roleState)
        {
        }
    }
}

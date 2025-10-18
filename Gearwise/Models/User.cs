using Gearwise.Models.Enums;

namespace Gearwise.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public RoleStates RoleStates { get; set; }

        public User() { }

        public User(int id, string firstName, string lastName, string email, string password, int? phone, RoleStates roleState)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            RoleStates = roleState;
        }
    }
}

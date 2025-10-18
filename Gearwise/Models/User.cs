using Gearwise.Models.Enums;

namespace Gearwise.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public RoleStates RoleStates { get; set; }

        public List<Advert> Adverts { get; set; } = new List<Advert>();

        public User() { }

        public User(int userId, string firstName, string lastName, string email, string password, string? phone, RoleStates roleState)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            RoleStates = roleState;
        }
    }
}

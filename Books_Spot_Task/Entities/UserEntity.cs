using System.ComponentModel.DataAnnotations;
using Books_Spot_Task.Enums;

namespace Books_Spot_Task.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? LibraryCardId { get; set; }
        public UserRole UserRole { get; set; }
        public string? Password { get; set; }

        public UserEntity(string firstName, string lastName, string email, string phoneNumber, string address, Guid readerId, UserRole userRole, string libraryCardId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Id = readerId;
            UserRole = userRole;
            LibraryCardId = libraryCardId;
        }

        public UserEntity()
        {

        }
    }
}

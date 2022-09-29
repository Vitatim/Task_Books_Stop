using System.ComponentModel.DataAnnotations;
using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;

namespace Books_Spot_Task.Models
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid Id { get; set; }
        public string? LibraryCardId { get; set; }
        public UserRole UserRole { get; set; }
        public string? Password { get; set; }

        public UserDto(string firstName, string lastName, string email, string phoneNumber, string address, Guid Id, UserRole userRole, string libraryCardId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Id = Id;
            UserRole = userRole;
            LibraryCardId = libraryCardId;
        }

        public UserDto()
        {

        }

        public UserDto(UserEntity userRetrieved)
        {
            FirstName = userRetrieved.FirstName;
            LastName = userRetrieved.LastName;
            Email = userRetrieved.Email;
            PhoneNumber = userRetrieved.PhoneNumber;
            Address = userRetrieved.Address;
            Id = userRetrieved.Id;
            UserRole = userRetrieved.UserRole;
            LibraryCardId = userRetrieved.LibraryCardId;
        }
    }
}

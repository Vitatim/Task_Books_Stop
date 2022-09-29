using Books_Spot_Task.DbContexts;
using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;
using Books_Spot_Task.Interfaces;
using Books_Spot_Task.Models;

namespace Books_Spot_Task.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DataBaseContext _dataBaseContext;
        public UserService(DataBaseContext dataBaseContext, IUserRepository userRepository)
        {
            _dataBaseContext = dataBaseContext;
            _userRepository = userRepository;
        }
        public UserDto GetUser(Guid id)
        {
            return _userRepository.GetUser(id);
        }

        public List<UserDto> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void RegisterUser(RegistrationFormDto registration)
        {
            var userRole = UserRole.Reader;
            if (registration.Email.Contains("@booksstop.com"))
                {
                userRole = UserRole.Admin;
                }
            var user = _userRepository.GetUserByEmail(registration.Email);
            if (user != null)
            {
                throw new Exception("The email entered has already been registered.");
            }
            var newUser = new UserEntity()
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.Email,
                PhoneNumber = registration.PhoneNumber,
                Address = registration.Address,
                Password = registration.Password,
                Id = Guid.NewGuid(),
                UserRole = userRole
            };
            _dataBaseContext.Add(newUser);
            _dataBaseContext.SaveChanges();
        }

        public void AssignLibraryCard(string email, string libraryCardId)
        {
            var user = _dataBaseContext.Users.FirstOrDefault(user => user.Email == email);
            if (user == null)
            {
                throw new Exception("Please enter a valid email address, or register the user.");
            }
            var userLibraryCard = _dataBaseContext.Users.FirstOrDefault(card => card.LibraryCardId == libraryCardId);
            if (userLibraryCard != null)
            {
                throw new Exception("Please note the library card ID has already been registered.");
            }
            user.LibraryCardId = libraryCardId;
            _dataBaseContext.SaveChanges();
        }

        public List<BookingDto> GetUserBookings(string libraryCardId)
        {
            return _userRepository.GetUserBookings(libraryCardId);
        } 
    }
}

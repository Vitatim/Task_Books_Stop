using Books_Spot_Task.DbContexts;
using Books_Spot_Task.Interfaces;
using Books_Spot_Task.Models;

namespace Books_Spot_Task.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public UserDto GetUser(Guid id)
        {
            var userRetrieved = _dataBaseContext.Users.FirstOrDefault(user => user.Id == id);
            if (userRetrieved == null)
            {
                throw new Exception("The user ID entered has not been found.");
            }
            return new UserDto(userRetrieved);
        }
        public List<UserDto> GetAllUsers()
        {
            var userList = _dataBaseContext.Users.Select(user => new UserDto(user)).ToList();
            return userList;
        }

        public UserDto GetUserByEmail(string email)
        {
            var user = _dataBaseContext.Users.FirstOrDefault(user => user.Email == email);
            if (user == null)
            {
                return null;
            }
            return new UserDto(user);
        }
        public List<BookingDto> GetUserBookings(string libraryCardId)
        {
            var userBooking = _dataBaseContext.Bookings.Where(booking => booking.LibraryCardId == libraryCardId).Select(booking => new BookingDto(booking)).ToList();
            return userBooking;
        }

    }
}

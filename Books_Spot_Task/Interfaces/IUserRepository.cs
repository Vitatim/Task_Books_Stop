using Books_Spot_Task.Models;

namespace Books_Spot_Task.Interfaces
{
    public interface IUserRepository
    {
        UserDto GetUser(Guid id);
        List<UserDto> GetAllUsers();
        UserDto GetUserByEmail(string email);
        List<BookingDto> GetUserBookings(string libraryCardId);
    }
}

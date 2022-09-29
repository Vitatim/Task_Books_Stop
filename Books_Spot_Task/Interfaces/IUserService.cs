using Books_Spot_Task.Models;

namespace Books_Spot_Task.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(RegistrationFormDto registration);
        void AssignLibraryCard(string email, string libraryCardId);
        UserDto GetUser(Guid id);
        List<UserDto> GetAllUsers();
        List<BookingDto> GetUserBookings(string libraryCardId);
    }
}

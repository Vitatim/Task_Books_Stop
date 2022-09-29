using Books_Spot_Task.DbContexts;
using Books_Spot_Task.Interfaces;

namespace Books_Spot_Task.Repositories
{
    public class BookingRepository: IBookingRepository
    {
            private readonly DataBaseContext _dataBaseContext;
            public BookingRepository(DataBaseContext dataBaseContext)
            {
                _dataBaseContext = dataBaseContext;
            }
            public void CheckLateBookings(string libraryCardId)
        {
            var bookingLateCheck = _dataBaseContext.Bookings.Where(booking => booking.LibraryCardId == libraryCardId && DateTime.UtcNow.AddDays(-30) > booking.DateBorrowed).ToList();
            if (bookingLateCheck.Count > 0)
            {
                throw new Exception("Please note that you are late to return 1 or more books, therefore, you cannot borrow more books until the late ones are returned");
            }
        }
    }
}

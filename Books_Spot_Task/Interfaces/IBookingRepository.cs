namespace Books_Spot_Task.Interfaces
{
    public interface IBookingRepository
    {
        void CheckLateBookings(string libraryCardId);
    }
}

using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;

namespace Books_Spot_Task.Models
{
    public class BookingDto
    {
        public Guid BookingCode { get; set; }
        public string LibraryCardId { get; set; }
        public string IsbnCode { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DateReserved { get; set; }
        public DateTime? DateReturned { get; set; }

        public BookingDto()
        {

        }

        public BookingDto(BookingEntity booking)
        {
            BookingCode = booking.BookingCode;
            LibraryCardId = booking.LibraryCardId;
            IsbnCode = booking.IsbnCode;
            DateBorrowed = booking.DateBorrowed;
            DateReserved = booking.DateReserved;
            DateReturned = booking.DateReturned;

        }
    }
}

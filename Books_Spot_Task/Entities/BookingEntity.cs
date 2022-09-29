using System.ComponentModel.DataAnnotations;
using Books_Spot_Task.Enums;

namespace Books_Spot_Task.Entities
{
    public class BookingEntity
    {
        [Key]
        public Guid BookingCode { get; set; }
        public string LibraryCardId { get; set; }
        public string IsbnCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateBorrowed { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateReserved { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateReturned { get; set; }

        public BookingEntity()
        {

        }
    }
}

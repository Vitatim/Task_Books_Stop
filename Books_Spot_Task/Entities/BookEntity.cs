using System.ComponentModel.DataAnnotations;
using Books_Spot_Task.Enums;

namespace Books_Spot_Task.Entities
{
    public class BookEntity
    {
        [Key]
        public string IsbnCode { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public string Genre { get; set; }
        public BookStatus? BookStatus { get; set; }

        public BookEntity(string title, string authorName, string publisher, DateTime publishingDate, string genre, string isbnCode, BookStatus? bookStatus) 
        {
            Title = title;
            AuthorName = authorName;
            Publisher = publisher;
            PublishingDate = publishingDate;
            Genre = genre;
            IsbnCode = isbnCode;
            BookStatus = bookStatus;
        }
    }
}

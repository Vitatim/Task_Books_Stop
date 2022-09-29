using System.ComponentModel.DataAnnotations;
using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;

namespace Books_Spot_Task.Models
{
    public class BookDto
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishingDate { get; set; }
        public string Genre { get; set; }
        public string IsbnCode { get; set; }
        public BookStatus? BookStatus { get; set; }


        public BookDto(string title, string authorName, string publisher, DateTime publishingDate, string genre, string isbnCode, BookStatus bookStatus)
        {
            Title = title;
            AuthorName = authorName;
            Publisher = publisher;
            PublishingDate = publishingDate;
            Genre = genre;
            IsbnCode = isbnCode;
            BookStatus = bookStatus;
        }
        public BookDto()
        {

        }

        public BookDto(BookEntity bookRetrieved)
        {
            Title = bookRetrieved.Title;
            AuthorName = bookRetrieved.AuthorName;
            Publisher = bookRetrieved.Publisher;
            PublishingDate = bookRetrieved.PublishingDate;
            Genre = bookRetrieved.Genre;
            IsbnCode = bookRetrieved.IsbnCode;
            BookStatus = bookRetrieved.BookStatus;
        }
    }
}

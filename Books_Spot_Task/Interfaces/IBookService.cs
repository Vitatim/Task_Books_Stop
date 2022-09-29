using Books_Spot_Task.Enums;
using Books_Spot_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books_Spot_Task.Interfaces
{
    public interface IBookService
    {
        BookingDto BookBorrowing(string libraryCardId, string isbnCode);
        BookingDto BookReservation(string libraryCardId, string isbnCode);
        BookingDto BookReturn(Guid bookingCode);
        BookingDto BookTermProlong(Guid bookingCode);
        BookDto GetBook(string isbnCode);
        List<BookDto> SearchBookByTerm(string? searchTerm);
        List<BookDto> SearchBookByYear(int searchYear);
        List<BookDto> SearchBookByGenre(string genre);
        List<BookDto> SearchBookByAvailability(BookStatus? availability);
        List<GenreDto> GetAllGenres();
        List<BookDto> GetAllBooks();
        void CheckForLateBooks();
        void CheckReservationTimeOut();
    }
}

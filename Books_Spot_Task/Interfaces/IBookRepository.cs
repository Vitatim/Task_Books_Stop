using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;
using Books_Spot_Task.Models;

namespace Books_Spot_Task.Interfaces
{
    public interface IBookRepository
    {
        BookEntity GetBookByIsbnCode(string isbnCode);
        List<BookDto> SearchBookByTerm(string? searchTerm);
        List<BookDto> SearchBookByYear(int searchYear);
        List<GenreDto> GetAllGenres();
        List<BookDto> SearchBookByGenre(string genre);
        List<BookDto> SearchBookByAvailability(BookStatus? availability);
        List<BookDto> GetAllBooks();



    }
}

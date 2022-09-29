using Books_Spot_Task.DbContexts;
using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;
using Books_Spot_Task.Interfaces;
using Books_Spot_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Spot_Task.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public BookRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public BookEntity GetBookByIsbnCode(string isbnCode)
        {
            var book = _dataBaseContext.Books.FirstOrDefault(book => book.IsbnCode == isbnCode);
            if (book == null)
            {
                throw new Exception("The ISBN Code entered has not been found.");
            }
            return book;
        }
        public List<BookDto> SearchBookByTerm(string? searchTerm)
        {
            searchTerm = searchTerm.Trim();
            return _dataBaseContext.Books.Where(book =>
                EF.Functions.ILike(book.Title, $"%{searchTerm}%")
                || EF.Functions.ILike(book.AuthorName, $"%{searchTerm}%")
                || EF.Functions.ILike(book.IsbnCode, $"%{searchTerm}%")
                || EF.Functions.ILike(book.Publisher, $"%{searchTerm}%"))
                .OrderBy(book => book.Title).Select(book => new BookDto(book)).ToList();
        }
        public List<BookDto> SearchBookByYear(int searchYear)
        {
            var yearStart = new DateTime(searchYear, 1, 1).ToUniversalTime();
            var yearEnd = new DateTime(searchYear, 12, 31).ToUniversalTime();
            return _dataBaseContext.Books.Where(book => book.PublishingDate < yearEnd && book.PublishingDate > yearStart).Select(book => new BookDto(book)).ToList();
        }
        public List<GenreDto> GetAllGenres()
        {
            var genreList = _dataBaseContext.Genres.Select(genre => new GenreDto(genre)).ToList();
            return genreList;
        }
        public List<BookDto> SearchBookByGenre(string genre)
        {
            genre = genre.Trim();
            return _dataBaseContext.Books.Where(book =>
                EF.Functions.ILike(book.Genre, $"%{genre}%")).OrderBy(book => book.Genre).Select(book => new BookDto(book)).ToList();
        }
        public List<BookDto> SearchBookByAvailability(BookStatus? availability)
        {
            return _dataBaseContext.Books.Where(book => book.BookStatus == availability).OrderBy(book => book.BookStatus).Select(book => new BookDto(book)).ToList();
        }
        public List<BookDto> GetAllBooks()
        {
            var booksList = _dataBaseContext.Books.Select(book => new BookDto(book)).ToList();
            return booksList;
        }
        
    }
}

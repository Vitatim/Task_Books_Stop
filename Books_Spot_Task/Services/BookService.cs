using Books_Spot_Task.DbContexts;
using Books_Spot_Task.Entities;
using Books_Spot_Task.Enums;
using Books_Spot_Task.Interfaces;
using Books_Spot_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books_Spot_Task.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly DataBaseContext _dataBaseContext;

        public BookService(IBookRepository bookRepository, DataBaseContext dataBaseContext, IBookingRepository bookingRepository)
        {
            _bookRepository = bookRepository;
            _dataBaseContext = dataBaseContext;
            _bookingRepository = bookingRepository;
        }
        public BookDto GetBook(string isbnCode)
        {
            return new BookDto(_bookRepository.GetBookByIsbnCode(isbnCode));
        }
        public List<BookDto> SearchBookByTerm(string? searchTerm)
        {
            searchTerm = searchTerm.Trim();
            return _bookRepository.SearchBookByTerm(searchTerm);
        }

        public List<BookDto> SearchBookByYear(int searchYear)
        {
            return _bookRepository.SearchBookByYear(searchYear);
        }

        public List<GenreDto> GetAllGenres()
        {
            return _bookRepository.GetAllGenres();
        }

        public List<BookDto> SearchBookByGenre(string genre)
        {
            return _bookRepository.SearchBookByGenre(genre);
        }

        public List<BookDto> SearchBookByAvailability(BookStatus? availability)
        {
            return _bookRepository.SearchBookByAvailability(availability);
        }

        public List<BookDto> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
        public BookingDto BookBorrowing(string libraryCardId, string isbnCode)
        {
            _bookingRepository.CheckLateBookings(libraryCardId);

            var book = _bookRepository.GetBookByIsbnCode(isbnCode);

            if (book.BookStatus == BookStatus.Unavailable)
            {
                throw new Exception("Please note the book is currently unavailable for borrowing.");
            }
            var booking = new BookingEntity()
            {
                LibraryCardId = libraryCardId,
                IsbnCode = isbnCode,
                BookingCode = Guid.NewGuid(),
                DateBorrowed = DateTime.UtcNow,
            };
            book.BookStatus = BookStatus.Unavailable;
            _dataBaseContext.Add(booking);
            _dataBaseContext.SaveChanges();
            return new BookingDto(booking);
        }
        public BookingDto BookReservation(string libraryCardId, string isbnCode)
        {
            _bookingRepository.CheckLateBookings(libraryCardId);
            var booking = new BookingEntity()
            {
                LibraryCardId = libraryCardId,
                IsbnCode = isbnCode,
                BookingCode = Guid.NewGuid(),
                DateReserved = DateTime.UtcNow,
            };
            var book = _bookRepository.GetBookByIsbnCode(isbnCode);
            if (book.BookStatus == BookStatus.Unavailable)
            {
                throw new Exception("Please note the book is currently unavailable for reservation.");
            }
            book.BookStatus = BookStatus.Unavailable;
            _dataBaseContext.Add(booking);
            _dataBaseContext.SaveChanges();
            return new BookingDto(booking);
        }

        public BookingDto BookReturn(Guid bookingCode)
        {
            var booking = _dataBaseContext.Bookings.FirstOrDefault(booking => booking.BookingCode == bookingCode);
            if (booking == null)
            {
                throw new Exception("Please enter a valid Booking code.");
            }
            var book = _bookRepository.GetBookByIsbnCode(booking.IsbnCode);
            book.BookStatus = BookStatus.Available;
            booking.DateReturned = DateTime.UtcNow;
            _dataBaseContext.SaveChanges();
            return new BookingDto(booking);
        }

        public BookingDto BookTermProlong(Guid bookingCode)
        {
            var bookingLateCheck = _dataBaseContext.Bookings.Where(booking => booking.BookingCode == bookingCode && DateTime.UtcNow.AddDays(-30).Date > booking.DateBorrowed).ToList();
            if (bookingLateCheck.Count > 0)
            {
                throw new Exception("Please note that you are late to return 1 or more books, therefore, you cannot rprolong more books until the late ones are returned");
            }
            var booking = _dataBaseContext.Bookings.FirstOrDefault(booking => booking.BookingCode == bookingCode);
            booking.DateBorrowed = DateTime.UtcNow;
            _dataBaseContext.SaveChanges();
            return new BookingDto(booking);
        }

        public void CheckForLateBooks()
        {
            var listOfLateBookings = _dataBaseContext.Bookings.Where(booking => DateTime.UtcNow.AddDays(-30).Date > booking.DateBorrowed).Select(booking => new BookingDto(booking)).ToList();
            foreach (BookingDto booking in listOfLateBookings)
            {
                var lateUser = _dataBaseContext.Users.FirstOrDefault(user => user.LibraryCardId == booking.LibraryCardId);
                Console.WriteLine(/*Send Email to late User*/ $"Dear {lateUser.FirstName} {lateUser.LastName}, \nKindly note, that you are late to return one or more books to Books Stop library. Please return your book(-s) as soon as possible.");
            }
        }
        public void CheckReservationTimeOut()
        {
            var listOfReservationTimeOut = _dataBaseContext.Bookings.Where(booking => DateTime.UtcNow.AddDays(-5).Date > booking.DateReserved).ToList();
            foreach (var booking in listOfReservationTimeOut)
            {
                var book = _bookRepository.GetBookByIsbnCode(booking.IsbnCode);
                book.BookStatus = BookStatus.Available;
                var TimedOutUser = _dataBaseContext.Users.FirstOrDefault(user => user.LibraryCardId == booking.LibraryCardId);
                Console.WriteLine(/*Send Email to late User*/ $"Dear {TimedOutUser.FirstName} {TimedOutUser.LastName}, \nKindly note, that your reservation period has ended for one or more books at Books Stop library. We kindly ask you to make a new reservation in case you want to borrow (a) book(-s).");
            }
            _dataBaseContext.Bookings.RemoveRange(listOfReservationTimeOut);
            _dataBaseContext.SaveChanges();
        }
    }
}

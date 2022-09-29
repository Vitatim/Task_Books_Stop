using Books_Spot_Task.Enums;
using Books_Spot_Task.Interfaces;
using Books_Spot_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books_Spot_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{isbnCode}")]

        public ActionResult<BookDto> GetBook(string isbnCode)
        {
            if (string.IsNullOrWhiteSpace(isbnCode))
            {
                return BadRequest("Please enter a valid ISBN Code.");
            }
            try
            {
                return new JsonResult(_bookService.GetBook(isbnCode));
            }
            catch (Exception)
            {
                return NotFound("The ISBN Code entered has not been found");
            }
        }

        [HttpGet("searchByTerm")]
        public ActionResult<List<BookDto>> SearchBookByTerm(string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Please enter title, author's name, publisher or ISBN of the book.");
            }
            try
            {
                return new JsonResult(_bookService.SearchBookByTerm(searchTerm));
            }
            catch (Exception)
            {
                return NotFound("The book information entered has not been found");
            }
        }

        [HttpGet("searchByAvailability")]
        public ActionResult<List<BookDto>> SearchBookByAvailability(BookStatus? availability)
        {
            if (availability == null)
            {
                return BadRequest("Please enter availability type of the book.");
            }
            try
            {
                return new JsonResult(_bookService.SearchBookByAvailability(availability));
            }
            catch (Exception)
            {
                return NotFound("The book availability type entered has not been found");
            }
        }

        [HttpGet("searchByYear")]
        public ActionResult<List<BookDto>> SearchBookByYear(int searchYear)
        {
            if (searchYear < 0)
            {
                return BadRequest("Please enter a valid year");
            }
            try
            {
                return new JsonResult(_bookService.SearchBookByYear(searchYear));
            }
            catch (Exception)
            {
                return NotFound("The year entered has not been found");
            }
        }

        [HttpGet("searchByGenre")]
        public ActionResult<List<BookDto>> SearchBookByGenre(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return BadRequest("Please select a valid genre");
            }
            try
            {
                return new JsonResult(_bookService.SearchBookByGenre(genre));
            }
            catch (Exception)
            {
                return NotFound("The genre entered has not been found");
            }
        }


        [HttpGet("getAllGenres")]
        public ActionResult<List<GenreDto>> GetAllGenres()
        {
            return new JsonResult(_bookService.GetAllGenres());
        }

        [HttpGet]
        public ActionResult<List<BookDto>> GetAllBooks()
        {
            return new JsonResult(_bookService.GetAllBooks());
        }

        [HttpPost("borrow")]
        public ActionResult<BookingDto> BookBorrowing(string libraryCardId, string isbnCode)
        {
            if (string.IsNullOrEmpty(libraryCardId))
            {
                return BadRequest("Please take out the physical Library Card at our Library in order to borrow Books!");
            }
            else if (string.IsNullOrWhiteSpace(isbnCode))
            {
                return BadRequest("Please enter a valid ISBN code.");
            }
            try
            {
                return _bookService.BookBorrowing(libraryCardId, isbnCode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reserve")]
        public ActionResult<BookingDto> BookReservation(string libraryCardId, string isbnCode)
        {
            if (string.IsNullOrEmpty(libraryCardId))
            {
                return BadRequest("Please take out the physical Library Card at our Library in order to reserve Books!");
            }
            else if (string.IsNullOrWhiteSpace(isbnCode))
            {
                return BadRequest("Please enter a valid ISBN code.");
            }
            try
            {
                return _bookService.BookReservation(libraryCardId, isbnCode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("return")]
        public ActionResult<BookingDto> BookReturn(Guid bookingCode)
        {
            if (bookingCode == Guid.Empty)
            {
                return BadRequest("Please enter a valid Booking code.");
            }
            try
            {
                return _bookService.BookReturn(bookingCode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("prolongTerm")]
        public ActionResult<BookingDto> BookTermProlong(Guid bookingCode)
        {
            if (bookingCode == Guid.Empty)
            {
                return BadRequest("Please enter a valid Booking code.");
            }
            try
            {
                return _bookService.BookTermProlong(bookingCode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("checkForBookingUpdates")]
        public void CheckForLateBooks()
        {
            _bookService.CheckForLateBooks();
            _bookService.CheckReservationTimeOut();
        }


    }
}
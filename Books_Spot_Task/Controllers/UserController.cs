using Books_Spot_Task.Enums;
using Books_Spot_Task.Interfaces;
using Books_Spot_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books_Spot_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registerUser")]
        public ActionResult<UserDto> RegisterUser([FromBody] RegistrationFormDto registration)
        {
            try
            {
                _userService.RegisterUser(registration);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("assignLibraryCard")]
        
        public ActionResult<UserDto> AssignLibraryCard(string email, string libraryCardId)
        {
            try
            {
                _userService.AssignLibraryCard(email, libraryCardId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

        [HttpGet]

        public ActionResult<UserDto> GetAllUsers()
        {
            return new JsonResult(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]

        public ActionResult<UserDto> GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please enter a valid user ID.");
            }
            try
            {
                return new JsonResult(_userService.GetUser(id));
            }
            catch (Exception)
            {
                return NotFound("The user ID entered has not been found");
            }
        }

        [HttpGet("getUserBookings")]
        public ActionResult<List<BookingDto>> GetUserBookings(string libraryCardId)
        {
            return new JsonResult(_userService.GetUserBookings(libraryCardId));
        }
    }
        

}



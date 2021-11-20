using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
        [Route("[controller]")]
        public class UsersController : ControllerBase
        {

            private readonly IUserService _userService;

            public UsersController(IUserService userService)
            {
                this._userService = userService;
            }

            [HttpGet]
            public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
            {
                Console.WriteLine("Here");
                try
                {
                    var user = await _userService.ValidateUserAsync(username, password);
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
}
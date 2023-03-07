using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namaa_CRUD_Project.Data;
using Namaa_CRUD_Project.Models;

namespace Namaa_CRUD_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UsersController(UserDbContext userDbContext)
        {
            _context=userDbContext;
        }
        [HttpPost("add_user")]
        public IActionResult AddUser([FromBody] Users_Model user_object)
        {
            if (user_object == null) { return BadRequest(string.Empty); }
            else
            {
                _context.usersModel.Add(user_object);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message="User Added Successfully"
                });
            }
        }

        [HttpPut("update_user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users_Model user_object)
        {
            var user_exist = await _context.usersModel.FirstOrDefaultAsync(x => x.ID == id);
            if (user_exist == null)
            { 
                return NotFound(new
                {
                    StatusCode=404,
                    Message="User Not Found"
                });
            }
            else
            {
                user_exist.Fname = user_object.Fname;
                user_exist.Lname = user_object.Lname;
                await _context.SaveChangesAsync();
                return Ok(user_exist);
            }
        }

        [HttpDelete("delete_user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user_exist = _context.usersModel.Find(id);
            if (user_exist == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                _context.Remove(user_exist);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Deleted Successfully"
                });
            }
        }

        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.usersModel.ToListAsync();
            return Ok(users);
        }

        [HttpGet("get_user_by_id/{id}")]
        public IActionResult GetUserByID(int id)
        {
            var user = _context.usersModel.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User Not Found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    User_Details = user
                });
            }
        }
    }
}

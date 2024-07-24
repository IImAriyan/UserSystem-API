using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserSystem.Entitys;

namespace UserSystem.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserSystem(DbContextApp dbContext) : ControllerBase
    {
        // Show Users Async Function
        [HttpGet("Users/list")]
        public  ActionResult<IEnumerable<UsersEntity>> ShowUsers()
        {
            return  dbContext.Users;
        }
        
        // Add User Function
        [HttpPost("Users/Add")]
        public async Task<ActionResult<UsersEntity>> AddUser(UsersEntity dto)
        {
            EntityEntry<UsersEntity> User = await dbContext.AddAsync(dto);
            
            dbContext.SaveChangesAsync();
            
            return Ok(User);
        }
    }
}

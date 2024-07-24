using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserSystem.Entitys;

namespace UserSystem.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserSystem(DbContextApp dbContext) : ControllerBase
    {
        [HttpGet("Users/list")]
        public  ActionResult<IEnumerable<UsersEntity>> ShowUsers()
        {
            return  dbContext.Users;
        }
    }
}

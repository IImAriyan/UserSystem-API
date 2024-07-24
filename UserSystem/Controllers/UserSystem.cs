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

        
        // Add User Function
        [HttpPost("Users/Add")]
        public async Task<ActionResult<UsersEntity>> AddUser(UsersEntity dto)
        {
            EntityEntry<UsersEntity> User = await dbContext.AddAsync(dto);
            
            dbContext.SaveChangesAsync();
            
            return Ok(User);
        }
        
        // Show Users Async Function
        [HttpGet("Users/list")]
        public  ActionResult<IEnumerable<UsersEntity>> ShowUsers()
        {
            return  dbContext.Users;
        }
        
        // ReadByID Function
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<UsersEntity>> ReadByID(int id)
        {
            UsersEntity User =  dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (User == null) return NotFound();
            
            return User;
        }
        
        // َDelete Async Function 
        
        [HttpGet("Users/Delete/{id}")]
        public async Task<ActionResult<UsersEntity>> Delete(int id)
        {
            UsersEntity User =  dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (User == null) return NotFound();
            
            dbContext.Remove(User);
            await dbContext.SaveChangesAsync();
            
            return Ok(User);
        }
        
        // Update User Async Function
        [HttpPost("Users/Update/{id}")]
        public async Task<ActionResult<UsersEntity>> UpdateUser(UsersEntity dto,int id)
        {
            UsersEntity User =  dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (User == null) return NotFound();

            User.Username = dto.Username;
            User.Password = dto.Password;
            User.Email = dto.Email;

            await dbContext.SaveChangesAsync();
            
            return Ok(User);
        }
        

        
    }
}

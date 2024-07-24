using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace UserSystem.Entitys;


[Table(name:"Users")]
public class UsersEntity
{
    [Key]
    [SwaggerIgnore]
    [Required]
    public int Id { get; set; }
    
    [Display(Name = "Username")]
    [Required(ErrorMessage = "Please Enter Username Field")]
    public string Username { get; set; }
    
    [Display(Name = "Password")]
    [Required(ErrorMessage = "Please Enter Password Field")]
    public string Password { get; set; }
    
    [Display(Name = "Email")]
    public string Email { get; set; }
    
}
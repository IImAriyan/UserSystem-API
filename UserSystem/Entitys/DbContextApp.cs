using Microsoft.EntityFrameworkCore;

namespace UserSystem.Entitys;

public class DbContextApp(DbContextOptions options): DbContext(options)
{
    public DbSet<UsersEntity> Users { get; set; }
    
}
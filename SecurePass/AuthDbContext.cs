using Microsoft.EntityFrameworkCore;

namespace SecurePass.Models
{
  public class AuthDbContext : DbContext
  {
    public DbSet<Auth> Auths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // Configure the SQLite database connection
      optionsBuilder.UseSqlite("Data Source=auth.db");
    }
  }
}

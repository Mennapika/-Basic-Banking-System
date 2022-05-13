using Microsoft.EntityFrameworkCore;
using Simple_Banking_System.Models;

namespace Simple_Banking_System.Data
{
    public class UserContext:DbContext
    {  public UserContext(DbContextOptions<UserContext> options) : base(options) { }
       public DbSet<User> Users { get; set; }
}
}

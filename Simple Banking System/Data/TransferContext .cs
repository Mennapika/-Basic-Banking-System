using Microsoft.EntityFrameworkCore;
using Simple_Banking_System.Models;

namespace Simple_Banking_System.Data
{
    public class TransferContext : DbContext
    {
        public TransferContext(DbContextOptions<TransferContext> options) : base(options) { }
        public DbSet<Transactions> Transfers { get; set; }
    }
    
}

using Microsoft.EntityFrameworkCore;

namespace MY_POCKET.Models;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {}
    
    public DbSet<Transaction> Transactions { set; get; }
    public DbSet<Category> Categories { set; get; }
    
}
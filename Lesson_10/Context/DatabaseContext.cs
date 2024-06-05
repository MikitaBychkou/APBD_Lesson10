using Lesson_10.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson_10.Context;

public class DatabaseContext: DbContext
{
    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Category> Categories { get; set; }
    
}
//dd
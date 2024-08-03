using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApi;


public class ApplicationDBContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<SuscriptionType> SuscriptionsTypes { get; set; }
    public DbSet<Suscription> Suscriptions { get; set; }
    public DbSet<Suscriptor> Suscriptors { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleProduct> SalesProducts { get; set; }
}

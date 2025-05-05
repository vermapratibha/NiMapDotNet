using Microsoft.EntityFrameworkCore;
using Rentify.Models;

namespace Rentify.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) { }
        
            public DbSet<Role> Roles { get; set; }
        public DbSet<Users> users { get; set; }

        public DbSet<Vendors> vendors { get; set; }

        public DbSet<RentalOrder> rentalOrders { get; set; }

        public DbSet<Categories> categories { get; set; }

        public DbSet<Products> products { get; set; }



    }

}


using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using CarDealershipRestApi.Models;

namespace CarDealershipRestApi.Data
{
    public class CarDealershipContext : DbContext

    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options) 
            : base(options)
        {
        }
    }
}

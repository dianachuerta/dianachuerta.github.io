using Microsoft.EntityFrameworkCore;

namespace b
{
    public class OrderDB: DbContext 
    {
        public DbSet<Order> orders { get; set; } // orders
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=orders.db");// Data Source=path to the database file
        }
    }
}
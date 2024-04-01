using Microsoft.EntityFrameworkCore;

namespace a
{
    public class CityDB: DbContext 
    {
        public DbSet<City> cities { get; set; }// This is going to be a table in the database.
                                                    // You can add multiple database tables

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=City.SqliteDB");// Data Source=path to the database file
        }



    }
}

using Microsoft.EntityFrameworkCore;

namespace c
{
    public class StuDB: DbContext
    {
        public DbSet<Student> Students { get; set; } // Students is the table name 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=Students.db");// Data Source=path to the database file
        }
    }
}


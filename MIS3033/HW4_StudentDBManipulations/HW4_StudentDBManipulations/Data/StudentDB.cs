using Microsoft.EntityFrameworkCore;

namespace c
{
    class StudentDB: DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=Students.db");// Data Source=path to the database file
        }

    }
}

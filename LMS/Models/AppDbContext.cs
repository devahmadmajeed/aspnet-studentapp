using System.Collections.Generic;
using System.Data.Entity;

namespace StudentApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("StudentDBContext") { }

        public DbSet<Student> Students { get; set; }
    }
}
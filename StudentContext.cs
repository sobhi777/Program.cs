using System.Data.Entity;

namespace StudentCodeFirst
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentDB")  // Connection name
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}

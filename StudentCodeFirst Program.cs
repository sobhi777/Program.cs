using System;
using System.Linq;

namespace StudentCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                // Create a new student and save it to the database
                Console.Write("Enter a student name: ");
                var name = Console.ReadLine();

                var student = new Student { StudentName = name };
                db.Students.Add(student);
                db.SaveChanges();

                // Display all students from the database
                var query = from s in db.Students
                            orderby s.StudentName
                            select s;

                Console.WriteLine("\nAll students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.StudentName);
                }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlClient;


namespace WeeklyProject4
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int StudentId;
        public int Faculty;

        public Student CreateStudent()
        {
            Student student = new Student();
            Console.WriteLine("Enter student name ");
            student.FirstName = Console.ReadLine();
            while (student.FirstName == "" || student.FirstName == null || student.FirstName.Length < 3)
            {
                Console.WriteLine("Name must be more than 3 characters,enter again ");
                student.FirstName = Console.ReadLine();
            }
            Console.WriteLine("Enter student surname ");
            student.LastName = Console.ReadLine();
            while (student.LastName == "" || student.LastName == null || student.LastName.Length < 4)
            {
                Console.WriteLine("Surname must be more than 4 characters,enter again ");
                student.LastName = Console.ReadLine();
            }
            Console.WriteLine("Enter student faculty ");
            student.Faculty = Convert.ToInt16(Console.ReadLine());
            while (student.Faculty < 5 || student.Faculty > 10)
            {
                Console.WriteLine("Faculty number must be between 5 and 10, enter again");
                student.Faculty = Convert.ToInt16(Console.ReadLine());
            }
            return student;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WeeklyProject4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string connectionString = @"Server=localhost\SQLExpress;" +
                        "Database=WeeklyProject4;" + "Integrated Security=SSPI;";

                DatabaseAccessLayer data = new DatabaseAccessLayer(connectionString);
                ShowMenu();
                int input = Convert.ToInt16(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Student student = new Student();
                        student = student.CreateStudent();                       
                        data.InsertStudent(student);
                        Console.WriteLine("Student inserted succesfully!");
                        break;
                    case 2:
                        Worker worker = new Worker();
                        worker = worker.GetWorker();
                        data.InsertWorker(worker);
                        Console.WriteLine("Worker inserted succesfully!");

                        break;
                    case 3:
                        List<Student> students = data.GetAllStudents();
                        foreach (var item in students)
                        {
                            Console.WriteLine($"Student ID: {item.StudentId}\nFirst Name: {item.FirstName} " +
                                $"\nLast Name: {item.LastName} \nFaculty: {item.Faculty}\n");
                        }
                        break;
                    case 4:
                        List<Worker> workers = data.GetAllWorkers();
                        foreach (var item in workers)
                        {
                            Console.WriteLine($"Worker ID: {item.WorkerId} \nFirst Name: {item.FirstName} \nLast Name: {item.LastName}" +
                                $"\nWeekly Work Hours: {item.WorkingHours} \nDaily Salary {item.DailySalary}\n");
                            Console.WriteLine("Total workers: " + workers.Count);
                        }
                        break;
                    case 5:
                        Environment.Exit(5);
                        break;
                    default:
                        Console.WriteLine("Enter a valid input");
                        break;
                }
            }
            Console.ReadLine();
        }
        static void ShowMenu()
        {
            Console.WriteLine("Select what you want:");
            Console.WriteLine("1.Insert student");
            Console.WriteLine("2.Insert worker");
            Console.WriteLine("3.View students");
            Console.WriteLine("4.View workers");
            Console.WriteLine("5.Exit");
        }
    }
}

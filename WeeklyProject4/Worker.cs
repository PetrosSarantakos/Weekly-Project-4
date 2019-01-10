using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace WeeklyProject4
{
    public class Worker
    {
        public string FirstName;
        public string LastName;
        public int WorkerId;
        public int WorkingHours;
        public int WeeklySalary;
        public double DailySalary;

        public Worker GetWorker()
        {
            Worker worker = new Worker();
            Console.WriteLine("Enter worker name");
            worker.FirstName = Console.ReadLine();
            while (worker.FirstName == "" || worker.FirstName == null || worker.FirstName.Length < 3)
            {
                Console.WriteLine("Name must be more than 3 characters,enter again ");
                worker.FirstName = Console.ReadLine();
            }
            Console.WriteLine("Enter worker surname");
            worker.LastName = Console.ReadLine();
            while (worker.LastName == "" || worker.LastName == null || worker.LastName.Length < 4)
            {
                Console.WriteLine("Surname must be more than 4 characters,enter again ");
                worker.LastName = Console.ReadLine();
            }
            Console.WriteLine("Enter worker's working hours ");
            worker.WorkingHours = Convert.ToInt32(Console.ReadLine());
            while (worker.WorkingHours < 1 || worker.WorkingHours > 12)
            {
                Console.WriteLine("Working hours must be between 1 and 12, enter again");
                worker.WorkingHours = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter worker's weekly salary ");
            worker.WeeklySalary = Convert.ToInt32(Console.ReadLine());
            while (worker.WeeklySalary <= 10)
            {
                Console.WriteLine("Weekly salary must be more than 10, enter again");
                worker.WeeklySalary = Convert.ToInt32(Console.ReadLine());
            }
            return worker;
        }
    }
}

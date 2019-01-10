using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace WeeklyProject4
{
    public class DatabaseAccessLayer
    {
        private string _connectionString { get; set; }
        private const string _getAllStudentsQuerie = "SELECT * FROM Students";
        private const string _getAllWorkersQuerie = "SELECT * FROM Workers";
        private const string _insertWorkerQuerie = "INSERT INTO Workers (firstName,lastName, dailyWorkingHours,weeklySalary)" +
            "VALUES(@FirstName,@LastName,@DailyHours,@WeeklySalary)";
        private const string _insertStudentQuerie = "INSERT INTO Students (firstName, lastName, facultyNumber) " +
            "VALUES (@FirstName, @LastName, @Faculty) ";



        public DatabaseAccessLayer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(_getAllStudentsQuerie, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                students.Add(new Student
                                {
                                    StudentId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Faculty= reader.GetInt32(3),
                                });
                            }
                        }
                    }
                }
            }
            return students;
        }

        public List<Worker> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(_getAllWorkersQuerie, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                workers.Add(new Worker
                                {
                                    WorkerId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    WorkingHours = reader.GetInt32(3),
                                    DailySalary = Convert.ToDouble(reader.GetInt32(4)/5)                                 
                                });
                            }
                        }
                    }
                }
            }
            return workers;
        }

        public void InsertStudent(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(_insertStudentQuerie, sqlConnection))
                {
                    command.Parameters.Add("@FirstName",System.Data.SqlDbType.NVarChar, 40).Value = student.FirstName.First().ToString().ToUpper() + student.FirstName.Substring(1);
                    command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 40).Value = student.LastName.First().ToString().ToUpper() + student.LastName.Substring(1);
                    command.Parameters.Add("@Faculty", System.Data.SqlDbType.Int).Value = student.Faculty;
                    command.ExecuteNonQuery();                     
                }
            }

        }

        public void InsertWorker(Worker worker)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(_insertWorkerQuerie, sqlConnection))
                {
                    command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 40).Value = worker.FirstName.First().ToString().ToUpper() + worker.FirstName.Substring(1);
                    command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 40).Value = worker.LastName.First().ToString().ToUpper() + worker.LastName.Substring(1);
                    command.Parameters.Add("@DailyHours", System.Data.SqlDbType.Int).Value = worker.WorkingHours;
                    command.Parameters.Add("@WeeklySalary", System.Data.SqlDbType.Int).Value = worker.WeeklySalary;

                    command.ExecuteNonQuery();
                }
            }

        }


    }
}

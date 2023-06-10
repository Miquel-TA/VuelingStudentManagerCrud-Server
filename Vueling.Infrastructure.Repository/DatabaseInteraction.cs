using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Vueling.Crosscutting.Models;

namespace Vueling.Infrastructure.Repository
{
    public class DatabaseInteraction
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Students";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        Guid guid = (Guid)reader["Guid"];
                        DateTime creationDate = (DateTime)reader["CreationDate"];
                        string name = (string)reader["Name"];
                        string surname = (string)reader["Surname"];
                        DateTime birthday = (DateTime)reader["Birthday"];
                        short age = (short)reader["Age"];

                        Student student = new Student()
                        {
                            Id = id,
                            Guid = guid,
                            CreationDate = creationDate,
                            Name = name,
                            Surname = surname,
                            Birthday = birthday,
                            Age = age
                        };

                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public bool AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Students (Birthday, Age, Name, Surname) " +
                               "VALUES (@Birthday, @Age, @Name, @Surname)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Birthday", student.Birthday);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Surname", student.Surname);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Students SET Birthday = @Birthday, Age = @Age, Name = @Name, Surname = @Surname WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Birthday", student.Birthday);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Surname", student.Surname);

                    command.Parameters.AddWithValue("@Id", student.Id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Students WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", student.Id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

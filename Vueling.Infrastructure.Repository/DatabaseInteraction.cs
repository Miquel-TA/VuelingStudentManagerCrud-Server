using System;
using System.Configuration;
using System.Data.SqlClient;
using Vueling.Crosscutting.Models;

namespace Vueling.Infrastructure.Repository
{
    public class DatabaseInteraction
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public bool InsertStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Students (Birthday, Age, Name, Surname) VALUES (@Birthday, @Age, @Name, @Surname)", connection))
                {
                    command.Parameters.AddWithValue("@Birthday", student.Birthday);
                    command.Parameters.AddWithValue("@Age", Utils.GetAgeFromBirthday(student.Birthday));
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Surname", student.Surname);

                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

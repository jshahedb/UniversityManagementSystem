using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL.Gateway
{
    public class DepartmentGateway
    {
        SqlConnection connection = new SqlConnection();
        string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConnString"].ConnectionString;
        public List<Department> GetAllDepartment()
        {
            string query = "SELECT * FROM Departments";

            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departments = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                department.Id = (int)reader["Id"];
                department.Name = reader["Name"].ToString();
                departments.Add(department);
            }
            reader.Close();
            connection.Close();

            return departments;
        }
    }
}
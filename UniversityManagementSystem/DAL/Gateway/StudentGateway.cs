using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL.Gateway
{
    public class StudentGateway
    {
        SqlConnection connection = new SqlConnection();
        string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConnString"].ConnectionString;
        public int Save(Student aStudent)
        {
            connection.ConnectionString = connectionString;


            //2. write the query

            //                INSERT INTO Students VALUES('name','address','regNo','phoneNumber');

            string query = "INSERT INTO Students(Name,Address,RegNo,Phone,DepartmentId) VALUES('" + aStudent.Name + "','" + aStudent.Address + "','" + aStudent.RegNo + "','" + aStudent.PhoneNo+ "','" + aStudent.DepartmentId + "')";

            //3. Execute the query using the connection

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            //4. Show Result (in this case -> saved or not)

            return rowAffected;
        }

        public bool IsStudentExist(Student student)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Students WHERE RegNo = '" + student.RegNo + "' AND Id <>"+student.Id;
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isRegNoExist = false;

            if (reader.HasRows)
            {
                isRegNoExist = true;
            }

            connection.Close();

            return isRegNoExist;
        }

        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM Students";

            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                Student student = new Student();
                student.Id = int.Parse(reader["Id"].ToString());
                student.Name = reader["Name"].ToString();
                student.Address = reader["Address"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.PhoneNo = reader["Phone"].ToString();
                student.DepartmentId = reader["DepartmentID"].ToString() == ""
                    ? (int?)null
                    : int.Parse(reader["DepartmentID"].ToString());

                students.Add(student);
            }
            reader.Close();
            connection.Close();

            return students;
        }

        public Student GetStudentById(int studentId)
        {
            string query = "SELECT * FROM Students WHERE Id ='"+studentId+"'";

            connection.ConnectionString = connectionString;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Student student = null;

            while (reader.Read())
            {
                student = new Student();
                student.Id = (int)reader["Id"];
                student.Name = reader["Name"].ToString();
                student.Address = reader["Address"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.PhoneNo = reader["Phone"].ToString();
                student.DepartmentId = reader["DepartmentID"].ToString() == ""
                    ? (int?)null
                    : int.Parse(reader["DepartmentID"].ToString());
                
            }
            reader.Close();
            connection.Close();

            return student;
        }

        public int Update(Student aStudent)
        {
            connection.ConnectionString = connectionString;



            string query = "Update Students Set Name='" + aStudent.Name + "', Address ='" + aStudent.Address + "', RegNo='" + aStudent.RegNo + "', Phone='" + aStudent.PhoneNo + "', DepartmentID='" + aStudent.DepartmentId + "' WHERE Id=" + aStudent.Id;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            //4. Show Result (in this case -> saved or not)

            return rowAffected;
        }

        public int Delete(int id)
        {
            connection.ConnectionString = connectionString;



            string query = "delete from Students WHERE Id=" + id;

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();

        public string Save(Student aStudent)
        {
            if (aStudent.RegNo.Length >= 6)
            {
                if (!studentGateway.IsStudentExist(aStudent))
                {
                    if (studentGateway.Save(aStudent) > 0)
                    {
                        return "Saved successfully.";
                    }
                    else
                    {
                        return "Save failed.";
                    }
                }
                else
                {
                    return "Duplicate registration number.";
                }
            }
            else
            {
                return "Registration number must be atleast six characters long.";
            }
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }


        public Student GetStudentById(int studentId)
        {
            return studentGateway.GetStudentById(studentId);
        }

        public string Update(Student aStudent)
        {
            if (aStudent.RegNo.Length >= 6)
            {
                if (!studentGateway.IsStudentExist(aStudent))
                {
                    if (studentGateway.Update(aStudent) > 0)
                    {
                        return "Updated successfully.";
                    }
                    else
                    {
                        return "Update failed.";
                    }
                }
                else
                {
                    return "Duplicate registration number.";
                }
            }
            else
            {
                return "Registration number must be atleast six characters long.";
            }
            
        }

        public bool Delete(int id)
        {
            int rowAffected = studentGateway.Delete(id);
            return rowAffected>0;
        }
    }
}
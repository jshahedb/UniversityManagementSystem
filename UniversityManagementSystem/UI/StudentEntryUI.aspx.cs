using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.UI
{
    public partial class StudentEntryUI : System.Web.UI.Page
    {
        StudentManager studentManager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartmentComboBox();
                int studentId = 0;
                // check if any query string
                if (Request.QueryString["id"] != null)
                {
                    // get query string value
                    string id = Request.QueryString["id"].ToString();
                    studentId = int.Parse(id);
                }


                if (studentId > 0)
                {
                    Student student = studentManager.GetStudentById(studentId);
                    if (student != null)
                    {
                        // load form by student with student id
                        FillFormWithStudent(student);
                        saveButton.Text = "Update";
                    }

                }
                LoadAllStudents();
            }
            

            
        }

        private void LoadDepartmentComboBox()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            
            if (departments == null)
            {
                departments = new List<Department>();
            }

            Department defaultDepartment = new Department();
            defaultDepartment.Id = -1;
            defaultDepartment.Name = "Select...";
            
            departments.Insert(0,defaultDepartment);

            departmentDropDown.DataSource = departments;
            
            departmentDropDown.DataTextField = "Name";
            departmentDropDown.DataValueField = "Id";
            departmentDropDown.DataBind();
            
        }

        private void FillFormWithStudent(Student student)
        {
            studentIdHidden.Value = student.Id.ToString();
            nameTextBox.Text = student.Name;
            regNoTextBox.Text = student.RegNo;
            phoneNumberTextBox.Text = student.PhoneNo;
            addressTextBox.Text = student.Address;
            departmentDropDown.SelectedValue = student.DepartmentId.ToString();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int selectedDepartmentId = Convert.ToInt32(departmentDropDown.SelectedValue);

            if (selectedDepartmentId == -1)
            {
                messageLabel.Text = "Please select a department to save a student!";
                return;
            }

            Student aStudent = new Student();
            aStudent.Name = nameTextBox.Text;
            aStudent.Address = addressTextBox.Text;
            aStudent.RegNo = regNoTextBox.Text;
            aStudent.PhoneNo = phoneNumberTextBox.Text;
            aStudent.DepartmentId = selectedDepartmentId;

            if (saveButton.Text.ToLower() =="Update".ToLower())
            {
                aStudent.Id = int.Parse(studentIdHidden.Value);
                messageLabel.Text = studentManager.Update(aStudent);
                LoadAllStudents();
            }
            else
            {
                messageLabel.Text = studentManager.Save(aStudent);
                LoadAllStudents();
            }
            
        }

        protected void showAllButton_Click(object sender, EventArgs e)
        {
            LoadAllStudents();
        }

        private void LoadAllStudents()
        {
            studentsGridView.DataSource = studentManager.GetAllStudents();
            studentsGridView.DataBind();
        }

        protected void deleteButton_OnClick(object sender, EventArgs e)
        {
            LinkButton deleteButton = sender as LinkButton ;

            GridViewRow selectedRow = deleteButton.Parent.Parent as GridViewRow;

            HiddenField idHiddenField = selectedRow.FindControl("idHiddenField") as HiddenField;

            int id = Convert.ToInt32(idHiddenField.Value);

            bool isDeleted = studentManager.Delete(id);

            if (isDeleted)
            {
                messageLabel.Text = "Deleted Successfully!";
                LoadAllStudents();
            }
            else
            {
                messageLabel.Text = "Delete failed!";

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.UI
{
    public partial class ViewStudentsUI : System.Web.UI.Page
    {
        StudentManager studentManager = new StudentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            studentsGridView.DataSource = studentManager.GetAllStudents();
            studentsGridView.DataBind();
        }
    }
}
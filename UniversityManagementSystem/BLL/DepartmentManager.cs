using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    
    public class DepartmentManager
    {
        DepartmentGateway gateway = new DepartmentGateway();
        public List<Department> GetAllDepartment()
        {
            return gateway.GetAllDepartment();
        }
    }
}
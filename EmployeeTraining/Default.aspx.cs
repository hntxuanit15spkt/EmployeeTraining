using EmployeeDB.CL;
using System;
using System.Web.UI;

namespace EmployeeTraining
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            var emps = employeeService.GetAll();
        }
    }
}
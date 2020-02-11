using EmployeeDB.BLL;
using EmployeeDB.CL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeTraining.EmployeeManagement
{
    public partial class Update : System.Web.UI.Page
    {
        //private string EmployeeID = string.Empty;
        //private Employee Employee = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employeeID = Request.QueryString["employeeID"] ?? string.Empty;
                var employeeService = new EmployeeService();
                var employee = employeeService.Find($"EmployeeId={employeeID}").FirstOrDefault();
                txtFullName.Text = employee.FullName;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            var employeeID = Request.QueryString["employeeID"] ?? string.Empty;
            var employee = employeeService.Find($"EmployeeId={employeeID}").FirstOrDefault();
            if (employee.FullName == null || !employee.FullName.Equals(txtFullName.Text.Trim()))
            {
                employee.FullName = txtFullName.Text.Trim();
                employeeService.Update(employee);
            }

            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("ContactCreateOrUpdate", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@ConatctID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
            //sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            //sqlCmd.ExecuteNonQuery();
            //sqlCon.Close();
            //string contactID = hfContactID.Value;
            //Clear();
            //if (contactID == "")
            //    lblSuccessMessage.Text = "Saved Successfully";
            //else
            //    lblSuccessMessage.Text = "Updated Successfully";
            //FillGridView();
        }
    }
}
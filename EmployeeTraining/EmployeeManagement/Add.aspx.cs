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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            Employee employee = new Employee();
            employee.FullName = txtFullName.Text.Trim();
            employee.CreatedOn = DateTime.UtcNow;
            employeeService.Insert(employee);
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
            Clear();
            //if (contactID == "")
            //    lblSuccessMessage.Text = "Saved Successfully";
            //else
            //    lblSuccessMessage.Text = "Updated Successfully";
            //FillGridView();
        }

        public void Clear()
        {
            txtFullName.Text = string.Empty;
            btnSave.Text = "Save";
            //hfContactID.Value = "";
            //txtName.Text = txtMobile.Text = txtAddress.Text = "";
            //lblSuccessMessage.Text = lblErrorMessage.Text = "";
            //btnSave.Text = "Save";
            //btnDelete.Enabled = false;

        }
    }
}
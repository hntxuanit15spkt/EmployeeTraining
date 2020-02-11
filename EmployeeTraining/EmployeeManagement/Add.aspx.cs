using EmployeeDB.BLL;
using EmployeeDB.CL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;
using System;
using System.Collections.Generic;
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
            //TransactionManager transactionManager = null;
            //try
            //{
            //    transactionManager = ConnectionScope.CreateTransaction();
            //    NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
            //    EmployeeService employeeService = new EmployeeService();
            //    Employee employee = new Employee();
            //    employee.FullName = txtFullName.Text.Trim();
            //    employee.FirstName = txtFirstName.Text.Trim();
            //    employee.MiddlesName = txtMiddlesName.Text.Trim();
            //    employee.LastName = txtLastName.Text.Trim();
            //    employee.Email = txtEmail.Text.Trim();
            //    employee.Bio = txtBio.Text.Trim();
            //    employee.DOB = DateTime.Parse(txtDOB.Text);
            //    employee.CreatedOn = DateTime.UtcNow;
            //    TextBox txtFirstName;
            //    TextBox txtLastName;
            //    TextBox txtContactNo;
            //    //employeeService.Insert(employee);
            //    if (!dataProvider.EmployeeProvider.Insert(transactionManager, employee))
            //    {
            //        transactionManager.Rollback();
            //    }
            //    foreach (GridViewRow row in gvContacts.Rows)
            //    {
            //        txtLine1 = (TextBox)row.FindControl("txtLine1");

            //        if (txtFirstName == null || txtLastName == null || txtContactNo == null)
            //        {
            //            return;
            //        }

            //        if (string.IsNullOrEmpty(txtFirstName.Text.Trim())
            //            || string.IsNullOrEmpty(txtLastName.Text.Trim())
            //            || string.IsNullOrEmpty(txtContactNo.Text.Trim()))
            //        {
            //            lblMsg.Text = "All fields are required!";
            //            return;
            //        }
            //        else
            //        {
            //            sb.AppendLine("     <contact>");
            //            sb.AppendLine("         <FirstName>" + txtFirstName.Text.Trim() + "</FirstName>");
            //            sb.AppendLine("         <LastName>" + txtLastName.Text.Trim() + "</LastName>");
            //            sb.AppendLine("         <ContactNo>" + txtContactNo.Text.Trim() + "</ContactNo>");
            //            sb.AppendLine("     </contact>");
            //        }

            //    }
            //    if (!dataProvider.EmployeeProvider.Insert(transactionManager, employee))
            //    {
            //        transactionManager.Rollback();
            //    }
            //    //var listAddress = dataProvider.AddressProvider.GetByEmployeeId(int.Parse(employeeId));
            //    //if (dataProvider.AddressProvider.Delete(listAddress) == 0)
            //    //{
            //    //    transactionManager.Rollback();
            //    //}
            //    //var employee = dataProvider.EmployeeProvider.Find($"EmployeeId={employeeId}").FirstOrDefault();
            //    //if (!dataProvider.EmployeeProvider.Delete(employee))
            //    //{
            //    //    transactionManager.Rollback();
            //    //}
            //    transactionManager.Commit();
            //    Clear();
            //}
            //catch (Exception exc)
            //{
            //    if (transactionManager != null && transactionManager.IsOpen)
            //        transactionManager.Rollback();
            //}
        }

        public void Clear()
        {
            txtFullName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddlesName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtBio.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtEmployeeCode.Text = string.Empty;
            btnSave.Text = "Save";
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRowsToGrid();
        }

        private void AddRowsToGrid()
        {
            List<int> noofRows = new List<int>();
            int rows = 0;
            int.TryParse(txtNoOfRecord.Text.Trim(), out rows);

            for (int i = 0; i < rows; i++)
            {
                noofRows.Add(i);
            }

            gvContacts.DataSource = noofRows;
            gvContacts.DataBind();
            if (gvContacts.Rows.Count > 0)
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Save Here
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" ?>");
            sb.AppendLine("     <contacts>");

            // Check Validity
            TextBox txtFirstName;
            TextBox txtLastName;
            TextBox txtContactNo;

            foreach (GridViewRow row in gvContacts.Rows)
            {
                txtFirstName = (TextBox)row.FindControl("txtFirstName");
                txtLastName = (TextBox)row.FindControl("txtLastName");
                txtContactNo = (TextBox)row.FindControl("txtContactNo");

                if (txtFirstName == null || txtLastName == null || txtContactNo == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(txtFirstName.Text.Trim())
                    || string.IsNullOrEmpty(txtLastName.Text.Trim())
                    || string.IsNullOrEmpty(txtContactNo.Text.Trim()))
                {
                    lblMsg.Text = "All fields are required!";
                    return;
                }
                else
                {
                    sb.AppendLine("     <contact>");
                    sb.AppendLine("         <FirstName>" + txtFirstName.Text.Trim() + "</FirstName>");
                    sb.AppendLine("         <LastName>" + txtLastName.Text.Trim() + "</LastName>");
                    sb.AppendLine("         <ContactNo>" + txtContactNo.Text.Trim() + "</ContactNo>");
                    sb.AppendLine("     </contact>");
                }

            }
            sb.AppendLine("     </contacts>");

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ContactBulkInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@XMLData", sb.ToString());
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                int affRow = cmd.ExecuteNonQuery();
                if (affRow > 0)
                {
                    lblMsg.Text = "Successfully " + affRow + " record inserted.";
                    PopulateData();
                    AddRowsToGrid();
                }
            }
        }
    }
}
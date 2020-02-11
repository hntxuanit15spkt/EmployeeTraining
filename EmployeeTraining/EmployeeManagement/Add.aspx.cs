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
            TransactionManager transactionManager = null;
            try
            {
                transactionManager = ConnectionScope.CreateTransaction();
                NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                EmployeeService employeeService = new EmployeeService();
                Employee employee = new Employee();
                employee.FullName = txtFullName.Text.Trim();
                employee.FirstName = txtFirstName.Text.Trim();
                employee.MiddlesName = txtMiddlesName.Text.Trim();
                employee.LastName = txtLastName.Text.Trim();
                employee.Email = txtEmail.Text.Trim();
                employee.Bio = txtBio.Text.Trim();
                employee.DOB = DateTime.Parse(txtDOB.Text);
                employee.CreatedOn = DateTime.UtcNow;
                if (!dataProvider.EmployeeProvider.Insert(transactionManager, employee))
                {
                    transactionManager.Rollback();
                }
                TextBox txtLine1;
                foreach (GridViewRow row in gvContacts.Rows)
                {
                    txtLine1 = (TextBox)row.FindControl("txtLine1");

                    if (string.IsNullOrEmpty(txtLine1?.Text.Trim()))
                    {
                        lblMsg.Text = "All fields are required!";
                        return;
                    }
                    else
                    {
                        Address address = new Address();
                        address.Line1 = txtLine1.Text.Trim();
                        address.EmployeeId = employee.EmployeeId;
                        if (!dataProvider.AddressProvider.Insert(transactionManager, address))
                        {
                            transactionManager.Rollback();
                            lblMsg.Text = "An error occurred while processing your request!";
                        }
                    }
                }
                transactionManager.Commit();
                Clear();
            }
            catch (Exception exc)
            {
                if (transactionManager != null && transactionManager.IsOpen)
                    transactionManager.Rollback();
                lblMsg.Text = "An error occurred while processing your request!";
            }
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
    }
}
using EmployeeDB.CL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace EmployeeTraining.EmployeeManagement
{
    public partial class List : System.Web.UI.Page
    {
        public class EmployeeAddressObject
        {
            public string Text { get; set; } = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Clear();
            if (!IsPostBack)
            {
                FillGridView();
            }
        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add.aspx");
        }

        protected void lnk_OnUpdate(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect("Update.aspx?employeeID=" + employeeID);
        }

        protected void CommandBtn_Click(Object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    if (!DeleteEmployee((string)e.CommandArgument))
                    {
                        lblMsg.Text = "An error occurred while deleting!";
                    }
                    break;
            }
            FillGridView();
        }
        private bool DeleteEmployee(string employeeId)
        {
            TransactionManager transactionManager = null;
            try
            {
                transactionManager = ConnectionScope.CreateTransaction();
                NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                var listAddress = dataProvider.AddressProvider.GetByEmployeeId(int.Parse(employeeId));
                if (dataProvider.AddressProvider.Delete(transactionManager, listAddress) == 0)
                {
                    transactionManager.Rollback();
                }
                var employee = dataProvider.EmployeeProvider.Find($"EmployeeId={employeeId}").FirstOrDefault();
                if (!dataProvider.EmployeeProvider.Delete(transactionManager, employee))
                {
                    transactionManager.Rollback();
                }
                transactionManager.Commit();
            }
            catch (Exception exc)
            {
                if (transactionManager != null && transactionManager.IsOpen)
                    transactionManager.Rollback();
                return false;
            }
            return true;
        }

        private void FillGridView()
        {
            EmployeeService employeeService = new EmployeeService();
            var employees = employeeService.GetAll();
            employeeService.DeepLoad(employees);
            DataTable table = new DataTable();
            table.Columns.Add("EmployeeId");
            table.Columns.Add("FullName");
            table.Columns.Add("DOB");
            table.Columns.Add("Addresses", typeof(List<EmployeeAddressObject>));
            foreach (var emp in employees)
            {
                DataRow row = table.NewRow();
                row["EmployeeId"] = emp.EmployeeId;
                row["FullName"] = emp.FullName;
                row["DOB"] = emp.DOB;
                List<EmployeeAddressObject> listAddress = new List<EmployeeAddressObject>();
                if (emp.AddressCollection?.Any() == true)
                {
                    var addressCollection = emp.AddressCollection.ToList();
                    foreach (var address in addressCollection)
                    {
                        EmployeeAddressObject addressObj = new EmployeeAddressObject();
                        addressObj.Text = $"{address.Line1}, {address.Line2}, {address.TownCity}, {address.StateOrProvince}";
                        listAddress.Add(addressObj);
                    }
                }
                row["Addresses"] = listAddress;
                table.Rows.Add(row);
            }
            EmployeeGrid.DataSource = table;
            EmployeeGrid.DataBind();
        }

        private void Clear()
        {
            lblMsg.Text = string.Empty;
        }
    }
}
using EmployeeDB.CL;
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
            if (!IsPostBack)
            {
                FillGridView();
                //EmployeeService employeeService = new EmployeeService();
                //var employees = employeeService.GetAll();
                //employeeService.DeepLoad(employees);
                //DataTable table = new DataTable();
                //table.Columns.Add("EmployeeId");
                //table.Columns.Add("FullName");
                //table.Columns.Add("DOB");
                //table.Columns.Add("Addresses", typeof(List<EmployeeAddressObject>));
                //foreach (var emp in employees)
                //{
                //    DataRow row = table.NewRow();
                //    row["EmployeeId"] = emp.EmployeeId;
                //    row["FullName"] = emp.FullName;
                //    row["DOB"] = emp.DOB;
                //    List<EmployeeAddressObject> listAddress = new List<EmployeeAddressObject>();
                //    if (emp.AddressCollection?.Any() == true)
                //    {
                //        var addressCollection = emp.AddressCollection.ToList();
                //        foreach (var address in addressCollection)
                //        {
                //            EmployeeAddressObject addressObj = new EmployeeAddressObject();
                //            addressObj.Text = $"{address.Line1}, {address.Line2}, {address.TownCity}, {address.StateOrProvince}";
                //            listAddress.Add(addressObj);
                //        }
                //    }
                //    row["Addresses"] = listAddress;
                //    table.Rows.Add(row);
                //}
                //EmployeeGrid.DataSource = table;
                //EmployeeGrid.DataBind();
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

        protected void CommandBtn_Click(Object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    DeleteEmployee((string)e.CommandArgument);
                    break;
            }
            FillGridView();
        }
        private void DeleteEmployee(string employeeId)
        {
            EmployeeService employeeService = new EmployeeService();
            employeeService.Delete(int.Parse(employeeId));
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
    }
}
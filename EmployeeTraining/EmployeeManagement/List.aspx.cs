using EmployeeDB.BLL;
using EmployeeDB.CL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            EmployeeService employeeService = new EmployeeService();
            var employees = employeeService.GetAll();
            employeeService.DeepLoad(employees);
            DataTable table = new DataTable();
            table.Columns.Add("FullName");
            table.Columns.Add("DOB");
            table.Columns.Add("Addresses", typeof(List<EmployeeAddressObject>));
            foreach (var emp in employees)
            {
                DataRow row = table.NewRow();
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

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    EmployeeService employeeService = new EmployeeService();
        //    var employees = employeeService.GetAll();
        //    employeeService.DeepLoad(employees);
        //    DataTable table = new DataTable();
        //    table.Columns.Add("FullName");
        //    table.Columns.Add("DOB");
        //    table.Columns.Add("Addresses", typeof(List<EmployeeAddressObject>));
        //    foreach (var emp in employees)
        //    {
        //        DataRow row = table.NewRow();
        //        row["FullName"] = emp.FullName;
        //        row["DOB"] = emp.DOB;
        //        if (emp.AddressCollection?.Any() == true)
        //        {
        //            List<EmployeeAddressObject> listAddress = new List<EmployeeAddressObject>();
        //            var addressCollection = emp.AddressCollection.ToList();
        //            foreach (var add in addressCollection)
        //            {
        //                EmployeeAddressObject address = new EmployeeAddressObject
        //                {
        //                    Address = add.Line1
        //                };
        //                listAddress.Add(address);
        //            }
        //            row["Addresses"] = listAddress;
        //        }
        //        table.Rows.Add(row);
        //    }
        //    EmployeeGrid.DataSource = table;
        //    EmployeeGrid.DataBind();
        //}

        //public class EmployeeAddressObject
        //{
        //    public string Address { get; set; }
        //    public string Line1 { get; set; }
        //    public string Line2 { get; set; }
        //}

        //private void BindGrid()
        //{
        //    EmployeeService employeeService = new EmployeeService();
        //    //DataTable dt = new DataTable("dt");
        //    //da.Fill(dt);
        //    var employees = employeeService.GetAll();
        //    //TList<Employee> listEmployeeBinding = new TList<Employee>();
        //    //var employeeBinding = new Employee();
        //    employeeService.DeepLoad(employees);
        //    EmployeeGrid.DataSource = employees;
        //    EmployeeGrid.DataBind();
        //    //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    //string query = "SELECT * FROM Customers";
        //    //using (SqlConnection con = new SqlConnection(constr))
        //    //{
        //    //    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
        //    //    {
        //    //        using (DataTable dt = new DataTable())
        //    //        {
        //    //            sda.Fill(dt);
        //    //            GridView1.DataSource = dt;
        //    //            GridView1.DataBind();
        //    //        }
        //    //    }
        //    //}
        //}
    }
}
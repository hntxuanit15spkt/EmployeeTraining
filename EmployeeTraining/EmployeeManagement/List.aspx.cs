using EmployeeDB.BLL;
using EmployeeDB.CL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;
using EmployeeTraining.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EmployeeTraining.EmployeeManagement
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeGrid.SelectedIndex = 0;
                FillGridView();
            }
            else
            {
            }
        }

        protected void RedirectToCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constant.ADD_URL);
        }
        private void Search(string date, string fromDate, string toDate, string keywords)
        {
            EmployeeFilterBuilder employeeFilterBuilder = new EmployeeFilterBuilder();
            if (!string.IsNullOrEmpty(keywords))
            {
                employeeFilterBuilder.Append(EmployeeDB.BLL.EmployeeColumn.FullName, $"%{keywords}%", true);
            }
            if (!string.IsNullOrEmpty(date))
            {
                DateTime.TryParse(date, out DateTime dateResult);
                employeeFilterBuilder.AppendEquals(EmployeeColumn.DOB, dateResult.ToString("yyyy-MM-dd"));
            }
            //if (!string.IsNullOrEmpty(fromDate))
            //{
            //    DateTime.TryParse(fromDate, out DateTime fromDateResult);
            //    employeeFilterBuilder.AppendGreaterThan(EmployeeColumn.DOB, fromDateResult.ToShortDateString());
            //}
            //if (!string.IsNullOrEmpty(toDate))
            //{
            //    DateTime.TryParse(toDate, out DateTime toDateResult);
            //    employeeFilterBuilder.AppendLessThan(EmployeeColumn.DOB, toDateResult.ToShortDateString());
            //    employeeFilterBuilder.AppendIn(EmployeeColumn.DOB, toDateResult.ToShortDateString());
            //}
            //employeeFilterBuilder.Append(EmployeeColumn.DOB, "London, Berlin");
            //employeeFilterBuilder.Append(EmployeeColumn.DOB, fromDate.ToString(), toDate.ToString());


            int count = 0;
            EmployeeService employeeService = new EmployeeService();
            TList<Employee> employees = DataRepository.EmployeeProvider.GetPaged(employeeFilterBuilder.ToString(), null, 0, 100, out count);
            employeeService.DeepLoad(employees);
            List<EmployeeModel> addressModels = new List<EmployeeModel>();
            foreach (var employee in employees)
            {
                var employeeModel = new EmployeeModel(employee.EmployeeId, employee.EmployeeCode, employee.FullName, employee.FirstName, employee.MiddlesName,
                                                        employee.LastName, employee.DOB, employee.Email, employee.Bio, employee.CreatedOn, employee.AddressCollection);
                addressModels.Add(employeeModel);
            }
            //EmployeeGrid.DataSource = addressModels.OrderByDescending(e => e.CreatedOn).ToList();
            EmployeeGrid.DataSource = addressModels;
            EmployeeGrid.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //DateTime fromDate = DateTime.Parse(txtFromDate.Text.Trim());
            //var a = fromDate.ToShortDateString();
            //DateTime toDate = DateTime.Parse(txtToDate.Text.Trim());
            //string keywords = txtSearch.Text.Trim();
            Search(txtDate.Text.Trim(), txtFromDate.Text.Trim(), txtToDate.Text.Trim(), txtSearch.Text.Trim());
            // Response.Redirect($"{Constant.LIST_URL}?fromDate={fromDate}&toDate={toDate}&{keywords}");
        }

        protected void EmployeeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmployeeGrid.PageIndex = e.NewPageIndex;
            FillGridView();
        }

        protected void lnk_OnUpdate(object sender, EventArgs e)
        {
            Response.Redirect($"{Constant.UPDATE_URL}?employeeID={Convert.ToInt32((sender as LinkButton).CommandArgument)}");
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
                if (listAddress?.Any() == true && dataProvider.AddressProvider.Delete(transactionManager, listAddress) == 0)
                {
                    throw new Exception("An error occurred while deleting Address!");
                }
                var employee = dataProvider.EmployeeProvider.Find($"EmployeeId={employeeId}").FirstOrDefault();
                if (employee != null && !dataProvider.EmployeeProvider.Delete(transactionManager, employee))
                {
                    throw new Exception("An error occurred while deleting Employee!");
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
            List<EmployeeModel> addressModels = new List<EmployeeModel>();
            foreach (var employee in employees)
            {
                var employeeModel = new EmployeeModel(employee.EmployeeId, employee.EmployeeCode, employee.FullName, employee.FirstName, employee.MiddlesName,
                                                        employee.LastName, employee.DOB, employee.Email, employee.Bio, employee.CreatedOn, employee.AddressCollection);
                addressModels.Add(employeeModel);
            }
            //EmployeeGrid.DataSource = addressModels.OrderByDescending(e => e.CreatedOn).ToList();
            EmployeeGrid.DataSource = addressModels;
            EmployeeGrid.DataBind();
        }
    }
}
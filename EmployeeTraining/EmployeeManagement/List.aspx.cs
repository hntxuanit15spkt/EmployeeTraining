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
        }

        protected void RedirectToCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constant.ADD_URL);
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
            EmployeeGrid.DataSource = addressModels.OrderByDescending(e => e.CreatedOn).ToList();
            EmployeeGrid.DataBind();
        }
    }
}
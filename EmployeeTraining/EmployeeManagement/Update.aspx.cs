using EmployeeDB.BLL;
using EmployeeDB.CL;
using EmployeeTraining.Code;
using System;
using System.Linq;

namespace EmployeeTraining.EmployeeManagement
{
    public partial class Update : System.Web.UI.Page
    {
        private string EmployeeID = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            EmployeeID = Request.QueryString["employeeID"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employeeObj = RetrieveEmployeeInformation();
                txtFullName.Text = employeeObj.FullName;
                txtEmployeeCode.Text = employeeObj.EmployeeCode;
                txtFirstName.Text = employeeObj.FirstName;
                txtMiddlesName.Text = employeeObj.MiddlesName;
                txtLastName.Text = employeeObj.LastName;
                txtDOB.Text = employeeObj.DOB.Value.ToString("yyyy-MM-dd");
                txtEmail.Text = employeeObj.Email;
                txtBio.Text = employeeObj.Bio;
                LoadAddress();
            }
        }

        private void ShowGridRows(TList<Address> addressesModel)
        {
            gvContacts.DataSource = addressesModel;
            gvContacts.DataBind();
        }

        private TList<Address> LoadAddress()
        {
            AddressService addressService = new AddressService();
            int.TryParse(EmployeeID, out int employeeId);
            var addresses = addressService.GetByEmployeeId(employeeId);
            ShowGridRows(addresses);
            return addresses;
        }

        private EmployeeModel RetrieveEmployeeInformation()
        {
            var employeeService = new EmployeeService();
            var employee = employeeService.Find($"EmployeeId={EmployeeID}").FirstOrDefault();
            var employeeObject = new EmployeeModel(employee.EmployeeId, employee.EmployeeCode, employee.FullName, employee.FirstName, employee.MiddlesName,
                                                   employee.LastName, employee.DOB, employee.Email, employee.Bio, employee.CreatedOn);
            return employeeObject;
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
        }
    }
}
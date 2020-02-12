using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeDB.BLL;
using EmployeeDB.CL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;
using EmployeeTraining.Code;
using System.Web.UI.WebControls;

namespace EmployeeTraining.EmployeeManagement
{
    public partial class Edit : System.Web.UI.Page
    {
        private string EmployeeID = string.Empty;
        private Employee Employee;
        protected void Page_Init(object sender, EventArgs e)
        {
            EmployeeID = Request.QueryString["employeeID"];
            Employee = GetEmployee();
        }
        private Employee GetEmployee()
        {
            EmployeeService employeeService = new EmployeeService();
            var employeeObject = employeeService.Find($"EmployeeId={EmployeeID}").FirstOrDefault();
            employeeService.DeepLoad(employeeObject);
            return employeeObject;
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constant.LIST_URL);
        }

        private void ShowGridRows(TList<Address> addressesModel)
        {
            gvAddresses.DataSource = addressesModel;
            gvAddresses.DataBind();
        }

        private TList<Address> LoadAddress()
        {
            AddressService addressService = new AddressService();
            int.TryParse(EmployeeID, out int employeeId);
            var addresses = addressService.GetByEmployeeId(employeeId);
            ShowGridRows(addresses);
            return addresses;
        }

        private TList<Countries> LoadCountries()
        {
            CountriesService countriesService = new CountriesService();
            return countriesService.GetAll();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var countries = LoadCountries();
                if (countries.Count > 0)
                {
                    //Find the DropDownList in the Row
                    DropDownList ddlCountries = (e.Row.FindControl("ddlCountries") as DropDownList);
                    ddlCountries.DataSource = countries;
                    ddlCountries.DataTextField = "Name";
                    ddlCountries.DataValueField = "CountryCode";
                    ddlCountries.DataBind();

                    ////Add Default Item in the DropDownList
                    //ddlCountries.Items.Insert(0, new ListItem("Please select"));

                    //Select the Country of Employee in DropDownList
                    string country = (e.Row.FindControl("lblCountryCode") as Label).Text;
                    ddlCountries.Items.FindByValue(country).Selected = true;
                }
            }
        }

        private EmployeeModel RetrieveEmployeeInformation()
        {
            return new EmployeeModel(Employee.EmployeeId, Employee.EmployeeCode, Employee.FullName, Employee.FirstName, Employee.MiddlesName,
                                                   Employee.LastName, Employee.DOB, Employee.Email, Employee.Bio, Employee.CreatedOn);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var employeeObj = new EmployeeModel(txtEmployeeCode.Text.Trim(), txtFullName.Text.Trim(), txtFirstName.Text.Trim(),
                                                txtMiddlesName.Text.Trim(), txtLastName.Text.Trim(), DateTime.Parse(txtDOB.Text.Trim()), txtEmail.Text.Trim(), txtBio.Text.Trim());
            List<AddressModel> listOfAddresses = new List<AddressModel>();
            foreach (GridViewRow row in gvAddresses.Rows)
            {
                var addressId = ((HiddenField)row.FindControl("txtAddressId")).Value;
                var line1 = ((TextBox)row.FindControl("txtLine1")).Text.Trim();
                var line2 = ((TextBox)row.FindControl("txtLine2")).Text.Trim();
                var townCity = ((TextBox)row.FindControl("txtTownCity")).Text.Trim();
                var stateOrProvince = ((TextBox)row.FindControl("txtStateOrProvince")).Text.Trim();
                var postCod = ((TextBox)row.FindControl("txtPostCod")).Text.Trim();
                var countryCode = ((DropDownList)row.FindControl("ddlCountries")).SelectedItem.Value;
                AddressModel address = new AddressModel(int.Parse(addressId), Employee.EmployeeId, line1, line2, townCity, stateOrProvince, postCod, countryCode);
                listOfAddresses.Add(address);
            }
            UpdateEmployee(employeeObj, listOfAddresses);
        }

        private bool UpdateEmployee(EmployeeModel employeeModel, List<AddressModel> addressModels)
        {
            TransactionManager transactionManager = null;
            try
            {
                transactionManager = ConnectionScope.CreateTransaction();
                NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                if (string.IsNullOrEmpty(employeeModel.FullName) || !Employee.FullName.Equals(employeeModel.FullName))
                {
                    Employee.FullName = employeeModel.FullName;
                }
                if (string.IsNullOrEmpty(employeeModel.EmployeeCode) || !Employee.EmployeeCode.Equals(employeeModel.EmployeeCode))
                {
                    Employee.EmployeeCode = employeeModel.EmployeeCode;
                }
                if (string.IsNullOrEmpty(employeeModel.FirstName) || !Employee.FirstName.Equals(employeeModel.FirstName))
                {
                    Employee.FirstName = employeeModel.FirstName;
                }
                if (string.IsNullOrEmpty(employeeModel.MiddlesName) || !Employee.MiddlesName.Equals(employeeModel.MiddlesName))
                {
                    Employee.MiddlesName = employeeModel.MiddlesName;
                }
                if (string.IsNullOrEmpty(employeeModel.LastName) || !Employee.LastName.Equals(employeeModel.LastName))
                {
                    Employee.LastName = employeeModel.LastName;
                }
                if (!employeeModel.DOB.HasValue || (Employee.DOB.HasValue && employeeModel.DOB.HasValue && DateTime.Compare(Employee.DOB.Value, employeeModel.DOB.Value) != 0))
                {
                    Employee.DOB = employeeModel.DOB;
                }
                if (string.IsNullOrEmpty(employeeModel.Email) || !Employee.Email.Equals(employeeModel.Email))
                {
                    Employee.Email = employeeModel.Email;
                }
                if (string.IsNullOrEmpty(employeeModel.Bio) || !Employee.Bio.Equals(employeeModel.Bio))
                {
                    Employee.Bio = employeeModel.Bio;
                }
                if (!dataProvider.EmployeeProvider.Update(transactionManager, Employee))
                {
                    throw new Exception("Can't update Employee");
                }
                TList<Address> addressForUpdate = Employee.AddressCollection;
                foreach (var model in addressModels)
                {
                    var address = addressForUpdate.Single(a => a.AddressId == model.AddressId);
                    if (string.IsNullOrEmpty(address.Line1) || !address.Line1.Equals(model.Line1))
                    {
                        address.Line1 = model.Line1;
                    }
                    if (string.IsNullOrEmpty(address.Line2) || !address.Line2.Equals(model.Line2))
                    {
                        address.Line2 = model.Line2;
                    }
                    if (string.IsNullOrEmpty(address.TownCity) || !address.TownCity.Equals(model.TownCity))
                    {
                        address.TownCity = model.TownCity;
                    }
                    if (string.IsNullOrEmpty(address.StateOrProvince) || !address.StateOrProvince.Equals(model.StateOrProvince))
                    {
                        address.StateOrProvince = model.StateOrProvince;
                    }
                    if (string.IsNullOrEmpty(address.PostCod) || !address.PostCod.Equals(model.PostCod))
                    {
                        address.PostCod = model.PostCod;
                    }
                    if (string.IsNullOrEmpty(address.CountryCode) || !address.CountryCode.Equals(model.CountryCode))
                    {
                        address.CountryCode = model.CountryCode;
                    }
                }
                if (dataProvider.AddressProvider.Update(transactionManager, addressForUpdate) == 0)
                {
                    throw new Exception("Can't update Address");
                }

                transactionManager.Commit();
            }
            catch (Exception exc)
            {
                if (transactionManager != null && transactionManager.IsOpen)
                {
                    transactionManager.Rollback();
                }
                return false;
            }
            return true;
        }
    }
}
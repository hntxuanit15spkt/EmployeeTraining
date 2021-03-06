﻿using System;
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

        //private void ShowGridRows(TList<EmployeeDB.BLL.Address> addressesModel)
        //{
        //    //gvAddresses.DataSource = addressesModel;
        //    //gvAddresses.DataBind();
        //}

        private void ShowGridRows(Address address)
        {
            //gvAddresses.DataSource = addressesModel;
            //gvAddresses.DataBind();
            //if (address != null)
            //{
            //    Address1.AddressId = address.AddressId.ToString();
            //    Address1.Line1 = address.Line1;
            //    Address1.Line2 = address.Line2;
            //    Address1.TownCity = address.TownCity;
            //    Address1.StateOrProvince = address.StateOrProvince;
            //    Address1.PostCod = address.PostCod;
            //    Address1.CountryCode = address.CountryCode;
            //}
            Address1.AddressId = address?.AddressId != null ? address.AddressId.ToString() : string.Empty;
            Address1.Line1 = !string.IsNullOrEmpty(address?.Line1) ? address.Line1 : string.Empty;
            Address1.Line2 = !string.IsNullOrEmpty(address?.Line2) ? address.Line2 : string.Empty;
            Address1.TownCity = !string.IsNullOrEmpty(address?.TownCity) ? address.TownCity : string.Empty;
            Address1.StateOrProvince = !string.IsNullOrEmpty(address?.StateOrProvince) ? address.StateOrProvince : string.Empty;
            Address1.PostCod = !string.IsNullOrEmpty(address?.PostCod) ? address.PostCod : string.Empty;
            Address1.CountryCode = !string.IsNullOrEmpty(address?.CountryCode) ? address.CountryCode : string.Empty;
        }

        private void LoadAddress()
        {
            AddressService addressService = new AddressService();
            int.TryParse(EmployeeID, out int employeeId);
            //var addresses = addressService.GetByEmployeeId(employeeId);
            var address = addressService.GetByEmployeeId(employeeId).FirstOrDefault();
            //ShowGridRows(addresses);
            ShowGridRows(address);
            //return addresses;
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
                    if (!string.IsNullOrEmpty(country))
                    {
                        ddlCountries.Items.FindByValue(country).Selected = true;
                    }
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
            //foreach (GridViewRow row in gvAddresses.Rows)
            //{
            //    var addressId = ((HiddenField)row.FindControl("txtAddressId")).Value;
            //    var line1 = ((TextBox)row.FindControl("txtLine1")).Text.Trim();
            //    var line2 = ((TextBox)row.FindControl("txtLine2")).Text.Trim();
            //    var townCity = ((TextBox)row.FindControl("txtTownCity")).Text.Trim();
            //    var stateOrProvince = ((TextBox)row.FindControl("txtStateOrProvince")).Text.Trim();
            //    var postCod = ((TextBox)row.FindControl("txtPostCod")).Text.Trim();
            //    var countryCode = ((DropDownList)row.FindControl("ddlCountries")).SelectedItem.Value;
            //    AddressModel address = new AddressModel(int.Parse(addressId), Employee.EmployeeId, line1, line2, townCity, stateOrProvince, postCod, countryCode);
            //    listOfAddresses.Add(address);
            //}
            int addressId = 0;
            int.TryParse(Address1.AddressId, out addressId);
            var address1 = new AddressModel(addressId, Employee.EmployeeId, Address1.Line1, Address1.Line2, Address1.TownCity, Address1.StateOrProvince, Address1.PostCod, Address1.CountryCode);
            listOfAddresses.Add(address1);
            UpdateEmployee(employeeObj, listOfAddresses);
        }

        //private void SaveAddress(Address address)
        //{
        //    AddressService addressService = new AddressService();
        //    addressService.Insert()
        //    TransactionManager transactionManager = null;
        //    try
        //    {
        //        transactionManager = ConnectionScope.CreateTransaction();
        //        NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
        //        EmployeeService employeeService = new EmployeeService();
        //        dataProvider.EmployeeProvider.Insert(transactionManager, employee);

        //        foreach (var address in addresses)
        //        {
        //            address.EmployeeId = employee.EmployeeId;
        //        }
        //        dataProvider.AddressProvider.Insert(transactionManager, addresses);
        //        transactionManager.Commit();
        //        Clear();
        //    }
        //    catch (Exception exc)
        //    {
        //        if (transactionManager != null && transactionManager.IsOpen)
        //            transactionManager.Rollback();
        //        lblMsg.Text = "An error occurred while processing your request!";
        //    }
        //}

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
                dataProvider.EmployeeProvider.Update(transactionManager, Employee);
                //if (!dataProvider.EmployeeProvider.Update(transactionManager, Employee))
                //{
                //    throw new Exception("Can't update Employee");
                //}
                TList<Address> addressForUpdate = Employee.AddressCollection;
                foreach (var model in addressModels)
                {
                    if (model.AddressId == 0)
                    {
                        var address = new Address {
                            EmployeeId = model.EmployeeId,
                            Line1 = model.Line1,
                            Line2 = model.Line2,
                            TownCity = model.TownCity,
                            StateOrProvince = model.StateOrProvince,
                            PostCod = model.PostCod,
                            CountryCode = model.CountryCode
                        };
                        dataProvider.AddressProvider.Insert(transactionManager, address);
                    }
                    else
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
                }
                dataProvider.AddressProvider.Update(transactionManager, addressForUpdate);
                //if (dataProvider.AddressProvider.Update(transactionManager, addressForUpdate) == 0)
                //{
                //    throw new Exception("Can't update Address");
                //}

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
﻿using EmployeeDB.BLL;
using EmployeeDB.CL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;
using EmployeeTraining.Code;
using System;
using System.Collections.Generic;
using System.Web.UI;
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
            Employee employee = new Employee
            {
                EmployeeCode = txtEmployeeCode.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                MiddlesName = txtMiddlesName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                DOB = DateTime.Parse(txtDOB.Text.Trim()),
                Email = txtEmail.Text.Trim(),
                Bio = txtBio.Text.Trim(),
                CreatedOn = DateTime.Now
            };
            TList<Address> listOfAddresses = new TList<Address>();
            Address address = new Address
            {
                Line1 = Address1.Line1,
                Line2 = Address1.Line2,
                TownCity = Address1.TownCity,
                StateOrProvince = Address1.StateOrProvince,
                PostCod = Address1.PostCod,
                CountryCode = Address1.CountryCode,
                //StateOrProvince = ((TextBox)row.FindControl("txtStateOrProvince")).Text.Trim(),
                //PostCod = ((TextBox)row.FindControl("txtPostCod")).Text.Trim(),
                //CountryCode = ((DropDownList)row.FindControl("ddlCountries")).SelectedItem.Value,
            };
            listOfAddresses.Add(address);
            //foreach (GridViewRow row in gvAddresses.Rows)
            //{                
            //    Address address = new Address
            //    {
            //        Line1 = ((TextBox)row.FindControl("txtLine1")).Text.Trim(),
            //        Line2 = ((TextBox)row.FindControl("txtLine2")).Text.Trim(),
            //        TownCity = ((TextBox)row.FindControl("txtTownCity")).Text.Trim(),
            //        StateOrProvince = ((TextBox)row.FindControl("txtStateOrProvince")).Text.Trim(),
            //        PostCod = ((TextBox)row.FindControl("txtPostCod")).Text.Trim(),
            //        CountryCode = ((DropDownList)row.FindControl("ddlCountries")).SelectedItem.Value,
            //    };
            //    listOfAddresses.Add(address);
            //}
            SaveEmployee(employee, listOfAddresses);
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Constant.LIST_URL);
        }

        private void SaveEmployee(Employee employee, TList<Address> addresses)
        {
            TransactionManager transactionManager = null;
            try
            {
                transactionManager = ConnectionScope.CreateTransaction();
                NetTiersProvider dataProvider = ConnectionScope.Current.DataProvider;
                EmployeeService employeeService = new EmployeeService();
                dataProvider.EmployeeProvider.Insert(transactionManager, employee);
                
                foreach (var address in addresses)
                {
                    address.EmployeeId = employee.EmployeeId;
                }
                dataProvider.AddressProvider.Insert(transactionManager, addresses);
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
        private TList<Countries> LoadCountries()
        {
            CountriesService countriesService = new CountriesService();
            return countriesService.GetAll();
        }
        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        var countries = LoadCountries();
        //        if (countries.Count > 0)
        //        {
        //            DropDownList ddlCountries = (e.Row.FindControl("ddlCountries") as DropDownList);
        //            ddlCountries.DataSource = countries;
        //            ddlCountries.DataTextField = "Name";
        //            ddlCountries.DataValueField = "CountryCode";
        //            ddlCountries.DataBind();
        //            ddlCountries.Items.Insert(0, new ListItem("Please select"));
        //        }
        //    }
        //}
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

        //protected void btnAddRow_Click(object sender, EventArgs e)
        //{
        //    AddRowsToGrid();
        //}

        //private void AddRowsToGrid()
        //{
        //    List<int> noofRows = new List<int>();
        //    //int rows = 0;
        //    int.TryParse(txtNoOfRecord.Text.Trim(), out int rows);
        //    //List<Control> listOfControl = new List<Control>();
        //    for (int i = 0; i < rows; i++)
        //    {
        //        noofRows.Add(i);
        //        Control control = (Control)Page.LoadControl("~/AddressControl.ascx");
        //        //gvAddresses.Controls.Add(myControl);
        //        //listOfControl.Add(control);
        //        PlaceHolderAddress.Controls.Add(control);
        //        //gvAddresses.Controls.Add(control);
        //    }
        //    //gvAddresses.DataSource = noofRows;
        //    //gvAddresses.DataBind();
        //    //Panel1.Controls.Add(myControl);

        //    //gvAddresses.DataSource = noofRows;
        //    //
        //    //if (gvAddresses.Rows.Count > 0)
        //    //{
        //    //    PanelAdd.Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    PanelAdd.Visible = false;
        //    //}
        //}
    }
}
using EmployeeDB.BLL;
using EmployeeDB.CL;
using System;
using System.Web.UI.WebControls;

namespace EmployeeTraining
{
    public partial class AddressControl : System.Web.UI.UserControl
    {
        public string AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string TownCity { get; set; }
        public string StateOrProvince { get; set; }
        public string PostCod { get; set; }
        public string CountryCode { get; set; }
        //public TextBox txtLine1 { get; set; }
        //public TextBox txtLine2 { get; set; }
        //public TextBox txtTownCity { get; set; }
        //public TextBox txtStateOrProvince { get; set; }
        //public TextBox txtPostCod { get; set; }
        //public string CountryCode { get; set; }
        protected void Page_Init(object sender, EventArgs e)
        {
            InitCountriesList();
        }
        private void InitCountriesList()
        {
            if (!string.IsNullOrEmpty(CountryCode))
            {
                ddlCountries.Items.FindByValue(CountryCode).Selected = true;
                //string country = (e.Row.FindControl("lblCountryCode") as Label).Text;
                //if (!string.IsNullOrEmpty(country))
                //{
                //    ddlCountries.Items.FindByValue(country).Selected = true;
                //}
            }
            else
            {
                var countries = LoadCountries();
                if (countries.Count > 0)
                {
                    ddlCountries.DataSource = countries;
                    ddlCountries.DataTextField = "Name";
                    ddlCountries.DataValueField = "CountryCode";
                    ddlCountries.DataBind();
                    ddlCountries.Items.Insert(0, new ListItem("Please select"));
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAddressControl();
            }
            else
            {
                LoadAddressModel();
            }
        }
        public void LoadAddressControl()
        {
            txtAddressId.Value = AddressId;
            txtLine1.Text = Line1;
            txtLine2.Text = Line2;
            txtTownCity.Text = TownCity;
            txtStateOrProvince.Text = StateOrProvince;
            txtPostCod.Text = PostCod;
            //ddlCountries.SelectedItem.Value = CountryCode;
            if (!string.IsNullOrEmpty(CountryCode))
            {
                ddlCountries.Items.FindByValue(CountryCode).Selected = true;
            }
        }
        public void LoadAddressModel()
        {
            AddressId = txtAddressId.Value;
            Line1 = txtLine1.Text.Trim();
            Line2 = txtLine2.Text.Trim();
            TownCity = txtTownCity.Text.Trim();
            StateOrProvince = txtStateOrProvince.Text.Trim();
            PostCod = txtPostCod.Text.Trim();
            CountryCode = ddlCountries.SelectedItem.Value;
        }
        //public void LoadAddressControl()
        //{
        //    txtAddressId.Value = AddressId;
        //    txtLine1.Text = Line1;
        //    txtLine2.Text = Line2;
        //    txtTownCity.Text = TownCity;
        //    txtStateOrProvince.Text = StateOrProvince;
        //    txtPostCod.Text = PostCod;
        //    //ddlCountries.SelectedItem.Value = CountryCode;
        //    ddlCountries.Items.FindByValue(CountryCode).Selected = true;
        //}
        private TList<Countries> LoadCountries()
        {
            CountriesService countriesService = new CountriesService();
            return countriesService.GetAll();
        }

    }
}
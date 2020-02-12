using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTraining.Code
{
    public class AddressModel
    {
        #region Primary key(s)
        /// <summary>			
        /// AddressId : 
        /// </summary>
        /// <remarks>Member of the primary key of the underlying table "Address"</remarks>
        public int AddressId;

        #endregion

        #region Non Primary key(s)

        /// <summary>
        /// EmployeeId : 
        /// </summary>
        public int EmployeeId { get; set; } = (int)0;

        /// <summary>
        /// Line1 : 
        /// </summary>
        public string Line1 { get; set; } = string.Empty;

        /// <summary>
        /// Line2 : 
        /// </summary>
        public string Line2 { get; set; } = string.Empty;

        /// <summary>
        /// TownCity : 
        /// </summary>
        public string TownCity { get; set; } = string.Empty;

        /// <summary>
        /// StateOrProvince : 
        /// </summary>
        public string StateOrProvince { get; set; } = string.Empty;

        /// <summary>
        /// PostCod : 
        /// </summary>
        public string PostCod { get; set; } = string.Empty;

        /// <summary>
        /// CountryCode : 
        /// </summary>
        public string CountryCode { get; set; } = string.Empty;
        #endregion

        public AddressModel(int employeeId, string line1, string line2, string townCity, string stateOrProvince, string postCod, string countryCode)
        {
            EmployeeId = employeeId;
            Line1 = line1;
            Line2 = line2;
            TownCity = townCity;
            StateOrProvince = stateOrProvince;
            PostCod = postCod;
            CountryCode = countryCode;
        }

        public AddressModel(string line1, string line2, string townCity, string stateOrProvince, string postCod, string countryCode)
        {
            Line1 = line1;
            Line2 = line2;
            TownCity = townCity;
            StateOrProvince = stateOrProvince;
            PostCod = postCod;
            CountryCode = countryCode;
        }

        public AddressModel(int addressId, int employeeId, string line1, string line2, string townCity, string stateOrProvince, string postCod, string countryCode)
        {
            AddressId = addressId;
            EmployeeId = employeeId;
            Line1 = line1;
            Line2 = line2;
            TownCity = townCity;
            StateOrProvince = stateOrProvince;
            PostCod = postCod;
            CountryCode = countryCode;
        }
    }
}
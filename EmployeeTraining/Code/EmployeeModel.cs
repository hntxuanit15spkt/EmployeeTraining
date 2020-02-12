using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTraining.Code
{
    public class EmployeeModel
    {
        #region Primary key(s)
        /// <summary>			
        /// EmployeeId : 
        /// </summary>
        /// <remarks>Member of the primary key of the underlying table "Employee"</remarks>
        public int EmployeeId { get; set; }

        #endregion

        #region Non Primary key(s)

        /// <summary>
        /// EmployeeCode : 
        /// </summary>
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// FullName : 
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// FirstName : 
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// MiddlesName : 
        /// </summary>
        public string MiddlesName { get; set; } = string.Empty;

        /// <summary>
        /// LastName : 
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// DOB : 
        /// </summary>
        public DateTime? DOB { get; set; } = DateTime.Now;

        /// <summary>
        /// Email : 
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Bio : 
        /// </summary>
        public string Bio { get; set; } = string.Empty;

        /// <summary>
        /// CreatedOn : 
        /// </summary>
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        #endregion
        public List<AddressModel> Addresses;

        public EmployeeModel(int employeeId, string employeeCode, string fullName, string firstName,
                             string middlesName, string lastName, DateTime? dOB, string email, string bio, DateTime? createdOn)
        {
            EmployeeId = employeeId;
            EmployeeCode = employeeCode;
            FullName = fullName;
            FirstName = firstName;
            MiddlesName = middlesName;
            LastName = lastName;
            DOB = dOB;
            Email = email;
            Bio = bio;
            CreatedOn = createdOn;
        }

        public EmployeeModel(string employeeCode, string fullName, string firstName, string middlesName, string lastName, DateTime? dOB, string email, string bio)
        {
            EmployeeCode = employeeCode;
            FullName = fullName;
            FirstName = firstName;
            MiddlesName = middlesName;
            LastName = lastName;
            DOB = dOB;
            Email = email;
            Bio = bio;
        }
    }
}
using EmployeeDB.CL;
using System;
using System.Web.UI;

namespace EmployeeTraining
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    //throw new Exception("some test exception");
            //    EmployeeService employeeService = new EmployeeService();
            //    //var emps = employeeService.GetAll();
            //}
            //catch(Exception ex)
            //{
            //    HandleCoreServicesException(ex);
            //}
        }

        /// <summary>
        /// Handles all CoreServices exception.
        /// </summary>
        /// <param name="ex">The CoreService exception.</param>
        /// <returns></returns>
        public  void HandleCoreServicesException(Exception ex)
        {
            if (DomainUtil.HandleException(ex, "CoreServicesPolicy"))
            {
                // the line below is only useful if PostHandling action is 'NotifyRethrow'
                throw ex;
            }
        }
    }
}
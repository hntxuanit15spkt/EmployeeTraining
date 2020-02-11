	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using EmployeeDB.BLL;
using EmployeeDB.BLL.Validation;

using EmployeeDB.DAL;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace EmployeeDB.CL
{		
	/// <summary>
	/// An component type implementation of the 'Employee' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class EmployeeService : EmployeeDB.CL.EmployeeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the EmployeeService class.
		/// </summary>
		public EmployeeService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace

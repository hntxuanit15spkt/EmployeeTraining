#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using EmployeeDB.BLL;
using EmployeeDB.DAL;

#endregion

namespace EmployeeDB.DAL.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="Departments"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlDepartmentsProvider: SqlDepartmentsProviderBase
	{
		/// <summary>
		/// Creates a new <see cref="SqlDepartmentsProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlDepartmentsProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}
	}
}
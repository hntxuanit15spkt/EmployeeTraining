#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using EmployeeDB.BLL;
using EmployeeDB.DAL;

#endregion

namespace EmployeeDB.DAL.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="DepartmentsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DepartmentsProviderBase : DepartmentsProviderBaseCore
	{
	} // end class
} // end namespace

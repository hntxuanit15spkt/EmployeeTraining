
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using EmployeeDB.BLL;

#endregion

namespace EmployeeDB.DAL.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current DepartmentsProviderBase instance.
		///</summary>
		public virtual DepartmentsProviderBase DepartmentsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeDepartmentsProviderBase instance.
		///</summary>
		public virtual EmployeeDepartmentsProviderBase EmployeeDepartmentsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeProviderBase instance.
		///</summary>
		public virtual EmployeeProviderBase EmployeeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountriesProviderBase instance.
		///</summary>
		public virtual CountriesProviderBase CountriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SkillLevelsProviderBase instance.
		///</summary>
		public virtual SkillLevelsProviderBase SkillLevelsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SkillProviderBase instance.
		///</summary>
		public virtual SkillProviderBase SkillProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BankAccountsProviderBase instance.
		///</summary>
		public virtual BankAccountsProviderBase BankAccountsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeSalaryProviderBase instance.
		///</summary>
		public virtual EmployeeSalaryProviderBase EmployeeSalaryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AddressProviderBase instance.
		///</summary>
		public virtual AddressProviderBase AddressProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeSkillsProviderBase instance.
		///</summary>
		public virtual EmployeeSkillsProviderBase EmployeeSkillsProvider{get {throw new NotImplementedException();}}
		
		
	}
}

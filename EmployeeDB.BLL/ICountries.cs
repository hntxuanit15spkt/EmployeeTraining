﻿using System;
using System.ComponentModel;

namespace EmployeeDB.BLL
{
	/// <summary>
	///		The data structure representation of the 'Countries' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICountries 
	{
		/// <summary>			
		/// CountryCode : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Countries"</remarks>
		System.String CountryCode { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalCountryCode { get; set; }
			
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _addressCountryCode
		/// </summary>	
		TList<Address> AddressCollection {  get;  set;}	

		#endregion Data Properties

	}
}



﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using EmployeeDB.BLL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;
using EmployeeDB.CL;
#endregion

namespace EmployeeDB.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AddressProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AddressDataSourceDesigner))]
	public class AddressDataSource : ProviderDataSource<Address, AddressKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressDataSource class.
		/// </summary>
		public AddressDataSource() : base(new AddressService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AddressDataSourceView used by the AddressDataSource.
		/// </summary>
		protected AddressDataSourceView AddressView
		{
			get { return ( View as AddressDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AddressDataSource control invokes to retrieve data.
		/// </summary>
		public AddressSelectMethod SelectMethod
		{
			get
			{
				AddressSelectMethod selectMethod = AddressSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AddressSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AddressDataSourceView class that is to be
		/// used by the AddressDataSource.
		/// </summary>
		/// <returns>An instance of the AddressDataSourceView class.</returns>
		protected override BaseDataSourceView<Address, AddressKey> GetNewDataSourceView()
		{
			return new AddressDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the AddressDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AddressDataSourceView : ProviderDataSourceView<Address, AddressKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AddressDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AddressDataSourceView(AddressDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AddressDataSource AddressOwner
		{
			get { return Owner as AddressDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AddressSelectMethod SelectMethod
		{
			get { return AddressOwner.SelectMethod; }
			set { AddressOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AddressService AddressProvider
		{
			get { return Provider as AddressService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Address> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Address> results = null;
			Address item;
			count = 0;
			
			System.Int32 _addressId;
			System.String _countryCode_nullable;
			System.Int32 _employeeId;

			switch ( SelectMethod )
			{
				case AddressSelectMethod.Get:
					AddressKey entityKey  = new AddressKey();
					entityKey.Load(values);
					item = AddressProvider.Get(entityKey);
					results = new TList<Address>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AddressSelectMethod.GetAll:
                    results = AddressProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AddressSelectMethod.GetPaged:
					results = AddressProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AddressSelectMethod.Find:
					if ( FilterParameters != null )
						results = AddressProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AddressProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AddressSelectMethod.GetByAddressId:
					_addressId = ( values["AddressId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AddressId"], typeof(System.Int32)) : (int)0;
					item = AddressProvider.GetByAddressId(_addressId);
					results = new TList<Address>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AddressSelectMethod.GetByCountryCode:
					_countryCode_nullable = (System.String) EntityUtil.ChangeType(values["CountryCode"], typeof(System.String));
					results = AddressProvider.GetByCountryCode(_countryCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case AddressSelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = AddressProvider.GetByEmployeeId(_employeeId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AddressSelectMethod.Get || SelectMethod == AddressSelectMethod.GetByAddressId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Address entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AddressProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<Address> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AddressProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AddressDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AddressDataSource class.
	/// </summary>
	public class AddressDataSourceDesigner : ProviderDataSourceDesigner<Address, AddressKey>
	{
		/// <summary>
		/// Initializes a new instance of the AddressDataSourceDesigner class.
		/// </summary>
		public AddressDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AddressSelectMethod SelectMethod
		{
			get { return ((AddressDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new AddressDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AddressDataSourceActionList

	/// <summary>
	/// Supports the AddressDataSourceDesigner class.
	/// </summary>
	internal class AddressDataSourceActionList : DesignerActionList
	{
		private AddressDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AddressDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AddressDataSourceActionList(AddressDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AddressSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion AddressDataSourceActionList
	
	#endregion AddressDataSourceDesigner
	
	#region AddressSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AddressDataSource.SelectMethod property.
	/// </summary>
	public enum AddressSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByAddressId method.
		/// </summary>
		GetByAddressId,
		/// <summary>
		/// Represents the GetByCountryCode method.
		/// </summary>
		GetByCountryCode,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion AddressSelectMethod

	#region AddressFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressFilter : SqlFilter<AddressColumn>
	{
	}
	
	#endregion AddressFilter

	#region AddressExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressExpressionBuilder : SqlExpressionBuilder<AddressColumn>
	{
	}
	
	#endregion AddressExpressionBuilder	

	#region AddressProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AddressChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressProperty : ChildEntityProperty<AddressChildEntityTypes>
	{
	}
	
	#endregion AddressProperty
}


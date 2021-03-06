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
	/// Represents the DataRepository.DepartmentsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DepartmentsDataSourceDesigner))]
	public class DepartmentsDataSource : ProviderDataSource<Departments, DepartmentsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsDataSource class.
		/// </summary>
		public DepartmentsDataSource() : base(new DepartmentsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DepartmentsDataSourceView used by the DepartmentsDataSource.
		/// </summary>
		protected DepartmentsDataSourceView DepartmentsView
		{
			get { return ( View as DepartmentsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DepartmentsDataSource control invokes to retrieve data.
		/// </summary>
		public DepartmentsSelectMethod SelectMethod
		{
			get
			{
				DepartmentsSelectMethod selectMethod = DepartmentsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DepartmentsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DepartmentsDataSourceView class that is to be
		/// used by the DepartmentsDataSource.
		/// </summary>
		/// <returns>An instance of the DepartmentsDataSourceView class.</returns>
		protected override BaseDataSourceView<Departments, DepartmentsKey> GetNewDataSourceView()
		{
			return new DepartmentsDataSourceView(this, DefaultViewName);
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
	/// Supports the DepartmentsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DepartmentsDataSourceView : ProviderDataSourceView<Departments, DepartmentsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DepartmentsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DepartmentsDataSourceView(DepartmentsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DepartmentsDataSource DepartmentsOwner
		{
			get { return Owner as DepartmentsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DepartmentsSelectMethod SelectMethod
		{
			get { return DepartmentsOwner.SelectMethod; }
			set { DepartmentsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DepartmentsService DepartmentsProvider
		{
			get { return Provider as DepartmentsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Departments> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Departments> results = null;
			Departments item;
			count = 0;
			
			System.String _departmentCode;

			switch ( SelectMethod )
			{
				case DepartmentsSelectMethod.Get:
					DepartmentsKey entityKey  = new DepartmentsKey();
					entityKey.Load(values);
					item = DepartmentsProvider.Get(entityKey);
					results = new TList<Departments>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DepartmentsSelectMethod.GetAll:
                    results = DepartmentsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DepartmentsSelectMethod.GetPaged:
					results = DepartmentsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DepartmentsSelectMethod.Find:
					if ( FilterParameters != null )
						results = DepartmentsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DepartmentsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DepartmentsSelectMethod.GetByDepartmentCode:
					_departmentCode = ( values["DepartmentCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["DepartmentCode"], typeof(System.String)) : string.Empty;
					item = DepartmentsProvider.GetByDepartmentCode(_departmentCode);
					results = new TList<Departments>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == DepartmentsSelectMethod.Get || SelectMethod == DepartmentsSelectMethod.GetByDepartmentCode )
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
				Departments entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DepartmentsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Departments> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DepartmentsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DepartmentsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DepartmentsDataSource class.
	/// </summary>
	public class DepartmentsDataSourceDesigner : ProviderDataSourceDesigner<Departments, DepartmentsKey>
	{
		/// <summary>
		/// Initializes a new instance of the DepartmentsDataSourceDesigner class.
		/// </summary>
		public DepartmentsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DepartmentsSelectMethod SelectMethod
		{
			get { return ((DepartmentsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DepartmentsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DepartmentsDataSourceActionList

	/// <summary>
	/// Supports the DepartmentsDataSourceDesigner class.
	/// </summary>
	internal class DepartmentsDataSourceActionList : DesignerActionList
	{
		private DepartmentsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DepartmentsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DepartmentsDataSourceActionList(DepartmentsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DepartmentsSelectMethod SelectMethod
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

	#endregion DepartmentsDataSourceActionList
	
	#endregion DepartmentsDataSourceDesigner
	
	#region DepartmentsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DepartmentsDataSource.SelectMethod property.
	/// </summary>
	public enum DepartmentsSelectMethod
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
		/// Represents the GetByDepartmentCode method.
		/// </summary>
		GetByDepartmentCode
	}
	
	#endregion DepartmentsSelectMethod

	#region DepartmentsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsFilter : SqlFilter<DepartmentsColumn>
	{
	}
	
	#endregion DepartmentsFilter

	#region DepartmentsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsExpressionBuilder : SqlExpressionBuilder<DepartmentsColumn>
	{
	}
	
	#endregion DepartmentsExpressionBuilder	

	#region DepartmentsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DepartmentsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsProperty : ChildEntityProperty<DepartmentsChildEntityTypes>
	{
	}
	
	#endregion DepartmentsProperty
}


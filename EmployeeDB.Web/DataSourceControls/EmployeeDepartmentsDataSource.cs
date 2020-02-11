#region Using Directives
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
	/// Represents the DataRepository.EmployeeDepartmentsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeeDepartmentsDataSourceDesigner))]
	public class EmployeeDepartmentsDataSource : ProviderDataSource<EmployeeDepartments, EmployeeDepartmentsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsDataSource class.
		/// </summary>
		public EmployeeDepartmentsDataSource() : base(new EmployeeDepartmentsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeeDepartmentsDataSourceView used by the EmployeeDepartmentsDataSource.
		/// </summary>
		protected EmployeeDepartmentsDataSourceView EmployeeDepartmentsView
		{
			get { return ( View as EmployeeDepartmentsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeeDepartmentsDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeeDepartmentsSelectMethod SelectMethod
		{
			get
			{
				EmployeeDepartmentsSelectMethod selectMethod = EmployeeDepartmentsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeeDepartmentsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeeDepartmentsDataSourceView class that is to be
		/// used by the EmployeeDepartmentsDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeeDepartmentsDataSourceView class.</returns>
		protected override BaseDataSourceView<EmployeeDepartments, EmployeeDepartmentsKey> GetNewDataSourceView()
		{
			return new EmployeeDepartmentsDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeeDepartmentsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeeDepartmentsDataSourceView : ProviderDataSourceView<EmployeeDepartments, EmployeeDepartmentsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeeDepartmentsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeeDepartmentsDataSourceView(EmployeeDepartmentsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeeDepartmentsDataSource EmployeeDepartmentsOwner
		{
			get { return Owner as EmployeeDepartmentsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeeDepartmentsSelectMethod SelectMethod
		{
			get { return EmployeeDepartmentsOwner.SelectMethod; }
			set { EmployeeDepartmentsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeeDepartmentsService EmployeeDepartmentsProvider
		{
			get { return Provider as EmployeeDepartmentsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmployeeDepartments> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmployeeDepartments> results = null;
			EmployeeDepartments item;
			count = 0;
			
			System.Int32 _employeeDepartmentId;
			System.String _departmentCode_nullable;
			System.Int32? _employeeId_nullable;

			switch ( SelectMethod )
			{
				case EmployeeDepartmentsSelectMethod.Get:
					EmployeeDepartmentsKey entityKey  = new EmployeeDepartmentsKey();
					entityKey.Load(values);
					item = EmployeeDepartmentsProvider.Get(entityKey);
					results = new TList<EmployeeDepartments>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeDepartmentsSelectMethod.GetAll:
                    results = EmployeeDepartmentsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeeDepartmentsSelectMethod.GetPaged:
					results = EmployeeDepartmentsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeeDepartmentsSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeeDepartmentsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeeDepartmentsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeeDepartmentsSelectMethod.GetByEmployeeDepartmentId:
					_employeeDepartmentId = ( values["EmployeeDepartmentId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeDepartmentId"], typeof(System.Int32)) : (int)0;
					item = EmployeeDepartmentsProvider.GetByEmployeeDepartmentId(_employeeDepartmentId);
					results = new TList<EmployeeDepartments>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EmployeeDepartmentsSelectMethod.GetByDepartmentCode:
					_departmentCode_nullable = (System.String) EntityUtil.ChangeType(values["DepartmentCode"], typeof(System.String));
					results = EmployeeDepartmentsProvider.GetByDepartmentCode(_departmentCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EmployeeDepartmentsSelectMethod.GetByEmployeeId:
					_employeeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32?));
					results = EmployeeDepartmentsProvider.GetByEmployeeId(_employeeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeeDepartmentsSelectMethod.Get || SelectMethod == EmployeeDepartmentsSelectMethod.GetByEmployeeDepartmentId )
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
				EmployeeDepartments entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeeDepartmentsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmployeeDepartments> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeeDepartmentsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeeDepartmentsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeeDepartmentsDataSource class.
	/// </summary>
	public class EmployeeDepartmentsDataSourceDesigner : ProviderDataSourceDesigner<EmployeeDepartments, EmployeeDepartmentsKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsDataSourceDesigner class.
		/// </summary>
		public EmployeeDepartmentsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeDepartmentsSelectMethod SelectMethod
		{
			get { return ((EmployeeDepartmentsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeeDepartmentsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeeDepartmentsDataSourceActionList

	/// <summary>
	/// Supports the EmployeeDepartmentsDataSourceDesigner class.
	/// </summary>
	internal class EmployeeDepartmentsDataSourceActionList : DesignerActionList
	{
		private EmployeeDepartmentsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeeDepartmentsDataSourceActionList(EmployeeDepartmentsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeDepartmentsSelectMethod SelectMethod
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

	#endregion EmployeeDepartmentsDataSourceActionList
	
	#endregion EmployeeDepartmentsDataSourceDesigner
	
	#region EmployeeDepartmentsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeeDepartmentsDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeeDepartmentsSelectMethod
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
		/// Represents the GetByEmployeeDepartmentId method.
		/// </summary>
		GetByEmployeeDepartmentId,
		/// <summary>
		/// Represents the GetByDepartmentCode method.
		/// </summary>
		GetByDepartmentCode,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion EmployeeDepartmentsSelectMethod

	#region EmployeeDepartmentsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsFilter : SqlFilter<EmployeeDepartmentsColumn>
	{
	}
	
	#endregion EmployeeDepartmentsFilter

	#region EmployeeDepartmentsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsExpressionBuilder : SqlExpressionBuilder<EmployeeDepartmentsColumn>
	{
	}
	
	#endregion EmployeeDepartmentsExpressionBuilder	

	#region EmployeeDepartmentsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeeDepartmentsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsProperty : ChildEntityProperty<EmployeeDepartmentsChildEntityTypes>
	{
	}
	
	#endregion EmployeeDepartmentsProperty
}


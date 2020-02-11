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
	/// Represents the DataRepository.EmployeeSalaryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeeSalaryDataSourceDesigner))]
	public class EmployeeSalaryDataSource : ProviderDataSource<EmployeeSalary, EmployeeSalaryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryDataSource class.
		/// </summary>
		public EmployeeSalaryDataSource() : base(new EmployeeSalaryService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeeSalaryDataSourceView used by the EmployeeSalaryDataSource.
		/// </summary>
		protected EmployeeSalaryDataSourceView EmployeeSalaryView
		{
			get { return ( View as EmployeeSalaryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeeSalaryDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeeSalarySelectMethod SelectMethod
		{
			get
			{
				EmployeeSalarySelectMethod selectMethod = EmployeeSalarySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeeSalarySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeeSalaryDataSourceView class that is to be
		/// used by the EmployeeSalaryDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeeSalaryDataSourceView class.</returns>
		protected override BaseDataSourceView<EmployeeSalary, EmployeeSalaryKey> GetNewDataSourceView()
		{
			return new EmployeeSalaryDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeeSalaryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeeSalaryDataSourceView : ProviderDataSourceView<EmployeeSalary, EmployeeSalaryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeeSalaryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeeSalaryDataSourceView(EmployeeSalaryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeeSalaryDataSource EmployeeSalaryOwner
		{
			get { return Owner as EmployeeSalaryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeeSalarySelectMethod SelectMethod
		{
			get { return EmployeeSalaryOwner.SelectMethod; }
			set { EmployeeSalaryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeeSalaryService EmployeeSalaryProvider
		{
			get { return Provider as EmployeeSalaryService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmployeeSalary> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmployeeSalary> results = null;
			EmployeeSalary item;
			count = 0;
			
			System.Int32 _employeeSalaryId;
			System.Int32? _employeeId_nullable;

			switch ( SelectMethod )
			{
				case EmployeeSalarySelectMethod.Get:
					EmployeeSalaryKey entityKey  = new EmployeeSalaryKey();
					entityKey.Load(values);
					item = EmployeeSalaryProvider.Get(entityKey);
					results = new TList<EmployeeSalary>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeSalarySelectMethod.GetAll:
                    results = EmployeeSalaryProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeeSalarySelectMethod.GetPaged:
					results = EmployeeSalaryProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeeSalarySelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeeSalaryProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeeSalaryProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeeSalarySelectMethod.GetByEmployeeSalaryId:
					_employeeSalaryId = ( values["EmployeeSalaryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeSalaryId"], typeof(System.Int32)) : (int)0;
					item = EmployeeSalaryProvider.GetByEmployeeSalaryId(_employeeSalaryId);
					results = new TList<EmployeeSalary>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EmployeeSalarySelectMethod.GetByEmployeeId:
					_employeeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32?));
					results = EmployeeSalaryProvider.GetByEmployeeId(_employeeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeeSalarySelectMethod.Get || SelectMethod == EmployeeSalarySelectMethod.GetByEmployeeSalaryId )
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
				EmployeeSalary entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeeSalaryProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmployeeSalary> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeeSalaryProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeeSalaryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeeSalaryDataSource class.
	/// </summary>
	public class EmployeeSalaryDataSourceDesigner : ProviderDataSourceDesigner<EmployeeSalary, EmployeeSalaryKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryDataSourceDesigner class.
		/// </summary>
		public EmployeeSalaryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeSalarySelectMethod SelectMethod
		{
			get { return ((EmployeeSalaryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeeSalaryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeeSalaryDataSourceActionList

	/// <summary>
	/// Supports the EmployeeSalaryDataSourceDesigner class.
	/// </summary>
	internal class EmployeeSalaryDataSourceActionList : DesignerActionList
	{
		private EmployeeSalaryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeeSalaryDataSourceActionList(EmployeeSalaryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeSalarySelectMethod SelectMethod
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

	#endregion EmployeeSalaryDataSourceActionList
	
	#endregion EmployeeSalaryDataSourceDesigner
	
	#region EmployeeSalarySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeeSalaryDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeeSalarySelectMethod
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
		/// Represents the GetByEmployeeSalaryId method.
		/// </summary>
		GetByEmployeeSalaryId,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion EmployeeSalarySelectMethod

	#region EmployeeSalaryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSalaryFilter : SqlFilter<EmployeeSalaryColumn>
	{
	}
	
	#endregion EmployeeSalaryFilter

	#region EmployeeSalaryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSalaryExpressionBuilder : SqlExpressionBuilder<EmployeeSalaryColumn>
	{
	}
	
	#endregion EmployeeSalaryExpressionBuilder	

	#region EmployeeSalaryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeeSalaryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSalaryProperty : ChildEntityProperty<EmployeeSalaryChildEntityTypes>
	{
	}
	
	#endregion EmployeeSalaryProperty
}


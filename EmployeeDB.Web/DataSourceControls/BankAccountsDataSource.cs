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
	/// Represents the DataRepository.BankAccountsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BankAccountsDataSourceDesigner))]
	public class BankAccountsDataSource : ProviderDataSource<BankAccounts, BankAccountsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsDataSource class.
		/// </summary>
		public BankAccountsDataSource() : base(new BankAccountsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BankAccountsDataSourceView used by the BankAccountsDataSource.
		/// </summary>
		protected BankAccountsDataSourceView BankAccountsView
		{
			get { return ( View as BankAccountsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BankAccountsDataSource control invokes to retrieve data.
		/// </summary>
		public BankAccountsSelectMethod SelectMethod
		{
			get
			{
				BankAccountsSelectMethod selectMethod = BankAccountsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BankAccountsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BankAccountsDataSourceView class that is to be
		/// used by the BankAccountsDataSource.
		/// </summary>
		/// <returns>An instance of the BankAccountsDataSourceView class.</returns>
		protected override BaseDataSourceView<BankAccounts, BankAccountsKey> GetNewDataSourceView()
		{
			return new BankAccountsDataSourceView(this, DefaultViewName);
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
	/// Supports the BankAccountsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BankAccountsDataSourceView : ProviderDataSourceView<BankAccounts, BankAccountsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BankAccountsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BankAccountsDataSourceView(BankAccountsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BankAccountsDataSource BankAccountsOwner
		{
			get { return Owner as BankAccountsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BankAccountsSelectMethod SelectMethod
		{
			get { return BankAccountsOwner.SelectMethod; }
			set { BankAccountsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BankAccountsService BankAccountsProvider
		{
			get { return Provider as BankAccountsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BankAccounts> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BankAccounts> results = null;
			BankAccounts item;
			count = 0;
			
			System.Int32 _bankAccountId;
			System.Int32 _employeeId;

			switch ( SelectMethod )
			{
				case BankAccountsSelectMethod.Get:
					BankAccountsKey entityKey  = new BankAccountsKey();
					entityKey.Load(values);
					item = BankAccountsProvider.Get(entityKey);
					results = new TList<BankAccounts>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BankAccountsSelectMethod.GetAll:
                    results = BankAccountsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case BankAccountsSelectMethod.GetPaged:
					results = BankAccountsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BankAccountsSelectMethod.Find:
					if ( FilterParameters != null )
						results = BankAccountsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BankAccountsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BankAccountsSelectMethod.GetByBankAccountId:
					_bankAccountId = ( values["BankAccountId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["BankAccountId"], typeof(System.Int32)) : (int)0;
					item = BankAccountsProvider.GetByBankAccountId(_bankAccountId);
					results = new TList<BankAccounts>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case BankAccountsSelectMethod.GetByEmployeeId:
					_employeeId = ( values["EmployeeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32)) : (int)0;
					results = BankAccountsProvider.GetByEmployeeId(_employeeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == BankAccountsSelectMethod.Get || SelectMethod == BankAccountsSelectMethod.GetByBankAccountId )
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
				BankAccounts entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					BankAccountsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BankAccounts> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			BankAccountsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BankAccountsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BankAccountsDataSource class.
	/// </summary>
	public class BankAccountsDataSourceDesigner : ProviderDataSourceDesigner<BankAccounts, BankAccountsKey>
	{
		/// <summary>
		/// Initializes a new instance of the BankAccountsDataSourceDesigner class.
		/// </summary>
		public BankAccountsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BankAccountsSelectMethod SelectMethod
		{
			get { return ((BankAccountsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BankAccountsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BankAccountsDataSourceActionList

	/// <summary>
	/// Supports the BankAccountsDataSourceDesigner class.
	/// </summary>
	internal class BankAccountsDataSourceActionList : DesignerActionList
	{
		private BankAccountsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BankAccountsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BankAccountsDataSourceActionList(BankAccountsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BankAccountsSelectMethod SelectMethod
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

	#endregion BankAccountsDataSourceActionList
	
	#endregion BankAccountsDataSourceDesigner
	
	#region BankAccountsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BankAccountsDataSource.SelectMethod property.
	/// </summary>
	public enum BankAccountsSelectMethod
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
		/// Represents the GetByBankAccountId method.
		/// </summary>
		GetByBankAccountId,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion BankAccountsSelectMethod

	#region BankAccountsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsFilter : SqlFilter<BankAccountsColumn>
	{
	}
	
	#endregion BankAccountsFilter

	#region BankAccountsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsExpressionBuilder : SqlExpressionBuilder<BankAccountsColumn>
	{
	}
	
	#endregion BankAccountsExpressionBuilder	

	#region BankAccountsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BankAccountsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsProperty : ChildEntityProperty<BankAccountsChildEntityTypes>
	{
	}
	
	#endregion BankAccountsProperty
}


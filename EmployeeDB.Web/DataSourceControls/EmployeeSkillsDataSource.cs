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
	/// Represents the DataRepository.EmployeeSkillsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmployeeSkillsDataSourceDesigner))]
	public class EmployeeSkillsDataSource : ProviderDataSource<EmployeeSkills, EmployeeSkillsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsDataSource class.
		/// </summary>
		public EmployeeSkillsDataSource() : base(new EmployeeSkillsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmployeeSkillsDataSourceView used by the EmployeeSkillsDataSource.
		/// </summary>
		protected EmployeeSkillsDataSourceView EmployeeSkillsView
		{
			get { return ( View as EmployeeSkillsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmployeeSkillsDataSource control invokes to retrieve data.
		/// </summary>
		public EmployeeSkillsSelectMethod SelectMethod
		{
			get
			{
				EmployeeSkillsSelectMethod selectMethod = EmployeeSkillsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmployeeSkillsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmployeeSkillsDataSourceView class that is to be
		/// used by the EmployeeSkillsDataSource.
		/// </summary>
		/// <returns>An instance of the EmployeeSkillsDataSourceView class.</returns>
		protected override BaseDataSourceView<EmployeeSkills, EmployeeSkillsKey> GetNewDataSourceView()
		{
			return new EmployeeSkillsDataSourceView(this, DefaultViewName);
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
	/// Supports the EmployeeSkillsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmployeeSkillsDataSourceView : ProviderDataSourceView<EmployeeSkills, EmployeeSkillsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmployeeSkillsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmployeeSkillsDataSourceView(EmployeeSkillsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmployeeSkillsDataSource EmployeeSkillsOwner
		{
			get { return Owner as EmployeeSkillsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmployeeSkillsSelectMethod SelectMethod
		{
			get { return EmployeeSkillsOwner.SelectMethod; }
			set { EmployeeSkillsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmployeeSkillsService EmployeeSkillsProvider
		{
			get { return Provider as EmployeeSkillsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmployeeSkills> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmployeeSkills> results = null;
			EmployeeSkills item;
			count = 0;
			
			System.Int32 _employeeSkillId;
			System.String _skillCode_nullable;
			System.String _skillLevel_nullable;
			System.Int32? _employeeId_nullable;

			switch ( SelectMethod )
			{
				case EmployeeSkillsSelectMethod.Get:
					EmployeeSkillsKey entityKey  = new EmployeeSkillsKey();
					entityKey.Load(values);
					item = EmployeeSkillsProvider.Get(entityKey);
					results = new TList<EmployeeSkills>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmployeeSkillsSelectMethod.GetAll:
                    results = EmployeeSkillsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmployeeSkillsSelectMethod.GetPaged:
					results = EmployeeSkillsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmployeeSkillsSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmployeeSkillsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmployeeSkillsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmployeeSkillsSelectMethod.GetByEmployeeSkillId:
					_employeeSkillId = ( values["EmployeeSkillId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeSkillId"], typeof(System.Int32)) : (int)0;
					item = EmployeeSkillsProvider.GetByEmployeeSkillId(_employeeSkillId);
					results = new TList<EmployeeSkills>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EmployeeSkillsSelectMethod.GetBySkillCode:
					_skillCode_nullable = (System.String) EntityUtil.ChangeType(values["SkillCode"], typeof(System.String));
					results = EmployeeSkillsProvider.GetBySkillCode(_skillCode_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EmployeeSkillsSelectMethod.GetBySkillLevel:
					_skillLevel_nullable = (System.String) EntityUtil.ChangeType(values["SkillLevel"], typeof(System.String));
					results = EmployeeSkillsProvider.GetBySkillLevel(_skillLevel_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case EmployeeSkillsSelectMethod.GetByEmployeeId:
					_employeeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["EmployeeId"], typeof(System.Int32?));
					results = EmployeeSkillsProvider.GetByEmployeeId(_employeeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EmployeeSkillsSelectMethod.Get || SelectMethod == EmployeeSkillsSelectMethod.GetByEmployeeSkillId )
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
				EmployeeSkills entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmployeeSkillsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmployeeSkills> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmployeeSkillsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmployeeSkillsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmployeeSkillsDataSource class.
	/// </summary>
	public class EmployeeSkillsDataSourceDesigner : ProviderDataSourceDesigner<EmployeeSkills, EmployeeSkillsKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsDataSourceDesigner class.
		/// </summary>
		public EmployeeSkillsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeSkillsSelectMethod SelectMethod
		{
			get { return ((EmployeeSkillsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmployeeSkillsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmployeeSkillsDataSourceActionList

	/// <summary>
	/// Supports the EmployeeSkillsDataSourceDesigner class.
	/// </summary>
	internal class EmployeeSkillsDataSourceActionList : DesignerActionList
	{
		private EmployeeSkillsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmployeeSkillsDataSourceActionList(EmployeeSkillsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmployeeSkillsSelectMethod SelectMethod
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

	#endregion EmployeeSkillsDataSourceActionList
	
	#endregion EmployeeSkillsDataSourceDesigner
	
	#region EmployeeSkillsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmployeeSkillsDataSource.SelectMethod property.
	/// </summary>
	public enum EmployeeSkillsSelectMethod
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
		/// Represents the GetByEmployeeSkillId method.
		/// </summary>
		GetByEmployeeSkillId,
		/// <summary>
		/// Represents the GetBySkillCode method.
		/// </summary>
		GetBySkillCode,
		/// <summary>
		/// Represents the GetBySkillLevel method.
		/// </summary>
		GetBySkillLevel,
		/// <summary>
		/// Represents the GetByEmployeeId method.
		/// </summary>
		GetByEmployeeId
	}
	
	#endregion EmployeeSkillsSelectMethod

	#region EmployeeSkillsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsFilter : SqlFilter<EmployeeSkillsColumn>
	{
	}
	
	#endregion EmployeeSkillsFilter

	#region EmployeeSkillsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsExpressionBuilder : SqlExpressionBuilder<EmployeeSkillsColumn>
	{
	}
	
	#endregion EmployeeSkillsExpressionBuilder	

	#region EmployeeSkillsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmployeeSkillsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsProperty : ChildEntityProperty<EmployeeSkillsChildEntityTypes>
	{
	}
	
	#endregion EmployeeSkillsProperty
}


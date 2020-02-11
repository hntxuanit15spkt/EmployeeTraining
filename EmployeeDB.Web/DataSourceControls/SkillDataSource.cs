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
	/// Represents the DataRepository.SkillProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SkillDataSourceDesigner))]
	public class SkillDataSource : ProviderDataSource<Skill, SkillKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillDataSource class.
		/// </summary>
		public SkillDataSource() : base(new SkillService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SkillDataSourceView used by the SkillDataSource.
		/// </summary>
		protected SkillDataSourceView SkillView
		{
			get { return ( View as SkillDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SkillDataSource control invokes to retrieve data.
		/// </summary>
		public SkillSelectMethod SelectMethod
		{
			get
			{
				SkillSelectMethod selectMethod = SkillSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SkillSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SkillDataSourceView class that is to be
		/// used by the SkillDataSource.
		/// </summary>
		/// <returns>An instance of the SkillDataSourceView class.</returns>
		protected override BaseDataSourceView<Skill, SkillKey> GetNewDataSourceView()
		{
			return new SkillDataSourceView(this, DefaultViewName);
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
	/// Supports the SkillDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SkillDataSourceView : ProviderDataSourceView<Skill, SkillKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SkillDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SkillDataSourceView(SkillDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SkillDataSource SkillOwner
		{
			get { return Owner as SkillDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SkillSelectMethod SelectMethod
		{
			get { return SkillOwner.SelectMethod; }
			set { SkillOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SkillService SkillProvider
		{
			get { return Provider as SkillService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Skill> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Skill> results = null;
			Skill item;
			count = 0;
			
			System.String _skillCode;

			switch ( SelectMethod )
			{
				case SkillSelectMethod.Get:
					SkillKey entityKey  = new SkillKey();
					entityKey.Load(values);
					item = SkillProvider.Get(entityKey);
					results = new TList<Skill>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SkillSelectMethod.GetAll:
                    results = SkillProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SkillSelectMethod.GetPaged:
					results = SkillProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SkillSelectMethod.Find:
					if ( FilterParameters != null )
						results = SkillProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SkillProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SkillSelectMethod.GetBySkillCode:
					_skillCode = ( values["SkillCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["SkillCode"], typeof(System.String)) : string.Empty;
					item = SkillProvider.GetBySkillCode(_skillCode);
					results = new TList<Skill>();
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
			if ( SelectMethod == SkillSelectMethod.Get || SelectMethod == SkillSelectMethod.GetBySkillCode )
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
				Skill entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SkillProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Skill> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SkillProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SkillDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SkillDataSource class.
	/// </summary>
	public class SkillDataSourceDesigner : ProviderDataSourceDesigner<Skill, SkillKey>
	{
		/// <summary>
		/// Initializes a new instance of the SkillDataSourceDesigner class.
		/// </summary>
		public SkillDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SkillSelectMethod SelectMethod
		{
			get { return ((SkillDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SkillDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SkillDataSourceActionList

	/// <summary>
	/// Supports the SkillDataSourceDesigner class.
	/// </summary>
	internal class SkillDataSourceActionList : DesignerActionList
	{
		private SkillDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SkillDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SkillDataSourceActionList(SkillDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SkillSelectMethod SelectMethod
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

	#endregion SkillDataSourceActionList
	
	#endregion SkillDataSourceDesigner
	
	#region SkillSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SkillDataSource.SelectMethod property.
	/// </summary>
	public enum SkillSelectMethod
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
		/// Represents the GetBySkillCode method.
		/// </summary>
		GetBySkillCode
	}
	
	#endregion SkillSelectMethod

	#region SkillFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillFilter : SqlFilter<SkillColumn>
	{
	}
	
	#endregion SkillFilter

	#region SkillExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillExpressionBuilder : SqlExpressionBuilder<SkillColumn>
	{
	}
	
	#endregion SkillExpressionBuilder	

	#region SkillProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SkillChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillProperty : ChildEntityProperty<SkillChildEntityTypes>
	{
	}
	
	#endregion SkillProperty
}


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
	/// Represents the DataRepository.SkillLevelsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SkillLevelsDataSourceDesigner))]
	public class SkillLevelsDataSource : ProviderDataSource<SkillLevels, SkillLevelsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsDataSource class.
		/// </summary>
		public SkillLevelsDataSource() : base(new SkillLevelsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SkillLevelsDataSourceView used by the SkillLevelsDataSource.
		/// </summary>
		protected SkillLevelsDataSourceView SkillLevelsView
		{
			get { return ( View as SkillLevelsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SkillLevelsDataSource control invokes to retrieve data.
		/// </summary>
		public SkillLevelsSelectMethod SelectMethod
		{
			get
			{
				SkillLevelsSelectMethod selectMethod = SkillLevelsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SkillLevelsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SkillLevelsDataSourceView class that is to be
		/// used by the SkillLevelsDataSource.
		/// </summary>
		/// <returns>An instance of the SkillLevelsDataSourceView class.</returns>
		protected override BaseDataSourceView<SkillLevels, SkillLevelsKey> GetNewDataSourceView()
		{
			return new SkillLevelsDataSourceView(this, DefaultViewName);
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
	/// Supports the SkillLevelsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SkillLevelsDataSourceView : ProviderDataSourceView<SkillLevels, SkillLevelsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SkillLevelsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SkillLevelsDataSourceView(SkillLevelsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SkillLevelsDataSource SkillLevelsOwner
		{
			get { return Owner as SkillLevelsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SkillLevelsSelectMethod SelectMethod
		{
			get { return SkillLevelsOwner.SelectMethod; }
			set { SkillLevelsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SkillLevelsService SkillLevelsProvider
		{
			get { return Provider as SkillLevelsService; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SkillLevels> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SkillLevels> results = null;
			SkillLevels item;
			count = 0;
			
			System.String _levelCode;

			switch ( SelectMethod )
			{
				case SkillLevelsSelectMethod.Get:
					SkillLevelsKey entityKey  = new SkillLevelsKey();
					entityKey.Load(values);
					item = SkillLevelsProvider.Get(entityKey);
					results = new TList<SkillLevels>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SkillLevelsSelectMethod.GetAll:
                    results = SkillLevelsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SkillLevelsSelectMethod.GetPaged:
					results = SkillLevelsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SkillLevelsSelectMethod.Find:
					if ( FilterParameters != null )
						results = SkillLevelsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SkillLevelsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SkillLevelsSelectMethod.GetByLevelCode:
					_levelCode = ( values["LevelCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["LevelCode"], typeof(System.String)) : string.Empty;
					item = SkillLevelsProvider.GetByLevelCode(_levelCode);
					results = new TList<SkillLevels>();
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
			if ( SelectMethod == SkillLevelsSelectMethod.Get || SelectMethod == SkillLevelsSelectMethod.GetByLevelCode )
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
				SkillLevels entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SkillLevelsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SkillLevels> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SkillLevelsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SkillLevelsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SkillLevelsDataSource class.
	/// </summary>
	public class SkillLevelsDataSourceDesigner : ProviderDataSourceDesigner<SkillLevels, SkillLevelsKey>
	{
		/// <summary>
		/// Initializes a new instance of the SkillLevelsDataSourceDesigner class.
		/// </summary>
		public SkillLevelsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SkillLevelsSelectMethod SelectMethod
		{
			get { return ((SkillLevelsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SkillLevelsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SkillLevelsDataSourceActionList

	/// <summary>
	/// Supports the SkillLevelsDataSourceDesigner class.
	/// </summary>
	internal class SkillLevelsDataSourceActionList : DesignerActionList
	{
		private SkillLevelsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SkillLevelsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SkillLevelsDataSourceActionList(SkillLevelsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SkillLevelsSelectMethod SelectMethod
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

	#endregion SkillLevelsDataSourceActionList
	
	#endregion SkillLevelsDataSourceDesigner
	
	#region SkillLevelsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SkillLevelsDataSource.SelectMethod property.
	/// </summary>
	public enum SkillLevelsSelectMethod
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
		/// Represents the GetByLevelCode method.
		/// </summary>
		GetByLevelCode
	}
	
	#endregion SkillLevelsSelectMethod

	#region SkillLevelsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsFilter : SqlFilter<SkillLevelsColumn>
	{
	}
	
	#endregion SkillLevelsFilter

	#region SkillLevelsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsExpressionBuilder : SqlExpressionBuilder<SkillLevelsColumn>
	{
	}
	
	#endregion SkillLevelsExpressionBuilder	

	#region SkillLevelsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SkillLevelsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsProperty : ChildEntityProperty<SkillLevelsChildEntityTypes>
	{
	}
	
	#endregion SkillLevelsProperty
}


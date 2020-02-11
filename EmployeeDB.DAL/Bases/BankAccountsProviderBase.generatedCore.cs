#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using EmployeeDB.BLL;
using EmployeeDB.DAL;

#endregion

namespace EmployeeDB.DAL.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="BankAccountsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BankAccountsProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.BankAccounts, EmployeeDB.BLL.BankAccountsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.BankAccountsKey key)
		{
			return Delete(transactionManager, key.BankAccountId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_bankAccountId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _bankAccountId)
		{
			return Delete(null, _bankAccountId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bankAccountId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _bankAccountId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BankAccounts_Employee key.
		///		FK_BankAccounts_Employee Description: 
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.BankAccounts objects.</returns>
		public TList<BankAccounts> GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BankAccounts_Employee key.
		///		FK_BankAccounts_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.BankAccounts objects.</returns>
		/// <remarks></remarks>
		public TList<BankAccounts> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_BankAccounts_Employee key.
		///		FK_BankAccounts_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.BankAccounts objects.</returns>
		public TList<BankAccounts> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BankAccounts_Employee key.
		///		fKBankAccountsEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.BankAccounts objects.</returns>
		public TList<BankAccounts> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BankAccounts_Employee key.
		///		fKBankAccountsEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.BankAccounts objects.</returns>
		public TList<BankAccounts> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_BankAccounts_Employee key.
		///		FK_BankAccounts_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.BankAccounts objects.</returns>
		public abstract TList<BankAccounts> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override EmployeeDB.BLL.BankAccounts Get(TransactionManager transactionManager, EmployeeDB.BLL.BankAccountsKey key, int start, int pageLength)
		{
			return GetByBankAccountId(transactionManager, key.BankAccountId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_BankAccounts index.
		/// </summary>
		/// <param name="_bankAccountId"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.BankAccounts"/> class.</returns>
		public EmployeeDB.BLL.BankAccounts GetByBankAccountId(System.Int32 _bankAccountId)
		{
			int count = -1;
			return GetByBankAccountId(null,_bankAccountId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BankAccounts index.
		/// </summary>
		/// <param name="_bankAccountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.BankAccounts"/> class.</returns>
		public EmployeeDB.BLL.BankAccounts GetByBankAccountId(System.Int32 _bankAccountId, int start, int pageLength)
		{
			int count = -1;
			return GetByBankAccountId(null, _bankAccountId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BankAccounts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bankAccountId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.BankAccounts"/> class.</returns>
		public EmployeeDB.BLL.BankAccounts GetByBankAccountId(TransactionManager transactionManager, System.Int32 _bankAccountId)
		{
			int count = -1;
			return GetByBankAccountId(transactionManager, _bankAccountId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BankAccounts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bankAccountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.BankAccounts"/> class.</returns>
		public EmployeeDB.BLL.BankAccounts GetByBankAccountId(TransactionManager transactionManager, System.Int32 _bankAccountId, int start, int pageLength)
		{
			int count = -1;
			return GetByBankAccountId(transactionManager, _bankAccountId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BankAccounts index.
		/// </summary>
		/// <param name="_bankAccountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.BankAccounts"/> class.</returns>
		public EmployeeDB.BLL.BankAccounts GetByBankAccountId(System.Int32 _bankAccountId, int start, int pageLength, out int count)
		{
			return GetByBankAccountId(null, _bankAccountId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_BankAccounts index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_bankAccountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.BankAccounts"/> class.</returns>
		public abstract EmployeeDB.BLL.BankAccounts GetByBankAccountId(TransactionManager transactionManager, System.Int32 _bankAccountId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;BankAccounts&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;BankAccounts&gt;"/></returns>
		public static TList<BankAccounts> Fill(IDataReader reader, TList<BankAccounts> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				EmployeeDB.BLL.BankAccounts c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("BankAccounts")
					.Append("|").Append((System.Int32)reader[((int)BankAccountsColumn.BankAccountId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<BankAccounts>(
					key.ToString(), // EntityTrackingKey
					"BankAccounts",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.BankAccounts();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.BankAccountId = (System.Int32)reader[((int)BankAccountsColumn.BankAccountId - 1)];
					c.EmployeeId = (System.Int32)reader[((int)BankAccountsColumn.EmployeeId - 1)];
					c.BankName = (reader.IsDBNull(((int)BankAccountsColumn.BankName - 1)))?null:(System.String)reader[((int)BankAccountsColumn.BankName - 1)];
					c.AccountNumber = (reader.IsDBNull(((int)BankAccountsColumn.AccountNumber - 1)))?null:(System.String)reader[((int)BankAccountsColumn.AccountNumber - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)BankAccountsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)BankAccountsColumn.CreatedOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.BankAccounts"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.BankAccounts"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.BankAccounts entity)
		{
			if (!reader.Read()) return;
			
			entity.BankAccountId = (System.Int32)reader[((int)BankAccountsColumn.BankAccountId - 1)];
			entity.EmployeeId = (System.Int32)reader[((int)BankAccountsColumn.EmployeeId - 1)];
			entity.BankName = (reader.IsDBNull(((int)BankAccountsColumn.BankName - 1)))?null:(System.String)reader[((int)BankAccountsColumn.BankName - 1)];
			entity.AccountNumber = (reader.IsDBNull(((int)BankAccountsColumn.AccountNumber - 1)))?null:(System.String)reader[((int)BankAccountsColumn.AccountNumber - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)BankAccountsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)BankAccountsColumn.CreatedOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.BankAccounts"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.BankAccounts"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.BankAccounts entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.BankAccountId = (System.Int32)dataRow["BankAccountId"];
			entity.EmployeeId = (System.Int32)dataRow["EmployeeId"];
			entity.BankName = Convert.IsDBNull(dataRow["BankName"]) ? null : (System.String)dataRow["BankName"];
			entity.AccountNumber = Convert.IsDBNull(dataRow["AccountNumber"]) ? null : (System.String)dataRow["AccountNumber"];
			entity.CreatedOn = Convert.IsDBNull(dataRow["CreatedOn"]) ? null : (System.DateTime?)dataRow["CreatedOn"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.BankAccounts"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.BankAccounts Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.BankAccounts entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employee|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmployeeId;
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.EmployeeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmployeeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the EmployeeDB.BLL.BankAccounts object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.BankAccounts instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.BankAccounts Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.BankAccounts entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region EmployeeIdSource
			if (CanDeepSave(entity, "Employee|EmployeeIdSource", deepSaveType, innerList) 
				&& entity.EmployeeIdSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeIdSource);
				entity.EmployeeId = entity.EmployeeIdSource.EmployeeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region BankAccountsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.BankAccounts</c>
	///</summary>
	public enum BankAccountsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		}
	
	#endregion BankAccountsChildEntityTypes
	
	#region BankAccountsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BankAccountsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsFilterBuilder : SqlFilterBuilder<BankAccountsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsFilterBuilder class.
		/// </summary>
		public BankAccountsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BankAccountsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BankAccountsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BankAccountsFilterBuilder
	
	#region BankAccountsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BankAccountsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsParameterBuilder : ParameterizedSqlFilterBuilder<BankAccountsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsParameterBuilder class.
		/// </summary>
		public BankAccountsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BankAccountsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BankAccountsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BankAccountsParameterBuilder
	
	#region BankAccountsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;BankAccountsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class BankAccountsSortBuilder : SqlSortBuilder<BankAccountsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsSqlSortBuilder class.
		/// </summary>
		public BankAccountsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion BankAccountsSortBuilder
	
} // end namespace

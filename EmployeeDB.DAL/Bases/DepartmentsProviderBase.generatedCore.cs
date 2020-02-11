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
	/// This class is the base class for any <see cref="DepartmentsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DepartmentsProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.Departments, EmployeeDB.BLL.DepartmentsKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.DepartmentsKey key)
		{
			return Delete(transactionManager, key.DepartmentCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_departmentCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _departmentCode)
		{
			return Delete(null, _departmentCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _departmentCode);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override EmployeeDB.BLL.Departments Get(TransactionManager transactionManager, EmployeeDB.BLL.DepartmentsKey key, int start, int pageLength)
		{
			return GetByDepartmentCode(transactionManager, key.DepartmentCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Departments index.
		/// </summary>
		/// <param name="_departmentCode"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Departments"/> class.</returns>
		public EmployeeDB.BLL.Departments GetByDepartmentCode(System.String _departmentCode)
		{
			int count = -1;
			return GetByDepartmentCode(null,_departmentCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="_departmentCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Departments"/> class.</returns>
		public EmployeeDB.BLL.Departments GetByDepartmentCode(System.String _departmentCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentCode(null, _departmentCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Departments"/> class.</returns>
		public EmployeeDB.BLL.Departments GetByDepartmentCode(TransactionManager transactionManager, System.String _departmentCode)
		{
			int count = -1;
			return GetByDepartmentCode(transactionManager, _departmentCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Departments"/> class.</returns>
		public EmployeeDB.BLL.Departments GetByDepartmentCode(TransactionManager transactionManager, System.String _departmentCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentCode(transactionManager, _departmentCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="_departmentCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Departments"/> class.</returns>
		public EmployeeDB.BLL.Departments GetByDepartmentCode(System.String _departmentCode, int start, int pageLength, out int count)
		{
			return GetByDepartmentCode(null, _departmentCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Departments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Departments"/> class.</returns>
		public abstract EmployeeDB.BLL.Departments GetByDepartmentCode(TransactionManager transactionManager, System.String _departmentCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Departments&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Departments&gt;"/></returns>
		public static TList<Departments> Fill(IDataReader reader, TList<Departments> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.Departments c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Departments")
					.Append("|").Append((System.String)reader[((int)DepartmentsColumn.DepartmentCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Departments>(
					key.ToString(), // EntityTrackingKey
					"Departments",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.Departments();
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
					c.DepartmentCode = (System.String)reader[((int)DepartmentsColumn.DepartmentCode - 1)];
					c.OriginalDepartmentCode = c.DepartmentCode;
					c.Name = (reader.IsDBNull(((int)DepartmentsColumn.Name - 1)))?null:(System.String)reader[((int)DepartmentsColumn.Name - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)DepartmentsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)DepartmentsColumn.CreatedOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Departments"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Departments"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.Departments entity)
		{
			if (!reader.Read()) return;
			
			entity.DepartmentCode = (System.String)reader[((int)DepartmentsColumn.DepartmentCode - 1)];
			entity.OriginalDepartmentCode = (System.String)reader["DepartmentCode"];
			entity.Name = (reader.IsDBNull(((int)DepartmentsColumn.Name - 1)))?null:(System.String)reader[((int)DepartmentsColumn.Name - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)DepartmentsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)DepartmentsColumn.CreatedOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Departments"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Departments"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.Departments entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DepartmentCode = (System.String)dataRow["DepartmentCode"];
			entity.OriginalDepartmentCode = (System.String)dataRow["DepartmentCode"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Departments"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Departments Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.Departments entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByDepartmentCode methods when available
			
			#region EmployeeDepartmentsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeDepartments>|EmployeeDepartmentsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeDepartmentsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeDepartmentsCollection = DataRepository.EmployeeDepartmentsProvider.GetByDepartmentCode(transactionManager, entity.DepartmentCode);

				if (deep && entity.EmployeeDepartmentsCollection.Count > 0)
				{
					deepHandles.Add("EmployeeDepartmentsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeDepartments>) DataRepository.EmployeeDepartmentsProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeDepartmentsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.Departments object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.Departments instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Departments Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.Departments entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<EmployeeDepartments>
				if (CanDeepSave(entity.EmployeeDepartmentsCollection, "List<EmployeeDepartments>|EmployeeDepartmentsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeDepartments child in entity.EmployeeDepartmentsCollection)
					{
						if(child.DepartmentCodeSource != null)
						{
							child.DepartmentCode = child.DepartmentCodeSource.DepartmentCode;
						}
						else
						{
							child.DepartmentCode = entity.DepartmentCode;
						}

					}

					if (entity.EmployeeDepartmentsCollection.Count > 0 || entity.EmployeeDepartmentsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeDepartmentsProvider.Save(transactionManager, entity.EmployeeDepartmentsCollection);
						
						deepHandles.Add("EmployeeDepartmentsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeDepartments >) DataRepository.EmployeeDepartmentsProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeDepartmentsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
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
	
	#region DepartmentsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.Departments</c>
	///</summary>
	public enum DepartmentsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Departments</c> as OneToMany for EmployeeDepartmentsCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeDepartments>))]
		EmployeeDepartmentsCollection,
	}
	
	#endregion DepartmentsChildEntityTypes
	
	#region DepartmentsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DepartmentsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsFilterBuilder : SqlFilterBuilder<DepartmentsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsFilterBuilder class.
		/// </summary>
		public DepartmentsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentsFilterBuilder
	
	#region DepartmentsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DepartmentsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsParameterBuilder : ParameterizedSqlFilterBuilder<DepartmentsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsParameterBuilder class.
		/// </summary>
		public DepartmentsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentsParameterBuilder
	
	#region DepartmentsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DepartmentsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DepartmentsSortBuilder : SqlSortBuilder<DepartmentsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsSqlSortBuilder class.
		/// </summary>
		public DepartmentsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DepartmentsSortBuilder
	
} // end namespace

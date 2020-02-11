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
	/// This class is the base class for any <see cref="EmployeeDepartmentsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeDepartmentsProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.EmployeeDepartments, EmployeeDB.BLL.EmployeeDepartmentsKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeDepartmentsKey key)
		{
			return Delete(transactionManager, key.EmployeeDepartmentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeDepartmentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeDepartmentId)
		{
			return Delete(null, _employeeDepartmentId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeDepartmentId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeDepartmentId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Departments key.
		///		FK_EmployeeDepartments_Departments Description: 
		/// </summary>
		/// <param name="_departmentCode"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByDepartmentCode(System.String _departmentCode)
		{
			int count = -1;
			return GetByDepartmentCode(_departmentCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Departments key.
		///		FK_EmployeeDepartments_Departments Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeDepartments> GetByDepartmentCode(TransactionManager transactionManager, System.String _departmentCode)
		{
			int count = -1;
			return GetByDepartmentCode(transactionManager, _departmentCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Departments key.
		///		FK_EmployeeDepartments_Departments Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByDepartmentCode(TransactionManager transactionManager, System.String _departmentCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDepartmentCode(transactionManager, _departmentCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Departments key.
		///		fKEmployeeDepartmentsDepartments Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByDepartmentCode(System.String _departmentCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByDepartmentCode(null, _departmentCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Departments key.
		///		fKEmployeeDepartmentsDepartments Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_departmentCode"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByDepartmentCode(System.String _departmentCode, int start, int pageLength,out int count)
		{
			return GetByDepartmentCode(null, _departmentCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Departments key.
		///		FK_EmployeeDepartments_Departments Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_departmentCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public abstract TList<EmployeeDepartments> GetByDepartmentCode(TransactionManager transactionManager, System.String _departmentCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Employee key.
		///		FK_EmployeeDepartments_Employee Description: 
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByEmployeeId(System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Employee key.
		///		FK_EmployeeDepartments_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeDepartments> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Employee key.
		///		FK_EmployeeDepartments_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Employee key.
		///		fKEmployeeDepartmentsEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Employee key.
		///		fKEmployeeDepartmentsEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public TList<EmployeeDepartments> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeDepartments_Employee key.
		///		FK_EmployeeDepartments_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeDepartments objects.</returns>
		public abstract TList<EmployeeDepartments> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength, out int count);
		
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
		public override EmployeeDB.BLL.EmployeeDepartments Get(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeDepartmentsKey key, int start, int pageLength)
		{
			return GetByEmployeeDepartmentId(transactionManager, key.EmployeeDepartmentId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmployeeDepartments index.
		/// </summary>
		/// <param name="_employeeDepartmentId"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> class.</returns>
		public EmployeeDB.BLL.EmployeeDepartments GetByEmployeeDepartmentId(System.Int32 _employeeDepartmentId)
		{
			int count = -1;
			return GetByEmployeeDepartmentId(null,_employeeDepartmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartments index.
		/// </summary>
		/// <param name="_employeeDepartmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> class.</returns>
		public EmployeeDB.BLL.EmployeeDepartments GetByEmployeeDepartmentId(System.Int32 _employeeDepartmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeDepartmentId(null, _employeeDepartmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeDepartmentId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> class.</returns>
		public EmployeeDB.BLL.EmployeeDepartments GetByEmployeeDepartmentId(TransactionManager transactionManager, System.Int32 _employeeDepartmentId)
		{
			int count = -1;
			return GetByEmployeeDepartmentId(transactionManager, _employeeDepartmentId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeDepartmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> class.</returns>
		public EmployeeDB.BLL.EmployeeDepartments GetByEmployeeDepartmentId(TransactionManager transactionManager, System.Int32 _employeeDepartmentId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeDepartmentId(transactionManager, _employeeDepartmentId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartments index.
		/// </summary>
		/// <param name="_employeeDepartmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> class.</returns>
		public EmployeeDB.BLL.EmployeeDepartments GetByEmployeeDepartmentId(System.Int32 _employeeDepartmentId, int start, int pageLength, out int count)
		{
			return GetByEmployeeDepartmentId(null, _employeeDepartmentId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeDepartments index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeDepartmentId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> class.</returns>
		public abstract EmployeeDB.BLL.EmployeeDepartments GetByEmployeeDepartmentId(TransactionManager transactionManager, System.Int32 _employeeDepartmentId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmployeeDepartments&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmployeeDepartments&gt;"/></returns>
		public static TList<EmployeeDepartments> Fill(IDataReader reader, TList<EmployeeDepartments> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.EmployeeDepartments c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmployeeDepartments")
					.Append("|").Append((System.Int32)reader[((int)EmployeeDepartmentsColumn.EmployeeDepartmentId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmployeeDepartments>(
					key.ToString(), // EntityTrackingKey
					"EmployeeDepartments",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.EmployeeDepartments();
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
					c.EmployeeDepartmentId = (System.Int32)reader[((int)EmployeeDepartmentsColumn.EmployeeDepartmentId - 1)];
					c.DepartmentCode = (reader.IsDBNull(((int)EmployeeDepartmentsColumn.DepartmentCode - 1)))?null:(System.String)reader[((int)EmployeeDepartmentsColumn.DepartmentCode - 1)];
					c.EmployeeId = (reader.IsDBNull(((int)EmployeeDepartmentsColumn.EmployeeId - 1)))?null:(System.Int32?)reader[((int)EmployeeDepartmentsColumn.EmployeeId - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)EmployeeDepartmentsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeDepartmentsColumn.CreatedOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.EmployeeDepartments"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.EmployeeDepartments entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeDepartmentId = (System.Int32)reader[((int)EmployeeDepartmentsColumn.EmployeeDepartmentId - 1)];
			entity.DepartmentCode = (reader.IsDBNull(((int)EmployeeDepartmentsColumn.DepartmentCode - 1)))?null:(System.String)reader[((int)EmployeeDepartmentsColumn.DepartmentCode - 1)];
			entity.EmployeeId = (reader.IsDBNull(((int)EmployeeDepartmentsColumn.EmployeeId - 1)))?null:(System.Int32?)reader[((int)EmployeeDepartmentsColumn.EmployeeId - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)EmployeeDepartmentsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeDepartmentsColumn.CreatedOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.EmployeeDepartments"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.EmployeeDepartments"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.EmployeeDepartments entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeDepartmentId = (System.Int32)dataRow["EmployeeDepartmentId"];
			entity.DepartmentCode = Convert.IsDBNull(dataRow["DepartmentCode"]) ? null : (System.String)dataRow["DepartmentCode"];
			entity.EmployeeId = Convert.IsDBNull(dataRow["EmployeeId"]) ? null : (System.Int32?)dataRow["EmployeeId"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.EmployeeDepartments"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.EmployeeDepartments Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeDepartments entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DepartmentCodeSource	
			if (CanDeepLoad(entity, "Departments|DepartmentCodeSource", deepLoadType, innerList) 
				&& entity.DepartmentCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DepartmentCode ?? string.Empty);
				Departments tmpEntity = EntityManager.LocateEntity<Departments>(EntityLocator.ConstructKeyFromPkItems(typeof(Departments), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DepartmentCodeSource = tmpEntity;
				else
					entity.DepartmentCodeSource = DataRepository.DepartmentsProvider.GetByDepartmentCode(transactionManager, (entity.DepartmentCode ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DepartmentCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DepartmentCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DepartmentsProvider.DeepLoad(transactionManager, entity.DepartmentCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DepartmentCodeSource

			#region EmployeeIdSource	
			if (CanDeepLoad(entity, "Employee|EmployeeIdSource", deepLoadType, innerList) 
				&& entity.EmployeeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.EmployeeId ?? (int)0);
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeIdSource = tmpEntity;
				else
					entity.EmployeeIdSource = DataRepository.EmployeeProvider.GetByEmployeeId(transactionManager, (entity.EmployeeId ?? (int)0));		
				
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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.EmployeeDepartments object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.EmployeeDepartments instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.EmployeeDepartments Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeDepartments entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DepartmentCodeSource
			if (CanDeepSave(entity, "Departments|DepartmentCodeSource", deepSaveType, innerList) 
				&& entity.DepartmentCodeSource != null)
			{
				DataRepository.DepartmentsProvider.Save(transactionManager, entity.DepartmentCodeSource);
				entity.DepartmentCode = entity.DepartmentCodeSource.DepartmentCode;
			}
			#endregion 
			
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
	
	#region EmployeeDepartmentsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.EmployeeDepartments</c>
	///</summary>
	public enum EmployeeDepartmentsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Departments</c> at DepartmentCodeSource
		///</summary>
		[ChildEntityType(typeof(Departments))]
		Departments,
			
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		}
	
	#endregion EmployeeDepartmentsChildEntityTypes
	
	#region EmployeeDepartmentsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeDepartmentsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsFilterBuilder : SqlFilterBuilder<EmployeeDepartmentsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsFilterBuilder class.
		/// </summary>
		public EmployeeDepartmentsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentsFilterBuilder
	
	#region EmployeeDepartmentsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeDepartmentsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeDepartmentsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsParameterBuilder class.
		/// </summary>
		public EmployeeDepartmentsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentsParameterBuilder
	
	#region EmployeeDepartmentsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeDepartmentsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeDepartmentsSortBuilder : SqlSortBuilder<EmployeeDepartmentsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsSqlSortBuilder class.
		/// </summary>
		public EmployeeDepartmentsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeDepartmentsSortBuilder
	
} // end namespace

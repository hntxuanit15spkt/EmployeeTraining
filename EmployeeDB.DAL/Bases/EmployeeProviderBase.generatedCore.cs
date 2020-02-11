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
	/// This class is the base class for any <see cref="EmployeeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.Employee, EmployeeDB.BLL.EmployeeKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeKey key)
		{
			return Delete(transactionManager, key.EmployeeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeId)
		{
			return Delete(null, _employeeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeId);		
		
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
		public override EmployeeDB.BLL.Employee Get(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeKey key, int start, int pageLength)
		{
			return GetByEmployeeId(transactionManager, key.EmployeeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Employee index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Employee"/> class.</returns>
		public EmployeeDB.BLL.Employee GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(null,_employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Employee"/> class.</returns>
		public EmployeeDB.BLL.Employee GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Employee"/> class.</returns>
		public EmployeeDB.BLL.Employee GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Employee"/> class.</returns>
		public EmployeeDB.BLL.Employee GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee index.
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Employee"/> class.</returns>
		public EmployeeDB.BLL.Employee GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength, out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Employee"/> class.</returns>
		public abstract EmployeeDB.BLL.Employee GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Employee&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Employee&gt;"/></returns>
		public static TList<Employee> Fill(IDataReader reader, TList<Employee> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.Employee c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Employee")
					.Append("|").Append((System.Int32)reader[((int)EmployeeColumn.EmployeeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Employee>(
					key.ToString(), // EntityTrackingKey
					"Employee",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.Employee();
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
					c.EmployeeId = (System.Int32)reader[((int)EmployeeColumn.EmployeeId - 1)];
					c.EmployeeCode = (reader.IsDBNull(((int)EmployeeColumn.EmployeeCode - 1)))?null:(System.String)reader[((int)EmployeeColumn.EmployeeCode - 1)];
					c.FullName = (reader.IsDBNull(((int)EmployeeColumn.FullName - 1)))?null:(System.String)reader[((int)EmployeeColumn.FullName - 1)];
					c.FirstName = (reader.IsDBNull(((int)EmployeeColumn.FirstName - 1)))?null:(System.String)reader[((int)EmployeeColumn.FirstName - 1)];
					c.MiddlesName = (reader.IsDBNull(((int)EmployeeColumn.MiddlesName - 1)))?null:(System.String)reader[((int)EmployeeColumn.MiddlesName - 1)];
					c.LastName = (reader.IsDBNull(((int)EmployeeColumn.LastName - 1)))?null:(System.String)reader[((int)EmployeeColumn.LastName - 1)];
					c.DOB = (reader.IsDBNull(((int)EmployeeColumn.DOB - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.DOB - 1)];
					c.Email = (reader.IsDBNull(((int)EmployeeColumn.Email - 1)))?null:(System.String)reader[((int)EmployeeColumn.Email - 1)];
					c.Bio = (reader.IsDBNull(((int)EmployeeColumn.Bio - 1)))?null:(System.String)reader[((int)EmployeeColumn.Bio - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)EmployeeColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.CreatedOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Employee"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Employee"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.Employee entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeId = (System.Int32)reader[((int)EmployeeColumn.EmployeeId - 1)];
			entity.EmployeeCode = (reader.IsDBNull(((int)EmployeeColumn.EmployeeCode - 1)))?null:(System.String)reader[((int)EmployeeColumn.EmployeeCode - 1)];
			entity.FullName = (reader.IsDBNull(((int)EmployeeColumn.FullName - 1)))?null:(System.String)reader[((int)EmployeeColumn.FullName - 1)];
			entity.FirstName = (reader.IsDBNull(((int)EmployeeColumn.FirstName - 1)))?null:(System.String)reader[((int)EmployeeColumn.FirstName - 1)];
			entity.MiddlesName = (reader.IsDBNull(((int)EmployeeColumn.MiddlesName - 1)))?null:(System.String)reader[((int)EmployeeColumn.MiddlesName - 1)];
			entity.LastName = (reader.IsDBNull(((int)EmployeeColumn.LastName - 1)))?null:(System.String)reader[((int)EmployeeColumn.LastName - 1)];
			entity.DOB = (reader.IsDBNull(((int)EmployeeColumn.DOB - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.DOB - 1)];
			entity.Email = (reader.IsDBNull(((int)EmployeeColumn.Email - 1)))?null:(System.String)reader[((int)EmployeeColumn.Email - 1)];
			entity.Bio = (reader.IsDBNull(((int)EmployeeColumn.Bio - 1)))?null:(System.String)reader[((int)EmployeeColumn.Bio - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)EmployeeColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.CreatedOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Employee"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Employee"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.Employee entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeId = (System.Int32)dataRow["EmployeeId"];
			entity.EmployeeCode = Convert.IsDBNull(dataRow["EmployeeCode"]) ? null : (System.String)dataRow["EmployeeCode"];
			entity.FullName = Convert.IsDBNull(dataRow["FullName"]) ? null : (System.String)dataRow["FullName"];
			entity.FirstName = Convert.IsDBNull(dataRow["FirstName"]) ? null : (System.String)dataRow["FirstName"];
			entity.MiddlesName = Convert.IsDBNull(dataRow["MiddlesName"]) ? null : (System.String)dataRow["MiddlesName"];
			entity.LastName = Convert.IsDBNull(dataRow["LastName"]) ? null : (System.String)dataRow["LastName"];
			entity.DOB = Convert.IsDBNull(dataRow["DOB"]) ? null : (System.DateTime?)dataRow["DOB"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Bio = Convert.IsDBNull(dataRow["Bio"]) ? null : (System.String)dataRow["Bio"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Employee"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Employee Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.Employee entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByEmployeeId methods when available
			
			#region EmployeeSkillsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeSkills>|EmployeeSkillsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeSkillsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeSkillsCollection = DataRepository.EmployeeSkillsProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeSkillsCollection.Count > 0)
				{
					deepHandles.Add("EmployeeSkillsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeSkills>) DataRepository.EmployeeSkillsProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeSkillsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmployeeDepartmentsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeDepartments>|EmployeeDepartmentsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeDepartmentsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeDepartmentsCollection = DataRepository.EmployeeDepartmentsProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeDepartmentsCollection.Count > 0)
				{
					deepHandles.Add("EmployeeDepartmentsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeDepartments>) DataRepository.EmployeeDepartmentsProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeDepartmentsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region EmployeeSalaryCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeSalary>|EmployeeSalaryCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeSalaryCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeSalaryCollection = DataRepository.EmployeeSalaryProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.EmployeeSalaryCollection.Count > 0)
				{
					deepHandles.Add("EmployeeSalaryCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeSalary>) DataRepository.EmployeeSalaryProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeSalaryCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Address>|AddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AddressCollection = DataRepository.AddressProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.AddressCollection.Count > 0)
				{
					deepHandles.Add("AddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Address>) DataRepository.AddressProvider.DeepLoad,
						new object[] { transactionManager, entity.AddressCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region BankAccountsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<BankAccounts>|BankAccountsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BankAccountsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BankAccountsCollection = DataRepository.BankAccountsProvider.GetByEmployeeId(transactionManager, entity.EmployeeId);

				if (deep && entity.BankAccountsCollection.Count > 0)
				{
					deepHandles.Add("BankAccountsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<BankAccounts>) DataRepository.BankAccountsProvider.DeepLoad,
						new object[] { transactionManager, entity.BankAccountsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.Employee object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.Employee instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Employee Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.Employee entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<EmployeeSkills>
				if (CanDeepSave(entity.EmployeeSkillsCollection, "List<EmployeeSkills>|EmployeeSkillsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeSkills child in entity.EmployeeSkillsCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.EmployeeSkillsCollection.Count > 0 || entity.EmployeeSkillsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeSkillsProvider.Save(transactionManager, entity.EmployeeSkillsCollection);
						
						deepHandles.Add("EmployeeSkillsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeSkills >) DataRepository.EmployeeSkillsProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeSkillsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<EmployeeDepartments>
				if (CanDeepSave(entity.EmployeeDepartmentsCollection, "List<EmployeeDepartments>|EmployeeDepartmentsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeDepartments child in entity.EmployeeDepartmentsCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
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
				
	
			#region List<EmployeeSalary>
				if (CanDeepSave(entity.EmployeeSalaryCollection, "List<EmployeeSalary>|EmployeeSalaryCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EmployeeSalary child in entity.EmployeeSalaryCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.EmployeeSalaryCollection.Count > 0 || entity.EmployeeSalaryCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EmployeeSalaryProvider.Save(transactionManager, entity.EmployeeSalaryCollection);
						
						deepHandles.Add("EmployeeSalaryCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EmployeeSalary >) DataRepository.EmployeeSalaryProvider.DeepSave,
							new object[] { transactionManager, entity.EmployeeSalaryCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Address>
				if (CanDeepSave(entity.AddressCollection, "List<Address>|AddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Address child in entity.AddressCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.AddressCollection.Count > 0 || entity.AddressCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AddressProvider.Save(transactionManager, entity.AddressCollection);
						
						deepHandles.Add("AddressCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Address >) DataRepository.AddressProvider.DeepSave,
							new object[] { transactionManager, entity.AddressCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<BankAccounts>
				if (CanDeepSave(entity.BankAccountsCollection, "List<BankAccounts>|BankAccountsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(BankAccounts child in entity.BankAccountsCollection)
					{
						if(child.EmployeeIdSource != null)
						{
							child.EmployeeId = child.EmployeeIdSource.EmployeeId;
						}
						else
						{
							child.EmployeeId = entity.EmployeeId;
						}

					}

					if (entity.BankAccountsCollection.Count > 0 || entity.BankAccountsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.BankAccountsProvider.Save(transactionManager, entity.BankAccountsCollection);
						
						deepHandles.Add("BankAccountsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< BankAccounts >) DataRepository.BankAccountsProvider.DeepSave,
							new object[] { transactionManager, entity.BankAccountsCollection, deepSaveType, childTypes, innerList }
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
	
	#region EmployeeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.Employee</c>
	///</summary>
	public enum EmployeeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeeSkillsCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeSkills>))]
		EmployeeSkillsCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeeDepartmentsCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeDepartments>))]
		EmployeeDepartmentsCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for EmployeeSalaryCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeSalary>))]
		EmployeeSalaryCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for AddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<Address>))]
		AddressCollection,

		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for BankAccountsCollection
		///</summary>
		[ChildEntityType(typeof(TList<BankAccounts>))]
		BankAccountsCollection,
	}
	
	#endregion EmployeeChildEntityTypes
	
	#region EmployeeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilterBuilder : SqlFilterBuilder<EmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		public EmployeeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeFilterBuilder
	
	#region EmployeeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		public EmployeeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeParameterBuilder
	
	#region EmployeeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeSortBuilder : SqlSortBuilder<EmployeeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSqlSortBuilder class.
		/// </summary>
		public EmployeeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeSortBuilder
	
} // end namespace

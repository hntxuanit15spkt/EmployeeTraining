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
	/// This class is the base class for any <see cref="AddressProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AddressProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.Address, EmployeeDB.BLL.AddressKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.AddressKey key)
		{
			return Delete(transactionManager, key.AddressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_addressId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _addressId)
		{
			return Delete(null, _addressId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _addressId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Countries key.
		///		FK_Address_Countries Description: 
		/// </summary>
		/// <param name="_countryCode"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByCountryCode(System.String _countryCode)
		{
			int count = -1;
			return GetByCountryCode(_countryCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Countries key.
		///		FK_Address_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		/// <remarks></remarks>
		public TList<Address> GetByCountryCode(TransactionManager transactionManager, System.String _countryCode)
		{
			int count = -1;
			return GetByCountryCode(transactionManager, _countryCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Countries key.
		///		FK_Address_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByCountryCode(TransactionManager transactionManager, System.String _countryCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryCode(transactionManager, _countryCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Countries key.
		///		fKAddressCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByCountryCode(System.String _countryCode, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryCode(null, _countryCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Countries key.
		///		fKAddressCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryCode"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByCountryCode(System.String _countryCode, int start, int pageLength,out int count)
		{
			return GetByCountryCode(null, _countryCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Countries key.
		///		FK_Address_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public abstract TList<Address> GetByCountryCode(TransactionManager transactionManager, System.String _countryCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Employee key.
		///		FK_Address_Employee Description: 
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByEmployeeId(System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Employee key.
		///		FK_Address_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		/// <remarks></remarks>
		public TList<Address> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Employee key.
		///		FK_Address_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Employee key.
		///		fKAddressEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Employee key.
		///		fKAddressEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public TList<Address> GetByEmployeeId(System.Int32 _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Address_Employee key.
		///		FK_Address_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.Address objects.</returns>
		public abstract TList<Address> GetByEmployeeId(TransactionManager transactionManager, System.Int32 _employeeId, int start, int pageLength, out int count);
		
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
		public override EmployeeDB.BLL.Address Get(TransactionManager transactionManager, EmployeeDB.BLL.AddressKey key, int start, int pageLength)
		{
			return GetByAddressId(transactionManager, key.AddressId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Address index.
		/// </summary>
		/// <param name="_addressId"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Address"/> class.</returns>
		public EmployeeDB.BLL.Address GetByAddressId(System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(null,_addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address index.
		/// </summary>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Address"/> class.</returns>
		public EmployeeDB.BLL.Address GetByAddressId(System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Address"/> class.</returns>
		public EmployeeDB.BLL.Address GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Address"/> class.</returns>
		public EmployeeDB.BLL.Address GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength)
		{
			int count = -1;
			return GetByAddressId(transactionManager, _addressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address index.
		/// </summary>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Address"/> class.</returns>
		public EmployeeDB.BLL.Address GetByAddressId(System.Int32 _addressId, int start, int pageLength, out int count)
		{
			return GetByAddressId(null, _addressId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Address index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_addressId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Address"/> class.</returns>
		public abstract EmployeeDB.BLL.Address GetByAddressId(TransactionManager transactionManager, System.Int32 _addressId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Address&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Address&gt;"/></returns>
		public static TList<Address> Fill(IDataReader reader, TList<Address> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.Address c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Address")
					.Append("|").Append((System.Int32)reader[((int)AddressColumn.AddressId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Address>(
					key.ToString(), // EntityTrackingKey
					"Address",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.Address();
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
					c.AddressId = (System.Int32)reader[((int)AddressColumn.AddressId - 1)];
					c.EmployeeId = (System.Int32)reader[((int)AddressColumn.EmployeeId - 1)];
					c.Line1 = (reader.IsDBNull(((int)AddressColumn.Line1 - 1)))?null:(System.String)reader[((int)AddressColumn.Line1 - 1)];
					c.Line2 = (reader.IsDBNull(((int)AddressColumn.Line2 - 1)))?null:(System.String)reader[((int)AddressColumn.Line2 - 1)];
					c.TownCity = (reader.IsDBNull(((int)AddressColumn.TownCity - 1)))?null:(System.String)reader[((int)AddressColumn.TownCity - 1)];
					c.StateOrProvince = (reader.IsDBNull(((int)AddressColumn.StateOrProvince - 1)))?null:(System.String)reader[((int)AddressColumn.StateOrProvince - 1)];
					c.PostCod = (reader.IsDBNull(((int)AddressColumn.PostCod - 1)))?null:(System.String)reader[((int)AddressColumn.PostCod - 1)];
					c.CountryCode = (reader.IsDBNull(((int)AddressColumn.CountryCode - 1)))?null:(System.String)reader[((int)AddressColumn.CountryCode - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Address"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Address"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.Address entity)
		{
			if (!reader.Read()) return;
			
			entity.AddressId = (System.Int32)reader[((int)AddressColumn.AddressId - 1)];
			entity.EmployeeId = (System.Int32)reader[((int)AddressColumn.EmployeeId - 1)];
			entity.Line1 = (reader.IsDBNull(((int)AddressColumn.Line1 - 1)))?null:(System.String)reader[((int)AddressColumn.Line1 - 1)];
			entity.Line2 = (reader.IsDBNull(((int)AddressColumn.Line2 - 1)))?null:(System.String)reader[((int)AddressColumn.Line2 - 1)];
			entity.TownCity = (reader.IsDBNull(((int)AddressColumn.TownCity - 1)))?null:(System.String)reader[((int)AddressColumn.TownCity - 1)];
			entity.StateOrProvince = (reader.IsDBNull(((int)AddressColumn.StateOrProvince - 1)))?null:(System.String)reader[((int)AddressColumn.StateOrProvince - 1)];
			entity.PostCod = (reader.IsDBNull(((int)AddressColumn.PostCod - 1)))?null:(System.String)reader[((int)AddressColumn.PostCod - 1)];
			entity.CountryCode = (reader.IsDBNull(((int)AddressColumn.CountryCode - 1)))?null:(System.String)reader[((int)AddressColumn.CountryCode - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Address"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Address"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.Address entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AddressId = (System.Int32)dataRow["AddressId"];
			entity.EmployeeId = (System.Int32)dataRow["EmployeeId"];
			entity.Line1 = Convert.IsDBNull(dataRow["Line1"]) ? null : (System.String)dataRow["Line1"];
			entity.Line2 = Convert.IsDBNull(dataRow["Line2"]) ? null : (System.String)dataRow["Line2"];
			entity.TownCity = Convert.IsDBNull(dataRow["TownCity"]) ? null : (System.String)dataRow["TownCity"];
			entity.StateOrProvince = Convert.IsDBNull(dataRow["StateOrProvince"]) ? null : (System.String)dataRow["StateOrProvince"];
			entity.PostCod = Convert.IsDBNull(dataRow["PostCod"]) ? null : (System.String)dataRow["PostCod"];
			entity.CountryCode = Convert.IsDBNull(dataRow["CountryCode"]) ? null : (System.String)dataRow["CountryCode"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Address"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Address Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.Address entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryCodeSource	
			if (CanDeepLoad(entity, "Countries|CountryCodeSource", deepLoadType, innerList) 
				&& entity.CountryCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CountryCode ?? string.Empty);
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryCodeSource = tmpEntity;
				else
					entity.CountryCodeSource = DataRepository.CountriesProvider.GetByCountryCode(transactionManager, (entity.CountryCode ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.CountryCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryCodeSource

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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.Address object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.Address instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Address Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.Address entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryCodeSource
			if (CanDeepSave(entity, "Countries|CountryCodeSource", deepSaveType, innerList) 
				&& entity.CountryCodeSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.CountryCodeSource);
				entity.CountryCode = entity.CountryCodeSource.CountryCode;
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
	
	#region AddressChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.Address</c>
	///</summary>
	public enum AddressChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Countries</c> at CountryCodeSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
			
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		}
	
	#endregion AddressChildEntityTypes
	
	#region AddressFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressFilterBuilder : SqlFilterBuilder<AddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressFilterBuilder class.
		/// </summary>
		public AddressFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressFilterBuilder
	
	#region AddressParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressParameterBuilder : ParameterizedSqlFilterBuilder<AddressColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressParameterBuilder class.
		/// </summary>
		public AddressParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressParameterBuilder
	
	#region AddressSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AddressColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AddressSortBuilder : SqlSortBuilder<AddressColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressSqlSortBuilder class.
		/// </summary>
		public AddressSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AddressSortBuilder
	
} // end namespace

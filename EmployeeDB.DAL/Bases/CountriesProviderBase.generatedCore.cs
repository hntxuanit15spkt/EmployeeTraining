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
	/// This class is the base class for any <see cref="CountriesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CountriesProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.Countries, EmployeeDB.BLL.CountriesKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.CountriesKey key)
		{
			return Delete(transactionManager, key.CountryCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_countryCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _countryCode)
		{
			return Delete(null, _countryCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _countryCode);		
		
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
		public override EmployeeDB.BLL.Countries Get(TransactionManager transactionManager, EmployeeDB.BLL.CountriesKey key, int start, int pageLength)
		{
			return GetByCountryCode(transactionManager, key.CountryCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Countries index.
		/// </summary>
		/// <param name="_countryCode"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Countries"/> class.</returns>
		public EmployeeDB.BLL.Countries GetByCountryCode(System.String _countryCode)
		{
			int count = -1;
			return GetByCountryCode(null,_countryCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Countries index.
		/// </summary>
		/// <param name="_countryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Countries"/> class.</returns>
		public EmployeeDB.BLL.Countries GetByCountryCode(System.String _countryCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryCode(null, _countryCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Countries index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Countries"/> class.</returns>
		public EmployeeDB.BLL.Countries GetByCountryCode(TransactionManager transactionManager, System.String _countryCode)
		{
			int count = -1;
			return GetByCountryCode(transactionManager, _countryCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Countries index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Countries"/> class.</returns>
		public EmployeeDB.BLL.Countries GetByCountryCode(TransactionManager transactionManager, System.String _countryCode, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryCode(transactionManager, _countryCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Countries index.
		/// </summary>
		/// <param name="_countryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Countries"/> class.</returns>
		public EmployeeDB.BLL.Countries GetByCountryCode(System.String _countryCode, int start, int pageLength, out int count)
		{
			return GetByCountryCode(null, _countryCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Countries index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Countries"/> class.</returns>
		public abstract EmployeeDB.BLL.Countries GetByCountryCode(TransactionManager transactionManager, System.String _countryCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Countries&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Countries&gt;"/></returns>
		public static TList<Countries> Fill(IDataReader reader, TList<Countries> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.Countries c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Countries")
					.Append("|").Append((System.String)reader[((int)CountriesColumn.CountryCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Countries>(
					key.ToString(), // EntityTrackingKey
					"Countries",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.Countries();
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
					c.CountryCode = (System.String)reader[((int)CountriesColumn.CountryCode - 1)];
					c.OriginalCountryCode = c.CountryCode;
					c.Name = (reader.IsDBNull(((int)CountriesColumn.Name - 1)))?null:(System.String)reader[((int)CountriesColumn.Name - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Countries"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Countries"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.Countries entity)
		{
			if (!reader.Read()) return;
			
			entity.CountryCode = (System.String)reader[((int)CountriesColumn.CountryCode - 1)];
			entity.OriginalCountryCode = (System.String)reader["CountryCode"];
			entity.Name = (reader.IsDBNull(((int)CountriesColumn.Name - 1)))?null:(System.String)reader[((int)CountriesColumn.Name - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Countries"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Countries"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.Countries entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CountryCode = (System.String)dataRow["CountryCode"];
			entity.OriginalCountryCode = (System.String)dataRow["CountryCode"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Countries"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Countries Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.Countries entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCountryCode methods when available
			
			#region AddressCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Address>|AddressCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AddressCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AddressCollection = DataRepository.AddressProvider.GetByCountryCode(transactionManager, entity.CountryCode);

				if (deep && entity.AddressCollection.Count > 0)
				{
					deepHandles.Add("AddressCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Address>) DataRepository.AddressProvider.DeepLoad,
						new object[] { transactionManager, entity.AddressCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.Countries object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.Countries instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Countries Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.Countries entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Address>
				if (CanDeepSave(entity.AddressCollection, "List<Address>|AddressCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Address child in entity.AddressCollection)
					{
						if(child.CountryCodeSource != null)
						{
							child.CountryCode = child.CountryCodeSource.CountryCode;
						}
						else
						{
							child.CountryCode = entity.CountryCode;
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
	
	#region CountriesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.Countries</c>
	///</summary>
	public enum CountriesChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Countries</c> as OneToMany for AddressCollection
		///</summary>
		[ChildEntityType(typeof(TList<Address>))]
		AddressCollection,
	}
	
	#endregion CountriesChildEntityTypes
	
	#region CountriesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesFilterBuilder : SqlFilterBuilder<CountriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesFilterBuilder class.
		/// </summary>
		public CountriesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesFilterBuilder
	
	#region CountriesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesParameterBuilder : ParameterizedSqlFilterBuilder<CountriesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesParameterBuilder class.
		/// </summary>
		public CountriesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesParameterBuilder
	
	#region CountriesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CountriesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CountriesSortBuilder : SqlSortBuilder<CountriesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesSqlSortBuilder class.
		/// </summary>
		public CountriesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CountriesSortBuilder
	
} // end namespace

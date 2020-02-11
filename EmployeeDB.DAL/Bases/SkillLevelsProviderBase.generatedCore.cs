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
	/// This class is the base class for any <see cref="SkillLevelsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SkillLevelsProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.SkillLevels, EmployeeDB.BLL.SkillLevelsKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.SkillLevelsKey key)
		{
			return Delete(transactionManager, key.LevelCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_levelCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _levelCode)
		{
			return Delete(null, _levelCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_levelCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _levelCode);		
		
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
		public override EmployeeDB.BLL.SkillLevels Get(TransactionManager transactionManager, EmployeeDB.BLL.SkillLevelsKey key, int start, int pageLength)
		{
			return GetByLevelCode(transactionManager, key.LevelCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SkillLevel index.
		/// </summary>
		/// <param name="_levelCode"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.SkillLevels"/> class.</returns>
		public EmployeeDB.BLL.SkillLevels GetByLevelCode(System.String _levelCode)
		{
			int count = -1;
			return GetByLevelCode(null,_levelCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SkillLevel index.
		/// </summary>
		/// <param name="_levelCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.SkillLevels"/> class.</returns>
		public EmployeeDB.BLL.SkillLevels GetByLevelCode(System.String _levelCode, int start, int pageLength)
		{
			int count = -1;
			return GetByLevelCode(null, _levelCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SkillLevel index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_levelCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.SkillLevels"/> class.</returns>
		public EmployeeDB.BLL.SkillLevels GetByLevelCode(TransactionManager transactionManager, System.String _levelCode)
		{
			int count = -1;
			return GetByLevelCode(transactionManager, _levelCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SkillLevel index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_levelCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.SkillLevels"/> class.</returns>
		public EmployeeDB.BLL.SkillLevels GetByLevelCode(TransactionManager transactionManager, System.String _levelCode, int start, int pageLength)
		{
			int count = -1;
			return GetByLevelCode(transactionManager, _levelCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SkillLevel index.
		/// </summary>
		/// <param name="_levelCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.SkillLevels"/> class.</returns>
		public EmployeeDB.BLL.SkillLevels GetByLevelCode(System.String _levelCode, int start, int pageLength, out int count)
		{
			return GetByLevelCode(null, _levelCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SkillLevel index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_levelCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.SkillLevels"/> class.</returns>
		public abstract EmployeeDB.BLL.SkillLevels GetByLevelCode(TransactionManager transactionManager, System.String _levelCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SkillLevels&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SkillLevels&gt;"/></returns>
		public static TList<SkillLevels> Fill(IDataReader reader, TList<SkillLevels> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.SkillLevels c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SkillLevels")
					.Append("|").Append((System.String)reader[((int)SkillLevelsColumn.LevelCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SkillLevels>(
					key.ToString(), // EntityTrackingKey
					"SkillLevels",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.SkillLevels();
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
					c.LevelCode = (System.String)reader[((int)SkillLevelsColumn.LevelCode - 1)];
					c.OriginalLevelCode = c.LevelCode;
					c.Name = (reader.IsDBNull(((int)SkillLevelsColumn.Name - 1)))?null:(System.String)reader[((int)SkillLevelsColumn.Name - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.SkillLevels"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.SkillLevels"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.SkillLevels entity)
		{
			if (!reader.Read()) return;
			
			entity.LevelCode = (System.String)reader[((int)SkillLevelsColumn.LevelCode - 1)];
			entity.OriginalLevelCode = (System.String)reader["LevelCode"];
			entity.Name = (reader.IsDBNull(((int)SkillLevelsColumn.Name - 1)))?null:(System.String)reader[((int)SkillLevelsColumn.Name - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.SkillLevels"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.SkillLevels"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.SkillLevels entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.LevelCode = (System.String)dataRow["LevelCode"];
			entity.OriginalLevelCode = (System.String)dataRow["LevelCode"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.SkillLevels"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.SkillLevels Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.SkillLevels entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByLevelCode methods when available
			
			#region EmployeeSkillsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeSkills>|EmployeeSkillsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeSkillsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeSkillsCollection = DataRepository.EmployeeSkillsProvider.GetBySkillLevel(transactionManager, entity.LevelCode);

				if (deep && entity.EmployeeSkillsCollection.Count > 0)
				{
					deepHandles.Add("EmployeeSkillsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EmployeeSkills>) DataRepository.EmployeeSkillsProvider.DeepLoad,
						new object[] { transactionManager, entity.EmployeeSkillsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.SkillLevels object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.SkillLevels instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.SkillLevels Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.SkillLevels entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.SkillLevelSource != null)
						{
							child.SkillLevel = child.SkillLevelSource.LevelCode;
						}
						else
						{
							child.SkillLevel = entity.LevelCode;
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
	
	#region SkillLevelsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.SkillLevels</c>
	///</summary>
	public enum SkillLevelsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>SkillLevels</c> as OneToMany for EmployeeSkillsCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeSkills>))]
		EmployeeSkillsCollection,
	}
	
	#endregion SkillLevelsChildEntityTypes
	
	#region SkillLevelsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SkillLevelsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsFilterBuilder : SqlFilterBuilder<SkillLevelsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsFilterBuilder class.
		/// </summary>
		public SkillLevelsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillLevelsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillLevelsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillLevelsFilterBuilder
	
	#region SkillLevelsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SkillLevelsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsParameterBuilder : ParameterizedSqlFilterBuilder<SkillLevelsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsParameterBuilder class.
		/// </summary>
		public SkillLevelsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillLevelsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillLevelsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillLevelsParameterBuilder
	
	#region SkillLevelsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SkillLevelsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SkillLevelsSortBuilder : SqlSortBuilder<SkillLevelsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsSqlSortBuilder class.
		/// </summary>
		public SkillLevelsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SkillLevelsSortBuilder
	
} // end namespace

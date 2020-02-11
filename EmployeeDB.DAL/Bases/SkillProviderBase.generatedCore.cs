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
	/// This class is the base class for any <see cref="SkillProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SkillProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.Skill, EmployeeDB.BLL.SkillKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.SkillKey key)
		{
			return Delete(transactionManager, key.SkillCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_skillCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _skillCode)
		{
			return Delete(null, _skillCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _skillCode);		
		
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
		public override EmployeeDB.BLL.Skill Get(TransactionManager transactionManager, EmployeeDB.BLL.SkillKey key, int start, int pageLength)
		{
			return GetBySkillCode(transactionManager, key.SkillCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Skill index.
		/// </summary>
		/// <param name="_skillCode"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Skill"/> class.</returns>
		public EmployeeDB.BLL.Skill GetBySkillCode(System.String _skillCode)
		{
			int count = -1;
			return GetBySkillCode(null,_skillCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Skill index.
		/// </summary>
		/// <param name="_skillCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Skill"/> class.</returns>
		public EmployeeDB.BLL.Skill GetBySkillCode(System.String _skillCode, int start, int pageLength)
		{
			int count = -1;
			return GetBySkillCode(null, _skillCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Skill index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Skill"/> class.</returns>
		public EmployeeDB.BLL.Skill GetBySkillCode(TransactionManager transactionManager, System.String _skillCode)
		{
			int count = -1;
			return GetBySkillCode(transactionManager, _skillCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Skill index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Skill"/> class.</returns>
		public EmployeeDB.BLL.Skill GetBySkillCode(TransactionManager transactionManager, System.String _skillCode, int start, int pageLength)
		{
			int count = -1;
			return GetBySkillCode(transactionManager, _skillCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Skill index.
		/// </summary>
		/// <param name="_skillCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Skill"/> class.</returns>
		public EmployeeDB.BLL.Skill GetBySkillCode(System.String _skillCode, int start, int pageLength, out int count)
		{
			return GetBySkillCode(null, _skillCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Skill index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.Skill"/> class.</returns>
		public abstract EmployeeDB.BLL.Skill GetBySkillCode(TransactionManager transactionManager, System.String _skillCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Skill&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Skill&gt;"/></returns>
		public static TList<Skill> Fill(IDataReader reader, TList<Skill> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.Skill c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Skill")
					.Append("|").Append((System.String)reader[((int)SkillColumn.SkillCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Skill>(
					key.ToString(), // EntityTrackingKey
					"Skill",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.Skill();
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
					c.SkillCode = (System.String)reader[((int)SkillColumn.SkillCode - 1)];
					c.OriginalSkillCode = c.SkillCode;
					c.Name = (reader.IsDBNull(((int)SkillColumn.Name - 1)))?null:(System.String)reader[((int)SkillColumn.Name - 1)];
					c.Category = (reader.IsDBNull(((int)SkillColumn.Category - 1)))?null:(System.String)reader[((int)SkillColumn.Category - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Skill"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Skill"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.Skill entity)
		{
			if (!reader.Read()) return;
			
			entity.SkillCode = (System.String)reader[((int)SkillColumn.SkillCode - 1)];
			entity.OriginalSkillCode = (System.String)reader["SkillCode"];
			entity.Name = (reader.IsDBNull(((int)SkillColumn.Name - 1)))?null:(System.String)reader[((int)SkillColumn.Name - 1)];
			entity.Category = (reader.IsDBNull(((int)SkillColumn.Category - 1)))?null:(System.String)reader[((int)SkillColumn.Category - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.Skill"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Skill"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.Skill entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SkillCode = (System.String)dataRow["SkillCode"];
			entity.OriginalSkillCode = (System.String)dataRow["SkillCode"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Category = Convert.IsDBNull(dataRow["Category"]) ? null : (System.String)dataRow["Category"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.Skill"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Skill Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.Skill entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySkillCode methods when available
			
			#region EmployeeSkillsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmployeeSkills>|EmployeeSkillsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeSkillsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EmployeeSkillsCollection = DataRepository.EmployeeSkillsProvider.GetBySkillCode(transactionManager, entity.SkillCode);

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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.Skill object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.Skill instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.Skill Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.Skill entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.SkillCodeSource != null)
						{
							child.SkillCode = child.SkillCodeSource.SkillCode;
						}
						else
						{
							child.SkillCode = entity.SkillCode;
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
	
	#region SkillChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.Skill</c>
	///</summary>
	public enum SkillChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Skill</c> as OneToMany for EmployeeSkillsCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmployeeSkills>))]
		EmployeeSkillsCollection,
	}
	
	#endregion SkillChildEntityTypes
	
	#region SkillFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SkillColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillFilterBuilder : SqlFilterBuilder<SkillColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillFilterBuilder class.
		/// </summary>
		public SkillFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillFilterBuilder
	
	#region SkillParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SkillColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillParameterBuilder : ParameterizedSqlFilterBuilder<SkillColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillParameterBuilder class.
		/// </summary>
		public SkillParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillParameterBuilder
	
	#region SkillSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SkillColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SkillSortBuilder : SqlSortBuilder<SkillColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillSqlSortBuilder class.
		/// </summary>
		public SkillSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SkillSortBuilder
	
} // end namespace

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
	/// This class is the base class for any <see cref="EmployeeSkillsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeSkillsProviderBaseCore : EntityProviderBase<EmployeeDB.BLL.EmployeeSkills, EmployeeDB.BLL.EmployeeSkillsKey>
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
		public override bool Delete(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeSkillsKey key)
		{
			return Delete(transactionManager, key.EmployeeSkillId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_employeeSkillId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _employeeSkillId)
		{
			return Delete(null, _employeeSkillId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeSkillId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _employeeSkillId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Skill key.
		///		FK_EmployeeSkills_Skill Description: 
		/// </summary>
		/// <param name="_skillCode"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillCode(System.String _skillCode)
		{
			int count = -1;
			return GetBySkillCode(_skillCode, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Skill key.
		///		FK_EmployeeSkills_Skill Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeSkills> GetBySkillCode(TransactionManager transactionManager, System.String _skillCode)
		{
			int count = -1;
			return GetBySkillCode(transactionManager, _skillCode, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Skill key.
		///		FK_EmployeeSkills_Skill Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillCode(TransactionManager transactionManager, System.String _skillCode, int start, int pageLength)
		{
			int count = -1;
			return GetBySkillCode(transactionManager, _skillCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Skill key.
		///		fKEmployeeSkillsSkill Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_skillCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillCode(System.String _skillCode, int start, int pageLength)
		{
			int count =  -1;
			return GetBySkillCode(null, _skillCode, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Skill key.
		///		fKEmployeeSkillsSkill Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_skillCode"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillCode(System.String _skillCode, int start, int pageLength,out int count)
		{
			return GetBySkillCode(null, _skillCode, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Skill key.
		///		FK_EmployeeSkills_Skill Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public abstract TList<EmployeeSkills> GetBySkillCode(TransactionManager transactionManager, System.String _skillCode, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_SkillLevels key.
		///		FK_EmployeeSkills_SkillLevels Description: 
		/// </summary>
		/// <param name="_skillLevel"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillLevel(System.String _skillLevel)
		{
			int count = -1;
			return GetBySkillLevel(_skillLevel, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_SkillLevels key.
		///		FK_EmployeeSkills_SkillLevels Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillLevel"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeSkills> GetBySkillLevel(TransactionManager transactionManager, System.String _skillLevel)
		{
			int count = -1;
			return GetBySkillLevel(transactionManager, _skillLevel, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_SkillLevels key.
		///		FK_EmployeeSkills_SkillLevels Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillLevel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillLevel(TransactionManager transactionManager, System.String _skillLevel, int start, int pageLength)
		{
			int count = -1;
			return GetBySkillLevel(transactionManager, _skillLevel, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_SkillLevels key.
		///		fKEmployeeSkillsSkillLevels Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_skillLevel"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillLevel(System.String _skillLevel, int start, int pageLength)
		{
			int count =  -1;
			return GetBySkillLevel(null, _skillLevel, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_SkillLevels key.
		///		fKEmployeeSkillsSkillLevels Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_skillLevel"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetBySkillLevel(System.String _skillLevel, int start, int pageLength,out int count)
		{
			return GetBySkillLevel(null, _skillLevel, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_SkillLevels key.
		///		FK_EmployeeSkills_SkillLevels Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_skillLevel"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public abstract TList<EmployeeSkills> GetBySkillLevel(TransactionManager transactionManager, System.String _skillLevel, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Employee key.
		///		FK_EmployeeSkills_Employee Description: 
		/// </summary>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetByEmployeeId(System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(_employeeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Employee key.
		///		FK_EmployeeSkills_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		/// <remarks></remarks>
		public TList<EmployeeSkills> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Employee key.
		///		FK_EmployeeSkills_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeId(transactionManager, _employeeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Employee key.
		///		fKEmployeeSkillsEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeId(null, _employeeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Employee key.
		///		fKEmployeeSkillsEmployee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public TList<EmployeeSkills> GetByEmployeeId(System.Int32? _employeeId, int start, int pageLength,out int count)
		{
			return GetByEmployeeId(null, _employeeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmployeeSkills_Employee key.
		///		FK_EmployeeSkills_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of EmployeeDB.BLL.EmployeeSkills objects.</returns>
		public abstract TList<EmployeeSkills> GetByEmployeeId(TransactionManager transactionManager, System.Int32? _employeeId, int start, int pageLength, out int count);
		
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
		public override EmployeeDB.BLL.EmployeeSkills Get(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeSkillsKey key, int start, int pageLength)
		{
			return GetByEmployeeSkillId(transactionManager, key.EmployeeSkillId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmployeeSkills index.
		/// </summary>
		/// <param name="_employeeSkillId"></param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeSkills"/> class.</returns>
		public EmployeeDB.BLL.EmployeeSkills GetByEmployeeSkillId(System.Int32 _employeeSkillId)
		{
			int count = -1;
			return GetByEmployeeSkillId(null,_employeeSkillId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeSkills index.
		/// </summary>
		/// <param name="_employeeSkillId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeSkills"/> class.</returns>
		public EmployeeDB.BLL.EmployeeSkills GetByEmployeeSkillId(System.Int32 _employeeSkillId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeSkillId(null, _employeeSkillId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeSkills index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeSkillId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeSkills"/> class.</returns>
		public EmployeeDB.BLL.EmployeeSkills GetByEmployeeSkillId(TransactionManager transactionManager, System.Int32 _employeeSkillId)
		{
			int count = -1;
			return GetByEmployeeSkillId(transactionManager, _employeeSkillId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeSkills index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeSkillId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeSkills"/> class.</returns>
		public EmployeeDB.BLL.EmployeeSkills GetByEmployeeSkillId(TransactionManager transactionManager, System.Int32 _employeeSkillId, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeSkillId(transactionManager, _employeeSkillId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeSkills index.
		/// </summary>
		/// <param name="_employeeSkillId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeSkills"/> class.</returns>
		public EmployeeDB.BLL.EmployeeSkills GetByEmployeeSkillId(System.Int32 _employeeSkillId, int start, int pageLength, out int count)
		{
			return GetByEmployeeSkillId(null, _employeeSkillId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmployeeSkills index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeSkillId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="EmployeeDB.BLL.EmployeeSkills"/> class.</returns>
		public abstract EmployeeDB.BLL.EmployeeSkills GetByEmployeeSkillId(TransactionManager transactionManager, System.Int32 _employeeSkillId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EmployeeSkills&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EmployeeSkills&gt;"/></returns>
		public static TList<EmployeeSkills> Fill(IDataReader reader, TList<EmployeeSkills> rows, int start, int pageLength)
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
				
				EmployeeDB.BLL.EmployeeSkills c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EmployeeSkills")
					.Append("|").Append((System.Int32)reader[((int)EmployeeSkillsColumn.EmployeeSkillId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EmployeeSkills>(
					key.ToString(), // EntityTrackingKey
					"EmployeeSkills",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new EmployeeDB.BLL.EmployeeSkills();
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
					c.EmployeeSkillId = (System.Int32)reader[((int)EmployeeSkillsColumn.EmployeeSkillId - 1)];
					c.EmployeeId = (reader.IsDBNull(((int)EmployeeSkillsColumn.EmployeeId - 1)))?null:(System.Int32?)reader[((int)EmployeeSkillsColumn.EmployeeId - 1)];
					c.SkillCode = (reader.IsDBNull(((int)EmployeeSkillsColumn.SkillCode - 1)))?null:(System.String)reader[((int)EmployeeSkillsColumn.SkillCode - 1)];
					c.SkillLevel = (reader.IsDBNull(((int)EmployeeSkillsColumn.SkillLevel - 1)))?null:(System.String)reader[((int)EmployeeSkillsColumn.SkillLevel - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)EmployeeSkillsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeSkillsColumn.CreatedOn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.EmployeeSkills"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.EmployeeSkills"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, EmployeeDB.BLL.EmployeeSkills entity)
		{
			if (!reader.Read()) return;
			
			entity.EmployeeSkillId = (System.Int32)reader[((int)EmployeeSkillsColumn.EmployeeSkillId - 1)];
			entity.EmployeeId = (reader.IsDBNull(((int)EmployeeSkillsColumn.EmployeeId - 1)))?null:(System.Int32?)reader[((int)EmployeeSkillsColumn.EmployeeId - 1)];
			entity.SkillCode = (reader.IsDBNull(((int)EmployeeSkillsColumn.SkillCode - 1)))?null:(System.String)reader[((int)EmployeeSkillsColumn.SkillCode - 1)];
			entity.SkillLevel = (reader.IsDBNull(((int)EmployeeSkillsColumn.SkillLevel - 1)))?null:(System.String)reader[((int)EmployeeSkillsColumn.SkillLevel - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)EmployeeSkillsColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeSkillsColumn.CreatedOn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="EmployeeDB.BLL.EmployeeSkills"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="EmployeeDB.BLL.EmployeeSkills"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, EmployeeDB.BLL.EmployeeSkills entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EmployeeSkillId = (System.Int32)dataRow["EmployeeSkillId"];
			entity.EmployeeId = Convert.IsDBNull(dataRow["EmployeeId"]) ? null : (System.Int32?)dataRow["EmployeeId"];
			entity.SkillCode = Convert.IsDBNull(dataRow["SkillCode"]) ? null : (System.String)dataRow["SkillCode"];
			entity.SkillLevel = Convert.IsDBNull(dataRow["SkillLevel"]) ? null : (System.String)dataRow["SkillLevel"];
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
		/// <param name="entity">The <see cref="EmployeeDB.BLL.EmployeeSkills"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">EmployeeDB.BLL.EmployeeSkills Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeSkills entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region SkillCodeSource	
			if (CanDeepLoad(entity, "Skill|SkillCodeSource", deepLoadType, innerList) 
				&& entity.SkillCodeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SkillCode ?? string.Empty);
				Skill tmpEntity = EntityManager.LocateEntity<Skill>(EntityLocator.ConstructKeyFromPkItems(typeof(Skill), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SkillCodeSource = tmpEntity;
				else
					entity.SkillCodeSource = DataRepository.SkillProvider.GetBySkillCode(transactionManager, (entity.SkillCode ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SkillCodeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SkillCodeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SkillProvider.DeepLoad(transactionManager, entity.SkillCodeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SkillCodeSource

			#region SkillLevelSource	
			if (CanDeepLoad(entity, "SkillLevels|SkillLevelSource", deepLoadType, innerList) 
				&& entity.SkillLevelSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SkillLevel ?? string.Empty);
				SkillLevels tmpEntity = EntityManager.LocateEntity<SkillLevels>(EntityLocator.ConstructKeyFromPkItems(typeof(SkillLevels), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SkillLevelSource = tmpEntity;
				else
					entity.SkillLevelSource = DataRepository.SkillLevelsProvider.GetByLevelCode(transactionManager, (entity.SkillLevel ?? string.Empty));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SkillLevelSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SkillLevelSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SkillLevelsProvider.DeepLoad(transactionManager, entity.SkillLevelSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SkillLevelSource

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
		/// Deep Save the entire object graph of the EmployeeDB.BLL.EmployeeSkills object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">EmployeeDB.BLL.EmployeeSkills instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">EmployeeDB.BLL.EmployeeSkills Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, EmployeeDB.BLL.EmployeeSkills entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region SkillCodeSource
			if (CanDeepSave(entity, "Skill|SkillCodeSource", deepSaveType, innerList) 
				&& entity.SkillCodeSource != null)
			{
				DataRepository.SkillProvider.Save(transactionManager, entity.SkillCodeSource);
				entity.SkillCode = entity.SkillCodeSource.SkillCode;
			}
			#endregion 
			
			#region SkillLevelSource
			if (CanDeepSave(entity, "SkillLevels|SkillLevelSource", deepSaveType, innerList) 
				&& entity.SkillLevelSource != null)
			{
				DataRepository.SkillLevelsProvider.Save(transactionManager, entity.SkillLevelSource);
				entity.SkillLevel = entity.SkillLevelSource.LevelCode;
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
	
	#region EmployeeSkillsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>EmployeeDB.BLL.EmployeeSkills</c>
	///</summary>
	public enum EmployeeSkillsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Skill</c> at SkillCodeSource
		///</summary>
		[ChildEntityType(typeof(Skill))]
		Skill,
			
		///<summary>
		/// Composite Property for <c>SkillLevels</c> at SkillLevelSource
		///</summary>
		[ChildEntityType(typeof(SkillLevels))]
		SkillLevels,
			
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeIdSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		}
	
	#endregion EmployeeSkillsChildEntityTypes
	
	#region EmployeeSkillsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeSkillsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsFilterBuilder : SqlFilterBuilder<EmployeeSkillsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsFilterBuilder class.
		/// </summary>
		public EmployeeSkillsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeSkillsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeSkillsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeSkillsFilterBuilder
	
	#region EmployeeSkillsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeSkillsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeSkillsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsParameterBuilder class.
		/// </summary>
		public EmployeeSkillsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeSkillsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeSkillsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeSkillsParameterBuilder
	
	#region EmployeeSkillsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeSkillsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeSkillsSortBuilder : SqlSortBuilder<EmployeeSkillsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsSqlSortBuilder class.
		/// </summary>
		public EmployeeSkillsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeSkillsSortBuilder
	
} // end namespace

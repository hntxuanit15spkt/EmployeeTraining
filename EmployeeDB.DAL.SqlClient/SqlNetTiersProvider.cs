
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using EmployeeDB.BLL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;

#endregion

namespace EmployeeDB.DAL.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : EmployeeDB.DAL.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "DepartmentsProvider"
			
		private SqlDepartmentsProvider innerSqlDepartmentsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Departments"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DepartmentsProviderBase DepartmentsProvider
		{
			get
			{
				if (innerSqlDepartmentsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDepartmentsProvider == null)
						{
							this.innerSqlDepartmentsProvider = new SqlDepartmentsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDepartmentsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDepartmentsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDepartmentsProvider SqlDepartmentsProvider
		{
			get {return DepartmentsProvider as SqlDepartmentsProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeDepartmentsProvider"
			
		private SqlEmployeeDepartmentsProvider innerSqlEmployeeDepartmentsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeDepartments"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeDepartmentsProviderBase EmployeeDepartmentsProvider
		{
			get
			{
				if (innerSqlEmployeeDepartmentsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeDepartmentsProvider == null)
						{
							this.innerSqlEmployeeDepartmentsProvider = new SqlEmployeeDepartmentsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeDepartmentsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeDepartmentsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeDepartmentsProvider SqlEmployeeDepartmentsProvider
		{
			get {return EmployeeDepartmentsProvider as SqlEmployeeDepartmentsProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeProvider"
			
		private SqlEmployeeProvider innerSqlEmployeeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeProviderBase EmployeeProvider
		{
			get
			{
				if (innerSqlEmployeeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeProvider == null)
						{
							this.innerSqlEmployeeProvider = new SqlEmployeeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeProvider SqlEmployeeProvider
		{
			get {return EmployeeProvider as SqlEmployeeProvider;}
		}
		
		#endregion
		
		
		#region "CountriesProvider"
			
		private SqlCountriesProvider innerSqlCountriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Countries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountriesProviderBase CountriesProvider
		{
			get
			{
				if (innerSqlCountriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountriesProvider == null)
						{
							this.innerSqlCountriesProvider = new SqlCountriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCountriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountriesProvider SqlCountriesProvider
		{
			get {return CountriesProvider as SqlCountriesProvider;}
		}
		
		#endregion
		
		
		#region "SkillLevelsProvider"
			
		private SqlSkillLevelsProvider innerSqlSkillLevelsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SkillLevels"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SkillLevelsProviderBase SkillLevelsProvider
		{
			get
			{
				if (innerSqlSkillLevelsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSkillLevelsProvider == null)
						{
							this.innerSqlSkillLevelsProvider = new SqlSkillLevelsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSkillLevelsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSkillLevelsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSkillLevelsProvider SqlSkillLevelsProvider
		{
			get {return SkillLevelsProvider as SqlSkillLevelsProvider;}
		}
		
		#endregion
		
		
		#region "SkillProvider"
			
		private SqlSkillProvider innerSqlSkillProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Skill"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SkillProviderBase SkillProvider
		{
			get
			{
				if (innerSqlSkillProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSkillProvider == null)
						{
							this.innerSqlSkillProvider = new SqlSkillProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSkillProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlSkillProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSkillProvider SqlSkillProvider
		{
			get {return SkillProvider as SqlSkillProvider;}
		}
		
		#endregion
		
		
		#region "BankAccountsProvider"
			
		private SqlBankAccountsProvider innerSqlBankAccountsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BankAccounts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BankAccountsProviderBase BankAccountsProvider
		{
			get
			{
				if (innerSqlBankAccountsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBankAccountsProvider == null)
						{
							this.innerSqlBankAccountsProvider = new SqlBankAccountsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBankAccountsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlBankAccountsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBankAccountsProvider SqlBankAccountsProvider
		{
			get {return BankAccountsProvider as SqlBankAccountsProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeSalaryProvider"
			
		private SqlEmployeeSalaryProvider innerSqlEmployeeSalaryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeSalary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeSalaryProviderBase EmployeeSalaryProvider
		{
			get
			{
				if (innerSqlEmployeeSalaryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeSalaryProvider == null)
						{
							this.innerSqlEmployeeSalaryProvider = new SqlEmployeeSalaryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeSalaryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeSalaryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeSalaryProvider SqlEmployeeSalaryProvider
		{
			get {return EmployeeSalaryProvider as SqlEmployeeSalaryProvider;}
		}
		
		#endregion
		
		
		#region "AddressProvider"
			
		private SqlAddressProvider innerSqlAddressProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Address"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AddressProviderBase AddressProvider
		{
			get
			{
				if (innerSqlAddressProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAddressProvider == null)
						{
							this.innerSqlAddressProvider = new SqlAddressProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAddressProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAddressProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAddressProvider SqlAddressProvider
		{
			get {return AddressProvider as SqlAddressProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeSkillsProvider"
			
		private SqlEmployeeSkillsProvider innerSqlEmployeeSkillsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmployeeSkills"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeSkillsProviderBase EmployeeSkillsProvider
		{
			get
			{
				if (innerSqlEmployeeSkillsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeSkillsProvider == null)
						{
							this.innerSqlEmployeeSkillsProvider = new SqlEmployeeSkillsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeSkillsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeSkillsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeSkillsProvider SqlEmployeeSkillsProvider
		{
			get {return EmployeeSkillsProvider as SqlEmployeeSkillsProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}

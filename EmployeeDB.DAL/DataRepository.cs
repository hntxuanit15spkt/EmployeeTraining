#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using EmployeeDB.BLL;
using EmployeeDB.DAL;
using EmployeeDB.DAL.Bases;

#endregion

namespace EmployeeDB.DAL
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("EmployeeDB.DAL") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.11.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region DepartmentsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Departments"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DepartmentsProviderBase DepartmentsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DepartmentsProvider;
			}
		}
		
		#endregion
		
		#region EmployeeDepartmentsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeeDepartments"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeDepartmentsProviderBase EmployeeDepartmentsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeDepartmentsProvider;
			}
		}
		
		#endregion
		
		#region EmployeeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeProviderBase EmployeeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeProvider;
			}
		}
		
		#endregion
		
		#region CountriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Countries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CountriesProviderBase CountriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountriesProvider;
			}
		}
		
		#endregion
		
		#region SkillLevelsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SkillLevels"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SkillLevelsProviderBase SkillLevelsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SkillLevelsProvider;
			}
		}
		
		#endregion
		
		#region SkillProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Skill"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SkillProviderBase SkillProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SkillProvider;
			}
		}
		
		#endregion
		
		#region BankAccountsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BankAccounts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BankAccountsProviderBase BankAccountsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BankAccountsProvider;
			}
		}
		
		#endregion
		
		#region EmployeeSalaryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeeSalary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeSalaryProviderBase EmployeeSalaryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeSalaryProvider;
			}
		}
		
		#endregion
		
		#region AddressProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Address"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AddressProviderBase AddressProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AddressProvider;
			}
		}
		
		#endregion
		
		#region EmployeeSkillsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmployeeSkills"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeSkillsProviderBase EmployeeSkillsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeSkillsProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region DepartmentsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsFilters : DepartmentsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsFilters class.
		/// </summary>
		public DepartmentsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentsFilters
	
	#region DepartmentsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DepartmentsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Departments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DepartmentsQuery : DepartmentsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DepartmentsQuery class.
		/// </summary>
		public DepartmentsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DepartmentsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DepartmentsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DepartmentsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DepartmentsQuery
		
	#region EmployeeDepartmentsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsFilters : EmployeeDepartmentsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsFilters class.
		/// </summary>
		public EmployeeDepartmentsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentsFilters
	
	#region EmployeeDepartmentsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeDepartmentsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeeDepartments"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeDepartmentsQuery : EmployeeDepartmentsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsQuery class.
		/// </summary>
		public EmployeeDepartmentsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeDepartmentsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeDepartmentsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeDepartmentsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeDepartmentsQuery
		
	#region EmployeeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilters : EmployeeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		public EmployeeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeFilters
	
	#region EmployeeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeQuery : EmployeeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		public EmployeeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeQuery
		
	#region CountriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesFilters : CountriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		public CountriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesFilters
	
	#region CountriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CountriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesQuery : CountriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		public CountriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesQuery
		
	#region SkillLevelsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsFilters : SkillLevelsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsFilters class.
		/// </summary>
		public SkillLevelsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillLevelsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillLevelsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillLevelsFilters
	
	#region SkillLevelsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SkillLevelsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SkillLevels"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillLevelsQuery : SkillLevelsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillLevelsQuery class.
		/// </summary>
		public SkillLevelsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillLevelsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillLevelsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillLevelsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillLevelsQuery
		
	#region SkillFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillFilters : SkillFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillFilters class.
		/// </summary>
		public SkillFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillFilters
	
	#region SkillQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SkillParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Skill"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SkillQuery : SkillParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SkillQuery class.
		/// </summary>
		public SkillQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SkillQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SkillQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SkillQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SkillQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SkillQuery
		
	#region BankAccountsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsFilters : BankAccountsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsFilters class.
		/// </summary>
		public BankAccountsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BankAccountsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BankAccountsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BankAccountsFilters
	
	#region BankAccountsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BankAccountsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BankAccounts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BankAccountsQuery : BankAccountsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BankAccountsQuery class.
		/// </summary>
		public BankAccountsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BankAccountsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BankAccountsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BankAccountsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BankAccountsQuery
		
	#region EmployeeSalaryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSalaryFilters : EmployeeSalaryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryFilters class.
		/// </summary>
		public EmployeeSalaryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeSalaryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeSalaryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeSalaryFilters
	
	#region EmployeeSalaryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeSalaryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeeSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSalaryQuery : EmployeeSalaryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryQuery class.
		/// </summary>
		public EmployeeSalaryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeSalaryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSalaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeSalaryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeSalaryQuery
		
	#region AddressFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressFilters : AddressFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressFilters class.
		/// </summary>
		public AddressFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressFilters
	
	#region AddressQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AddressParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Address"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AddressQuery : AddressParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AddressQuery class.
		/// </summary>
		public AddressQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AddressQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AddressQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AddressQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AddressQuery
		
	#region EmployeeSkillsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsFilters : EmployeeSkillsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsFilters class.
		/// </summary>
		public EmployeeSkillsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeSkillsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeSkillsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeSkillsFilters
	
	#region EmployeeSkillsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeSkillsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmployeeSkills"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeSkillsQuery : EmployeeSkillsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsQuery class.
		/// </summary>
		public EmployeeSkillsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeSkillsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeSkillsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeSkillsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeSkillsQuery
	#endregion

	
}

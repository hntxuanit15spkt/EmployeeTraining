﻿#region Using Directives
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using EmployeeDB.BLL;
using EmployeeDB.DAL;
#endregion

namespace EmployeeDB.CL
{
	/// <summary>
	/// The base class that each component business domain service of the model implements.
	/// </summary>
	public abstract partial class ServiceBase<Entity, EntityKey> : ServiceBaseCore<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new() 
		where EntityKey : IEntityKey, new()
	{

	}
}

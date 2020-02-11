﻿
/*
	File generated by NetTiers templates [www.nettiers.net]
	Important: Do not modify this file. Edit the file SkillLevels.cs instead.
*/

#region using directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EmployeeDB.BLL.Validation;
#endregion

namespace EmployeeDB.BLL
{
	///<summary>
	/// An object representation of the 'SkillLevels' table. [No description found the database]	
	///</summary>
	[Serializable]
	[DataObject, CLSCompliant(true)]
	public abstract partial class SkillLevelsBase : EntityBase, ISkillLevels, IEntityId<SkillLevelsKey>, System.IComparable, System.ICloneable, ICloneableEx, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private SkillLevelsEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private SkillLevelsEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private SkillLevelsEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<SkillLevels> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event SkillLevelsEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event SkillLevelsEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="SkillLevelsBase"/> instance.
		///</summary>
		public SkillLevelsBase()
		{
			this.entityData = new SkillLevelsEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="SkillLevelsBase"/> instance.
		///</summary>
		///<param name="_levelCode"></param>
		///<param name="_name"></param>
		public SkillLevelsBase(System.String _levelCode, System.String _name)
		{
			this.entityData = new SkillLevelsEntityData();
			this.backupData = null;

			this.LevelCode = _levelCode;
			this.Name = _name;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="SkillLevels"/> instance.
		///</summary>
		///<param name="_levelCode"></param>
		///<param name="_name"></param>
		public static SkillLevels CreateSkillLevels(System.String _levelCode, System.String _name)
		{
			SkillLevels newSkillLevels = new SkillLevels();
			newSkillLevels.LevelCode = _levelCode;
			newSkillLevels.Name = _name;
			return newSkillLevels;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the LevelCode property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		
		




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false, 10)]
		public virtual System.String LevelCode
		{
			get
			{
				return this.entityData.LevelCode; 
			}
			
			set
			{
				if (this.entityData.LevelCode == value)
					return;
				
                OnPropertyChanging("LevelCode");                    
				OnColumnChanging(SkillLevelsColumn.LevelCode, this.entityData.LevelCode);
				this.entityData.LevelCode = value;
				this.EntityId.LevelCode = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(SkillLevelsColumn.LevelCode, this.entityData.LevelCode);
				OnPropertyChanged("LevelCode");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the LevelCode property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the LevelCode property.</remarks>
		/// <value>This type is varchar</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.String OriginalLevelCode
		{
			get { return this.entityData.OriginalLevelCode; }
			set { this.entityData.OriginalLevelCode = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		
		




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 20)]
		public virtual System.String Name
		{
			get
			{
				return this.entityData.Name; 
			}
			
			set
			{
				if (this.entityData.Name == value)
					return;
				
                OnPropertyChanging("Name");                    
				OnColumnChanging(SkillLevelsColumn.Name, this.entityData.Name);
				this.entityData.Name = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(SkillLevelsColumn.Name, this.entityData.Name);
				OnPropertyChanged("Name");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
	
		/// <summary>
		///	Holds a collection of EmployeeSkills objects
		///	which are related to this object through the relation FK_EmployeeSkills_SkillLevels
		/// </summary>	
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
		public virtual TList<EmployeeSkills> EmployeeSkillsCollection
		{
			get { return entityData.EmployeeSkillsCollection; }
			set { entityData.EmployeeSkillsCollection = value; }	
		}
		#endregion Children Collections
		
		#endregion
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule( CommonRules.NotNull,
				new ValidationRuleArgs("LevelCode", "Level Code"));
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("LevelCode", "Level Code", 10));
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("Name", "Name", 20));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "SkillLevels"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"LevelCode", "Name"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as SkillLevelsEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (SkillLevels) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<SkillLevels>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as SkillLevels);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed SkillLevels Entity 
		///</summary>
		protected virtual SkillLevels Copy(IDictionary existingCopies)
		{
			if (existingCopies == null)
			{
				// This is the root of the tree to be copied!
				existingCopies = new Hashtable();
			}

			//shallow copy entity
			SkillLevels copy = new SkillLevels();
			existingCopies.Add(this, copy);
			copy.SuppressEntityEvents = true;
				copy.LevelCode = this.LevelCode;
					copy.OriginalLevelCode = this.OriginalLevelCode;
				copy.Name = this.Name;
			
		
			//deep copy nested objects
			copy.EmployeeSkillsCollection = (TList<EmployeeSkills>) MakeCopyOf(this.EmployeeSkillsCollection, existingCopies); 
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}		
		
		
		
		///<summary>
		///  Returns a Typed SkillLevels Entity 
		///</summary>
		public virtual SkillLevels Copy()
		{
			return this.Copy(null);	
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy(null);
		}
		
		///<summary>
		/// ICloneableEx.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone(IDictionary existingCopies)
		{
			return this.Copy(existingCopies);
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x, IDictionary existingCopies)
		{
			if (x == null)
				return null;
			
			if (x is ICloneableEx)
			{
				// Return a deep copy of the object
				return ((ICloneableEx)x).Clone(existingCopies);
			}
			else if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable or IClonableEx Interface.");
		}
		
		
		///<summary>
		///  Returns a Typed SkillLevels Entity which is a deep copy of the current entity.
		///</summary>
		public virtual SkillLevels DeepCopy()
		{
			return EntityHelper.Clone<SkillLevels>(this as SkillLevels);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as SkillLevelsEntityData;
			}
			else
			{
				//Since this had no _originalData, then just reset the entityData with a new one.  entityData cannot be null.
				this.entityData = new SkillLevelsEntityData();
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as SkillLevelsEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(SkillLevelsColumn column)
		{
			switch(column)
			{
					case SkillLevelsColumn.LevelCode:
					return entityData.LevelCode != _originalData.LevelCode;
					case SkillLevelsColumn.Name:
					return entityData.Name != _originalData.Name;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="columnName">The column name.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public override bool IsPropertyChanged(string columnName)
		{
			return 	IsPropertyChanged(EntityHelper.GetEnumValue< SkillLevelsColumn >(columnName));
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if data has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.LevelCode != _originalData.LevelCode;
			result = result || entityData.Name != _originalData.Name;
			return result;
		}	
		
		///<summary>
		///  Returns a SkillLevels Entity with the original data.
		///</summary>
		public SkillLevels GetOriginalEntity()
		{
			if (_originalData != null)
				return CreateSkillLevels(
				_originalData.LevelCode,
				_originalData.Name
				);
				
			return (SkillLevels)this.Clone();
		}
		#endregion
	
	#region Value Semantics Instance Equality
        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object using value semantics.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="SkillLevelsBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			// Cast exception if Object1 is null or DbNull
			if (Object1 != null && Object1 != DBNull.Value && Object1 is SkillLevelsBase)
				return ValueEquals(this, (SkillLevelsBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="SkillLevelsBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.LevelCode.GetHashCode() ^ 
					((this.Name == null) ? string.Empty : this.Name.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object using value semantics.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="SkillLevelsBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(SkillLevelsBase toObject)
		{
			if (toObject == null)
				return false;
			return ValueEquals(this, toObject);
		}
		#endregion
		
		///<summary>
		/// Determines whether the specified <see cref="SkillLevelsBase"/> instances are considered equal using value semantics.
		///</summary>
		///<param name="Object1">The first <see cref="SkillLevelsBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="SkillLevelsBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool ValueEquals(SkillLevelsBase Object1, SkillLevelsBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.LevelCode != Object2.LevelCode)
				equal = false;
			if ( Object1.Name != null && Object2.Name != null )
			{
				if (Object1.Name != Object2.Name)
					equal = false;
			}
			else if (Object1.Name == null ^ Object2.Name == null )
			{
				equal = false;
			}
					
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((SkillLevelsBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static SkillLevelsComparer GetComparer()
        {
            return new SkillLevelsComparer();
        }
        */

        // Comparer delegates back to SkillLevels
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(SkillLevels rhs, SkillLevelsColumn which)
        {
            switch (which)
            {
            	
            	
            	case SkillLevelsColumn.LevelCode:
            		return this.LevelCode.CompareTo(rhs.LevelCode);
            		
            		                 
            	
            	
            	case SkillLevelsColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<SkillLevelsKey> Members
		
		// member variable for the EntityId property
		private SkillLevelsKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual SkillLevelsKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new SkillLevelsKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("SkillLevels")
					.Append("|").Append( this.LevelCode.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- LevelCode: {0}{2}- Name: {1}{2}{4}", 
				this.LevelCode,
				(this.Name == null) ? string.Empty : this.Name.ToString(),
				System.Environment.NewLine, 
				this.GetType(),
				this.Error.Length == 0 ? string.Empty : string.Format("- Error: {0}\n",this.Error));
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'SkillLevels' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class SkillLevelsEntityData : ICloneable, ICloneableEx
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
		/// <summary>			
		/// LevelCode : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "SkillLevels"</remarks>
		public System.String LevelCode;
			
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		public System.String OriginalLevelCode;
		
		#endregion
		
		#region Non Primary key(s)
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String Name = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
        
		#endregion Variable Declarations

		#region Data Properties

		#region EmployeeSkillsCollection
		
		private TList<EmployeeSkills> _employeeSkillsSkillLevel;
		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _employeeSkillsSkillLevel
		/// </summary>
		
		public TList<EmployeeSkills> EmployeeSkillsCollection
		{
			get
			{
				if (_employeeSkillsSkillLevel == null)
				{
				_employeeSkillsSkillLevel = new TList<EmployeeSkills>();
				}
	
				return _employeeSkillsSkillLevel;
			}
			set { _employeeSkillsSkillLevel = value; }
		}
		
		#endregion

		#endregion Data Properties
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			SkillLevelsEntityData _tmp = new SkillLevelsEntityData();
						
			_tmp.LevelCode = this.LevelCode;
			_tmp.OriginalLevelCode = this.OriginalLevelCode;
			
			_tmp.Name = this.Name;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			if (this._employeeSkillsSkillLevel != null)
				_tmp.EmployeeSkillsCollection = (TList<EmployeeSkills>) MakeCopyOf(this.EmployeeSkillsCollection); 
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone(IDictionary existingCopies)
		{
			if (existingCopies == null)
				existingCopies = new Hashtable();
				
			SkillLevelsEntityData _tmp = new SkillLevelsEntityData();
						
			_tmp.LevelCode = this.LevelCode;
			_tmp.OriginalLevelCode = this.OriginalLevelCode;
			
			_tmp.Name = this.Name;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			//deep copy nested objects
			_tmp.EmployeeSkillsCollection = (TList<EmployeeSkills>) MakeCopyOf(this.EmployeeSkillsCollection, existingCopies); 
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct

		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SkillLevelsColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanging(SkillLevelsColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SkillLevelsColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanged(SkillLevelsColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SkillLevelsColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanging(SkillLevelsColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
                EntityManager.StopTracking(entityTrackingKey);
                
			if (!SuppressEntityEvents)
			{
				SkillLevelsEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new SkillLevelsEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="SkillLevelsColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanged(SkillLevelsColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				SkillLevelsEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new SkillLevelsEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region SkillLevelsEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="SkillLevels"/> object.
	/// </remarks>
	public class SkillLevelsEventArgs : System.EventArgs
	{
		private SkillLevelsColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the SkillLevelsEventArgs class.
		///</summary>
		public SkillLevelsEventArgs(SkillLevelsColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the SkillLevelsEventArgs class.
		///</summary>
		public SkillLevelsEventArgs(SkillLevelsColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The SkillLevelsColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="SkillLevelsColumn" />
		public SkillLevelsColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all SkillLevels related events.
	///</summary>
	public delegate void SkillLevelsEventHandler(object sender, SkillLevelsEventArgs e);
	
	#region SkillLevelsComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class SkillLevelsComparer : System.Collections.Generic.IComparer<SkillLevels>
	{
		SkillLevelsColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:SkillLevelsComparer"/> class.
        /// </summary>
		public SkillLevelsComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SkillLevelsComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public SkillLevelsComparer(SkillLevelsColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <see cref="SkillLevels"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <see cref="SkillLevels"/> to compare.</param>
        /// <param name="b">The second <c>SkillLevels</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(SkillLevels a, SkillLevels b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(SkillLevels entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(SkillLevels a, SkillLevels b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public SkillLevelsColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region SkillLevelsKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="SkillLevels"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class SkillLevelsKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the SkillLevelsKey class.
		/// </summary>
		public SkillLevelsKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the SkillLevelsKey class.
		/// </summary>
		public SkillLevelsKey(SkillLevelsBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.LevelCode = entity.LevelCode;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the SkillLevelsKey class.
		/// </summary>
		public SkillLevelsKey(System.String _levelCode)
		{
			#region Init Properties

			this.LevelCode = _levelCode;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private SkillLevelsBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public SkillLevelsBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the LevelCode property
		private System.String _levelCode;
		
		/// <summary>
		/// Gets or sets the LevelCode property.
		/// </summary>
		public System.String LevelCode
		{
			get { return _levelCode; }
			set
			{
				if ( this.Entity != null )
					this.Entity.LevelCode = value;
				
				_levelCode = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				LevelCode = ( values["LevelCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["LevelCode"], typeof(System.String)) : string.Empty;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("LevelCode", LevelCode);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("LevelCode: {0}{1}",
								LevelCode,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region SkillLevelsColumn Enum
	
	/// <summary>
	/// Enumerate the SkillLevels columns.
	/// </summary>
	[Serializable]
	public enum SkillLevelsColumn : int
	{
		/// <summary>
		/// LevelCode : 
		/// </summary>
		[EnumTextValue("Level Code")]
		[ColumnEnum("LevelCode", typeof(System.String), System.Data.DbType.AnsiString, true, false, false, 10)]
		LevelCode = 1,
		/// <summary>
		/// Name : 
		/// </summary>
		[EnumTextValue("Name")]
		[ColumnEnum("Name", typeof(System.String), System.Data.DbType.String, false, false, true, 20)]
		Name = 2
	}//End enum

	#endregion SkillLevelsColumn Enum

} // end namespace

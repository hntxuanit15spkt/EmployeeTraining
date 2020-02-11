using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace EmployeeDB.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>AddressRepeater</c>
    /// </summary>
	public class AddressRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AddressRepeaterDesigner"/> class.
        /// </summary>
		public AddressRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AddressRepeater))
			{ 
				throw new ArgumentException("Component is not a AddressRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			AddressRepeater z = (AddressRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="AddressRepeater"/> Type.
    /// </summary>
	[Designer(typeof(AddressRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AddressRepeater runat=\"server\"></{0}:AddressRepeater>")]
	public class AddressRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AddressRepeater"/> class.
        /// </summary>
		public AddressRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AddressItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AddressItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(AddressItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AddressItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(AddressItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						EmployeeDB.BLL.Address entity = o as EmployeeDB.BLL.Address;
						AddressItem container = new AddressItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class AddressItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private EmployeeDB.BLL.Address _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AddressItem"/> class.
        /// </summary>
		public AddressItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AddressItem"/> class.
        /// </summary>
		public AddressItem(EmployeeDB.BLL.Address entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the AddressId
        /// </summary>
        /// <value>The AddressId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AddressId
		{
			get { return _entity.AddressId; }
		}
        /// <summary>
        /// Gets the EmployeeId
        /// </summary>
        /// <value>The EmployeeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmployeeId
		{
			get { return _entity.EmployeeId; }
		}
        /// <summary>
        /// Gets the Line1
        /// </summary>
        /// <value>The Line1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Line1
		{
			get { return _entity.Line1; }
		}
        /// <summary>
        /// Gets the Line2
        /// </summary>
        /// <value>The Line2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Line2
		{
			get { return _entity.Line2; }
		}
        /// <summary>
        /// Gets the TownCity
        /// </summary>
        /// <value>The TownCity.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TownCity
		{
			get { return _entity.TownCity; }
		}
        /// <summary>
        /// Gets the StateOrProvince
        /// </summary>
        /// <value>The StateOrProvince.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String StateOrProvince
		{
			get { return _entity.StateOrProvince; }
		}
        /// <summary>
        /// Gets the PostCod
        /// </summary>
        /// <value>The PostCod.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PostCod
		{
			get { return _entity.PostCod; }
		}
        /// <summary>
        /// Gets the CountryCode
        /// </summary>
        /// <value>The CountryCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CountryCode
		{
			get { return _entity.CountryCode; }
		}

        /// <summary>
        /// Gets a <see cref="T:EmployeeDB.BLL.Address"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public EmployeeDB.BLL.Address Entity
        {
            get { return _entity; }
        }
	}
}

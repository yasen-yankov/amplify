using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace Telerik.Sitefinity.AMP
{
    /// <summary>
    /// Localizable strings for the AMP module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<AMPResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("AMPResources", ResourceClassId = "AMPResources", Title = "AMPResourcesTitle", TitlePlural = "AMPResourcesTitlePlural", Description = "AMPResourcesDescription")]
    public class AMPResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="AMPResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public AMPResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="AMPResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public AMPResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// AMP Resources
        /// </summary>
        [ResourceEntry("AMPResourcesTitle",
            Value = "AMP module labels",
            Description = "The title of this class.",
            LastModified = "2016/10/26")]
        public string AMPResourcesTitle
        {
            get
            {
                return this["AMPResourcesTitle"];
            }
        }

        /// <summary>
        /// AMP Resources Title plural
        /// </summary>
        [ResourceEntry("AMPResourcesTitlePlural",
            Value = "AMP module labels",
            Description = "The title plural of this class.",
            LastModified = "2016/10/26")]
        public string AMPResourcesTitlePlural
        {
            get
            {
                return this["AMPResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for AMP module.
        /// </summary>
        [ResourceEntry("AMPResourcesDescription",
            Value = "Contains localizable resources for AMP module.",
            Description = "The description of this class.",
            LastModified = "2016/10/26")]
        public string AMPResourcesDescription
        {
            get
            {
                return this["AMPResourcesDescription"];
            }
        }
        #endregion

        #region AmpPageses
        /// <summary>
        /// Messsage: PageTitle
        /// </summary>
        /// <value>Title for the AmpPages's page.</value>
        [ResourceEntry("AmpPagesGroupPageTitle",
            Value = "AmpPages",
            Description = "The title of AmpPages's page.",
            LastModified = "2016/10/26")]
        public string AmpPagesGroupPageTitle
        {
            get
            {
                return this["AmpPagesGroupPageTitle"];
            }
        }

        /// <summary>
        /// Messsage: PageDescription
        /// </summary>
        /// <value>Description for the AmpPages's page.</value>
        [ResourceEntry("AmpPagesGroupPageDescription",
            Value = "AmpPages",
            Description = "The description of AmpPages's page.",
            LastModified = "2016/10/26")]
        public string AmpPagesGroupPageDescription
        {
            get
            {
                return this["AmpPagesGroupPageDescription"];
            }
        }

        /// <summary>
		/// The URL name of AmpPages's page.
		/// </summary>
		[ResourceEntry("AmpPagesGroupPageUrlName",
			Value = "AMP-AmpPages",
			Description = "The URL name of AmpPages's page.",
			LastModified = "2016/10/26")]
		public string AmpPagesGroupPageUrlName
		{
			get
			{
				return this["AmpPagesGroupPageUrlName"];
			}
		}


        /// <summary>
        /// Message displayed to user on empty page
        /// </summary>
        /// <value>Products empty page</value>
        [ResourceEntry("AmpPagesEmptyPageMessage",
            Value = "AmpPages empty page",
            Description = "Message displayed to user on empty page",
            LastModified = "2016/10/26")]
        public string AmpPagesEmptyPageMessage
        {
            get
            {
                return this["AmpPagesEmptyPageMessage"];
            }
        }
        
        /// <summary>
        /// The URL name of AmpPages's page.
        /// </summary>
        /// <value>AmpPagesMasterPageUrl</value>
        [ResourceEntry("AmpPagesMasterPageUrl",
            Value = "AmpPagesMasterPageUrl",
            Description = "The URL name of AmpPages's page.",
            LastModified = "2016/10/26")]
        public string AmpPagesMasterPageUrl
        {
            get
            {
                return this["AmpPagesMasterPageUrl"];
            }
        }
        #endregion

		#region AmpPage

		[ResourceEntry("AmpPageTitle", Value = "Amp Page")]
		public string AmpPageTitle
		{
			get
			{
				return this["AmpPageTitle"];
			}
		}

		[ResourceEntry("AmpPageDescription", Value = "Amp Page Description")]
		public string AmpPageDescription
		{
			get
			{
				return this["AmpPageDescription"];
			}
		}

		[ResourceEntry("AmpPageUrl", Value = "Amp Page url")]
		public string AmpPageUrl
		{
			get
			{
				return this["AmpPageUrl"];
			}
		}

		#endregion

	}
}
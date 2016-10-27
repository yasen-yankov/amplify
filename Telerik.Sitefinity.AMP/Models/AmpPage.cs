using System;
using System.Linq;
using Telerik.Sitefinity.Model;

namespace Telerik.Sitefinity.AMP.Models
{
    public class AmpPage : IDataItem
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="AmpPage" /> class.
        /// </summary>
        public AmpPage()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AmpPage" /> class.
        /// </summary>
        /// <param name="id">The AmpPages ID.</param>
        /// <param name="applicationName">Name of the application.</param>
        public AmpPage(Guid id, string applicationName)
        {
            this.Id = id;
            this.ApplicationName = applicationName;
            this.DateCreated = DateTime.UtcNow;
            this.LastModified = DateTime.UtcNow;
        }
        #endregion
        
        #region Properties
        /// <summary>
        /// Gets or sets the name of the application to which this data item belongs to.
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName
        {
            get
            {
                return this.applicationName;
            }
            set
            {
                this.applicationName = value;
            }
        }
        
        /// <summary>
        /// The data provider this item was instantiated(retrieved or created) with.
        /// </summary>
        public object Provider
        {
            get
            {
                return this.provider;
            }
            set
            {
                this.provider = value;
            }
        }

        /// <summary>
        /// The transaction scope this item belongs to or null. This property is set by the specific forums provider implementation
        /// </summary>
        public object Transaction
        {
            get
            {
                return this.transaction;
            }
            set
            {
                this.transaction = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the time this item was last modified.
        /// </summary>
        /// <value>The last modified time.</value>
        public DateTime LastModified { get; set; }
        
        /// <summary>
        /// Gets the unique identity of the AmpPages.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the UrlName.
        /// </summary>
        public string UrlName { get; set; }

        /// <summary>
        /// Gets or sets the ModuleType.
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the PageId.
        /// </summary>
        public Guid PageId { get; set; }

		/// <summary>
		/// Gets or sets the page URL.
		/// </summary>
		/// <value>The page URL.</value>
		public string PageUrl { get; set; }

        /// <summary>
        /// Gets or sets the FieldsListJSON.
        /// </summary>
        public string FieldsListJson { get; set; }

		/// <summary>
		/// Gets or sets the layout template path.
		/// </summary>
		/// <value>The layout template path.</value>
		public string LayoutTemplatePath { get; set; }

		/// <summary>
		/// Gets or sets the templte path.
		/// </summary>
		/// <value>The templte path.</value>
		public string TempltePath { get; set; }

        #endregion
        
        #region Private fields and constants
        private string applicationName;
        private object provider;
        private object transaction;
        #endregion
    }
}
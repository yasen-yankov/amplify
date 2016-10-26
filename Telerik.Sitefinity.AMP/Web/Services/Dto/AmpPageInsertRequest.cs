using System;

namespace Telerik.Sitefinity.AMP.Web.Services.Dto
{
    /// <summary>
    /// AMP page message.
    /// </summary>
    internal class AmpPageInsertRequest
    {
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
        /// Gets or sets the FieldsListJSON.
        /// </summary>
        public string FieldsListJson { get; set; }
    }
}
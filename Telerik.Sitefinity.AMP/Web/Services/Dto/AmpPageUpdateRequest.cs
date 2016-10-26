using System;

namespace Telerik.Sitefinity.AMP.Web.Services.Dto
{
    /// <summary>
    /// AMP page message.
    /// </summary>
    internal class AmpPageUpdateRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
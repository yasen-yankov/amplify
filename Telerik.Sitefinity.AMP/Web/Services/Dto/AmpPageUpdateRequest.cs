﻿using System;
using System.Collections.Generic;

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
        /// Gets or sets the Fields list.
        /// </summary>
        public IList<AmpPageFieldDto> Fields { get; set; }

		/// <summary>
		/// Gets or sets the layout template path.
		/// </summary>
		/// <value>The layout template path.</value>
		public string LayoutTemplatePath { get; set; }

		/// <summary>
		/// Gets or sets the templte path.
		/// </summary>
		/// <value>The templte path.</value>
		public string TemplatePath { get; set; }

		/// <summary>
		/// Gets or sets the page URL.
		/// </summary>
		/// <value>The page URL.</value>
		public string PageUrl { get; set; }
    }
}
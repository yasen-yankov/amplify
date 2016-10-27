using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.AMP.Models;

namespace Telerik.Sitefinity.AMP.Web.Services.Dto
{
	internal class AmpPageDto
	{
        public AmpPageDto()
        {
        }

        public AmpPageDto(AmpPage ampPage)
        {
            if (ampPage == null)
            {
                return;
            }

            this.Id = ampPage.Id;
            this.Title = ampPage.Title;
            this.ItemType = ampPage.ItemType;
            this.PageId = ampPage.PageId;
            this.Fields = JsonSerializer.DeserializeFromString<IList<AmpPageFieldDto>>(ampPage.FieldsListJson);
            this.UrlName = ampPage.UrlName;
			this.TempltePath = ampPage.TempltePath;
			this.LayoutTemplatePath = ampPage.LayoutTemplatePath;
			this.PageUrl = ampPage.PageUrl;
        }

        public AmpPageDto(AmpPageInsertRequest ampPageInsertRequest)
        {
            if (ampPageInsertRequest == null)
            {
                return;
            }

            this.Title = ampPageInsertRequest.Title;
            this.ItemType = ampPageInsertRequest.ItemType;
            this.PageId = ampPageInsertRequest.PageId;
            this.Fields = ampPageInsertRequest.Fields;
            this.UrlName = ampPageInsertRequest.UrlName;
			this.TempltePath = ampPageInsertRequest.TempltePath;
			this.LayoutTemplatePath = ampPageInsertRequest.LayoutTemplatePath;
			this.PageUrl = ampPageInsertRequest.PageUrl;
        }

        public AmpPageDto(AmpPageUpdateRequest ampPageUpdateRequest)
        {
            if (ampPageUpdateRequest == null)
            {
                return;
            }

            this.Id = ampPageUpdateRequest.Id;
            this.Title = ampPageUpdateRequest.Title;
            this.ItemType = ampPageUpdateRequest.ItemType;
            this.PageId = ampPageUpdateRequest.PageId;
            this.Fields = ampPageUpdateRequest.Fields;
            this.UrlName = ampPageUpdateRequest.UrlName;
			this.TempltePath = ampPageUpdateRequest.TempltePath;
			this.LayoutTemplatePath = ampPageUpdateRequest.LayoutTemplatePath;
			this.PageUrl = ampPageUpdateRequest.PageUrl;
        }

        public void ToAmpPage(AmpPage ampPage)
        {
            ampPage.Title = this.Title;
            ampPage.ItemType = this.ItemType;
            ampPage.PageId = this.PageId;
            ampPage.FieldsListJson = JsonSerializer.SerializeToString<IList<AmpPageFieldDto>>(this.Fields);
            ampPage.UrlName = this.UrlName;
			ampPage.LayoutTemplatePath = this.LayoutTemplatePath;
			ampPage.TempltePath = this.TempltePath;
			ampPage.PageUrl = this.PageUrl;
        }

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
		public string TempltePath { get; set; }

		/// <summary>
		/// Gets or sets the page URL.
		/// </summary>
		/// <value>The page URL.</value>
		public string PageUrl { get; set; }
	}
}
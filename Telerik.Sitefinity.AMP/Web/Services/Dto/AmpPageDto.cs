using System;
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
            this.FieldsListJson = ampPageInsertRequest.FieldsListJson;
            this.UrlName = ampPageInsertRequest.UrlName;
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
            this.FieldsListJson = ampPageUpdateRequest.FieldsListJson;
            this.UrlName = ampPageUpdateRequest.UrlName;
        }

        public void ToAmpPage(AmpPage ampPage)
        {
            ampPage.Title = this.Title;
            ampPage.ItemType = this.ItemType;
            ampPage.PageId = this.PageId;
            ampPage.FieldsListJson = this.FieldsListJson;
            ampPage.UrlName = this.UrlName;
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
        /// Gets or sets the FieldsListJSON.
        /// </summary>
        public string FieldsListJson { get; set; }
    }
}
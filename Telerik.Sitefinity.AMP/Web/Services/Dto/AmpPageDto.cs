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
        }

        public AmpPageDto(AmpPageUpdateRequest ampPageUpdateRequest)
        {
            if (ampPageUpdateRequest == null)
            {
                return;
            }

            this.Id = ampPageUpdateRequest.Id;
            this.Title = ampPageUpdateRequest.Title;
        }

        public void ToAmpPage(AmpPage ampPage)
        {
            ampPage.Title = this.Title;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
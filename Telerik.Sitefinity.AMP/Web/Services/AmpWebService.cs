using System;
using System.Linq;
using ServiceStack;
using System.Collections.Generic;
using Telerik.Sitefinity.AMP.Web.Services.Dto;
using Telerik.Sitefinity.AMP.Models;

namespace Telerik.Sitefinity.AMP.Web.Services
{
    internal class AmpWebService : Service
    {
        public AmpWebService()
        {
        }

        public IEnumerable<AmpPageDto> Get(AmpPagesGetRequest request)
        {
            var ampManager = AMPManager.GetManager();

            IQueryable<AmpPage> ampPagesQuery = ampManager.GetAmpPages();

            if (request.Id.HasValue)
            {
                ampPagesQuery = ampPagesQuery.Where(p => p.Id == request.Id);
            }

            var ampPageDtos = ampPagesQuery.Select(a => new AmpPageDto(a));

            return ampPageDtos;
        }

        public AmpPageDto Put(AmpPageInsertRequest request)
        {
            var ampPageDto = new AmpPageDto(request);

            var ampManager = AMPManager.GetManager();
            AmpPage ampPage = ampManager.CreateAmpPage();
            ampPageDto.ToAmpPage(ampPage);

            ampManager.SaveChanges();

            ampPageDto = new AmpPageDto(ampPage);

            return ampPageDto;
        }

        public AmpPageDto Post(AmpPageUpdateRequest request)
        {
            var ampPageDto = new AmpPageDto(request);

            var ampManager = AMPManager.GetManager();
            AmpPage ampPage = ampManager.GetAmpPage(ampPageDto.Id);
            ampPageDto.ToAmpPage(ampPage);

            ampManager.SaveChanges();

            ampPageDto = new AmpPageDto(ampPage);

            return ampPageDto;
        }

        public void Delete(AmpPageDeleteRequest request)
        {
            var ampManager = AMPManager.GetManager();
            AmpPage ampPage = ampManager.GetAmpPage(request.Id);
            ampManager.DeleteAmpPage(ampPage);

            ampManager.SaveChanges();
        }
    }
}
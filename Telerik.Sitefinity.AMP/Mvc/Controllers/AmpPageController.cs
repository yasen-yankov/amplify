using ComboRox.Core.Utilities.SimpleGuard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.AMP;
using Telerik.Sitefinity.AMP.Web.Services.Dto;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Mvc.Controllers
{
	public class AmpPageController : Controller
	{
		[HttpGet]
		public ActionResult Index(string ampPageUrl, string itemUrl)
		{
			Guard.Requires(ampPageUrl, "ampPageUrl").IsNotNullOrEmpty();
			Guard.Requires(itemUrl, "itemUrl").IsNotNullOrEmpty();

			itemUrl = "/" + itemUrl;

			var ampPageData = AMPManager.GetManager().GetAmpPage(ampPageUrl);

			if (ampPageData == null)
			{
				return this.HttpNotFound(string.Format("There is no AMP page with url: {0}", ampPageUrl));
			}

			var itemType = TypeResolutionService.ResolveType(ampPageData.ItemType);
			IDataItem dataItem = this.GetDataItem(itemType, itemUrl);

			this.ViewBag.Title = ampPageData.Title;

			var fields = JsonConvert.DeserializeObject<List<AmpPageFieldDto>>(ampPageData.FieldsListJson);

			return View(new AmpPageViewModel
			{
				DataItem = dataItem,
				Fields = fields.OrderBy(x => x.Ordinal)
			});
		}

		private IDataItem GetDataItem(Type itemType, string itemUrl)
		{
			var manager = ManagerBase.GetMappedManager(itemType);

			string redirectUrl;
			var dataItem = ((IUrlProvider)manager.Provider).GetItemFromUrl(itemType, itemUrl, out redirectUrl);

			return dataItem;
		}
	}
}
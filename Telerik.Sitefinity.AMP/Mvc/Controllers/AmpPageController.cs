using ComboRox.Core.Utilities.SimpleGuard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Mvc.Controllers
{
	public class AmpPageController : Controller
	{
		[HttpGet]
		public ActionResult Index(string ampPage, string itemUrl)
		{
			Guard.Requires(ampPage, "ampPage").IsNotNullOrEmpty();
			Guard.Requires(itemUrl, "itemUrl").IsNotNullOrEmpty();

			itemUrl = "/" + itemUrl;

			AmpPageDataModel ampPageData = this.GetAmpPageData();
			IDataItem dataItem = this.GetDataItem(ampPageData.ItemType, itemUrl);

			this.ViewBag.Title = ampPageData.Title;

			return View(new AmpPageViewModel
			{
				DataItem = dataItem,
				Fields = ampPageData.Fields.OrderBy(x => x.Ordinal)
			});
		}

		private IDataItem GetDataItem(Type itemType, string itemUrl)
		{
			var manager = ManagerBase.GetMappedManager(itemType);

			string redirectUrl;
			var dataItem = ((IUrlProvider)manager.Provider).GetItemFromUrl(itemType, itemUrl, out redirectUrl);

			return dataItem;
		}

		private AmpPageDataModel GetAmpPageData()
		{
			return new AmpPageDataModel
			{
				Title = "My cool AMP page",
				ItemType = TypeResolutionService.ResolveType("Telerik.Sitefinity.Blogs.Model.BlogPost"),
				Fields = new List<AmpFieldModel>
				{
					new AmpFieldModel { FieldName = "Title", Ordinal = 0, WrapperTag = new WrapperTagModel { TagName = "h1" }},
					new AmpFieldModel { FieldName = "Title", Ordinal = 1},
					new AmpFieldModel { FieldName = "Content", Ordinal = 2, WrapperTag = new WrapperTagModel { TagName = "div", CssClass = "test" }},
				}
			};
		}
	}
}
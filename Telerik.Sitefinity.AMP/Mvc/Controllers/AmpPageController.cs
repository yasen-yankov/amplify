﻿using ComboRox.Core.Utilities.SimpleGuard;
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
using Telerik.Sitefinity.AMP.Configuration;
using Telerik.Sitefinity.AMP.Models;
using Telerik.Sitefinity.AMP.Web.Services.Dto;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace Telerik.Sitefinity.AMP.Mvc.Models
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

			this.SetPageData(ampPageData);

			string layoutTemplatePath = GetLayoutTemplate(ampPageData.LayoutTemplatePath);
			string templatePath = GetTemplate(ampPageData.TempltePath);

			var fields = JsonConvert.DeserializeObject<List<AmpPageFieldDto>>(ampPageData.FieldsListJson).OrderBy(x => x.Ordinal);
			IDataItem dataItem = this.GetDataItem(ampPageData.ItemType, itemUrl);

			return View(templatePath, masterName: layoutTemplatePath, model: new AmpPageViewModel
			{
				DataItem = dataItem,
				Fields = fields
			});
		}
 
		private void SetPageData(AmpPage ampPageData)
		{
			this.ViewBag.Title = ampPageData.Title;
			this.ViewBag.OriginalPageUrl = ampPageData.PageUrl;
		}

		private static string GetTemplate(string template)
		{
			if (string.IsNullOrEmpty(template))
			{
				return Config.Get<AMPConfig>().DefaultTemplate;
			}

			return template;
		}

		private static string GetLayoutTemplate(string layoutTemplatePath)
		{
			if (string.IsNullOrEmpty(layoutTemplatePath))
			{
				return Config.Get<AMPConfig>().DefaultLayoutTemplate;
			}

			return layoutTemplatePath;
		}

		private IDataItem GetDataItem(string itemTypeName, string itemUrl)
		{
			var itemType = TypeResolutionService.ResolveType(itemTypeName);
			var manager = ManagerBase.GetMappedManager(itemType);

			string redirectUrl;
			var dataItem = ((IUrlProvider)manager.Provider).GetItemFromUrl(itemType, itemUrl, out redirectUrl);

			return dataItem;
		}
	}
}
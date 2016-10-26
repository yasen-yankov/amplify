﻿using Html2Amp;
using SitefinityWebApp.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.Utilities;

namespace SitefinityWebApp.Mvc.HtmlHelpers
{
	public static class AmpComponentHtmlHelper
	{
		private static readonly Lazy<HtmlToAmpConverter> ampConverter = new Lazy<HtmlToAmpConverter>(InitializeConverter);

		private static HtmlToAmpConverter InitializeConverter()
		{
			return new HtmlToAmpConverter().WithConfiguration(new RunConfiguration
			{
				RelativeUrlsHost = "http://localhost"
			});
		}

		public static IHtmlString AmpHtml(this HtmlHelper htmlHelper, IDataItem dataItem, string fieldName, AmpComponentModel ampComponent)
		{
			object fieldValue = ((IDynamicFieldsContainer)dataItem).GetValue(fieldName);

			if (fieldValue is string || fieldValue is Lstring)
			{
				DynamicLinksParser dynamicLinksParser = new DynamicLinksParser(false);
				fieldValue = dynamicLinksParser.Apply(fieldValue.ToString());
			}

			string ampHtml = string.Empty;
			if (ampComponent == null)
			{
				ampHtml = ampConverter.Value.ConvertFromHtml(fieldValue.ToString());
			}
			else
			{
				// Amp component
			}

			return htmlHelper.Raw(ampHtml);
		}

		public static IHtmlString WrapperTag(this HtmlHelper htmlHelper, string html, WrapperTagModel wrapperTag)
		{
			if (wrapperTag == null || string.IsNullOrEmpty(wrapperTag.TagName))
			{
				return new HtmlString(html);
			}

			if (string.IsNullOrEmpty(wrapperTag.CssClass))
			{
				return htmlHelper.Raw(string.Format("<{0}>{1}</{0}>", wrapperTag.TagName, html));
			}

			return htmlHelper.Raw(string.Format("<{0} class=\"{1}\">{2}</{0}>", wrapperTag.TagName, wrapperTag.CssClass, html));
		}

		public static IHtmlString WrapperTag(this HtmlHelper htmlHelper, IHtmlString html, WrapperTagModel wrapperTag)
		{
			return htmlHelper.WrapperTag(html.ToString(), wrapperTag);
		}
	}
}
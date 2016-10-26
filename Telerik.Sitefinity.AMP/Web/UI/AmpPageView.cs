﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;

namespace Telerik.Sitefinity.AMP.Web.UI
{
	public class AmpPageView : SimpleScriptView
	{
		#region Properties

		/// <summary>
		/// Gets or sets the path of the external template to be used by the control.
		/// </summary>
		public override string LayoutTemplatePath
		{
			get
			{
				if (string.IsNullOrEmpty(base.LayoutTemplatePath))
					base.LayoutTemplatePath = AmpPageView.LayoutTemplatePathName;
				return base.LayoutTemplatePath;
			}

			set
			{
				base.LayoutTemplatePath = value;
			}
		}

		/// <summary>
		/// Gets the name of the embedded layout template.
		/// </summary>
		/// <remarks>
		/// Override this property to change the embedded template to be used with the dialog
		/// </remarks>
		protected override string LayoutTemplateName
		{
			get { return null; }
		}

		#endregion

		#region Control references

		/// <summary>
		/// Gets the reference to the export types service URL hidden field
		/// </summary>
		//protected HiddenField AmpPageServiceUrlHiddenField
		//{
		//	get { return this.Container.GetControl<HiddenField>("hdfAddonsServiceUrl", true); }
		//}

		#endregion

		/// <inheritdoc />
		protected override HtmlTextWriterTag TagKey
		{
			get
			{
				return HtmlTextWriterTag.Div;
			}
		}

		/// <inheritdoc />
		public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			return new ScriptDescriptor[0];
		}

		/// <inheritdoc />
		public override IEnumerable<ScriptReference> GetScriptReferences()
		{
			var scripts = new List<ScriptReference>();
			scripts.Add(new ScriptReference(AmpPageView.ScriptReference, typeof(AmpPageView).Assembly.FullName));
			return scripts;
		}

		/// <inheritdoc />
		protected override void InitializeControls(GenericContainer container)
		{
			var currentNode = BackendSiteMap.FindSiteMapNode(AmpPageId, false);
			//this.AmpPagePageUrlHiddenField.Value = RouteHelper.ResolveUrl(currentNode != null ? currentNode.Url : "~/Sitefinity", UrlResolveOptions.Rooted | UrlResolveOptions.RemoveTrailingSlash);
			//this.AmpPageServiceUrlHiddenField.Value =  VirtualPathUtility.ToAbsolute("~/RestApi/" + AmpServiceStackPlugin.AmpPageInsertRoute);
		}

		internal Guid AmpPageId = Guid.Parse("19489ce6-04b8-47dc-ad4c-19cde280ee74");
		internal const string ScriptReference = "Telerik.Sitefinity.AMP.Web.UI.Scripts.AmpPageView.js";

		private static readonly string LayoutTemplatePathName = "~/AMP/Telerik.Sitefinity.AMP.Web.UI.Views.AmpPageView.ascx";
	}
}
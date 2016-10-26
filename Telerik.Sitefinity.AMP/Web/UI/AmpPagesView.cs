using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.AMP.Web.Services;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;

namespace Telerik.Sitefinity.AMP.Web.UI
{
	/// <summary>
	/// View used for listing all amp pages
	/// </summary>
	public class AmpPagesView : SimpleScriptView
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
					base.LayoutTemplatePath = AmpPagesView.LayoutTemplatePathName;
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
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Gets a reference to the html element that serves URL for single amp page hidden field
		/// </summary>
		protected HiddenField AmpPagesPageUrlHiddenField
		{
			get
			{
				return this.Container.GetControl<HiddenField>("hdfAmpPagesPageHyperLink", true);
			}
		}

		#endregion

		#region Control references

		/// <summary>
		/// Gets the reference to the export types service URL hidden field
		/// </summary>
		protected HiddenField AmpServiceUrlHiddenField
		{
			get
			{
				return this.Container.GetControl<HiddenField>("hdfAmpServiceUrl", true);
			}
		}

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
			scripts.Add(new ScriptReference(AmpPagesView.ScriptReference, typeof(AmpPagesView).Assembly.FullName));
			return scripts;
		}

		/// <inheritdoc />
		protected override void InitializeControls(GenericContainer container)
		{
			var currentNode = BackendSiteMap.FindSiteMapNode(AmpPagesPagesId, false);
			this.AmpPagesPageUrlHiddenField.Value = RouteHelper.ResolveUrl(currentNode != null ? currentNode.Url : "~/Sitefinity", UrlResolveOptions.Rooted | UrlResolveOptions.RemoveTrailingSlash);
			this.AmpServiceUrlHiddenField.Value = VirtualPathUtility.ToAbsolute("~/RestApi/" + AmpServiceStackPlugin.AmpPagesRoute);
		}

		internal Guid AmpPagesPagesId = Guid.Parse("3e74a66b-e8c9-4420-9ceb-36810311a480");
		
		internal const string ScriptReference = "Telerik.Sitefinity.AMP.Web.UI.Scripts.AmpPagesView.js";
		private static readonly string LayoutTemplatePathName = "~/AMP/Telerik.Sitefinity.AMP.Web.UI.Views.AmpPagesView.ascx";
	}
}
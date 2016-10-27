using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.AMP.Web.Services;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;
using System.Linq;

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
		protected HiddenField AmpServiceUrlHiddenField
		{
			get
			{
				return this.Container.GetControl<HiddenField>("hdfAmpServiceUrl", true);
			}
		}

        protected HiddenField AmpConfigServiceUrlHiddenField
		{
			get
			{
				return this.Container.GetControl<HiddenField>("hdfAmpConfigServiceUrl", true);
			}
		}

		protected HiddenField AmpGroupPageUrlHiddenField
		{
			get
			{
				return this.Container.GetControl<HiddenField>("hdfAmpGroupPageUrl", true);
			}
		}

        protected HiddenField IsCreateModeHiddenField
		{
			get
			{
				return this.Container.GetControl<HiddenField>("hdfIsCreateMode", true);
			}
		}

        /// <summary>
        /// Gets a reference to the html element that serves as a back button to All add-ons
        /// </summary>
        protected HyperLink AllAmpPagesButton
        {
            get
            {
                return this.Container.GetControl<HyperLink>("hlAllAmpPages", true);
            }
        }

        /// <summary>
        /// Gets the reference to the add-on id hidden field
        /// </summary>
        protected HiddenField AmpPageIdHiddenField
        {
            get
            {
                return this.Container.GetControl<HiddenField>("hdfAmpPageId", true);
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
			scripts.Add(new ScriptReference(AmpPageView.ScriptReference, typeof(AmpPageView).Assembly.FullName));
			
            return scripts;
		}

		/// <inheritdoc />
        protected override void InitializeControls(GenericContainer container)
        {
            var page = this.Page;
            var urlParameters = page.GetUrlParameters();
            if (urlParameters == null || urlParameters.Length == 0)
            {
                this.ReturnPageNotFoundResponse(page);

                return;
            }

            Guid ampPageId = Guid.Empty;
            bool hasAmpPageId = Guid.TryParse(urlParameters[0], out ampPageId);
            if (Guid.TryParse(urlParameters[0], out ampPageId))
            {
                hasAmpPageId = true;

                var ampManager = AMPManager.GetManager();
                var ampPageIds = ampManager.GetAmpPages().Select(p => p.Id);
                if (!ampPageIds.Contains(ampPageId))
                {
                    this.ReturnPageNotFoundResponse(page);

                    return;
                }
            }

            if (urlParameters[0] != "Create" && !hasAmpPageId)
            {
                this.ReturnPageNotFoundResponse(page);

                return;
            }

            bool isCreateMode = false;

            if (!hasAmpPageId)
            {
                isCreateMode = true;
            }

            var currentNode = BackendSiteMap.FindSiteMapNode(AMPModule.AmpPagesGroupPageId, false);
            this.AmpGroupPageUrlHiddenField.Value = RouteHelper.ResolveUrl(currentNode != null ? currentNode.Url : "~/Sitefinity", UrlResolveOptions.Rooted | UrlResolveOptions.RemoveTrailingSlash);

            this.AmpPageIdHiddenField.Value = ampPageId.ToString();
            this.IsCreateModeHiddenField.Value = isCreateMode.ToString();

			this.AmpServiceUrlHiddenField.Value = VirtualPathUtility.ToAbsolute("~/RestApi/" + AmpServiceStackPlugin.AmpPagesRoute);
            this.AmpConfigServiceUrlHiddenField.Value = VirtualPathUtility.ToAbsolute("~/RestApi/" + AmpServiceStackPlugin.AmpConfigurationRoute);
        }
 
        private void ReturnPageNotFoundResponse(Page page)
        {
            page.Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            page.Response.SuppressContent = true;
            this.Context.ApplicationInstance.CompleteRequest();
        }

		internal const string ScriptReference = "Telerik.Sitefinity.AMP.Web.UI.Scripts.AmpPageView.js";

		private static readonly string LayoutTemplatePathName = "~/AMP/Telerik.Sitefinity.AMP.Web.UI.Views.AmpPageView.ascx";
	}
}
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Fluent.Modules;
using Telerik.Sitefinity.Fluent.Modules.Toolboxes;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.AMP.Configuration;
using Telerik.Sitefinity.AMP.Web.UI.AmpPageses;
using Telerik.Sitefinity.AMP.Web.Services;
using Telerik.Sitefinity.AMP.Web.UI;

namespace Telerik.Sitefinity.AMP
{
    /// <summary>
    /// Custom Sitefinity module 
    /// </summary>
    public class AMPModule : ModuleBase
    {
        #region Properties
        /// <summary>
        /// Gets the landing page id for the module.
        /// </summary>
        /// <value>The landing page id.</value>
        public override Guid LandingPageId
        {
            get
            {
                return SiteInitializer.DashboardPageNodeId;
            }
        }

        /// <summary>
        /// Gets the CLR types of all data managers provided by this module.
        /// </summary>
        /// <value>An array of <see cref="T:System.Type" /> objects.</value>
        public override Type[] Managers
        {
            get
            {
                //Commented by Sitefinity Thunder
                //return new Type[0];

                return AMPModule.managerTypes;
            }
        }
        #endregion

        #region Module Initialization
        /// <summary>
        /// Initializes the service with specified settings.
        /// This method is called every time the module is initializing (on application startup by default)
        /// </summary>
        /// <param name="settings">The settings.</param>
        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);

            // Add your initialization logic here
            // here we register the module resources
            // but if you have you should register your module configuration or web service here

            App.WorkWith()
                .Module(settings.Name)
                    .Initialize()
                    .Localization<AMPResources>()
                    .Configuration<AMPConfig>()
                    .ServiceStackPlugin(new AmpServiceStackPlugin());

            // Here is also the place to register to some Sitefinity specific events like Bootstrapper.Initialized or subscribe for an event in with the EventHub class            
            // Please refer to the documentation for additional information http://www.sitefinity.com/documentation/documentationarticles/developers-guide/deep-dive/sitefinity-event-system/ieventservice-and-eventhub
        }

        /// <summary>
        /// Installs this module in Sitefinity system for the first time.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        public override void Install(SiteInitializer initializer)
        {
            // Here you can install a virtual path to be used for this assembly
            // A virtual path is required to access the embedded resources
            //this.InstallVirtualPaths(initializer);

            // Here you can install you backend pages
            //this.InstallBackendPages(initializer);

            // Here you can also install your page/form/layout widgets
            //this.InstallPageWidgets(initializer);

            this.InstallVirtualPaths(initializer);

            this.InstallBackendPages(initializer);

			this.AddAmpPagesNode(initializer);
        }

        /// <summary>
        /// Upgrades this module from the specified version.
        /// This method is called instead of the Install method when the module is already installed with a previous version.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        /// <param name="upgradeFrom">The version this module us upgrading from.</param>
        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
            // Here you can check which one is your prevous module version and execute some code if you need to
            // See the example bolow
            //
            //if (upgradeFrom < new Version("1.0.1.0"))
            //{
            //    some upgrade code that your new version requires
            //}
        }

        /// <summary>
        /// Uninstalls the specified initializer.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public override void Uninstall(SiteInitializer initializer)
        {
            base.Uninstall(initializer);
            // Add your uninstall logic here
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the module configuration.
        /// </summary>
        protected override ConfigSection GetModuleConfig()
        {
            //Commented by Sitefinity Thunder
            // If you have a module configuration, you should return it here
            // return Config.Get<ModuleConfigurationType>();
            //return null;

            return Config.Get<AMPConfig>();
        }
        #endregion

        #region Virtual paths
        /// <summary>
        /// Installs module virtual paths.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallVirtualPaths(SiteInitializer initializer)
        {
            // Here you can register your module virtual paths

            //var virtualPaths = initializer.Context.GetConfig<VirtualPathSettingsConfig>().VirtualPaths;
            //var moduleVirtualPath = AMPModule.ModuleVirtualPath + "*";
            //if (!virtualPaths.ContainsKey(moduleVirtualPath))
            //{
            //    virtualPaths.Add(new VirtualPathElement(virtualPaths)
            //    {
            //        VirtualPath = moduleVirtualPath,
            //        ResolverName = "EmbeddedResourceResolver",
            //        ResourceLocation = typeof(AMPModule).Assembly.GetName().Name
            //    });
            //}
            var virtualPaths = initializer.Context.GetConfig<VirtualPathSettingsConfig>().VirtualPaths;
            var moduleVirtualPath = AMPModule.ModuleVirtualPath + "*";
            if (!virtualPaths.ContainsKey(moduleVirtualPath))
            {
                virtualPaths.Add(new VirtualPathElement(virtualPaths)
                {
                    VirtualPath = moduleVirtualPath,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = typeof(AMPModule).Assembly.GetName().Name
                });
            }
        }
        #endregion

        #region Install backend pages
        /// <summary>
        /// Installs the backend pages.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallBackendPages(SiteInitializer initializer)
        {
            // Using our Fluent Api you can add your module backend pages hierarchy in no time
            // Here is an example using resources to localize the title of the page and adding a dummy control
            // to the module page. 

            //Guid groupPageId = new Guid("2f09ece0-683c-4735-b313-06d4c3a3b7d6");
            //Guid pageId = new Guid("2161c928-2120-4287-af52-349c3a2327d7");

            //initializer.Installer
            //    .CreateModuleGroupPage(groupPageId, "AMP group page")
            //        .PlaceUnder(SiteInitializer.SitefinityNodeId)
            //        .SetOrdinal(100)
            //        .LocalizeUsing<AMPResources>()
            //        .SetTitleLocalized("AMPGroupPageTitle")
            //        .SetUrlNameLocalized("AMPGroupPageUrlName")
            //        .SetDescriptionLocalized("AMPGroupPageDescription")
            //        .ShowInNavigation()
            //        .AddChildPage(pageId, "AMP page")
            //            .SetOrdinal(1)
            //            .LocalizeUsing<AMPResources>()
            //            .SetTitleLocalized("AMPPageTitle")
            //            .SetHtmlTitleLocalized("AMPPageTitle")
            //            .SetUrlNameLocalized("AMPPageUrlName")
            //            .SetDescriptionLocalized("AMPPageDescription")
            //            .AddControl(new System.Web.UI.WebControls.Literal()
            //            {
            //                Text = "<h1 class=\"sfBreadCrumb\">AMP module Installed</h1>",
            //                Mode = LiteralMode.PassThrough
            //            })
            //            .ShowInNavigation()
            //        .Done()
            //    .Done();

			//initializer.Installer 
			//	.CreateModuleGroupPage(AMPModule.AmpPagesGroupPageId, "AmpPages")
			//		.PlaceUnder(CommonNode.TypesOfContent)
			//		.LocalizeUsing<AMPResources>()
			//		.SetTitleLocalized("AmpPagesGroupPageTitle")
			//		.SetUrlNameLocalized("AmpPagesGroupPageUrlName")
			//		.SetDescriptionLocalized("AmpPagesGroupPageDescription")
			//		.ShowInNavigation()
			//		.AddChildPage(AMPModule.AmpPagesHomePageId, "AmpPagesMaster")
			//			.LocalizeUsing<AMPResources>()
			//			.SetTitleLocalized("AmpPagesGroupPageTitle")
			//			.SetHtmlTitleLocalized("AmpPagesGroupPageTitle")
			//			.SetUrlNameLocalized("AmpPagesMasterPageUrl")
			//			.SetDescriptionLocalized("AmpPagesGroupPageDescription")
			//			.AddControl(new AmpPagesesEmptyPage())
			//			.HideFromNavigation()
			//		.Done()
			//	.Done();

			
        }
        #endregion

        #region Widgets
        /// <summary>
        /// Installs the form widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallFormWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom form widgets in the toolbox.
            // See the example below.

            //string moduleFormWidgetSectionName = "AMP";
            //string moduleFormWidgetSectionTitle = "AMP";
            //string moduleFormWidgetSectionDescription = "AMP";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.FormWidgets)
            //        .LoadOrAddSection(moduleFormWidgetSectionName)
            //            .SetTitle(moduleFormWidgetSectionTitle)
            //            .SetDescription(moduleFormWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<AMPResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (this is optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the layout widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallLayoutWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom layout widgets in the toolbox.
            // See the example below.

            //string moduleLayoutWidgetSectionName = "AMP";
            //string moduleLayoutWidgetSectionTitle = "AMP";
            //string moduleLayoutWidgetSectionDescription = "AMP";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.Layouts)
            //        .LoadOrAddSection(moduleLayoutWidgetSectionName)
            //            .SetTitle(moduleLayoutWidgetSectionTitle)
            //            .SetDescription(moduleLayoutWidgetSectionDescription)
            //            .LoadOrAddWidget<LayoutControl>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<AMPResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //                .SetParameters(new NameValueCollection() 
            //                { 
            //                    { "layoutTemplate", FullPathToTheLayoutWidget },
            //                })
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the page widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallPageWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom page widgets in the toolbox.
            // See the example below.

            //string modulePageWidgetSectionName = "AMP";
            //string modulePageWidgetSectionTitle = "AMP";
            //string modulePageWidgetSectionDescription = "AMP";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.PageWidgets)
            //        .LoadOrAddSection(modulePageWidgetSectionName)
            //            .SetTitle(modulePageWidgetSectionTitle)
            //            .SetDescription(modulePageWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<AMPResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }

        #endregion

        #region Upgrade methods
        #endregion

		private void AddAmpPagesNode(SiteInitializer initializer)
		{
			initializer.Installer
				.CreateModuleGroupPage(AMPModule.AmpPagesGroupPageId, "AmpPages")
					.PlaceUnder(CommonNode.Administration)
					.LocalizeUsing<AMPResources>()
					.SetTitleLocalized("AmpPagesGroupPageTitle")
					.SetUrlNameLocalized("AmpPagesGroupPageUrlName")
					.SetDescriptionLocalized("AmpPagesGroupPageDescription")
					.ShowInNavigation()
					.AddChildPage(AMPModule.AmpPagesHomePageId, "Amp pages")
						.LocalizeUsing<AMPResources>()
						.SetTitleLocalized("AmpPagesGroupPageTitle")
						.SetHtmlTitleLocalized("AmpPagesGroupPageTitle")
						.SetUrlNameLocalized("AmpPagesMasterPageUrl")
						.SetDescriptionLocalized("AmpPagesGroupPageDescription")
						.AddControl(new AmpPagesView())
						.HideFromNavigation()
					.Done()
					.AddChildPage(AMPModule.AmpPageDetailPageId, "Amp page")
						   .LocalizeUsing<AMPResources>()
						   .SetTitleLocalized("AmpPageTitle")
						   .SetDescriptionLocalized("AmpPageDescription")
						   .SetUrlNameLocalized("AmpPageUrl")
						   .SetTemplate(SiteInitializer.BackendHtml5TemplateId)
						   .AddControl(new AmpPageView())
						   .HideFromNavigation()
						   .Done()
				.Done();
		}

        #region Private members & constants
        public const string ModuleName = "AMP";
        internal const string ModuleTitle = "AMP";
        internal const string ModuleDescription = "This is a Custom Module which has been built with Sitefinity Thunder.";
        internal const string ModuleVirtualPath = "~/AMP/";
        private static readonly Type[] managerTypes = new Type[] { typeof(AMPManager) };


		//TODO: Check if this is the correct id. If it's the same as in AmpPagesView, move it to common place
		internal Guid AmpPagesPagesId = Guid.Parse("3e74a66b-e8c9-4420-9ceb-36810311a480");
		internal Guid ModuleNodeId = Guid.Parse("da18dcb8-0480-4969-9dde-caa496b869ab");

        internal static readonly Guid AmpPagesGroupPageId = new Guid("3e74a66b-e8c9-4420-9ceb-36810311a480");
        internal static readonly Guid AmpPagesHomePageId = new Guid("e8816474-4b2b-45a9-8e1d-9beda4f7dcd1");
		internal static readonly Guid AmpPageDetailPageId = new Guid("ceeaa11e-1334-4444-9494-60d92aa02ef6");
        public const string AmpPagesWebServiceUrl = "Sitefinity/Services/AMP/AmpPagesesService.svc/";
        #endregion
    }
}
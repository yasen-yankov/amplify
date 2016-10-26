using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.Configuration;
using Telerik.Sitefinity.AMP.Data.OpenAccess;

namespace Telerik.Sitefinity.AMP.Configuration
{
    /// <summary>
    /// Represents the configuration section for AMP module.
    /// </summary>
    [ObjectInfo(Title = "AMP Config Title", Description = "AMP Config Description")]
    public class AMPConfig : ModuleConfigBase
    {
        #region Public and overriden methods
		protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(providers)
            {
                Name = "AMPOpenAccessDataProvider", 
                Title = "Default Products",
                Description = "A provider that stores products data in database using $DefaultProviderFriendlyName$.",
                ProviderType = typeof(AMPOpenAccessDataProvider),
                Parameters = new NameValueCollection() { { "applicationName", "/AMP" } }
            });
        }

		protected override void OnPropertiesInitialized()
		{
			base.OnPropertiesInitialized();

			this.EnabledBuiltInModues.Add(new ConfigValue<string>("Telerik.Sitefinity.Modules.Blogs.BlogsModule, Telerik.Sitefinity", this.EnabledBuiltInModues));
			this.EnabledBuiltInModues.Add(new ConfigValue<string>("Telerik.Sitefinity.Modules.News.NewsModule, Telerik.Sitefinity", this.EnabledBuiltInModues));
			this.EnabledBuiltInModues.Add(new ConfigValue<string>("Telerik.Sitefinity.Modules.Events.EventsModule, Telerik.Sitefinity", this.EnabledBuiltInModues));
			this.EnabledBuiltInModues.Add(new ConfigValue<string>("Telerik.Sitefinity.Modules.Lists.ListsModule, Telerik.Sitefinity", this.EnabledBuiltInModues));
		}

        /// <summary>
        /// Gets or sets the name of the default data provider. 
        /// </summary>
        [DescriptionResource(typeof(ConfigDescriptions), "DefaultProvider")]
        [ConfigurationProperty("defaultProvider", DefaultValue = "AMPOpenAccessDataProvider")]
        public override string DefaultProvider
        {
            get
            {
                return (string)this["defaultProvider"];
            }
            set
            {
                this["defaultProvider"] = value;
            }
        }
	    #endregion

		[ConfigurationProperty("enabledBuiltInModues")]
		public ConfigElementList<ConfigValue<string>> EnabledBuiltInModues
		{
			get
			{
				return (ConfigElementList<ConfigValue<string>>)this["enabledBuiltInModues"];
			}
			set
			{
				this["enabledBuiltInModues"] = value;
			}
		}
    }
}
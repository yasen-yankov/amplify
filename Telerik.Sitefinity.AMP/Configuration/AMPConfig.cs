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
using Telerik.Sitefinity.AMP.AmpComponents;
using Telerik.Sitefinity.Modules.Blogs;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Modules.Events;
using Telerik.Sitefinity.Modules.Lists;
using Telerik.Sitefinity.Blogs.Model;
using Telerik.Sitefinity.Events.Model;
using Telerik.Sitefinity.Lists.Model;
using Telerik.Sitefinity.News.Model;

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

			this.EnabledBuiltInModues.Add(new ConfigValue<string>(typeof(BlogPost).FullName, this.EnabledBuiltInModues));
			this.EnabledBuiltInModues.Add(new ConfigValue<string>(typeof(NewsItem).FullName, this.EnabledBuiltInModues));
			this.EnabledBuiltInModues.Add(new ConfigValue<string>(typeof(Event).FullName, this.EnabledBuiltInModues));
			this.EnabledBuiltInModues.Add(new ConfigValue<string>(typeof(List).FullName, this.EnabledBuiltInModues));

			this.AmpComponents.Add("Image", typeof(ImageAmpComponent).AssemblyQualifiedName);
			this.AmpComponents.Add("Gallery", typeof(GalleryAmpComponent).AssemblyQualifiedName);
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

		[ConfigurationProperty("ampComponents")]
		public ConfigValueDictionary AmpComponents
		{
			get
			{
				return (ConfigValueDictionary)this["ampComponents"];
			}
			set
			{
				this["ampComponents"] = value;
			}
		}

		[ConfigurationProperty("defaultLayoutTemplate", DefaultValue = "_AMPLayout")]
		public string DefaultLayoutTemplate
		{
			get
			{
				return (string)this["defaultLayoutTemplate"];
			}
			set
			{
				this["defaultLayoutTemplate"] = value;
			}
		}

		[ConfigurationProperty("defaultTemplate", DefaultValue="Index")]
		public string DefaultTemplate
		{
			get
			{
				return (string)this["defaultTemplate"];
			}
			set
			{
				this["defaultTemplate"] = value;
			}
		}
	}
}
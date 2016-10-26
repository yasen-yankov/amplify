using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.AMP.Configuration;
using Telerik.Sitefinity.AMP.Models;

namespace Telerik.Sitefinity.AMP
{
    public class AMPManager : ManagerBase<AMPDataProvider>
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="AMPManager" /> class.
        /// </summary>
        public AMPManager() : this(null)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AMPManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        public AMPManager(string providerName) : base(providerName)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AMPManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        public AMPManager(string providerName, string transactionName) : base(providerName, transactionName)
        {
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the default provider delegate.
        /// </summary>
        /// <value>The default provider delegate.</value>
        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get
            {
                return () => Config.Get<AMPConfig>().DefaultProvider;
            }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public override string ModuleName
        {
            get
            {
                return AMPModule.ModuleName;
            }
        }

        /// <summary>
        /// Gets the providers settings.
        /// </summary>
        /// <value>The providers settings.</value>
        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get
            {
                return Config.Get<AMPConfig>().Providers;
            }
        }

        /// <summary>
        /// Get an instance of the Telerik.Sitefinity.AMP manager using the default provider.
        /// </summary>
        /// <returns>Instance of the Telerik.Sitefinity.AMP manager</returns>
        public static AMPManager GetManager()
        {
            return ManagerBase<AMPDataProvider>.GetManager<AMPManager>();
        }

        /// <summary>
        /// Get an instance of the Telerik.Sitefinity.AMP manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <returns>Instance of the Telerik.Sitefinity.AMP manager</returns>
        public static AMPManager GetManager(string providerName)
        {
            return ManagerBase<AMPDataProvider>.GetManager<AMPManager>(providerName);
        }

        /// <summary>
        /// Get an instance of the Telerik.Sitefinity.AMP manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        /// <returns>Instance of the Telerik.Sitefinity.AMP manager</returns>
        public static AMPManager GetManager(string providerName, string transactionName)
        {
            return ManagerBase<AMPDataProvider>.GetManager<AMPManager>(providerName, transactionName);
        }

        /// <summary>
        /// Creates a AmpPages.
        /// </summary>
        /// <returns>The created AmpPages.</returns>
        public AmpPages CreateAmpPages()
        {
            return this.Provider.CreateAmpPages();
        }

        /// <summary>
        /// Updates the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public void UpdateAmpPages(AmpPages entity)
        {
            this.Provider.UpdateAmpPages(entity);
        }

        /// <summary>
        /// Deletes the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public void DeleteAmpPages(AmpPages entity)
        {
            this.Provider.DeleteAmpPages(entity);
        }

        /// <summary>
        /// Gets the AmpPages by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The AmpPages.</returns>
        public AmpPages GetAmpPages(Guid id)
        {
            return this.Provider.GetAmpPages(id);
        }

        /// <summary>
        /// Gets a query of all the AmpPages items.
        /// </summary>
        /// <returns>The AmpPages items.</returns>
        public IQueryable<AmpPages> GetAmpPageses()
        {
            return this.Provider.GetAmpPageses();
        }
        #endregion
    }
}
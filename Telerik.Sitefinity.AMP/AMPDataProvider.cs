using System;
using System.Linq;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.AMP.Models;

namespace Telerik.Sitefinity.AMP
{
    public abstract class AMPDataProvider : DataProviderBase
    {
        #region Public and overriden methods
        /// <summary>
        /// Gets the known types.
        /// </summary>
        public override Type[] GetKnownTypes()
        {
            if (knownTypes == null)
            {
                knownTypes = new Type[]
                {
                    typeof(AmpPage)
                };
            }
            return knownTypes;
        }
        
        /// <summary>
        /// Gets the root key.
        /// </summary>
        /// <value>The root key.</value>
        public override string RootKey
        {
            get
            {
                return "AMPDataProvider";
            }
        }

		public AmpPage GetAmpPage(string pageUrl)
		{
			return this.GetAmpPages().FirstOrDefault(x => x.UrlName == pageUrl);
		}
        #endregion
        
        #region Abstract methods
        /// <summary>
        /// Creates a new AmpPages and returns it.
        /// </summary>
        /// <returns>The new AmpPages.</returns>
        public abstract AmpPage CreateAmpPage();
        
        /// <summary>
        /// Gets a AmpPages by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The AmpPages.</returns>
        public abstract AmpPage GetAmpPage(Guid id);
        
        /// <summary>
        /// Gets a query of all the AmpPages items.
        /// </summary>
        /// <returns>The AmpPages items.</returns>
        public abstract IQueryable<AmpPage> GetAmpPages();
        
        /// <summary>
        /// Updates the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public abstract void UpdateAmpPage(AmpPage entity);
        
        /// <summary>
        /// Deletes the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public abstract void DeleteAmpPage(AmpPage entity);
        #endregion
        
        #region Private fields and constants
        private static Type[] knownTypes;
        #endregion
	}
}
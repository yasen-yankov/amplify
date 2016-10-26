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
                    typeof(AmpPages)
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
        #endregion
        
        #region Abstract methods
        /// <summary>
        /// Creates a new AmpPages and returns it.
        /// </summary>
        /// <returns>The new AmpPages.</returns>
        public abstract AmpPages CreateAmpPages();
        
        /// <summary>
        /// Gets a AmpPages by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The AmpPages.</returns>
        public abstract AmpPages GetAmpPages(Guid id);
        
        /// <summary>
        /// Gets a query of all the AmpPages items.
        /// </summary>
        /// <returns>The AmpPages items.</returns>
        public abstract IQueryable<AmpPages> GetAmpPageses();
        
        /// <summary>
        /// Updates the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public abstract void UpdateAmpPages(AmpPages entity);
        
        /// <summary>
        /// Deletes the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public abstract void DeleteAmpPages(AmpPages entity);
        #endregion
        
        #region Private fields and constants
        private static Type[] knownTypes;
        #endregion
    }
}
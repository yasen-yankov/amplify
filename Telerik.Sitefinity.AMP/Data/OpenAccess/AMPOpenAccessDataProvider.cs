using System;
using System.Linq;
using System.Reflection;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.AMP.Models;

namespace Telerik.Sitefinity.AMP.Data.OpenAccess
{
    public class AMPOpenAccessDataProvider : AMPDataProvider, IOpenAccessDataProvider
    {
        #region Properties
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public OpenAccessProviderContext Context { get; set; }
        #endregion
        
        #region Public and overriden methods
        /// <summary>
        /// Gets the meta data source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The meta data source</returns>
        public MetadataSource GetMetaDataSource(IDatabaseMappingContext context)
        {
            return new AMPStorageMetadataSource(context);
        }
        
        /// <summary>
        /// Gets a query of all the AmpPages items.
        /// </summary>
        /// <returns>The AmpPages items.</returns>
        public override IQueryable<AmpPage> GetAmpPages()
        {
            return SitefinityQuery
                .Get<AmpPage>(this, MethodBase.GetCurrentMethod())
                .Where(b => b.ApplicationName == this.ApplicationName);
        }
        
        /// <summary>
        /// Gets a AmpPages by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The AmpPages.</returns>
        public override AmpPage GetAmpPage(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be Empty Guid");

            return this.GetContext().GetItemById<AmpPage>(id.ToString());
        }
        
        /// <summary>
        /// Creates a new AmpPages and returns it.
        /// </summary>
        /// <returns>The new AmpPages.</returns>
        public override AmpPage CreateAmpPage()
        {
            Guid id = Guid.NewGuid();

            var item = new AmpPage(id, this.ApplicationName);
                
            if (id != Guid.Empty)
                this.GetContext().Add(item);
        
            return item;
        }
        
        /// <summary>
        /// Updates the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public override void UpdateAmpPage(AmpPage entity)
        {
            entity.LastModified = DateTime.UtcNow;
        }
        
        /// <summary>
        /// Deletes the AmpPages.
        /// </summary>
        /// <param name="entity">The AmpPages entity.</param>
        public override void DeleteAmpPage(AmpPage entity)
        {
            this.GetContext().Remove(entity);
        }
        #endregion
    }
}
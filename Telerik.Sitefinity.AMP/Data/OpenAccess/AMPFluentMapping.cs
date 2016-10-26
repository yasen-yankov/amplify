using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.Sitefinity.AMP.Models;
using Telerik.Sitefinity.Model;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace Telerik.Sitefinity.AMP.Data.OpenAccess
{
    public class AMPFluentMapping : OpenAccessFluentMappingBase
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="AMPFluentMapping" /> class.
        /// </summary>
        internal AMPFluentMapping() : this(null)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AMPFluentMapping" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AMPFluentMapping(IDatabaseMappingContext context) : base(context)
        {
        }
        #endregion
        
        #region Public and overriden methods
        /// <summary>
        /// Gets the list of mapping configurations.
        /// </summary>
        /// <inheritdoc />
        /// <returns></returns>
        public override IList<MappingConfiguration> GetMapping()
        {
            var mappings = new List<MappingConfiguration>();
            
            this.MapAmpPageses(mappings);
        
            return mappings;
        }
        #endregion
        
        #region Private methods
        /// <summary>
        /// Maps the AmpPages items.
        /// </summary>
        /// <param name="mappings">The mappings.</param>
        private void MapAmpPageses(List<MappingConfiguration> mappings)
        {
            var mapping = new MappingConfiguration<AmpPage>();
            
			mapping.MapType(p => new { }).SetTableName("AMP_AmpPages", this.Context);
				
			mapping.HasProperty(p => p.Id).IsIdentity().IsNotNullable();
			mapping.HasProperty(p => p.Title).IsNotNullable().IsText(this.Context, 255);
			mapping.HasProperty(p => p.ItemType).IsText(this.Context, 255);
            mapping.HasProperty(p => p.UrlName).IsText(this.Context, 255);
            mapping.HasProperty(p => p.PageId);
            mapping.HasProperty(p => p.FieldsListJson).IsNullable().WithInfiniteLength();
            mapping.HasProperty(p => p.ApplicationName);
            mapping.HasProperty(p => p.LastModified);
            mapping.HasProperty(p => p.DateCreated);

            mapping.HasIndex(p => p.Title).IsUnique().WithName("idx_title");
            mapping.HasIndex(p => p.UrlName).IsUnique().WithName("idx_urlName");
            mapping.HasIndex(p => p.PageId).IsUnique().WithName("idx_pageId");
				
            mappings.Add(mapping);
        }
        #endregion
    }
}
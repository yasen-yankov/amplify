using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.AMP.Models;

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
            var mapping = new MappingConfiguration<AmpPages>();
            
			mapping.MapType(p => new { }).SetTableName("AMP_AmpPageses", this.Context);			
				
			mapping.HasProperty(p => p.Id).IsIdentity().IsNotNullable();
			mapping.HasProperty(p => p.Title).IsNotNullable().IsText(this.Context, 255);
			mapping.HasProperty(p => p.ModuleType).IsText(this.Context, 255);
           mapping.HasProperty(p => p.ApplicationName);
            mapping.HasProperty(p => p.LastModified);
            mapping.HasProperty(p => p.DateCreated);   	
				
            mappings.Add(mapping);
        }
        #endregion
    }
}
using System;
using System.Linq;

namespace Telerik.Sitefinity.AMP.Web.Services.Dto
{
    internal class AmpPageFieldDto
    {
        public string FieldName { get; set; }

        public AmpComponentDto AmpComponent { get; set; }

        public WrapperTagDto WrapperTag { get; set; }

        public int Ordinal { get; set; }
    }
}
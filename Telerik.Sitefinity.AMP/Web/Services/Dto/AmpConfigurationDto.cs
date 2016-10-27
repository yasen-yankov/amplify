using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telerik.Sitefinity.AMP.Web.Services.Dto
{
	public class AmpConfigurationDto
	{
		public IDictionary<string, string> AmpComponentTypes { get; set; }

		public IEnumerable<string> EnabledBuiltInModules { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.AMP.Web.Services.Dto;
using Telerik.Sitefinity.Model;

namespace Telerik.Sitefinity.AMP.Mvc.Models
{
	public class AmpPageViewModel
	{
		public IDataItem DataItem { get; set; }

		public IEnumerable<AmpPageFieldDto> Fields { get; set; }
	}
}
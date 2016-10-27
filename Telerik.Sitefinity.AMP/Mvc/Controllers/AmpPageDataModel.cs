using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.AMP.Web.Services.Dto;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.Controllers
{
	public class AmpPageDataModel
	{
		public string Title { get; set; }

		public Type ItemType { get; set; }

		public List<AmpFieldModel> Fields { get; set; }
	}

	public class AmpFieldModel
	{
		public string FieldName { get; set; }

		public AmpComponentModel AmpComponent { get; set; }

		public WrapperTagModel WrapperTag { get; set; }

		public int Ordinal { get; set; }
	}

	public class WrapperTagModel
	{
		public string TagName { get; set; }

		public string CssClass { get; set; }
	}

	public class AmpComponentModel
	{
		public Type ComponentType { get; set; }

		public string CssClass { get; set; }
	}

	public class AmpPageViewModel
	{
		public IDataItem DataItem { get; set; }

		public IEnumerable<AmpPageFieldDto> Fields { get; set; }
	}
}
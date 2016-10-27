using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Model;

namespace Telerik.Sitefinity.AMP.AmpComponents
{
	public class ImageAmpComponent : IAmpComponent
	{
		private string ampImgTemplate = "<amp-img src=\"{0}\" alt=\"{1}\" height=\"{2}\" width=\"{3}\" layout=\"responsive\"></amp-img>";

		public string Generate(object fieldValue)
		{
			var images = ((IEnumerable<IDataItem>)fieldValue).Cast<Image>().ToList();

			if (images != null && images.Any())
			{
				var image = images.First();
				return string.Format(ampImgTemplate, image.MediaUrl, image.AlternativeText, image.Height, image.Width);
			}

			return null;
		}
	}
}
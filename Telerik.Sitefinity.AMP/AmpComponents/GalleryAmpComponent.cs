using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Model;

namespace Telerik.Sitefinity.AMP.AmpComponents
{
	public class GalleryAmpComponent : IAmpComponent
	{
		private string ampImgGalleryTemplate = "<div class=\"slide\"><amp-img src=\"{0}\" alt=\"{1}\" height=\"{2}\" width=\"{3}\" layout=\"fill\"></amp-img></div>";

		private string ampGalleryTemplate = "<amp-carousel layout=\"responsive\" width=\"{0}\" height=\"{1}\" type=\"slides\">{2}</amp-carousel>";

		public string Generate(object fieldValue)
		{
			var images = ((IEnumerable<IDataItem>)fieldValue).Cast<Image>().ToList();

			if (images != null && images.Any())
			{
				var imagesTemplate = new StringBuilder();

				foreach (var image in images)
				{
					imagesTemplate.AppendFormat(ampImgGalleryTemplate, image.MediaUrl, image.AlternativeText, image.Width, image.Height);
				}

				var imageWithHighestWidth = images.OrderByDescending(x => x.Width).First();
				var imageWithHighestHeight = images.OrderByDescending(x => x.Height).First();

				return string.Format(ampGalleryTemplate, imageWithHighestWidth.Width, imageWithHighestHeight.Height, imagesTemplate);
			}

			return null;

		}
	}
}
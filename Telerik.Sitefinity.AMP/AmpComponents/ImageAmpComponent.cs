using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Modules.Libraries;

namespace Telerik.Sitefinity.AMP.AmpComponents
{
	public class ImageAmpComponent : IAmpComponent
	{
		private string ampImgTemplate = "<amp-img src=\"{0}\" alt=\"{1}\" height=\"{2}\" width=\"{3}\" layout=\"responsive\"></amp-img>";

		public string Generate(object fieldValue)
		{
			var imagesIds = fieldValue as IEnumerable<Guid>;

			if (imagesIds != null && imagesIds.Any())
			{
				//TODO: Handle multiple images (gallery)

				var imageId = imagesIds.First();

				var manager = LibrariesManager.GetManager();
				var image = manager.GetImage(imageId);

				return string.Format(ampImgTemplate, image.AlternativeText, image.Height, image.Width);
			}

			return null;
		}
	}
}
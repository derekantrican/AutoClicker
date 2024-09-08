using System;
using System.Drawing;
using System.Threading;
using AutoClicker.Helpers;

namespace AutoClicker.Objects
{
	public class ImageValidation : IBaseEvent
	{
		public Point CheckAreaLocation { get; set; }
		public Size CheckAreaSize { get; set; }
		public Bitmap Image { get; set; }

		public bool PerformAction(CancellationToken cancellationToken /*Not Implemented here*/)
		{
			using (Bitmap bitmap = new Bitmap(CheckAreaSize.Width, CheckAreaSize.Height))
			{
				using (Graphics g = Graphics.FromImage(bitmap))
				{
					g.CopyFromScreen(CheckAreaLocation, Point.Empty, bitmap.Size);
				}

				return bitmap.GetPixelMap().Contains(Image.GetPixelMap() /*this could be cached, but it's not a big deal*/, (color1, color2) =>
				{
					//Todo: this currently doesn't support images with transparent pixels. We could easily make it so "if color2 is transparent => return true"
					//but that won't work for trying to match the top-left corner (we would have to check every pixel in the CheckArea). So currently we
					//will disallow images with transparency in the AddEditEventDialog

					int tolerance = 3;
					return Math.Abs(color1.R - color2.R) <= tolerance &&
					Math.Abs(color1.G - color2.G) <= tolerance &&
					Math.Abs(color1.B - color2.B) <= tolerance;
				});
			}
		}

		public override string ToString()
		{
			return $"[ImageValidation] Validate against a reference image at {CheckAreaLocation}";
		}
	}
}

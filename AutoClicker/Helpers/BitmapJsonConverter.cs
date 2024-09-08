using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Newtonsoft.Json;

namespace AutoClicker.Helpers
{
	public class BitmapJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Bitmap);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			byte[] imageAsBytes = Convert.FromBase64String(reader.Value as string);
			using (MemoryStream ms = new MemoryStream(imageAsBytes, 0, imageAsBytes.Length))
			{
				ms.Write(imageAsBytes, 0, imageAsBytes.Length);
				return new Bitmap(Image.FromStream(ms, true));
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				(value as Bitmap).Save(ms, ImageFormat.Jpeg);
				writer.WriteValue(Convert.ToBase64String(ms.ToArray()));
			}
		}
	}
}

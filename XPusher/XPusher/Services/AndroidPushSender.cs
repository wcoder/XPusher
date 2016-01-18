using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using XPusher.Infrastructure;

namespace XPusher.Services
{
	public class AndroidPushSender : IPushSender
	{
		private const string GcmUrl = "https://gcm-http.googleapis.com/gcm/send";

		public string Name => nameof(AndroidPushSender);

		public async Task<string> SendMessageAsync(string apiKey, string message)
		{
			var jData = new JObject {{"message", message}};
			var jGcmData = new JObject {{"to", "/topics/global"}, {"data", jData}};
			var content = new StringContent(jGcmData.ToString(), Encoding.UTF8, "application/json");

			try
			{
				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={apiKey}");

					var response = await client.PostAsync(new Uri(GcmUrl), content);
					return await response.Content.ReadAsStringAsync();
				}
			}
			catch (Exception e)
			{
				return $"Error: {e.Message}";
			}
		}
	}
}
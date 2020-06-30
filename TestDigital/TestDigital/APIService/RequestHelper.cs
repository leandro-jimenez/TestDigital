using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestDigital.APIService
{
	class RequestHelper
	{
		private const string URL = "https://www.datos.gov.co/resource/xdk5-pm3f.json";
		private HttpRequestMessage httpRequestMessage;
		private HttpClient client;

		public RequestHelper()
		{
			this.httpRequestMessage = new HttpRequestMessage();
			this.httpRequestMessage.Method = HttpMethod.Get;
			this.httpRequestMessage.Headers.Add("Accept", "application/json");
		}

		public async Task<List<GeoInfo>> GetGeoInfosAsync() {
			this.client = new HttpClient();
			this.httpRequestMessage.RequestUri = new Uri(URL);
			HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
			HttpContent content = response.Content;
			var geoList = new List<GeoInfo>();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var json = await content.ReadAsStringAsync();
				geoList = JsonConvert.DeserializeObject<List<GeoInfo>>(json);
			}

			return geoList;
		}
	}
}

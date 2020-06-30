using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestDigital.APIService
{
	public class ApiGeoResponse
	{
		public List<GeoInfo> geoList { get; set; }
	}

	public class GeoInfo
	{ 
		[JsonProperty ("region")]
		public string region { get; set; }
		[JsonProperty ("c_digo_dane_del_departamento")]
		public string depto_codigo { get; set; }
		[JsonProperty ("departamento")]
		public string  depto_name{ get; set; }
		[JsonProperty ("c_digo_dane_del_municipio")]
		public string  municipio_code{ get; set; }
		[JsonProperty ("municipio")]
		public string  municipio_name{ get; set; }

		public GeoInfo(string deptoName, string deptoCode) {
			this.depto_name = deptoName;
			this.depto_codigo = deptoCode;
		}
		public GeoInfo() { }
	}
}

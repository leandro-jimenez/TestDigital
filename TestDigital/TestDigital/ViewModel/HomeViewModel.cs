using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using TestDigital.APIService;
using TestDigital.Model;
using Xamarin.Forms;

namespace TestDigital.ViewModel
{
    class HomeViewModel: BaseViewModel
	{
        private List<GeoInfo> apiResponse;
        
        private readonly HttpClient client = new HttpClient();

		private List<GeoInfo> deptoList;

		public List<GeoInfo> DeptoList
		{
			get { return deptoList; }
			set { deptoList = value;
                OnPropertyChanged("DeptoList");
            }
		}

		public bool IsLoading { get; set; }
		private List<GeoInfo> mupiosList;

		public List<GeoInfo> MupiosList
		{
			get { return mupiosList; }
			set { mupiosList = value;
                OnPropertyChanged("MupiosList");
            }
		}

		private GeoInfo deptoSelected;

		public GeoInfo DeptoSelected
		{
			get { return deptoSelected; }
			set { deptoSelected = value;
                OnPropertyChanged("DeptoSelected");
            }
		}

		private GeoInfo mupioSelected;

		public GeoInfo MupioSelected
		{
			get { return mupioSelected; }
			set { mupioSelected = value;
                OnPropertyChanged("MupioSelected");
            }
		}



		public HomeViewModel() {
            //this.DeptoList = new List<GeoInfo>();
            LoadPetition();
        }

        private async void LoadPetition() {
            var request_aux = new RequestHelper();
            apiResponse = await request_aux.GetGeoInfosAsync();
            LoadDeptos();
        }

        private void LoadDeptos() {
            var deptos =
                from geoInfo in this.apiResponse
                group geoInfo by new
                {
                    deptoName = geoInfo.depto_name,
                    deptoCode = geoInfo.depto_codigo
                } into geoInfoGroup
                orderby geoInfoGroup.Key.deptoName
                select geoInfoGroup;
            var auxDepto = new List<GeoInfo>();
            foreach (var depto in deptos)
            {
                var geoInfo = new GeoInfo(depto.Key.deptoName, depto.Key.deptoCode);
                auxDepto.Add(geoInfo);
            }
            this.DeptoList = auxDepto;
        }

        /// <summary>
        /// /Load different city according to the picker selection
        /// </summary>
        /// <param name="mupioName"></param>
        public void LoadMupios(string mupioName) {
            IEnumerable<GeoInfo> mupios =
                from geoInfo in apiResponse
                where  geoInfo.depto_name.Equals(mupioName)
                select geoInfo;

            var aux_mupios = new List<GeoInfo>();
			foreach (var mupio in mupios)
            {
                aux_mupios.Add(mupio);
            }
            MupiosList = aux_mupios;
        }
    }
}

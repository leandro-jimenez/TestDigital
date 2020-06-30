using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestDigital.APIService;
using TestDigital.Model;
using TestDigital.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDigital.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		private ResourceManager RM;
		private UserInfo User;
		public Home ()
		{
			InitializeComponent ();
			this.BindingContext = new HomeViewModel();
			RM = new ResourceManager("TestDigital.StringResources", Assembly.GetExecutingAssembly());
			
			this.confirmInfo.Text = RM.GetString("HomeConfirmLbl");
			this.userInfo.Text = string.Format(RM.GetString("HomeUsrWelcomeLbl"), "Pepito");
			this.addressInfo.Text = RM.GetString("HomeAddressLbl");
			this.AddressEntry.Placeholder = RM.GetString("HomeAddressHint");
			this.departmentInfo.Title = RM.GetString("HomeSelectDepto");
			this.cityInfo.Title = RM.GetString("HomeSelectCity");
		}
		public Home(UserInfo userInfo)
		{
			InitializeComponent();
			this.BindingContext = new HomeViewModel();
			this.User = userInfo;
			
			RM = new ResourceManager("TestDigital.StringResources", Assembly.GetExecutingAssembly());
			
			this.confirmInfo.Text = RM.GetString("HomeConfirmLbl");
			this.userInfo.Text = string.Format(RM.GetString("HomeUsrWelcomeLbl"), userInfo.UserName);
			this.addressInfo.Text = RM.GetString("HomeAddressLbl");
			this.AddressEntry.Placeholder = RM.GetString("HomeAddressHint");
			this.DetailBtn.Text = RM.GetString("HomeConfirmBtn");
			this.departmentInfo.Title = RM.GetString("HomeSelectDepto");
			this.cityInfo.Title = RM.GetString("HomeSelectCity");
			this.InfoView.Title = RM.GetString("HomeTitle");
		}

		public void ChangeDepto(object sender, EventArgs args) {
			GeoInfo geoInfo = (GeoInfo)this.departmentInfo.SelectedItem;
			var Vm = (HomeViewModel)this.BindingContext;
			this.cityInfo.Title = RM.GetString("HomeSelectCity");
			Vm.MupioSelected = new GeoInfo();
			Vm.LoadMupios(geoInfo.depto_name);
		}

		async void OnConfirmButtonClicked(object sender, EventArgs e)
		{
			var Vm = (HomeViewModel)this.BindingContext;
			User.Department = Vm.DeptoSelected.depto_name;
			User.City = Vm.MupioSelected.municipio_name;
			User.Address = this.AddressEntry.Text;
			await Navigation.PushAsync(new Detail(User));
		}
	}
}
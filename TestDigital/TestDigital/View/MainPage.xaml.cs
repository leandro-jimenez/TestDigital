using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestDigital.View;
using TestDigital.ViewModel;
using Xamarin.Forms;
using TestDigital.Model;

namespace TestDigital
{
	public partial class MainPage : ContentPage
	{
		private ResourceManager RM;
		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = new MainPageViewModel();
			RM = new ResourceManager("TestDigital.StringResources", Assembly.GetExecutingAssembly());
			this.UserEntry.Placeholder = RM.GetString("LoginUserEntryHint");
			this.UserPwd.Placeholder = RM.GetString("LoginPasswordEntryHint");
			this.LoginBtn.Text = RM.GetString("LoginBtn");
		}

		async void OnNextPageButtonClicked(object sender, EventArgs e)
		{
			var VModel = (MainPageViewModel)this.BindingContext;
			if (string.IsNullOrEmpty(this.UserEntry.Text) || string.IsNullOrEmpty(this.UserPwd.Text))
			{
				VModel.showAlert(RM.GetString("LoginEmptyInfo"));
			}
			else if (VModel.ValidateUserInfo(UserEntry.Text, UserPwd.Text))
			{
				await Navigation.PushAsync(new Home(new UserInfo(UserEntry.Text, UserPwd.Text)));
			}
			else {
				VModel.showAlert(RM.GetString("LoginWrongInfoAlert"));
			}
		}
	}
}

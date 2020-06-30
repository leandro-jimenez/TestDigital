using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestDigital.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDigital.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
		public Detail ()
		{
			InitializeComponent ();
		}

		public Detail(UserInfo usr)
		{
			InitializeComponent();
			var RM = new ResourceManager("TestDigital.StringResources", Assembly.GetExecutingAssembly());
			this.DetailView.Title = RM.GetString("DetailTitle");
			this.WelcomeTitle.Text = RM.GetString("DetailHeading");
			this.UserName.Text = string.Format(RM.GetString("DetailUserName"), usr.UserName);
			this.UserDepto.Text = string.Format(RM.GetString("DetailUserDepto"), usr.Department);
			this.UserMupio.Text = string.Format(RM.GetString("DetailUserCity"), usr.City);
			this.UserAddress.Text = string.Format(RM.GetString("DetailUserAddress"), usr.Address);

		}
	}
}
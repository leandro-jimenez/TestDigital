using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Text;

namespace TestDigital.Model
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public ResourceManager resourceManager;
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public async void showAlert(string txt) {
			resourceManager = new ResourceManager("TestDigital.StringResources", Assembly.GetExecutingAssembly());
			await App.Current.MainPage.DisplayAlert(resourceManager.GetString("UtilsAlert"), txt, "OK");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using TestDigital.Model;

namespace TestDigital.ViewModel
{
    class MainPageViewModel: BaseViewModel
    {

		private string _username;
		private string _password;
		private UserInfo _user;

		public string Username {
			get { return _username; }
			set {
				_username = value;
				OnPropertyChanged("Username");
			}
		}

		public string Password
		{
			get { return _password; }
			set
			{
				_password = value;
				OnPropertyChanged("Password");
			}
		}
		public MainPageViewModel() {
			this._user = new UserInfo("Pepito", "123456");
		}

		public bool ValidateUserInfo(string usrname, string usrpwd) {
			return this._user.Validate_user(usrname, usrpwd) ;
		}
    }
}

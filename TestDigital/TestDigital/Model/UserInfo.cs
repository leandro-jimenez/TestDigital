using System;
using System.Collections.Generic;
using System.Text;

namespace TestDigital.Model
{
    public class UserInfo
    {
		public string UserName { get; set; }
		private string Password { get; set; }
		public string Department { get; set; }
		public string City { get; set; }
		public string Address { get; set; }

		public UserInfo(string usrname, string pwd)
		{
			this.UserName = usrname;
			this.Password = pwd;
		}

		public UserInfo()
		{
		}

		public bool Validate_user(string usrname, string pwd)
		{
			return this.UserName.Equals(usrname) && this.Password.Equals(pwd);
		}
	}
}

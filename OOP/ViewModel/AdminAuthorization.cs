using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class AdminAuthorization : INotifyPropertyChanged
	{
		private string username;
		private string password;

		public AdminAuthorization()
		{
			username = "";
			password = "";
		}

		public string UserName
		{
			get => username;
			set
			{
				username = value;
				OnPropertyChanged();
			}
		}
		public string Password
		{
			get => password;
			set
			{
				password = value;
				OnPropertyChanged();
			}
		}

		public bool CheckLogPass()
		{
			if (Password == "admin" && UserName == "admin")
			{
				return true;
			}
			return false;
		}

		public bool IsEmpty()
		{
			if (Password == "" || UserName == "")
			{
				return true;
			}
			return false;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class AdminAuthorization : Person, INotifyPropertyChanged
	{
	

		public AdminAuthorization()
		{
			UserName = "";
			Password = "";
		}

		public bool CheckLogPass()
		{
			if (Password == "a" && UserName == "a")
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
	}
}

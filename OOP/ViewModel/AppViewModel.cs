using OOP.Model;
using OOP.View;
using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class AppViewModel : INotifyPropertyChanged
	{

		public AdminAuthorization adminLogin = new AdminAuthorization();
		private CarAction carAct = new CarAction();
		private ClientAction clientAct = new ClientAction();
		private BillAction billAct = new BillAction();

		public BillAction BillAct
		{
			get => billAct;
			set
			{
				billAct = value;
				OnPropertyChanged();
			}
		}
		public CarAction CarAct
		{
			get => carAct;
			set
			{
				carAct = value;
				OnPropertyChanged();
			}
		}
		public ClientAction ClientAct
		{
			get => clientAct;
			set
			{
				clientAct = value;
				OnPropertyChanged();
			}
		}

		

		private RelayCommand adminLoginCommand;

		#region RelayCommand
		public RelayCommand AdminLoginCommand
		{
			get => adminLoginCommand ?? (adminLoginCommand = new
				RelayCommand(obj =>
				{

				}));
		}
		#endregion

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

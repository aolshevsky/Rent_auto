using Newtonsoft.Json;
using OOP.Model;
using OOP.View;
using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
		private Client currenUser = new Client();
		public bool IsAdmin { get; set; }
		private string user;
		private string pass;
		private IDialogService dialogService;



		public string User
		{
			get => user;
			set
			{
				user = value;
				OnPropertyChanged();
			}
		}
		public string Pass
		{
			get => pass;
			set
			{
				pass = value;
				OnPropertyChanged();
			}
		}

		public AppViewModel()
		{
			IsAdmin = false;
			carAct.AppVM = this;
			this.dialogService = new DefaultDialogService();
		}
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
		public Client CurrenUser
		{
			get => currenUser;
			set
			{
				currenUser = value;
				OnPropertyChanged();
			}
		}

		public bool Validate()
		{
			adminLogin.UserName = User;
			adminLogin.Password = Pass;
			if (adminLogin.CheckLogPass())
			{
				IsAdmin = true;
				return true;
			}
			foreach(Client cl in ClientAct.Сlients)
			{
				if(cl.UserName == User && cl.Password == Pass)
				{
					currenUser = cl;
					IsAdmin = false;
					return true;
				}
			}
			return false;
		}
		

		private RelayCommand saveCommand;

		#region RelayCommand
		public RelayCommand SaveCommand
		{
			get => saveCommand ?? (saveCommand = new
				RelayCommand(obj =>
				{
					if (dialogService.SaveFileDialog() == true)
					{
						if (dialogService.Filter() == 1)
						{
							string json = "";

							json = JsonConvert.SerializeObject(currenUser);

							if (!File.Exists(dialogService.FilePath))
							{
								File.WriteAllText(dialogService.FilePath, json);
							}
							else
							{
								File.WriteAllText(dialogService.FilePath, json);
							}

						}
					}

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

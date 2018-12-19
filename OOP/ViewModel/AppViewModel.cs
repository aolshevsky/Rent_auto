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
		private string CarsFilePath;
		private string ClientsFilePath;
		private string BillsFilePath;

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
			CarsFilePath = "D:\\Облако-_-\\OneDrive\\Лабораторные\\OOP_git\\road_to_the_dream\\OOP\\Assets\\Cars.json";
			ClientsFilePath = "D:\\Облако-_-\\OneDrive\\Лабораторные\\OOP_git\\road_to_the_dream\\OOP\\Assets\\Clients.json";
			BillsFilePath = "D:\\Облако-_-\\OneDrive\\Лабораторные\\OOP_git\\road_to_the_dream\\OOP\\Assets\\Bills.json";
			IsAdmin = false;
			carAct.AppVM = this;
			this.dialogService = new DefaultDialogService();
			OpenFiles();
			carAct.Default();
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
			foreach (Client cl in ClientAct.Сlients)
			{
				if (cl.UserName == User && cl.Password == Pass)
				{
					currenUser = cl;
					IsAdmin = false;
					return true;
				}
			}
			return false;
		}

		#region RelayCommand

		public void PrepCar()
		{
			if (dialogService.OpenFileDialog() && dialogService.Filter() == 1)
			{
				ClientsFilePath = dialogService.FilePath;
			}
			OpenFiles();
		}
		public void SaveFile()
		{
			string json = "";

			json = JsonConvert.SerializeObject(carAct);

			if (!File.Exists(CarsFilePath))
			{
				File.WriteAllText(CarsFilePath, json);
			}
			else
			{
				File.WriteAllText(CarsFilePath, json);
			}

			json = JsonConvert.SerializeObject(clientAct);
			File.Delete(ClientsFilePath);
			File.WriteAllText(ClientsFilePath, json);


			json = JsonConvert.SerializeObject(billAct);
			if (!File.Exists(BillsFilePath))
			{
				File.WriteAllText(BillsFilePath, json);
			}
			else
			{
				File.WriteAllText(BillsFilePath, json);
			}

		}
		public void OpenFiles()
		{
			string json = File.ReadAllText(CarsFilePath);
			var crA = JsonConvert.DeserializeObject<CarAction>(json);
			carAct = crA;
			if (carAct == null)
				carAct = new CarAction();
			carAct.RefreshPages();

			json = File.ReadAllText(ClientsFilePath);
			var clA = JsonConvert.DeserializeObject<ClientAction>(json);
			clientAct = clA;
			if (clientAct == null)
				clientAct = new ClientAction();

			json = File.ReadAllText(BillsFilePath);
			var bl = JsonConvert.DeserializeObject<BillAction>(json);
			billAct = bl;
			if (billAct == null)
				billAct = new BillAction();
		}

		#endregion

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		~AppViewModel()
		{
			SaveFile();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class ClientAction : INotifyPropertyChanged
	{

		public static ObservableCollection<Client> clients = new ObservableCollection<Client>();
		private Client newClient = new Client();

		public ObservableCollection<Client> Сlients
		{
			get => clients;
			set
			{
				clients = value;
				OnPropertyChanged();
			}
		}
		public Client NewClient
		{
			get => newClient;
			set
			{
				newClient = value;
				OnPropertyChanged();
			}
		}

		public void AddClient()
		{
			clients.Add(NewClient);

		}

		public void DeleteCar()
		{

		}

		public void EditCar()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

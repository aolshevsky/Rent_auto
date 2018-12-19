using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	[DataContract(IsReference = true)]
	public class ClientAction : INotifyPropertyChanged
	{

		public static ObservableCollection<Client> clients = new ObservableCollection<Client>();
		private Client newClient = new Client();
		[DataMember]
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
			NewClient.SetId();
			clients.Add(NewClient);
		}
		public bool CheckUserLog()
		{
			foreach (Client cl in Сlients)
			{
				if (cl.UserName == NewClient.UserName)
				{
					return true;
				}
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

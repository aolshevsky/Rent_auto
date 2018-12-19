using OOP.ViewModel.Enumerations;
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
	public class Reservation : INotifyPropertyChanged
	{
		
		private string extras = "";
		private Dictionary<string, bool> dict = new Dictionary<string, bool>();
		private DateTime pickupDate;
		private DateTime returnDate;
		private Client client;
		private Car car;
		private Location pickupLoc;
		private Location returnLoc;

		public bool Paid { get; set; }
		public bool Billed { get; set; }
		public bool Returned { get; set; }
		private ObservableCollection<Car> cars = new ObservableCollection<Car>();

		public ObservableCollection<Car> Cars
		{
			get => cars;
			set
			{
				cars = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public Car Car
		{
			get => car;
			set
			{
				car = value;
				cars = null;
				cars = new ObservableCollection<Car>();
				Cars.Add(car);
				OnPropertyChanged("Cars");
				OnPropertyChanged();
			}
		}
		[DataMember]
		public Location PickupLoc
		{
			get => pickupLoc;
			set
			{
				pickupLoc = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public Location ReturnLoc
		{
			get => returnLoc;
			set
			{
				returnLoc = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public Client Client
		{
			get => client;
			set
			{
				client = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public string Extras
		{
			get => extras;
			set
			{
				extras = value;
				OnPropertyChanged();
			}
		}
		public Dictionary<string, bool> ExtrasDict
		{
			get => dict;
			set
			{
				dict = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public DateTime PickupDate
		{
			get => pickupDate;
			set
			{
				pickupDate = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public DateTime ReturnDate
		{
			get => returnDate;
			set
			{
				returnDate = value;
				OnPropertyChanged();
			}
		}


		public Reservation()
		{
			this.Returned = false;
			PickupDate = DateTime.Now;
			ReturnDate = DateTime.Now;
		}

		public bool ReturnCar()
		{
			try
			{
				this.Returned = true;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool CheckDate()
		{
			if (this.PickupDate <= this.ReturnDate && this.PickupDate >= DateTime.Now.Date && this.ReturnDate >= DateTime.Now.Date)
			{
				return true;
			}
			return false;
		}

		public void TransformExtras()
		{
			string extra = "";
			foreach (var tg in dict)
			{
				if (tg.Value)
				{
					extra += tg.Key + ", ";
				}
			}
			if (extra.Length != 0)
			{
				Extras = extra.Substring(0, extra.Length - 2);
			}
		}
		public double? Total(double? price, int days)
		{
			int extras = Extras.Split(' ').Length;
			double? total = 0;
			total = extras * 10 + price * days;
			return total;
		}
		public bool IsEmptyFields()
		{
			if (Car == null || Client == null)
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

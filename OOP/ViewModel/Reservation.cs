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
	public class Reservation : INotifyPropertyChanged
	{
		public bool IsEmptyFields()
		{
			if (Car == null || Client == null)
			{
				return true;
			}
			return false;
		}
		public static int ID = 0;
		private string extras = "";
		private Dictionary<string, bool> dict = new Dictionary<string, bool>();
		private DateTime pickupDate;
		private DateTime returnDate;
		private Client client;
		private Car car;


		public int ReservationId { get; set; }

		public bool Paid { get; set; }
		public bool Billed { get; set; }
		public bool Returned { get; set; }

		
		public Location PickupLoc { get; set; }
		public Location ReturnLoc { get; set; }

		public Car Car
		{
			get => car;
			set
			{
				car = value;
				OnPropertyChanged();
			}
		}
		public Client Client
		{
			get => client;
			set
			{
				client = value;
				OnPropertyChanged();
			}
		}

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
		public DateTime PickupDate
		{
			get => pickupDate;
			set
			{
				pickupDate = value;
				OnPropertyChanged();
			}
		}
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
			SetIDs();
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
		
		public void SetIDs() => ReservationId = ID++;

		

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

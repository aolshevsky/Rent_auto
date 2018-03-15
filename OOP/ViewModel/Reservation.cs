using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	class Reservation : INotifyPropertyChanged
	{

		
		private string extras = "";
		private Dictionary<string, bool> dict = new Dictionary<string, bool>();

		public int ReservationId { get; set; }
		public DateTime PickupDate { get; set; }
		public DateTime ReturnDate { get; set; }

		public bool Paid { get; set; }
		public bool Billed { get; set; }
		public bool Returned { get; set; }

		public int ClientId { get; set; }
		public int CarId { get; set; }


		public virtual Client Client { get; set; }
		public virtual Car Car { get; set; }
		public virtual Bill Bill { get; set; }

	
		
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


		public Reservation()
		{
			this.Returned = false;
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

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

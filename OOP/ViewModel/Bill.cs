using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class Bill : INotifyPropertyChanged
	{
		public Bill() { }

		private double? cost;
		private Reservation rent = new Reservation();

		public Reservation Rent
		{
			get => rent;
			set
			{
				rent = value;
				OnPropertyChanged();
			}
		}


		public double? Cost
		{
			get => cost;
			set
			{
				cost = value;
				OnPropertyChanged();
			}
		}
		public void CalculateTotalCost()
		{
			DateTime startDate = Rent.PickupDate;
			DateTime endDate = Rent.ReturnDate;
			double? costPerDay = Rent.Car.Price;
			var days = (int)endDate.Subtract(startDate).TotalDays + 1;
			this.Cost = Rent.Total(costPerDay, days);
		}


		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

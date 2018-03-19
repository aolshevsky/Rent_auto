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
		public Bill()
		{
			SetId();
		}

		private double? cost;
		private Reservation rent = new Reservation();
		public static int id_static = -1;
		private int id;
		private bool isSelected = false;


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
		public int ID
		{
			get => id;
			set
			{
				id = value;
				OnPropertyChanged();
			}
		}
		public bool IsSelected
		{
			get => isSelected;
			set
			{
				isSelected = value;
				OnPropertyChanged();
			}
		}

		public void SetId() => id = id_static++;

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

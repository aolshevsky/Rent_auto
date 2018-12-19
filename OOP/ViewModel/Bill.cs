using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	[DataContract(IsReference = true)]
	public class Bill : INotifyPropertyChanged
	{
		public Bill()
		{
		}

		private double? cost;
		private Reservation rent = new Reservation();
		[DataMember]
		public static int id_static = 1;
		private int id;
		private bool isSelected = false;

		[DataMember]
		public Reservation Rent
		{
			get => rent;
			set
			{
				rent = value;
				OnPropertyChanged();
			}
		}

		[DataMember]
		public double? Cost
		{
			get => cost;
			set
			{
				cost = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
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

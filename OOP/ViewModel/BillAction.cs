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
	public class BillAction : INotifyPropertyChanged
	{
		public static ObservableCollection<Bill> bills = new ObservableCollection<Bill>();

		private Bill newBill = new Bill();

		public Bill NewBill
		{
			get => newBill;
			set
			{
				newBill = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Bill> Bills
		{
			get => bills;
			set
			{
				bills = value;
				OnPropertyChanged();
			}
		}

		public void AddReservation()
		{
			newBill.Rent.TransformExtras();
			newBill.CalculateTotalCost();
		}

		public void DeleteReservation()
		{

		}

		public void EditReservation()
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

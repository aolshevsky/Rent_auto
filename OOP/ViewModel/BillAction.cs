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
	public class BillAction : INotifyPropertyChanged
	{
		public static ObservableCollection<Bill> bills = new ObservableCollection<Bill>();
		public static ObservableCollection<Bill> paidBills = new ObservableCollection<Bill>();
		private bool isAllBillSelected = false;

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
		[DataMember]
		public ObservableCollection<Bill> Bills
		{
			get => bills;
			set
			{
				bills = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public ObservableCollection<Bill> PaidBills
		{
			get => paidBills;
			set
			{
				paidBills = value;
			}
		}
		public bool IsAllBillSelected
		{
			get => isAllBillSelected;
			set
			{
				isAllBillSelected = value;
				SelectedAllBills();
				OnPropertyChanged();
			}
		}

		public void AddReservation()
		{
			newBill.SetId();
			newBill.Rent.TransformExtras();
			newBill.CalculateTotalCost();
			newBill.Rent.Client.TakenCars.Add(newBill.Rent.Car);
			newBill.Rent.Client.CurrentReserv.Add(newBill);
			Bills.Add(newBill);
		}

		public void DeleteReservation()
		{
			ObservableCollection<Bill> iterBills = new ObservableCollection<Bill>();
			foreach (Bill bl in Bills)
			{
				iterBills.Add(bl);
			}
			foreach (Bill bill in iterBills)
			{
				if (bill.IsSelected)
				{
					bill.Rent.Client.TakenCars.Remove(bill.Rent.Car);
					bill.Rent.Client.ReservationHistory.Add(bill);
					bill.Rent.Client.CurrentReserv.Remove(bill);
					bill.Rent.Client.SpentMoney += bill.Cost;
					paidBills.Add(bill);
					Bills.Remove(bill);
				}
			}
		}
		public void OnlyDeleteReservation()
		{
			ObservableCollection<Bill> iterBills = new ObservableCollection<Bill>();
			foreach (Bill bl in Bills)
			{
				iterBills.Add(bl);
			}
			foreach (Bill bill in iterBills)
			{
				if (bill.IsSelected)
				{
					bill.Rent.Client.CurrentReserv.Remove(bill);
					bill.Rent.Client.TakenCars.Remove(bill.Rent.Car);
					Bills.Remove(bill);
				}
			}

		}

		public void EditReservation()
		{

		}

		public void SelectedAllBills()
		{
			foreach (Bill bill in Bills)
			{
				bill.IsSelected = isAllBillSelected;
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

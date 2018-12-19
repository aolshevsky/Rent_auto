using OOP.ViewModel;
using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP.View
{
	/// <summary>
	/// Interaction logic for NewReservation.xaml
	/// </summary>
	public partial class NewReservation : Window
	{
		AppViewModel appviemodel;
		public NewReservation(AppViewModel app, Car chooseCar=null, Client chooseClient=null)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
			cbPickupLoc.ItemsSource = Enum.GetValues(typeof(Location)).Cast<Location>();
			cbReturnLoc.ItemsSource = Enum.GetValues(typeof(Location)).Cast<Location>();
			appviemodel.BillAct.NewBill = null;
			appviemodel.BillAct.NewBill = new Bill();
			if (!appviemodel.IsAdmin)
				gdClient.Visibility = Visibility.Collapsed;
			if (chooseCar != null)
				appviemodel.BillAct.NewBill.Rent.Car = chooseCar;
			if (chooseClient != null && !appviemodel.IsAdmin)
				appviemodel.BillAct.NewBill.Rent.Client = chooseClient;
		}
		private void btCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}


		private void btAddNewCus_Click(object sender, RoutedEventArgs e)
		{
			NewCustomer nc = new NewCustomer(appviemodel);
			nc.Show();
		}
		private void btAddNewCar_Click(object sender, RoutedEventArgs e)
		{
			NewCar nc = new NewCar(appviemodel, true);
			nc.Show();
		}
		private void btCalculate_Click(object sender, RoutedEventArgs e)
		{
			if (!appviemodel.BillAct.NewBill.Rent.CheckDate())
			{
				MessageBox.Show("Enter correct date!");
				return;
			}
			if (appviemodel.BillAct.NewBill.Rent.IsEmptyFields())
			{
				MessageBox.Show("Enter empty fields!");
				return;
			}
			if (!appviemodel.BillAct.NewBill.Rent.Client.CanTake())
			{
				MessageBox.Show("This client have unpaid rent, pay, before creating a new rent!");
				return;
			}
			try
			{
				appviemodel.BillAct.NewBill.Rent.PickupLoc = (Location)cbPickupLoc.SelectedItem;
				appviemodel.BillAct.NewBill.Rent.ReturnLoc = (Location)cbReturnLoc.SelectedItem;
			}
			catch
			{
				MessageBox.Show("Enter locations");
				return;
			}

			appviemodel.BillAct.AddReservation();
			this.Close();
		}
	}
}

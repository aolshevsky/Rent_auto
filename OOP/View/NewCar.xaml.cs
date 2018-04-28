using OOP.ViewModel;
using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for NewCar.xaml
	/// </summary>
	public partial class NewCar : Window
	{
		AppViewModel appviemodel;
		bool add;
		public NewCar(AppViewModel app, bool add)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
			this.add = add;
			cbBrande.ItemsSource = Enum.GetValues(typeof(CarBrands)).Cast<CarBrands>();
			cbTransmission.ItemsSource = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>();
			cbType.ItemsSource = Enum.GetValues(typeof(CarType)).Cast<CarType>();
			cbEnergy.ItemsSource = Enum.GetValues(typeof(EngineType)).Cast<EngineType>();
			if (add)
			{
				appviemodel.CarAct.NewCar = null;
				appviemodel.CarAct.NewCar = new Car();
			}
			else
			{
				SetSeats();
				cbBrande.SelectedItem = appviemodel.CarAct.NewCar.Brand;
				cbTransmission.SelectedItem = appviemodel.CarAct.NewCar.TransmType;
				cbType.SelectedItem = appviemodel.CarAct.NewCar.Type;
				cbEnergy.SelectedItem = appviemodel.CarAct.NewCar.EngineType;
				tbMain.Text = " EDIT CAR";
				btCancel.Visibility = Visibility.Collapsed;
				btAdd.Content = "EDIT";
			}
		
		}
		private void btAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				appviemodel.CarAct.NewCar.NumberOfSeats = Seats();
				appviemodel.CarAct.NewCar.Brand = (CarBrands)cbBrande.SelectedItem;
				appviemodel.CarAct.NewCar.TransmType = (TransmissionType)cbTransmission.SelectedItem;
				appviemodel.CarAct.NewCar.Type = (CarType)cbType.SelectedItem;
				appviemodel.CarAct.NewCar.EngineType = (EngineType)cbEnergy.SelectedItem;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Enter empty fields!");
				return;
			}
			try
			{
				appviemodel.CarAct.NewCar.IsEmptyFields();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			if (add)
			{
				appviemodel.CarAct.AddCar();
			}
			this.Close();
		}
		private void btCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private int Seats()
		{
			if (rbSeats2.IsChecked == true)
			{
				return 2;
			}
			else if (rbSeats4.IsChecked == true)
			{
				return 4;
			}
			else if (rbSeats6.IsChecked == true)
			{
				return 6;
			}
			return 0;
		}
		private void SetSeats()
		{
			if(appviemodel.CarAct.NewCar.NumberOfSeats == 2)
			{
				rbSeats2.IsChecked = true;
			}
			else if (appviemodel.CarAct.NewCar.NumberOfSeats == 4)
			{
				rbSeats4.IsChecked = true;
			}
			else if (appviemodel.CarAct.NewCar.NumberOfSeats == 6)
			{
				rbSeats6.IsChecked = true;
			}
		}

	}
}

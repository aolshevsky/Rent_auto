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

		public NewCar(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
			cbBrande.ItemsSource = Enum.GetValues(typeof(CarBrands)).Cast<CarBrands>();
			cbTransmission.ItemsSource = Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>();
			cbType.ItemsSource = Enum.GetValues(typeof(CarType)).Cast<CarType>();
			appviemodel.CarAct.NewCar = null;
			appviemodel.CarAct.NewCar = new Car();
		}
		private void btAdd_Click(object sender, RoutedEventArgs e)
		{
			appviemodel.CarAct.NewCar.NumberOfSeats = Seats();
			appviemodel.CarAct.NewCar.Brand = (CarBrands)cbBrande.SelectedItem;
			if (appviemodel.CarAct.NewCar.IsEmptyFields())
			{
				MessageBox.Show("Enter empty fields!");
				return;
			}
			appviemodel.CarAct.AddCar();
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

	}
}

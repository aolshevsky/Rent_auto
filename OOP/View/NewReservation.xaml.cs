using OOP.ViewModel;
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
		public NewReservation(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
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
			NewCar nc = new NewCar(appviemodel);
			nc.Show();
		}
		private void btCalculate_Click(object sender, RoutedEventArgs e)
		{ }
	}
}

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
	/// Interaction logic for ShowCar.xaml
	/// </summary>
	public partial class ShowCar : Window
	{
		AppViewModel appviemodel;
		public ShowCar(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
		}


		private void btCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void btAdd_Click(object sender, RoutedEventArgs e)
		{
			appviemodel.BillAct.NewBill.Rent.Car = appviemodel.CarAct.SelectedCar;
			if (appviemodel.IsAdmin)
			{

				NewReservation nr = new NewReservation(appviemodel, appviemodel.CarAct.SelectedCar);
				nr.ShowDialog();
			}
			else
			{
				NewReservation nr = new NewReservation(appviemodel, appviemodel.CarAct.SelectedCar, appviemodel.CurrenUser);
				nr.ShowDialog();
			}
			this.Close();
		}
	}
}

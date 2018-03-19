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
	public partial class AdminMain : Window
	{
		AppViewModel appviemodel;

		public AdminMain(ViewModel.AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
		}
		private void ButtonFechar_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int index = ListViewMenu.SelectedIndex;
			MoveCursorMenu(index);

			switch (index)
			{
				case 0:
					GridPrincipal.Children.Clear();
					//GridPrincipal.Children.Add(new UseControlReservation());
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Collapsed;
					break;
				case 1:
					GridPrincipal.Children.Clear();
					appviemodel.CarAct.RefreshPages();
					GridPrincipal.Children.Add(new UserControl1(appviemodel));
					stPages.Visibility = Visibility.Visible;
					stAddEdit.Visibility = Visibility.Visible;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Visible;
					break;
				case 2:
					GridPrincipal.Children.Clear();
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					svReserv.Visibility = Visibility.Visible;
					stAddEditRemRes.Visibility = Visibility.Visible;
					stSearch.Visibility = Visibility.Collapsed;
					break;
				case 3:
					GridPrincipal.Children.Clear();
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Collapsed;
					NewCustomer nc = new NewCustomer(appviemodel);
					nc.ShowDialog();
					break;
				default:
					break;
			}
		}

		private void MoveCursorMenu(int index)
		{
			TrainsitionigContentSlide.OnApplyTemplate();
			GridCursor.Margin = new Thickness(0, (100 + (40 * index)), 0, 0);
		}

		private void btEdit(object sender, RoutedEventArgs e)
		{
			appviemodel.CarAct.EditCar();
			NewCar ac = new NewCar(appviemodel, false);
			ac.ShowDialog();
		}

		private void btAdd(object sender, RoutedEventArgs e)
		{
			if (ListViewMenu.SelectedIndex == 1)
			{
				NewCar ac = new NewCar(appviemodel, true);
				ac.ShowDialog();
				appviemodel.CarAct.RefreshPages();
			}
			else
			{
				NewReservation nr = new NewReservation(appviemodel);
				nr.ShowDialog();
			}
		}

		private void btDel(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes)
			{
				if (ListViewMenu.SelectedIndex == 1)
				{
					appviemodel.CarAct.DeleteCar();
				}
				else
				{
					appviemodel.BillAct.DeleteReservation();
				}
			}

		}
	}
}

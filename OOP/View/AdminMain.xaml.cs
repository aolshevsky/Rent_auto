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

		public AdminMain(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
			if (!appviemodel.IsAdmin)
			{
				NewClient.Visibility = Visibility.Collapsed;
				lvClients.Visibility = Visibility.Collapsed;
				tbHi.Text = "Hi! " + appviemodel.CurrenUser.FirstName;
			}

		}


		private void ButtonFechar_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		private void btLogout(object sender, RoutedEventArgs e)
		{
			MainWindow log = new MainWindow(appviemodel);
			log.Show();
			Close();
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int index = ListViewMenu.SelectedIndex;
			MoveCursorMenu(ref index);

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
					svHistory.Visibility = Visibility.Collapsed;
					svReservUser.Visibility = Visibility.Collapsed;
					svHistoryAdmin.Visibility = Visibility.Collapsed;
					svClentsAdmin.Visibility = Visibility.Collapsed;
					break;
				case 1:
					GridPrincipal.Children.Clear();
					appviemodel.CarAct.RefreshPages();
					GridPrincipal.Children.Add(new UserControl1(appviemodel));
					stPages.Visibility = Visibility.Visible;
					if (appviemodel.IsAdmin)
						stAddEdit.Visibility = Visibility.Visible;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Visible;
					svHistory.Visibility = Visibility.Collapsed;
					svReservUser.Visibility = Visibility.Collapsed;
					svHistoryAdmin.Visibility = Visibility.Collapsed;
					svClentsAdmin.Visibility = Visibility.Collapsed;
					break;
				case 2:
					GridPrincipal.Children.Clear();
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					if (appviemodel.IsAdmin)
						svReserv.Visibility = Visibility.Visible;
					else
						svReservUser.Visibility = Visibility.Visible;
					stAddEditRemRes.Visibility = Visibility.Visible;
					stSearch.Visibility = Visibility.Collapsed;
					svHistory.Visibility = Visibility.Collapsed;
					svHistoryAdmin.Visibility = Visibility.Collapsed;
					svClentsAdmin.Visibility = Visibility.Collapsed;
					break;
				case 3:
					GridPrincipal.Children.Clear();
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Collapsed;
					svReservUser.Visibility = Visibility.Collapsed;
					svHistoryAdmin.Visibility = Visibility.Collapsed;
					svClentsAdmin.Visibility = Visibility.Collapsed;
					if (appviemodel.IsAdmin)
					{
						NewCustomer nc = new NewCustomer(appviemodel);
						nc.ShowDialog();
					}
					else
					{
						svHistory.Visibility = Visibility.Visible;
					}
					break;
				case 4:
					GridPrincipal.Children.Clear();
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Collapsed;
					svReservUser.Visibility = Visibility.Collapsed;
					svClentsAdmin.Visibility = Visibility.Collapsed;
					if (appviemodel.IsAdmin)
					{
						svHistoryAdmin.Visibility = Visibility.Visible;
					}
					break;
				case 5:
					GridPrincipal.Children.Clear();
					stPages.Visibility = Visibility.Collapsed;
					stAddEdit.Visibility = Visibility.Collapsed;
					svReserv.Visibility = Visibility.Collapsed;
					stAddEditRemRes.Visibility = Visibility.Collapsed;
					stSearch.Visibility = Visibility.Collapsed;
					svReservUser.Visibility = Visibility.Collapsed;
					svHistoryAdmin.Visibility = Visibility.Collapsed;
					if (appviemodel.IsAdmin)
					{
						svClentsAdmin.Visibility = Visibility.Visible;
					}
					break;

				default:
					break;
			}
		}

		private void MoveCursorMenu(ref int index)
		{
			if (index == 4 && !appviemodel.IsAdmin)
				index = 3;
			TrainsitionigContentSlide.OnApplyTemplate();
			GridCursor.Margin = new Thickness(0, (100 + (40 * index)), 0, 0);
		}

		private void btEdit(object sender, RoutedEventArgs e)
		{
			if (ListViewMenu.SelectedIndex == 1)
			{
				appviemodel.CarAct.EditCar();
				NewCar ac = new NewCar(appviemodel, false);
				ac.ShowDialog();
			}
			else
			{
				appviemodel.BillAct.OnlyDeleteReservation();
			}
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
				if (!appviemodel.IsAdmin)
				{
					if (!appviemodel.CurrenUser.CanTake())
					{
						MessageBox.Show("You have unpaid rent, pay, before creating a new rent!");
						return;
					}
					NewReservation nr = new NewReservation(appviemodel, null, appviemodel.CurrenUser);
					nr.ShowDialog();
				}
				else
				{
					NewReservation nr = new NewReservation(appviemodel);
					nr.ShowDialog();
				}
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
		private void Grid_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Button_Click(sender, e);
			}
		}
		public void Button_Click(object sender, RoutedEventArgs e)
		{
			GridPrincipal.Children.Clear();
			appviemodel.CarAct.FindByName();
			appviemodel.CarAct.RefreshPages();
			GridPrincipal.Children.Add(new UserControl1(appviemodel));
			stPages.Visibility = Visibility.Visible;
			stAddEdit.Visibility = Visibility.Visible;
			svReserv.Visibility = Visibility.Collapsed;
			stAddEditRemRes.Visibility = Visibility.Collapsed;
			stSearch.Visibility = Visibility.Visible;
		}

		private void Open(object sender, RoutedEventArgs e)
		{
			appviemodel.PrepCar();
		}
	}
}

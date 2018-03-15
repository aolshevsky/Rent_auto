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
					break;
				case 1:
					GridPrincipal.Children.Clear();
					GridPrincipal.Children.Add(new UserControlCar());
					break;
				case 2:
					GridPrincipal.Children.Clear();
					NewCustomer nc = new NewCustomer(appviemodel);
					nc.ShowDialog();
					break;
				case 3:
					GridPrincipal.Children.Clear();
					NewCar ac = new NewCar(appviemodel);
					ac.ShowDialog();
					break;
				case 4:
					GridPrincipal.Children.Clear();
					NewReservation nr = new NewReservation(appviemodel);
					nr.ShowDialog();
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
	}
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP.View
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class UserControl1 : UserControl
	{
		AppViewModel appviemodel;
		public UserControl1(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ShowCar sc = new ShowCar(appviemodel);
			sc.ShowDialog();
		}
	}
}

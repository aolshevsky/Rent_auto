using System.Windows;
using OOP.View;
using OOP.ViewModel;

namespace OOP
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		AppViewModel appviemodel;

		public MainWindow()
		{
			InitializeComponent();
			appviemodel = new AppViewModel();
			DataContext = appviemodel;
		}

		private void btUser_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btAdmin_Click(object sender, RoutedEventArgs e)
		{
			
			Login log = new Login(appviemodel);
			log.Show();
			this.Close();

		}

		private void ButtonFechar_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

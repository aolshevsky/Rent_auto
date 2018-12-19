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

		public MainWindow(AppViewModel app)
		{
			InitializeComponent();
			appviemodel = app;
			DataContext = appviemodel;
		}

		private void btCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();

		}

		private void btForgot_Click(object sender, RoutedEventArgs e)
		{
			NewCustomer nc = new NewCustomer(appviemodel);
			nc.ShowDialog();

		}
		private void btLogin_Click(object sender, RoutedEventArgs e)
		{
			appviemodel.Pass = txtPassword.Password.ToString();
			if (!appviemodel.Validate())
			{
				MessageBox.Show("Invalid data! Repeat one more time!");
			}

			else
			{
				AdminMain adminMain = new AdminMain(appviemodel);
				adminMain.Show();
				Close();
			}
		}
	}
}

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
	public partial class Login : Window
	{
		AppViewModel appviemodel;

		public Login(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;

		}
		private void btCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();

		}

		private void btForgot_Click(object sender, RoutedEventArgs e)
		{

			this.Close();

		}
		private void btLogin_Click(object sender, RoutedEventArgs e)
		{
			appviemodel.adminLogin.Password = txtPassword.Password.ToString();
			appviemodel.adminLogin.UserName = txtUser.Text;
			if (!appviemodel.adminLogin.CheckLogPass())
			{
				if (appviemodel.adminLogin.IsEmpty())
					MessageBox.Show("Enter empty fields!");
				else
					MessageBox.Show("Uncorrect data!");
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

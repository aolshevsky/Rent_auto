using OOP.ViewModel;
using OOP.ViewModel.Enumerations;
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
	/// Interaction logic for NewCustomer.xaml
	/// </summary>
	public partial class NewCustomer : Window
	{
		AppViewModel appviemodel;

		public NewCustomer(AppViewModel app)
		{
			InitializeComponent();
			DataContext = app;
			appviemodel = app;
			appviemodel.ClientAct.NewClient = null;
			appviemodel.ClientAct.NewClient = new Client();
		}

		private void btDelete_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void btAdd_Click(object sender, RoutedEventArgs e)
		{
			appviemodel.ClientAct.NewClient.Sex = (Sex)(RadioButtonGender());
			appviemodel.ClientAct.NewClient.Password = txtPass.Password.ToString();
			if (appviemodel.ClientAct.CheckUserLog())
			{
				MessageBox.Show("This user is registered. Change user name!");
				return;
			}
			try
			{
				appviemodel.ClientAct.NewClient.IsEmptyFields();
			}
			catch(Exception reg)
			{
				MessageBox.Show(reg.Message);
				return;
			}
			appviemodel.ClientAct.AddClient();
			this.Close();
		}
		public int? RadioButtonGender()
		{
			if (rbMale.IsChecked == true)
			{
				return 0;
			}
			if (rbFemale.IsChecked == true)
			{
				return 1;
			}
			return null;
		}
	}
}

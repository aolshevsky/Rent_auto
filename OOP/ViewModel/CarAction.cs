using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class CarAction : INotifyPropertyChanged
	{
		public static ObservableCollection<Car> cars = new ObservableCollection<Car>();
		private Car newCar = new Car();

		public Car NewCar
		{
			get => newCar;
			set
			{
				newCar = value;
				OnPropertyChanged();
			}
		}


		public void AddCar()
		{
			cars.Add(NewCar);

		}

		public void DeleteCar()
		{

		}

		public void EditCar()
		{

		}


		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

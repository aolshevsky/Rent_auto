using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.ViewModel.Enumerations;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OOP.ViewModel
{
	public class Car : INotifyPropertyChanged
	{
		#region fields
		private int numberInUse;
		private int numberReserved;
		private string model;
		private int numberOfSeats;
		private double? price;
		private int? year;
		private bool airConditin;
		private double? fuelConsumtionPerHundredKm;
		private string imageName;
		public static int ID = 0;
		private CarBrands brand;
		private TransmissionType transmType;
		private EngineType engineType;
		private CarType type;
		#endregion


		public Car(EngineType engineType, CarBrands brand, int year, double price, int numberOfSeats, double fuelConsumtionPerHundredKm,
					string model, CarType type, TransmissionType transmType)
		{
			this.Model = model;
			this.Type = type;
			this.Brand = brand;
			this.Year = year;
			this.Price = price;
			this.NumberOfSeats = numberOfSeats;
			this.FuelConsumtionPerHundredKm = fuelConsumtionPerHundredKm;
			this.EngineType = engineType;
			this.TransmType = transmType;
		}

		public Car()
		{
			SetId();
		}


		#region properties
		public string ImagePath
		{
			get
			{
				string directory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Assets");
				if (File.Exists(directory + "//" + imageName + ".jpg"))
				{
					return directory + "//" + imageName + ".jpg";
				}
				else if (File.Exists(directory + "//" + imageName + ".png"))
				{
					return directory + "//" + imageName + ".png";
				}
				else
				{
					return directory + "//default.png";
				}
			}
		}
		public string ImageName
		{
			get => imageName;
			set
			{
				imageName = value;
				OnPropertyChanged();
			}
		}
		public bool AirConditin
		{
			get => airConditin;
			set
			{
				airConditin = value;
				OnPropertyChanged();
			}
		}
		public string Model
		{
			get => model;
			set
			{
				model = value;
				OnPropertyChanged();
			}
		}
		public int NumberOfSeats
		{
			get => numberOfSeats;
			set
			{
				if (value < 1)
				{
					//throw new ArgumentOutOfRangeException("Number of seats in the vehicle must be at least 1.");
				}
				numberOfSeats = value;
			}
		}
		public double? Price
		{
			get => price;
			set
			{
				if (value < 0)
				{
					//throw new ArgumentOutOfRangeException("Price of the car must be a positive number to 0.");
				}
				price = value;
				OnPropertyChanged();
			}
		}
		public double? FuelConsumtionPerHundredKm
		{
			get => fuelConsumtionPerHundredKm;
			set
			{
				fuelConsumtionPerHundredKm = value;
				OnPropertyChanged();
			}
		}
		public int? Year
		{
			get => year;

			set
			{
				year = value;
				OnPropertyChanged();
			}
		}
		public CarBrands Brand
		{
			get => brand;
			set => brand = value;
		}
		public TransmissionType TransmType
		{
			get => transmType;
			set => transmType = value;
		}
		public EngineType EngineType
		{
			get => engineType;
			set => engineType = value;
		}
		public CarType Type
		{
			get => type;
			set => type = value;
		}


		#endregion
		public int CarId { get; set; }
		public bool IsEmptyFields()
		{
			if (Model == "" || Year == null || FuelConsumtionPerHundredKm == null ||
				Price == null || ImageName == "" || numberOfSeats == 0)
			{
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			StringBuilder toString = new StringBuilder();

			toString.AppendLine("Information about car:");
			toString.AppendLine();
			toString.AppendFormat(" Car brand - {0}", this.Brand);
			toString.AppendLine();
			toString.AppendFormat(" Car type - {0}", this.Type);
			toString.AppendLine();
			toString.AppendFormat(" Year of manifacture - {0}", this.Year);
			toString.AppendLine();
			toString.AppendFormat(" Engine type - {0}", this.EngineType);
			toString.AppendLine();
			toString.AppendFormat(" transmission type - {0}", this.TransmType);
			toString.AppendLine();
			toString.AppendFormat(" Number of seats - {0}", this.NumberOfSeats);
			toString.AppendLine();
			toString.AppendFormat(" Fuel consumption per 100km - {0}", this.FuelConsumtionPerHundredKm);
			toString.AppendLine();
			toString.AppendFormat(" Price - {0:$}", this.Price);

			return toString.ToString();
		}
		public void SetId() => CarId = ID++;
		public string FullName => Brand.ToString() + " " + Model; 
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

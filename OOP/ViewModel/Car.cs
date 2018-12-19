using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.ViewModel.Enumerations;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace OOP.ViewModel
{
	[DataContract(IsReference = true)]
	public class Car : INotifyPropertyChanged
	{
		#region fields
		private string model;
		private int numberOfSeats;
		private double? price;
		private int? year;
		private bool airConditin;
		private double? fuelConsumtionPerHundredKm;
		private string imageName;
		[DataMember]
		public static int id_static = 19;
		private int id;
		private CarBrands brand;
		private TransmissionType transmType;
		private EngineType engineType;
		private CarType type;
		#endregion


		public Car(EngineType engineType, CarBrands brand, int year,
					double price, int numberOfSeats,
					double fuelConsumtionPerHundredKm,
					string model, CarType type,
					TransmissionType transmType)
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
			
		}


		#region properties
		[DataMember]
		public int ID
		{
			get => id;
			set
			{
				id = value;
				OnPropertyChanged();
			}
		}

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
		[DataMember]
		public string ImageName
		{
			get => imageName;
			set
			{
				imageName = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public bool AirConditin
		{
			get => airConditin;
			set
			{
				airConditin = value;
				OnPropertyChanged();
			}
		}

		[DataMember]
		public string Model
		{
			get => model;
			set
			{
				model = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public int NumberOfSeats
		{
			get => numberOfSeats;
			set
			{
				numberOfSeats = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public double? Price
		{
			get => price;
			set
			{
				price = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public double? FuelConsumtionPerHundredKm
		{
			get => fuelConsumtionPerHundredKm;
			set
			{
				fuelConsumtionPerHundredKm = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public int? Year
		{
			get => year;

			set
			{
				year = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public CarBrands Brand
		{
			get => brand;
			set
			{
				brand = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public TransmissionType TransmType
		{
			get => transmType;
			set
			{
				transmType = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public EngineType EngineType
		{
			get => engineType;
			set
			{
				engineType = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public CarType Type
		{
			get => type;
			set
			{
				type = value;
				OnPropertyChanged();
			}
		}
		public string BrandAndModel => Brand + " " + Model; 


		#endregion

		public void IsEmptyFields()
		{
			Regex len = new Regex("^.{4,4}$");
			if (Model == "" || Year == null || FuelConsumtionPerHundredKm == null ||
				Price == null || ImageName == "" || numberOfSeats == 0)
			{
				throw new Exception("Enter empty fields!");
			}
			if (!Regex.IsMatch(Model, @"^[a-zA-Z0-9]+$"))
			{
				throw new Exception("Check model!");
			}
			if (Year < 1950 && Year > DateTime.Now.Year)
			{
				throw new Exception("Check year!");
			}
			
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
		public void SetId() => id = id_static++;
		public string FullName => Brand.ToString() + " " + Model; 
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

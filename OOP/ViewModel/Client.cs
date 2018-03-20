using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	[DataContract(IsReference = true)]
	public class Client : Person, INotifyPropertyChanged
	{
		#region fields
		private string firstName;
		private string lastName;

		private DateTime dateOfBirth;
		private Sex sex;
		private string city;
		private string country;
		private string phoneNumber;
		private ObservableCollection<Car> takenCars = new ObservableCollection<Car>();
		private ObservableCollection<Bill> reservationHistory = new ObservableCollection<Bill>();
		private ObservableCollection<Bill> currentReserv = new ObservableCollection<Bill>();
		public static int ID = 0;

		#endregion



		#region properties
		[DataMember]
		public ObservableCollection<Car> TakenCars
		{
			get => takenCars;
			set
			{
				takenCars = value;
				OnPropertyChanged();
			}
		}
		//[DataMember]
		public ObservableCollection<Bill> ReservationHistory
		{
			get => reservationHistory;
			set
			{
				reservationHistory = value;
				OnPropertyChanged();
			}
		}
		//[DataMember]
		public ObservableCollection<Bill> CurrentReserv
		{
			get => currentReserv;
			set
			{
				currentReserv = value;
				OnPropertyChanged();
			}
		}
		public int ClientId { get; set; }
		[DataMember]
		public Sex Sex
		{
			get => sex;
			set => sex = value;
		}
		[DataMember]
		public DateTime DateOfBirth
		{
			get => dateOfBirth;
			set
			{
				dateOfBirth = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public string City
		{
			get => city;
			set
			{
				city = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public string Country
		{
			get => country;
			set
			{
				country = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public string FirstName
		{
			get => firstName;
			set
			{
				firstName = value;
				OnPropertyChanged();

			}
		}
		[DataMember]
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public string PhoneNumber
		{
			get => phoneNumber;
			set
			{
				phoneNumber = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public int Age
		{
			get
			{
				TimeSpan age = DateTime.Now - this.DateOfBirth;

				if (age.Days / 365 < 18)
				{
					//throw new ArgumentOutOfRangeException("You must be 18 years or older to rent a car.");
				}
				return age.Days / 365;
			}
		}
		public string FullName => FirstName + " " + LastName;

		#endregion

		public Client()
		{
			DateOfBirth = DateTime.Now;
			SetId();
		}
		public bool CanTake()
		{
			return CurrentReserv.Count == 0 ? true : false;
		}
		public Client(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		public void SetId() => ClientId = ID++;
	}
}

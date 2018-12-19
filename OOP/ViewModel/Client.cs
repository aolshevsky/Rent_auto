using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
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
		[DataMember]
		public static int ID = 1;
		private int clientId;
		private double? spentMoney = 0;

		public void IsEmptyFields()
		{
			Regex len = new Regex("^.{4,8}$");
			Regex num = new Regex("\\d");
			Regex alpha = new Regex("\\D");
			Regex special = new Regex("[><%#@]");
			if (City == null || FirstName == null || LastName == null ||
				 PhoneNumber == null )
			{
				throw new Exception("Enter empty fields");
			}
			if(Age < 18 || Age > 100)
			{
				throw new Exception("You must be 18 years or older to rent a car. Invalid age: 18<age<100");
			}
			if(!len.IsMatch(Password))
			{
				throw new Exception("Check password: 4<lenght<8");
			}
			if (!Regex.IsMatch(City, @"^[a-zA-Z]+$"))
			{
				throw new Exception("Check city!");
			}
			if (!Regex.IsMatch(FirstName, @"^[a-zA-Z]+$"))
			{
				throw new Exception("Check FirstName!");
			}
			if (!Regex.IsMatch(LastName, @"^[a-zA-Z]+$"))
			{
				throw new Exception("Check LastName!");
			}
			if (!Regex.IsMatch(PhoneNumber, @"^[0-9]+$"))
			{
				throw new Exception("Check PhoneNumber!");
			}
		}
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
		[DataMember]
		public ObservableCollection<Bill> ReservationHistory
		{
			get => reservationHistory;
			set
			{
				reservationHistory = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public ObservableCollection<Bill> CurrentReserv
		{
			get => currentReserv;
			set
			{
				currentReserv = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public int ClientId {
			get => clientId;
			set
			{
				clientId = value;
				OnPropertyChanged();
			}
		}
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
		public double? SpentMoney
		{
			get => spentMoney;
			set
			{
				spentMoney = value;
				OnPropertyChanged();
			}
		}
		public int Age
		{
			get
			{
				TimeSpan age = DateTime.Now - this.DateOfBirth;
				return age.Days / 365;
			}
		}
		public string FullName => FirstName + " " + LastName;

		#endregion

		public Client()
		{
			DateOfBirth = DateTime.Now;
		}
		public bool CanTake()
		{
			return CurrentReserv.Count == 0 ? true : false;
		}
		public bool IsNo18()
		{
			TimeSpan age = DateTime.Now - this.DateOfBirth;

			if (age.Days / 365 < 18)
			{
				return true;
			}
			return false;
		}
		public Client(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		public void SetId() => ClientId = ID++;
		public int PaidReserv => ReservationHistory.Count;
		
	}
}

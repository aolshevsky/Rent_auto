﻿using OOP.ViewModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	public class Client : INotifyPropertyChanged
	{
		#region fields
		private string firstName;
		private string lastName;

		private DateTime dateOfBirth;
		private Sex sex;
		private string city;
		private string country;
		private string username;
		private string password;
		private string phoneNumber;
		public static int ID = 0;

		#endregion



		#region properties
		public int ClientId { get; set; }
		public Sex Sex
		{
			get => sex;
			set => sex = value;
		}
		public DateTime DateOfBirth
		{
			get => dateOfBirth;
			set
			{
				dateOfBirth = value;
				OnPropertyChanged();
			}
		}
		public string City
		{
			get => city;
			set
			{
				city = value;
				OnPropertyChanged();
			}
		}
		public string Country
		{
			get => country;
			set
			{
				country = value;
				OnPropertyChanged();
			}
		}
		public string FirstName
		{
			get => firstName;
			set
			{
				firstName = value;
				OnPropertyChanged();

			}
		}
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				OnPropertyChanged();
			}
		}
		public string Username
		{
			get => username;
			set
			{
				username = value;
				OnPropertyChanged();
			}
		}
		public string Password
		{
			get => password;
			set
			{
				password = value;
				OnPropertyChanged();
			}
		}
		public string PhoneNumber
		{
			get => phoneNumber;
			set
			{
				phoneNumber = value;
				OnPropertyChanged();
			}
		}
		public int Age
		{
			get
			{
				TimeSpan age = DateTime.Now - this.DateOfBirth;

				if (age.Days / 365 < 18)
				{
					throw new ArgumentOutOfRangeException("You must be 18 years or older to rent a car.");
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

		public Client(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		public void SetId() => ClientId = ID++;

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}

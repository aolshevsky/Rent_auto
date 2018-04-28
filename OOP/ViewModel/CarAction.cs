using OOP.Model;
using OOP.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	[DataContract(IsReference = true)]
	public class CarAction : INotifyPropertyChanged
	{
		public string NextPageC { get; set; }
		public string PrevPageC { get; set; }
		public string LastPageC { get; set; }
		public string FirstPageC { get; set; }

		private int currentPageValue;
		private int maxPageValue;
		private int rowInPage;
		private string findText;

		private RelayCommand nextPageCommand;
		private RelayCommand prevPageCommand;
		private RelayCommand firstPageCommand;
		private RelayCommand lastPageCommand;

		public static MyCollection<Car> cars = new MyCollection<Car>();
		private Car newCar = new Car();
		private Car selectedCar = new Car();
		private ObservableCollection<Car> tempCars;
		private ObservableCollection<Car> currentPage;
		private ObservableCollection<Car> nextPage;
		private ObservableCollection<Car> prevPage;

		public AppViewModel AppVM { get; set; }


		public CarAction()
		{
			rowInPage = 3;
			currentPage = new ObservableCollection<Car>();
			prevPage = new ObservableCollection<Car>();
			nextPage = new ObservableCollection<Car>();
			tempCars = new ObservableCollection<Car>();
			HotKeys();
			RefreshPages();
		}

		public string FindText
		{
			get => findText;
			set
			{
				//Default();
				findText = value;
				
				//Cars.Refresh();
				OnPropertyChanged();
			}
		}

		

		public Car NewCar
		{
			get => newCar;
			set
			{
				newCar = value;
				OnPropertyChanged();
			}
		}
		public Car SelectedCar
		{
			get => selectedCar;
			set
			{
				selectedCar = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public MyCollection<Car> Cars
		{
			get => cars;
			set
			{
				cars = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Car> NextPage
		{
			get => nextPage;
			set
			{
				nextPage = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Car> CurrentPage
		{
			get => currentPage;
			set
			{
				currentPage = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Car> PrevPage
		{
			get => prevPage;
			set
			{
				prevPage = value;
				OnPropertyChanged();
			}
		}
		[DataMember]
		public ObservableCollection<Car> TempCars
		{
			get => tempCars;
			set
			{
				tempCars = value;
				OnPropertyChanged();
			}
		}

		public int CurrentPageValue
		{
			get => currentPageValue;
			set
			{
				currentPageValue = value;
				CurrentPageValueBind = value + 1;
				OnPropertyChanged();
			}
		}
		private int currentPageValueBind;
		public int CurrentPageValueBind
		{
			get => currentPageValueBind;
			set
			{
				currentPageValueBind = value;
				OnPropertyChanged();
			}
		}
		private int amountOfPagesBind;
		public int AmountOfPagesBind
		{
			get => amountOfPagesBind;
			set
			{
				amountOfPagesBind = value;
				OnPropertyChanged();
			}
		}
		public int AmountOfPages
		{
			get => maxPageValue;
			set
			{
				int n = 0;
				n = Cars.Count;
				maxPageValue = (n - 1) / (rowInPage);
				AmountOfPagesBind = maxPageValue + 1;
				OnPropertyChanged();
			}
		}
		public void RefreshPages()
		{
			AmountOfPages = 0;
			CurrentPageValue = 0;
			CurrentPage = new ObservableCollection<Car>(Cars.Skip((currentPageValue) * rowInPage).Take(rowInPage).ToArray());
			if (CurrentPage.Count != 0)
			{
				SelectedCar = CurrentPage.First();
			}
			LoadPrevPage();
			LoadNextPage();
		}

		public void AddCar()
		{
			NewCar.SetId();
			tempCars.Add(NewCar);
			cars.Add(NewCar);
		}

		public void DeleteCar()
		{
			cars.Remove(SelectedCar);
			tempCars.Remove(SelectedCar);
			RefreshPages();
		}

		public void EditCar()
		{
			NewCar = SelectedCar;
		}
		public void Default()
		{
			cars = new MyCollection<Car>();
			foreach (Car cr in TempCars)
			{
				Cars.Add(cr);
			}
			SelectedCar = cars.First();
			RefreshPages();
		}
		public void HotKeys()
		{
			HotKey s = (HotKey)ConfigurationManager.GetSection("keys");
			LastPageC = s.LastPage.Key;
			FirstPageC = s.FirstPage.Key;
			NextPageC = s.NextPage.Key;
			PrevPageC = s.PrevPage.Key;

		}

		public void LoadNextPage()
		{
			var task = Task.Factory.StartNew(() =>
			{

				nextPage = new ObservableCollection<Car>(
					cars.Skip((currentPageValue + 1) * rowInPage).Take(rowInPage).ToArray());
			});
			task.Wait();
			task.Dispose();

		}
		public void LoadPrevPage()
		{

			if (currentPageValue <= 0)
			{
				CurrentPageValue = 0;
				prevPage = new ObservableCollection<Car>();
				return;
			}
			var task = Task.Factory.StartNew(() =>
			{
				prevPage = new ObservableCollection<Car>(
					cars.Skip((currentPageValue - 1) * rowInPage).Take(rowInPage).ToArray());
			});
			task.Wait();
			task.Dispose();
		}
		public void FindByName()
		{
			IEnumerable<Car> sequenc = from cr in tempCars
									   where cr.FullName.ToLower().Contains(findText.ToLower())
									   select cr;
			cars = new MyCollection<Car>();
			foreach (Car que in sequenc)
			{
				cars.Add(que);
			}
			if (cars.Count != 0)
				SelectedCar = cars.First();
		}
		public RelayCommand NextPageCommand => nextPageCommand ??
				  (nextPageCommand = new RelayCommand(obj =>
				  {

					  if (nextPage == null || nextPage.Count == 0) return;
					  CurrentPage = new ObservableCollection<Car>(nextPage);
					  SelectedCar = currentPage.First();
					  CurrentPageValue++;
					  LoadNextPage();
					  LoadPrevPage();
				  }));
		public RelayCommand PrevPageCommand => prevPageCommand ??
				  (prevPageCommand = new RelayCommand(obj =>
				  {
					  if (currentPageValue == 0) return;
					  CurrentPage = new ObservableCollection<Car>(prevPage);
					  SelectedCar = currentPage.First();
					  CurrentPageValue--;
					  LoadPrevPage();
					  LoadNextPage();
				  }));
		public RelayCommand FirstPageCommand => firstPageCommand ??
			(firstPageCommand = new RelayCommand(obj =>
				{
					CurrentPageValue = 0;

					CurrentPage = new ObservableCollection<Car>(cars.Take(rowInPage).ToArray());
					SelectedCar = currentPage.First();

					LoadNextPage();
					LoadPrevPage();

				}));

		public RelayCommand LastPageCommand => lastPageCommand ??
			(lastPageCommand = new RelayCommand(obj =>
				{
					CurrentPageValue = AmountOfPages - 1;

					CurrentPage = new ObservableCollection<Car>(
						cars.Skip((currentPageValue + 1) * rowInPage).Take(rowInPage).ToArray());
					SelectedCar = currentPage.First();
					CurrentPageValue++;
					LoadNextPage();
					LoadPrevPage();
				}));



		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
		
	}
}

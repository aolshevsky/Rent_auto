using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.ViewModel
{
	class Bill
	{
		public Bill() { }


		public DateTime Date { get; set; }


		public double Cost { get; set; }

		public virtual Reservation Rent { get; set; }

		public void CalculateTotalCost(DateTime startDate, DateTime endDate, double costPerDay)
		{
			var days = (int)endDate.Subtract(startDate).TotalDays + 1;
			this.Cost = days * costPerDay;
		}
	}
}

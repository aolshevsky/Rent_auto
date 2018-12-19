using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOP.Model
{
	public class EmptyField : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
			{
				return new ValidationResult(false, "necessary field");
			}
			else
			{
				return new ValidationResult(true, null);
			}
		}
	}
}
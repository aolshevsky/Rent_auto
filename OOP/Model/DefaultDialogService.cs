using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP.Model
{
	class DefaultDialogService : IDialogService
	{
		private int filter = 1;

		public string FilePath { get; set; }

		public bool OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Json|*.json";
			openFileDialog.Title = "Open database";
			if (openFileDialog.ShowDialog() == true)
			{
				filter = openFileDialog.FilterIndex == 1 ? 1 : openFileDialog.FilterIndex == 2 ? 2 : 3;
				FilePath = openFileDialog.FileName;
				return true;
			}
			return false;
		}


		public bool SaveFileDialog()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "JSON|*.json";
			saveFileDialog.Title = "Save database";
			if (saveFileDialog.ShowDialog() == true)
			{
				filter = saveFileDialog.FilterIndex == 1 ? 1 : saveFileDialog.FilterIndex == 2 ? 2 : 3;
				FilePath = saveFileDialog.FileName;
				return true;
			}
			return false;
		}



		public int Filter() => filter;


		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}

	public interface IDialogService
	{
		void ShowMessage(string message);
		string FilePath { get; set; }
		bool OpenFileDialog();
		bool SaveFileDialog();
		int Filter();
	}

}

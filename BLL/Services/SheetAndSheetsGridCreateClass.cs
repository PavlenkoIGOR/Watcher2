/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:02
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using watcherWPF_modified.BLL.ForSerialize;
using watcherWPF_modified.BLL.ViewModel;

namespace watcherWPF_modified.BLL
{
	/// <summary>
	/// Description of SheetAndSheetsGridCreateClass.
	/// </summary>
	public class SheetAndSheetsGridCreateClass// : INotifyPropertyChanged
	{
		private DocumInfo _docInfo;
		
		public SheetAndSheetsGridCreateClass(DocumInfo di)
		{
			_docInfo = di;
		}

		/// <summary>
        /// Метод для создания таблицы "Лист/Листов"
        /// </summary>
        /// <returns>Grid</returns>
        internal Grid CreateSheetAndSheetsGrid()
        {
        	#region привязка
        	// Создание привязки
        	Binding binding = new Binding(/*path: "DocCode"*/);
        	binding.Mode = BindingMode.TwoWay;
        	binding.Path = new PropertyPath("docIVM.DocCode");
        	binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        	
            TextBox tBoxDocCode = new TextBox() { 
        		FontSize = 10,
        		HorizontalAlignment = HorizontalAlignment.Stretch,
        		VerticalAlignment = VerticalAlignment.Stretch,
        		Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)),
        		BorderThickness = new Thickness(2, 0, 2, 1),
        		BorderBrush = Brushes.Black
        	};
        	
        	// Установка привязки
        	BindingOperations.SetBinding(tBoxDocCode, TextBox.TextProperty, binding);
        	#endregion

        	#region	
            Grid.SetRow(tBoxDocCode, 0);
            Grid.SetColumn(tBoxDocCode, 0);
            Grid.SetColumnSpan(tBoxDocCode, 2);

            TextBox tSheet = new TextBox() 
            {
            	FontSize = 10, Text = "Лист",
            	HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)),
            	VerticalContentAlignment = VerticalAlignment.Center, HorizontalContentAlignment = HorizontalAlignment.Center,
            	BorderThickness = new Thickness(2, 1, 1, 1), BorderBrush = Brushes.Black
            };
            Grid.SetRow(tSheet, 1);
            Grid.SetColumn(tSheet, 0);

            TextBox tSheets = new TextBox() 
            {
            	FontSize = 10, HorizontalAlignment = HorizontalAlignment.Stretch,
            	VerticalAlignment = VerticalAlignment.Stretch,
            	Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)),
            	Text = "Листов", VerticalContentAlignment = VerticalAlignment.Center,
            	HorizontalContentAlignment = HorizontalAlignment.Center,
            	BorderThickness = new Thickness(1, 1, 2, 1),
            	BorderBrush = Brushes.Black
            };
            
            Grid.SetRow(tSheets, 1);
            Grid.SetColumn(tSheets, 1);

            TextBox tSheetNumber = new TextBox() 
            {
            	Name = "SheetsQuantity",
            	FontSize = 10,
            	HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch,
            	Background = Brushes.White,
            	Text = "1",
            	VerticalContentAlignment = VerticalAlignment.Center, HorizontalContentAlignment = HorizontalAlignment.Center,
            	BorderThickness = new Thickness(2, 1, 1, 2), BorderBrush = Brushes.Black
            };
            Grid.SetRow(tSheetNumber, 2);
            Grid.SetColumn(tSheetNumber, 0);

            #region привязка
        	// Создание привязки
        	Binding bindingSQ = new Binding(/*path: "DocCode"*/);
        	bindingSQ.Mode = BindingMode.TwoWay;
        	bindingSQ.Path = new PropertyPath("docIVM.DocSheetsQuantity");
        	bindingSQ.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TextBox tSheetsQuantity = new TextBox() 
            {
            	FontSize = 10,
            	HorizontalAlignment = HorizontalAlignment.Stretch,
            	VerticalAlignment = VerticalAlignment.Stretch,
            	Background = Brushes.White,
            	//Text = "кол-во листов",
            	VerticalContentAlignment = VerticalAlignment.Center,
            	HorizontalContentAlignment = HorizontalAlignment.Center,
            	BorderThickness = new Thickness(1, 1, 2, 2),
            	BorderBrush = Brushes.Black
            };
            Grid.SetRow(tSheetsQuantity, 2);
            Grid.SetColumn(tSheetsQuantity, 1);
            // Установка привязки
        	BindingOperations.SetBinding(tSheetsQuantity, TextBox.TextProperty, bindingSQ);
        	#endregion

            Grid sheetsAndSheet = new Grid() { ShowGridLines = false, HorizontalAlignment = HorizontalAlignment.Right };
            sheetsAndSheet.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            sheetsAndSheet.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            sheetsAndSheet.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            sheetsAndSheet.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(56.7) });
            sheetsAndSheet.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(75.6) });
            Grid.SetRow(sheetsAndSheet, 1);
            Grid.SetColumn(sheetsAndSheet, 1);
            sheetsAndSheet.Children.Add(tBoxDocCode);
            sheetsAndSheet.Children.Add(tSheet);
            sheetsAndSheet.Children.Add(tSheets);
            sheetsAndSheet.Children.Add(tSheetNumber);
            sheetsAndSheet.Children.Add(tSheetsQuantity);
            #endregion
            return sheetsAndSheet;
        }
        
        

	}
}

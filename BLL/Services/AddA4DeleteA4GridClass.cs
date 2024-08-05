/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:01
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Office.Interop.Word;
using watcherWPF_modified.BLL.ForSerialize;
using watcherWPF_modified.BLL.Services;
using watcherWPF_modified.BLL.Services.LogicMethods;

namespace watcherWPF_modified.BLL
{
	/// <summary>
	/// Description of AddA4DeleteA4Class.
	/// </summary>
	public class AddA4DeleteA4GridClass
	{
		public TechProcGridCreatingClass _techProcGridCreatingClass; 
		public Creating2x2GridClass _Creating2x2GridClass;
		public SheetAndSheetsGridCreateClass _SheetAndSheetsGridCreateClass;
		public StackCreatingClass _StackCreatingClass;
		A4CreatingClass _a4CreatingClass;
		StackPanel _techProcSP;
		DocumInfo _docInfo;
		A4Format _a4Format;
		
		
		public AddA4DeleteA4GridClass(DocumInfo di, A4Format format, StackPanel sp)
		{
			_docInfo = di;
			_a4Format = format;
			_techProcGridCreatingClass = new TechProcGridCreatingClass(sp);
			_Creating2x2GridClass = new Creating2x2GridClass();
			_SheetAndSheetsGridCreateClass = new SheetAndSheetsGridCreateClass(_docInfo);
			_StackCreatingClass = new StackCreatingClass();
			_a4CreatingClass = new A4CreatingClass(_a4Format);
			_techProcSP = sp;
		}
        public Grid AddA4DeleteA4(Grid curentGrid)
        {
        	
            #region Кнопки добавления/удаления листов
            //Создание кнопки "Добавить новый лист"
            Button button_AddNewList = new Button() { Height = 50, Width = 152, VerticalAlignment = VerticalAlignment.Bottom, Content = "Добавить Лист", Background = new SolidColorBrush(Colors.Bisque), BorderThickness = new Thickness(0, 5, 0, 5), BorderBrush = new SolidColorBrush(Color.FromArgb(255, 180, 120, 120)) };
            Grid.SetColumn(button_AddNewList, 0);
            button_AddNewList.Click += (s,e) => AddNewA4(s,e,_techProcSP);

            //Создание кнопки "Удалить лист"
            Button button_DeleteSheet = new Button() { Height = 50, Width = 152, VerticalAlignment = VerticalAlignment.Bottom, Content = "Удалить Лист", Background = new SolidColorBrush(Colors.Bisque), BorderThickness = new Thickness(0, 5, 0, 5), BorderBrush = new SolidColorBrush(Color.FromArgb(255, 180, 120, 120)) };
            Grid.SetColumn(button_DeleteSheet, 1);
            button_DeleteSheet.Click += (s,e) => DeleteSheet(s,e,curentGrid, _techProcSP);

            //создание Grid для кнопок добавления/удаления листов
            Grid gridForButton = new Grid() { VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Center };
            gridForButton.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            gridForButton.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            gridForButton.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridForButton.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridForButton.Children.Add(button_AddNewList);
            gridForButton.Children.Add(button_DeleteSheet);
            Grid.SetRow(gridForButton, curentGrid.RowDefinitions.Count-1);
            #endregion
            return gridForButton;
        }
        
        
        /// <summary>
        /// добавляет новый лист А4
        /// </summary>
        public void AddNewA4(object sender, RoutedEventArgs e, StackPanel sp)
        {
            //MessageBox.Show("asdasdasdasda!!!");
            if (sender is Button)
            {            	
            	CreateA4AndFillForTechProcess _createA4AndFillForTechProcess = new CreateA4AndFillForTechProcess(_docInfo, _a4Format, sp);
            	BrutForceIn2Tab brutForce = new BrutForceIn2Tab(sp);            	
            	sp.Children.Add(_createA4AndFillForTechProcess.CreateA4AndFill());
            	brutForce.BrutForceIn2TabMethod();
            }
            else
            {
                return;
            }
        }
        
        /// <summary>
        /// Удаляет лист А4
        /// </summary>
        public void DeleteSheet(object sender, RoutedEventArgs e, Grid currGrid, StackPanel sp)
        {
        	int rowIndex = 0;
        	
        	#region получение родительского элемента       	
        	Button clickedButton = sender as Button;
        	
        	if (clickedButton != null)
        	{
        		Grid parentGrid = (Grid)clickedButton.Parent;
        		Grid mainGrid = (Grid)parentGrid.Parent;
        		
        		if (mainGrid != null)
        		{
        			rowIndex = Grid.GetRow(parentGrid);
        		}
        	}
        	#endregion
        	
        	#region Удаление содержимого и перемещение элементов
        	if (rowIndex >= 0)
        	{
        		// Сохраняем индексы элементов для удаления
        		List<int> elementsToRemove = new List<int>();
        		for (int i = 0; i < currGrid.Children.Count; i++)
        		{
        			UIElement child = currGrid.Children[i];
        			if (Grid.GetRow(child) == rowIndex)
        			{
        				elementsToRemove.Add(i);
        			}
        		}
        		
        		// Удаляем содержимое текущей строки
        		for (int i = elementsToRemove.Count - 1; i >= 0; i--)
        		{
        			currGrid.Children.RemoveAt(elementsToRemove[i]);
        		}     		

        		// Теперь все элементы в строках под второй переместим на одну строку вверх
        		for (int i = 0; i < currGrid.Children.Count; i++)
        		{
        			UIElement child = currGrid.Children[i];
        			
        			if (Grid.GetRow(child) > rowIndex) // Сдвигаем всё, что ниже второй строки
        			{
        				Grid.SetRow(child, Grid.GetRow(child) - 1);
        			}
        		}
        		
        		// Удаляем последнюю строку, если она пустая
        		if (currGrid.RowDefinitions.Count > 0)
        		{
        			int lastRowIndex = currGrid.RowDefinitions.Count - 1;
        			
        			// Проверяем, есть ли элементы в последней строке
        			bool isLastRowEmpty = true;
        			for (int i = 0; i < currGrid.Children.Count; i++)
        			{
        				if (Grid.GetRow(currGrid.Children[i]) == lastRowIndex)
        				{
        					isLastRowEmpty = false;
        					break;
        				}
        			}
        			
        			// Если последняя строка пустая, удаляем её
        			if (isLastRowEmpty)
        			{
        				currGrid.RowDefinitions.RemoveAt(lastRowIndex);
        				currGrid.Height = currGrid.RowDefinitions.Count * 793.7; // Обновляем высоту грида
        			}
        		}        		
        	}
        	#endregion
        	BrutForceIn2Tab brutForce = new BrutForceIn2Tab(sp); 
        	brutForce.BrutForceIn2TabMethod();
        }
	}
}

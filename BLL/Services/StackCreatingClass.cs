/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:02
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace watcherWPF_modified.BLL
{
	/// <summary>
	/// Description of StackCreatingClass.
	/// </summary>
	public class StackCreatingClass
	{
		 /// <summary>
        /// Создание StackPanel c TextBoxa'ами
        /// </summary>
        /// <param name="currentGrid"></param>
        internal StackPanel CreateStackPanelIntoTeckProcesstable()
        {
            StackPanel newStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0,0,0,0),
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                IsEnabled = true,
                Name = "stackPanel",
                Background = Brushes.Blue
            };

            #region  создание textBox'ов для Grid в stackLayout
            TextBox textBoxSP1 = new TextBox() { MinHeight = 18.9, HorizontalAlignment = HorizontalAlignment.Stretch, Text = "", BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2), FontSize = 10, HorizontalContentAlignment = HorizontalAlignment.Left };
            TextBox textBoxSP2 = new TextBox() 
            {
            	MinHeight = 18.9,
            	HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, Text = "",
            	BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2), Margin = new Thickness(0, 0, 0, 0),
            	FontSize = 10
            };
            //textBoxSP1.KeyDown += OnTextBoxKeyDown;
            //или так
            textBoxSP1.AddHandler(TextBox.KeyDownEvent, new KeyEventHandler(AddTextBoxIntoStackPanel));
            textBoxSP1.TextWrapping = TextWrapping.Wrap;
            textBoxSP1.AcceptsReturn = false;

            textBoxSP2.AddHandler(TextBox.KeyDownEvent, new KeyEventHandler(AddTextBoxIntoStackPanel));
            textBoxSP2.TextWrapping = TextWrapping.Wrap;
            textBoxSP2.AcceptsReturn = false;
            Grid.SetColumn(textBoxSP1, 0);
            Grid.SetColumn(textBoxSP2, 1);
            #endregion

            #region добавление в newStackPanel новой таблицы (newGridIntoStack[textBoxSP1|textBoxSP2])
            Grid newGridIntoStack = new Grid() { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, Margin = new Thickness(0) };
            newGridIntoStack.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(158.7) });
            newGridIntoStack.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(34.0) });
            newGridIntoStack.Children.Add(textBoxSP1);
            newGridIntoStack.Children.Add(textBoxSP2);

            newStackPanel.Children.Add(newGridIntoStack);
            #endregion
            return newStackPanel;
        }

        ///<summary>
        ///добавление textbox'ов в StackPanel
        ///</summary>
        private void AddTextBoxIntoStackPanel(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
					Grid grid = new Grid() { };
					TextBox txt1 = new TextBox() { Name = "toolsCell", FontSize = 10, MinHeight = 18.9, HorizontalAlignment = HorizontalAlignment.Stretch, Margin = new Thickness(0, 0, 0, 0), BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2), HorizontalContentAlignment = HorizontalAlignment.Left };
					txt1.AddHandler(TextBox.KeyDownEvent, new KeyEventHandler(AddTextBoxIntoStackPanel));
					txt1.TextWrapping = TextWrapping.Wrap;
					txt1.AcceptsReturn = false;
					
					TextBox txt2 = new TextBox() { Name = "quantityCell", FontSize = 10, MinHeight = 18.9, HorizontalAlignment = HorizontalAlignment.Stretch, Margin = new Thickness(0, 0, 0, 0), BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2), HorizontalContentAlignment = HorizontalAlignment.Center };
					txt2.AddHandler(TextBox.KeyDownEvent, new KeyEventHandler(AddTextBoxIntoStackPanel));
					txt2.TextWrapping = TextWrapping.Wrap;
					txt2.AcceptsReturn = false;
					
					grid.RowDefinitions.Add(new RowDefinition() /*{Height = new GridLength(1, GridUnitType.Star) }*/);
					grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(158.7) });
					grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(37.0) });
					grid.Children.Add(txt1);
					grid.Children.Add(txt2);
					Grid.SetColumn(txt2, 1);

					Grid parentGrid = (sender as TextBox).Parent as Grid;
					StackPanel stPanel = parentGrid.Parent as StackPanel;
					stPanel.Children.Add(grid);
            }
        }
	}
}

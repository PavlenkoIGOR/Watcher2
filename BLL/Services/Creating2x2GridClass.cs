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
using System.Windows.Media;

namespace watcherWPF_modified.BLL
{
	/// <summary>
	/// Description of Creating2x2GridClass.
	/// </summary>
	public class Creating2x2GridClass
	{
		internal Grid Creating2x2Grid(/*Grid headGrid*/)
        {
            TextBox textBox = new TextBox() 
            {
            	Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)),
            	VerticalAlignment = VerticalAlignment.Stretch,
            	HorizontalAlignment = HorizontalAlignment.Stretch,
            	Text = "6",
            	VerticalContentAlignment = VerticalAlignment.Center,
            	HorizontalContentAlignment = HorizontalAlignment.Center,
            	BorderBrush = Brushes.Black,
            	BorderThickness = new Thickness(2,2,1,1)
            };
            
            Grid.SetRow( textBox, 0 );
            Grid.SetColumn( textBox, 0 );

            Grid dvaNaDvaGrid = new Grid()
            {
                Name = "dvaNaDvaGrid",
                Background = new SolidColorBrush(Colors.Aqua),
                Margin = new Thickness(30, 50, 30, 30),
                ShowGridLines = false,
                VerticalAlignment = VerticalAlignment.Top
            };

            //mainGrid.Children.Add(headGrid);

            dvaNaDvaGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            dvaNaDvaGrid.RowDefinitions.Add(new RowDefinition() /*{ Height = new GridLength(1, GridUnitType.Auto) }*/);
            dvaNaDvaGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30) });
            dvaNaDvaGrid.ColumnDefinitions.Add(new ColumnDefinition());
            dvaNaDvaGrid.Children.Add( textBox );
            return dvaNaDvaGrid;
        }
	}
}

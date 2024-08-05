/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/30/2024
 * Time: 16:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace watcherWPF_modified.BLL.Services.SchemasPages
{
	/// <summary>
	/// Description of SchemasCreator.
	/// </summary>
	internal class SchemasGridCreator
	{
		private A4Format _a4Format;
		internal SchemasGridCreator(A4Format a4Format)
		{
			_a4Format = a4Format;
		}
		
		internal Grid CreateGridForSchema()
		{
			Grid schemasGrid = new Grid();
			schemasGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
			schemasGrid.VerticalAlignment = VerticalAlignment.Stretch;
			schemasGrid.Background = Brushes.BurlyWood;
			schemasGrid.Margin = new Thickness(50, 30, 30, 30);
			schemasGrid.ShowGridLines = true;
			
			schemasGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            schemasGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            schemasGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            schemasGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            

			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30) });
			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(38) });
			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(90) });
			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60) });
			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(38) });
			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star), MinWidth = 30 });
			schemasGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40) });

			
			#region RichTB
			RichTextBox rtb00 = new RichTextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};

			Grid.SetColumn(rtb00,0);
			Grid.SetColumnSpan(rtb00, 7);
			Grid.SetRow(rtb00,0);
			#endregion
			
			#region 2 строка
			#region TextBox tb01
			TextBox tb01 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb01,0);
			Grid.SetRow(tb01,1);
			#endregion
			
			#region TextBox tb11
			TextBox tb11 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb11,1);
			Grid.SetRow(tb11,1);
			#endregion
			
			#region TextBox tb21
			TextBox tb21 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb21,2);
			Grid.SetRow(tb21,1);
			#endregion
			
			#region TextBox tb31
			TextBox tb31 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb31,3);
			Grid.SetRow(tb31,1);
			#endregion
			
			#region TextBox tb41
			TextBox tb41 = new TextBox()
			{
				FontSize = 10, 
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb41,4);
			Grid.SetRow(tb41,1);
			#endregion
			
			#region TextBox tb61
			TextBox tb61 = new TextBox()
			{
				FontSize = 10, Text = "Лист",
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb61,6);
			Grid.SetRow(tb61,1);
			#endregion
			#endregion
			
			#region 3 строка
			#region tb02
						TextBox tb02 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb02,0);
			Grid.SetRow(tb02,2);
			#endregion
			
			#region tb12
			TextBox tb12 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb12,1);
			Grid.SetRow(tb12,2);
			#endregion
			
			#region tb22
			TextBox tb22 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb22,2);
			Grid.SetRow(tb22,2);
			#endregion
			
			#region tb32
			TextBox tb32 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb32,3);
			Grid.SetRow(tb32,2);
			#endregion
			
			#region tb42
			TextBox tb42 = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb42,4);
			Grid.SetRow(tb42,2);
			#endregion
			
			#region tb62
			TextBox tb62 = new TextBox()
			{
				FontSize = 10, Text = "",
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb62,6);
			Grid.SetRow(tb62,2);
			Grid.SetRowSpan(tb62,2);
			#endregion
			#endregion
			
			#region 4 строка
			#region TextBox tb03
			TextBox tb03 = new TextBox()
			{
				FontSize = 10, Text = "Изм.",
				BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black, Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb03,0);
			Grid.SetRow(tb03,3);
			#endregion
			
			#region TextBox tb13
			TextBox tb13 = new TextBox()
			{
				FontSize = 10, Text = "Лист",
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb13,1);
			Grid.SetRow(tb13,3);
			#endregion
			
			#region TextBox tb23
			TextBox tb23 = new TextBox()
			{
				FontSize = 10, Text = "№ Докум.",
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb23,2);
			Grid.SetRow(tb23,3);
			#endregion
			
			#region TextBox tb33
			TextBox tb33 = new TextBox()
			{
				FontSize = 10, Text = "Подпись",
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb33,3);
			Grid.SetRow(tb33,3);
			#endregion
			
			#region TextBox tb43
			TextBox tb43 = new TextBox()
			{
				FontSize = 10, Text = "Дата",
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			Grid.SetColumn(tb43,4);
			Grid.SetRow(tb43,3);
			#endregion
			#endregion
			
			#region tb_DocName
			// Создание привязки
        	Binding tb_DocName_binding = new Binding(/*path: "DocCode"*/);
        	tb_DocName_binding.Mode = BindingMode.TwoWay;
        	tb_DocName_binding.Path = new PropertyPath("DocCode");
        	tb_DocName_binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

        	TextBox tb_DocName = new TextBox()
			{
				FontSize = 10,
				BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black,
				Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center
			};			
			
			Grid.SetColumn(tb_DocName,5);
			Grid.SetRow(tb_DocName,1);
			Grid.SetRowSpan(tb_DocName,3);
			// Установка привязки
        	BindingOperations.SetBinding(tb_DocName, TextBox.TextProperty, tb_DocName_binding);
			#endregion
			
			schemasGrid.Children.Add(rtb00);
			schemasGrid.Children.Add(tb01);
			schemasGrid.Children.Add(tb11);
			schemasGrid.Children.Add(tb21);
			schemasGrid.Children.Add(tb31);
			schemasGrid.Children.Add(tb41);
			schemasGrid.Children.Add(tb61);
			
			schemasGrid.Children.Add(tb02);
			schemasGrid.Children.Add(tb12);
			schemasGrid.Children.Add(tb22);
			schemasGrid.Children.Add(tb32);
			schemasGrid.Children.Add(tb42);
			schemasGrid.Children.Add(tb62);
			
			schemasGrid.Children.Add(tb03);
			schemasGrid.Children.Add(tb13);
			schemasGrid.Children.Add(tb23);
			schemasGrid.Children.Add(tb33);
			schemasGrid.Children.Add(tb43);
			
			schemasGrid.Children.Add(tb_DocName);

            return schemasGrid;
		}
	}
}

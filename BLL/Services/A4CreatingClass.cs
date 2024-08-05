/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:01
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
	/// Description of A4CreatingClass.
	/// </summary>
	public class A4CreatingClass
	{
		private A4Format A4Size;
		public Grid A4;
		public int SheetNumber;
		
        public A4CreatingClass(A4Format A4Hor) 
        {
        	A4Size = A4Hor;
        }
        public Grid CreatA4()
        {
            A4 = new Grid() { 
        		VerticalAlignment = VerticalAlignment.Top,
        		HorizontalAlignment = HorizontalAlignment.Center,
        		Height = A4Size.A4HeightHoriz,
        		Width = A4Size.A4WidthHoriz,
        		Name = "A4",
        		ShowGridLines = true
        	};
            A4.RowDefinitions.Add(new RowDefinition());
            A4.ColumnDefinitions.Add(new ColumnDefinition());
            return A4;
        }
	}
}

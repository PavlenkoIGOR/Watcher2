/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:17
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified
{
    /// <summary>
    /// Логика взаимодействия для TitlePage.xaml
    /// </summary>
	public partial class TitlePage : Page
	{
		internal DocumInfo docInfo;

		#region для масштабирования рабочего поля
		private double scale = 1.0;
		#endregion
		
		public TitlePage(DocumInfo dInfo)
		{
			docInfo = dInfo;
			InitializeComponent();
		}
		private void Click_func(object sender, MouseButtonEventArgs e)
		{
			switch ((sender as Grid).Name)
			{
				case ("A4"):
					A4.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(793.7) });
					A4.Height += 793.7;
					A4.ShowGridLines = true;
					break;
			}
		}

		#region для масштабирования рабочего поля
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) {
				// Отменяем стандартное поведение прокрутки
				e.Handled = true;

				// Меняем масштаб
				if (e.Delta > 0)
				{
					scale *= 1.1; // Увеличиваем масштаб
				}
				else
				{
					scale /= 1.1; // Уменьшаем масштаб
				}

				// Применяем масштаб к содержимому
				A4.LayoutTransform = new ScaleTransform(scale, scale);
			}
		}
		#endregion
		
		private void myTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				(sender as TextBox).AppendText(Environment.NewLine); // Вставить символ новой строки
				e.Handled = true; // Предотвратить добавление символа Enter в текстовое содержимое
			}
		}
	}
}
/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:03
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using watcherWPF_modified.BLL.Services.LogicMethods;
using AppC = watcherWPF_modified.BLL.Services.AppController;


namespace watcherWPF_modified.BLL
{
	/// <summary>
	/// Description of TechProcGridCreatingClass.
	/// </summary>
	public class TechProcGridCreatingClass
	{
		public int NumOfRow = 1;        
		StackPanel mainSP;
        internal TechProcGridCreatingClass(StackPanel mainSPan)
        {            
        	mainSP = mainSPan;
        }

        #region метод для заполнения нового листа
        /// <summary>
        /// метод для заполнения нового листа
        /// </summary>
        /// <returns>new Grid</returns>
        internal Grid CreateMainTable()
        {
            //Создание "Основные и вспомогательные производственные операции и их последовательность"
            TextBox tb_OpAndFoll = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 2, 2, 1), BorderBrush = Brushes.Black, Text = "Основные и вспомогательные производственные операции и их последовательность", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center };
            Grid.SetRow(tb_OpAndFoll, 0);
            Grid.SetColumn(tb_OpAndFoll, 0);
            Grid.SetColumnSpan(tb_OpAndFoll, 8);

            //Создание №п/п
            TextBox tb_PP = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "№   п/п", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_PP, 1);
            Grid.SetColumn(tb_PP, 0);
            Grid.SetRowSpan(tb_PP, 2);

            //Создание "Наименование операции"
            TextBox tb_OperName = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Наименование операции", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_OperName, 1);
            Grid.SetColumn(tb_OperName, 1);
            Grid.SetRowSpan(tb_OperName, 2);

            //Создание "Исполнитель"
            TextBox tb_Executor = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Исполнитель", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_Executor, 1);
            Grid.SetColumn(tb_Executor, 2);
            Grid.SetRowSpan(tb_Executor, 2);

            //Создание "Оборудование, оснастка, инструмент"
            TextBox tb_ToolToolTool = new TextBox() 
            {
            	FontSize = 10,
            	Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)),
            	BorderThickness = new Thickness(1, 1, 1, 1),
            	BorderBrush = Brushes.Black,
            	TextWrapping = TextWrapping.Wrap,
            	Text = "Оборудование, оснастка, инструмент",
            	Margin = new Thickness(0, 0, 0, 0),
            	VerticalAlignment = VerticalAlignment.Stretch,
            	HorizontalAlignment = HorizontalAlignment.Stretch,
            	HorizontalContentAlignment = HorizontalAlignment.Center,
            	VerticalContentAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(tb_ToolToolTool, 1);
            Grid.SetColumn(tb_ToolToolTool, 3);
            Grid.SetColumnSpan(tb_ToolToolTool, 3);

            //Сощдание "Позиция на схеме"
            TextBox tb_PsitionOnSchema = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Позиция на схеме", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_PsitionOnSchema, 2);
            Grid.SetColumn(tb_PsitionOnSchema, 3);

            //Создание "Наименование"
            TextBox tb_Name = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Наименование", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_Name, 2);
            Grid.SetColumn(tb_Name, 4);

            //Создание "Кол-во"
            TextBox tb_Quantites = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Кол-во", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_Quantites, 2);
            Grid.SetColumn(tb_Quantites, 5);

            //Создание "Мероприятия"
            TextBox tb_Meropr = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 1, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Мероприятия по безопасному выполнению работ", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_Meropr, 1);
            Grid.SetColumn(tb_Meropr, 6);
            Grid.SetRowSpan(tb_Meropr, 2);

            //Создание "Опасные и вредные производственные факторы"
            TextBox tb_Dangerous = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 2, 1), BorderBrush = Brushes.Black, TextWrapping = TextWrapping.Wrap, Text = "Опасные и вредные производственные факторы", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb_Dangerous, 1);
            Grid.SetColumn(tb_Dangerous, 7);
            Grid.SetRowSpan(tb_Dangerous, 2);

            //создание tb6_2
            TextBox tb6_2 = new TextBox() { FontSize = 10, Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), BorderThickness = new Thickness(1, 1, 2, 2), BorderBrush = Brushes.Black, Text = "6.2 Выполнение работы", Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetRow(tb6_2, 4);
            Grid.SetColumn(tb6_2, 0);
            Grid.SetColumnSpan(tb6_2, 8);

            //таблица с Т.П.
            Grid headGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch, ShowGridLines = false };
            headGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            headGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            headGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            headGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            headGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(18.9) });
            headGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(270) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(124) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(49) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(158.7) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(34) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(184) });
            headGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            Grid.SetRow(headGrid, 0);
            Grid.SetColumn(headGrid, 1);
            headGrid.Children.Add(tb6_2);
            headGrid.Children.Add(tb_OpAndFoll);
            headGrid.Children.Add(tb_PP);
            headGrid.Children.Add(tb_OperName);
            headGrid.Children.Add(tb_Executor);
            headGrid.Children.Add(tb_ToolToolTool);
            headGrid.Children.Add(tb_PsitionOnSchema);
            headGrid.Children.Add(tb_Name);
            headGrid.Children.Add(tb_Quantites);
            headGrid.Children.Add(tb_Meropr);
            headGrid.Children.Add(tb_Dangerous);
            //headGrid.Children.Add(_stackCreatingClass.CreateStackPanelIntoTeckProcesstable(headGrid));
            CreateTextBox1_2_3_4_7_8(headGrid); //заполнение textBox'ам
            //_stackCreatingClass.AddStackPanelIntoTeckProcesstable(headGrid); //создание StackPanel в таблице с Т.П.

            //создание Textbox'ов 1-8 под номера колонок в шапке
            for (int i = 0; i < headGrid.ColumnDefinitions.Count; i++)
            {
                TextBox textBox = new TextBox() { 
            		FontSize = 10,
            		VerticalContentAlignment = VerticalAlignment.Center,
            		HorizontalContentAlignment = HorizontalAlignment.Center,
            		Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180)), Text = Convert.ToString(i + 1),
            		Margin = new Thickness(0, 0, 0, 0), VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch,
            		BorderBrush = Brushes.Black,
            		BorderThickness = new Thickness(1, 1, 1, 1)
            	};
                Grid.SetRow(textBox, 3);
                Grid.SetColumn(textBox, i);
                headGrid.Children.Add(textBox);
            }

            return headGrid;
        }
        #endregion

        /// <summary>
        /// Метод создания textBox'ов в колонки 1-4,7,8
        /// </summary>
        private void CreateTextBox1_2_3_4_7_8(Grid currentGrid)
        {
            //1
            TextBox textBox_1 = new TextBox() { 
            	Name="NumOfRow",
            	AcceptsReturn = true,
            	MinHeight = 18.9,
            	HorizontalAlignment = HorizontalAlignment.Stretch,
            	VerticalAlignment = VerticalAlignment.Stretch,
            	Margin = new Thickness(0, 0, 0, 0),
            	Text = "1",
            	VerticalContentAlignment=VerticalAlignment.Top,
            	HorizontalContentAlignment=HorizontalAlignment.Center,
            	BorderBrush = Brushes.Black,
            	BorderThickness = new Thickness(1, 0, 1, 2),
            	FontSize = 10,
            	TextWrapping = TextWrapping.Wrap 
            };
            
            Grid.SetColumn(textBox_1, 0);
            Grid.SetRow(textBox_1, currentGrid.RowDefinitions.Count - 1);
            currentGrid.Children.Add(textBox_1);
            
            AppC.TBForPP tbForPP = new AppC.TBForPP();
            tbForPP.num++;
            tbForPP.TB = textBox_1;
            AppC.NumeratorTBForPP.TBForPPList.Add(tbForPP);
            
            #region textBox_2 - поле для операции
            TextBox textBox_2 = new TextBox() { 
            	AcceptsReturn = true,
            	MinHeight = 18.9,
            	HorizontalAlignment = HorizontalAlignment.Stretch,
            	VerticalAlignment = VerticalAlignment.Stretch,
            	Margin = new Thickness(0, 0, 0, 0),
            	Text = "Новая операция",
            	BorderBrush = Brushes.Black,
            	BorderThickness = new Thickness(1, 0, 1, 2),
            	FontSize = 10,
            	TextWrapping = TextWrapping.Wrap
            };
            
            textBox_2.SpellCheck.IsEnabled = true;
            Grid.SetColumn(textBox_2, 1);
            Grid.SetRow(textBox_2, currentGrid.RowDefinitions.Count - 1);

            ContextMenu textBox2_ContextMenu = new ContextMenu();
            MenuItem textBox2_ContextMenu_ContextMenuItem = new MenuItem();
            textBox2_ContextMenu_ContextMenuItem.Header = "Добавить строку с тех.процессом";
            textBox2_ContextMenu_ContextMenuItem.Click += AddRow;
            //textBox_2ContextMenuContextMenuItem.IsCheckable = true; //ставит галочку
            //textBox_2ContextMenuContextMenuItem.Checked=; //если поставлена галочка, то ...
            //textBox_2ContextMenuContextMenuItem.Unchecked=; //если убирается галочка, то ...
            textBox2_ContextMenu.Items.Add(textBox2_ContextMenu_ContextMenuItem);
            textBox_2.ContextMenu = textBox2_ContextMenu; //"Добавить строку с тех.процессом";

            currentGrid.Children.Add(textBox_2);
            #endregion
            //3
            TextBox textBox_3 = new TextBox() { AcceptsReturn = true, MinHeight = 18.9, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Margin = new Thickness(0, 0, 0, 0), Text = "Должности", BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2), FontSize = 10, TextWrapping = TextWrapping.Wrap };
            Grid.SetColumn(textBox_3, 2);
            Grid.SetRow(textBox_3, currentGrid.RowDefinitions.Count - 1);
            currentGrid.Children.Add(textBox_3);
            //4
            TextBox textBox_4 = new TextBox() { AcceptsReturn = true, MinHeight = 18.9, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Margin = new Thickness(0, 0, 0, 0), Text = "", BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2), FontSize = 10, TextWrapping = TextWrapping.Wrap };
            Grid.SetColumn(textBox_4, 3);
            Grid.SetRow(textBox_4, currentGrid.RowDefinitions.Count - 1);
            currentGrid.Children.Add(textBox_4);
            //7
            TextBox textBox_7 = new TextBox() 
            {
            	AcceptsReturn = true, TextWrapping = TextWrapping.Wrap, Text = "", FontSize = 10,
            	MinHeight = 18.9,
            	HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Margin = new Thickness(0, 0, 0, 0),            	
            	BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 2)            	
            };
            Grid.SetColumn(textBox_7, 6);
            Grid.SetRow(textBox_7, currentGrid.RowDefinitions.Count - 1);
            currentGrid.Children.Add(textBox_7);
            //8
            TextBox textBox_8 = new TextBox() { AcceptsReturn = true, MinHeight = 18.9, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Margin = new Thickness(0, 0, 0, 0), Text = "", BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 2, 2), FontSize = 10, TextWrapping = TextWrapping.Wrap };
            Grid.SetColumn(textBox_8, 7);
            Grid.SetRow(textBox_8, currentGrid.RowDefinitions.Count - 1);
            currentGrid.Children.Add(textBox_8);
        }

        ///<summary>
        ///Добавление новой строки c textBox'ами 1-4,7,8 в таблицу с Т.п. c 
        ///</summary>
        internal void AddRow(object sender, RoutedEventArgs e)
        {
        	BrutForceIn2Tab bForce = new BrutForceIn2Tab(mainSP);
        	
            // Получаем контекстное меню, которое вызвало событие
            ContextMenu contextMenu = ((MenuItem)sender).Parent as ContextMenu;

            // Получаем TextBox, которому принадлежит контекстное меню
            TextBox textBox = contextMenu.PlacementTarget as TextBox;
            Grid parentGrid = textBox.Parent as Grid;
            parentGrid.RowDefinitions.Add(new RowDefinition() { });
            parentGrid.Height += 18.9;

            StackCreatingClass newSP = new StackCreatingClass();
            StackPanel newStackPanel = newSP.CreateStackPanelIntoTeckProcesstable();
            Grid.SetRow(newStackPanel, parentGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(newStackPanel, 4);
            Grid.SetColumnSpan(newStackPanel, 2);

            parentGrid.Children.Add(newStackPanel);

            #region создание textBox'ов в колонки 1-4,7,8
            CreateTextBox1_2_3_4_7_8(parentGrid);
            #endregion
            bForce.BrutForceIn2TabMethod();
        }
	}
}

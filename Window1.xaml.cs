/*
 * Создано в SharpDevelop.
 * Пользователь: pavlenko_i_l
 * Дата: 09.10.2023
 * Время: 9:00
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using watcherWPF_modified.BLL.ForSerialize;
using watcherWPF_modified.BLL.Services;
using watcherWPF_modified.BLL.Services.AppController;
using watcherWPF_modified.BLL.Services.LogicMethods;
using watcherWPF_modified.BLL.Services.LogicMethods.SaveLoad;
using watcherWPF_modified.BLL.ViewModel;
using watcherWPF_modified.BLL;
using WRD = Microsoft.Office.Interop.Word;


namespace watcherWPF_modified
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private DocumInfo _documInfo;
		
		//для работы с текстбоксами "NumOfRow"
		List<TextBox> NumsOfRowsList = new List<TextBox>();
		int countTB = 1;
		A4Format _A4Form;
		SheetAndSheetsGridCreateClass _sheetsAndSheet;
		StackCreatingClass _stackCreatingClass;
		TechProcGridCreatingClass _fotTechProcTab;
		TitlePage titlePage;
		SchemasPages schemasPages;
		A4CreatingClass _A4CreatingClass;
		Creating2x2GridClass _creating2x2GridClass;
		AddA4DeleteA4GridClass _addA4DeleteA4Class;
		StackPanel _mainSP;
		CreateA4AndFillForTechProcess _createA4AndFillForTechProcess;
		
		SaveClass _saveClass; //для сохранения документа
		BrutForceIn2Tab brutForceIn2Tab;
		
		#region для масштабирования рабочего поля
		private double scale = 1.0;
		#endregion
		RichTBViewModel _rTVM;
		TexBViewModel _tBVM;
		DocumInfoViewModel _docInfoVM;

		public Window1()
		{
			InitializeComponent();
			
			_mainSP = FindName("TechProcSP") as StackPanel;
			_documInfo = new DocumInfo();
			_A4Form = new A4Format();

			_A4CreatingClass = new A4CreatingClass(_A4Form);
			_sheetsAndSheet = new SheetAndSheetsGridCreateClass(_documInfo);
			_stackCreatingClass = new StackCreatingClass();
			_fotTechProcTab = new TechProcGridCreatingClass(_mainSP);
			_creating2x2GridClass = new Creating2x2GridClass();
			_addA4DeleteA4Class = new AddA4DeleteA4GridClass(_documInfo, _A4Form, _mainSP);
			_createA4AndFillForTechProcess = new CreateA4AndFillForTechProcess(_documInfo, _A4Form, _mainSP);
			
			#region SaveLoad
			_saveClass = new SaveClass(_mainSP);
			brutForceIn2Tab = new BrutForceIn2Tab(_mainSP);
			#endregion
			
			
			titlePage = new TitlePage(_documInfo);
			schemasPages = new SchemasPages(_A4Form, _documInfo);
			//forTitlePage.Source = new Uri("TitlePage.xaml", UriKind.Relative); //эта строка подключает свой Page. В данный момент не нужна т.к. подключается сейчас через InputPage().
			InputPage();
			
			InsertA4IntoStackPanel();
			SaveAsWRD.Click += (s, e) => SaveGridToWord(_fotTechProcTab.CreateMainTable());
			SaveMy.Click += (s, e) => RecursivelyProcessVisualTree();
			
			_rTVM = new RichTBViewModel(_documInfo);
			_tBVM = new TexBViewModel();			
			_docInfoVM = new DocumInfoViewModel(_documInfo);
			//this.DataContext = _rTVM;
			//this.DataContext = new TexBViewModel();			
			this.DataContext = new MainViewModel(_tBVM, _rTVM, _docInfoVM);
			//this.DataContext = _docInfoVM;
		}
		
		/// <summary>
		/// метод для сохранения документа
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SerializerDocument(object sender, RoutedEventArgs e)
		{
			_saveClass.SaveDocument();
		}
		
		/// <summary>
		/// метод для подключения своих Frame
		/// </summary>
		private void InputPage()
		{
			//MainWindow mainWindow = new MainWindow();
			Frame mainFrame = this.FindName("forTitlePage") as Frame; // Найдите элемент Frame в главном окне
			Frame schemasFrame = this.FindName("schemasFrame") as Frame;
			mainFrame.Navigate(titlePage); // Загружает свою страницу во Frame
			schemasFrame.Navigate(schemasPages); // Загружает свою страницу во Frame
			this.Show(); // Отображаете главное окно
		}



		#region сегодня это не нужно
		/// <summary>
		/// Метод вставки А4 во вкладку
		/// </summary>
		private void InsertA4IntoStackPanel()
		{
			_mainSP.Children.Add(_createA4AndFillForTechProcess.CreateA4AndFill());
		}

		//перебор элементов !!!!!!!!!!!!!!!!!!!!Этот метод можно использовать для сериализации всех данных отрисовки в иерархии визуального объекта.
		/// <summary>
		/// Метод, устанавливающий номера строк с ТП - где он?
		/// </summary>
		List<UIElement> elementsMain = new List<UIElement>();
		public void RecursivelyProcessVisualTree()
		{
			TabControl tabControl = this.FindName("myTabControl") as TabControl;
			if (tabControl != null) {
				MyTraverse.TraverseElements(tabControl, elementsMain);
			}
			
			MyTraverse.TraverseElements(tabControl, elementsMain);
			MyCreateFile.MyCreateFileMethod(elementsMain);
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
				_mainSP.LayoutTransform = new ScaleTransform(scale, scale);
			}
		}
		#endregion
		
		private void Renew(object sender, RoutedEventArgs e)
		{
			Dictionary<string, string> tools = new Dictionary<string, string>();
			string textBox1Value = String.Empty;
			string textBox2Value = String.Empty;
			int Count = 0;
			
			for (int i = 0; i <_mainSP.Children.Count; i++)//int i = 0; i < _mainSP.Children.Count; i++)//перебор всех А4 в StackPanel
			{		
				if (_mainSP.Children[i] is Grid)
				{
					Grid a4 = (Grid)(_mainSP.Children[i]);
					foreach (UIElement elemenTabMain in a4.Children) { //перебор элементов//********* ((Grid)A4_2.Children[rowIndexM]).Children
						if (elemenTabMain is Grid) { //здесь таблица dvaNaDvaGrid (в ней уже надо искать таблицу tableWithTechProc)
							foreach (UIElement elementTP in (elemenTabMain as Grid).Children) {
								if (elementTP is Grid) {
									foreach (UIElement element in (elementTP as Grid).Children) { //перечисление всех дочерних элементов у tableWithTechProc таблицы
										if (element is StackPanel) {
											Count++;
											foreach (UIElement grid in ((StackPanel)element).Children) { //переборка всех гридов в StackPanel
												if (grid is Grid) {
													for (int rowIndex = 0; rowIndex <= ((Grid)grid).RowDefinitions.Count; rowIndex++) {
														TextBox textBoxColumn1 = ((Grid)grid).Children.Cast<TextBox>().FirstOrDefault(c => Grid.GetRow(c) == rowIndex && Grid.GetColumn(c) == 0);
														TextBox textBoxColumn2 = ((Grid)grid).Children.Cast<TextBox>().FirstOrDefault(a => Grid.GetRow(a) == rowIndex && Grid.GetColumn(a) == 1);
														if (textBoxColumn1 != null) {
															tools[textBoxColumn1.Text] = textBoxColumn2.Text;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}					
				}
			countTB = 0;
			titlePage.mainToolsList.Clear();
			StringBuilder sb = new StringBuilder(titlePage.mainToolsList.Text);
			foreach (var item in tools) {
				if ((item.Key != String.Empty) && (item.Value != String.Empty)) {
					sb.AppendLine(item.Key + ", шт. - " + item.Value);
					titlePage.mainToolsList.Text = sb.ToString();
				} else if ((item.Key != String.Empty) && (item.Value == String.Empty)) {
					sb.AppendLine(item.Key);
					titlePage.mainToolsList.Text = sb.ToString();
				}
			}
			sb.Clear();
			}
			
//			for (int elemen = 0; elemen < NumeratorTBForPP.TBForPPList.Count; elemen++) {
//				NumeratorTBForPP.TBForPPList[elemen].TB.Text = (elemen + 1).ToString();
//			}
//			MessageBox.Show(NumeratorTBForPP.TBForPPList.Count.ToString());
			brutForceIn2Tab.BrutForceIn2TabMethod();
		}

		/// <summary>
		/// Метод для добавления миниатюр А4 с дочерними элементами
		/// </summary>
		private void Click_func2(object sender, RoutedEventArgs e)
		{
			violetGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(250) });
			violetGrid.Height += 250;
			violetGrid.ShowGridLines = true;
		}

		/// <summary>
		/// Метод проверки в TextBox'е ли каретка
		/// </summary>
		private void GetCursor(object sender, EventArgs e)
		{
			//Проверка в textbox'е ли каретка
			if ((sender as TextBox).IsKeyboardFocused) {
				string thisBoxName = (sender as TextBox).Name;

				titlePage.ActualDocsGrid.Text += thisBoxName;
			}
		}


		private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			// Выполнить нужное действие при получении фокуса клавиатуры, например, задать команду для вызова
			var focusedElement = Keyboard.FocusedElement as FrameworkElement;
			if (focusedElement != null) {
				string elementName = focusedElement.Name;
				// можно использовать elementName в коде
			}
		}
		#endregion

		///<summary>
		/// метод отправки на печать
		/// </summary>
		private void GoPrinting(object sender, RoutedEventArgs e)
		{
			//создание окна печати
			PrintDialog printDialog = new PrintDialog();

			
			DocumentViewer docViewer = new DocumentViewer(); 	//Представляет элемент управления для просмотра документа, который
			//может содержать разбитое по страницам содержимое FixedDocument, например XpsDocument.
			
			FixedDocument fixDoc = new FixedDocument();
			
			//IDocumentPaginatorSource  fd = flowDocument as IDocumentPaginatorSource;
/*
//			List<FixedPage> fixedPages = new List<FixedPage>();
//			    		for (int i = 0; i < gridForPtint.RowDefinitions.Count; i++)
//			    		{
//			    			PageContent pgContent = new PageContent();
//			    			//pgContent.
//			    			FixedPage fixedPage = new FixedPage();
//			    			fixedPage.Width = _A4Form.A4WidthHoriz;
//			    			fixedPage.Height = _A4Form.A4HeightHoriz;
//			    			fixedPage.Children.Add(gridForPtint.Children[i]);
//			    			pgContent.Child = fixedPage;
//			    			fixDoc.Pages.Add(pgContent);
//			    		}
*/			

			printDialog.PageRangeSelection = PageRangeSelection.AllPages;
			// Разрешаем пользователю выбирать ориентацию печати в окне печати
			printDialog.UserPageRangeEnabled = true;

			FlowDocument doc = (FlowDocument)docViewer.Document;

			if (printDialog.ShowDialog() == true) {
//				//первый вариант печати
				// Здесь создается документ, который будет напечатан
				FlowDocument flowDoc = new FlowDocument();
				Paragraph par =  new Paragraph();
				
				//printDialog.PrintDocument(fd.DocumentPaginator, "Printing Flow Document...");
			
				
				
				//flowDoc.Blocks.Add(par);
				// Вы можете добавлять различные элементы в документ
				// Устанавливаем источник документа для печати
				//printDialog.PrintDocument(((IDocumentPaginatorSource)flowDoc).DocumentPaginator, "Printing FlowDocument");
				
				
				//MessageBox.Show(gridForPtint.Children.Count.ToString());
				//второй вариант печати
//				for (int i = 0; i < gridForPtint.RowDefinitions.Count; i++) {
//					if ((gridForPtint.Children[i] is Grid) && (gridForPtint.Children[i] as Grid).RowDefinitions.Count > 1) {
//						printDialog.PrintVisual(gridForPtint.Children[i] as Visual, "Печать содержимого gridForPtint");
//					}
//				}
				//printDialog.PrintVisual(_mainSP.Children[1] as Visual, "Печать содержимого gridForPtint");
}
else
{
    return;
}
			 
		}


		private void SaveGridToWord(Grid grid)
		{
			// Создание нового экземпляра приложения Word
			WRD.Application wordApp = new WRD.Application();
			// Создание нового документа
			WRD.Document document = wordApp.Documents.Add();

			// Получение активного раздела документа
			WRD.Section section = document.ActiveWindow.Selection.Sections.Add();

			// Создаем таблицу с теми же размерами, что и Grid
			WRD.Table wordTable = document.Tables.Add(document.Range(), grid.RowDefinitions.Count, grid.ColumnDefinitions.Count);

			// Проходим через каждую ячейку Grid
			for (int i = 0; i < grid.RowDefinitions.Count; i++) {
				for (int j = 0; j < grid.ColumnDefinitions.Count; j++) {
					// Получаем TextBox в ячейке Grid
					TextBox textBox = grid.Children[j] as TextBox;

					// Вставляем текст из TextBox в ячейку таблицы Word
					wordTable.Cell(i, j).Range.Text = textBox.Text;
				}
			}

			// Обход элементов внутри Grid
			foreach (var element in grid.Children) {
				if (element is TextBox) {
					// Получение текста из TextBox
					string text = (element as TextBox).Text;

					// Добавление текста в документ
					var paragraph = section.Range.Paragraphs.Add();
					paragraph.Range.Text = text;
				}
			}

			//        	// Сохранение документа
			//        	string filePath = "путь_к_файлу.docx";
			//document.SaveAs(filePath);
			// Сохраняем документ Word в нужном формате
			document.SaveAs2(@"D:\VS\qwerty.docx", (object)WRD.WdSaveFormat.wdFormatDocumentDefault);

			// Закрытие документа и приложения Word
			document.Close();
			wordApp.Quit();
		}

		private void Testing_Button_Click(object sender, RoutedEventArgs e)
		{
			Grid headGrid = (Grid)myTabControl.FindName("headGrid");
			foreach (var child in headGrid.Children.OfType<TextBox>().ToList()) {
				headGrid.Children.Remove(child);
			}
		}


		
		
		void Button_Click(object sender, RoutedEventArgs e)
		{
			_documInfo.SheetsQuantity = _mainSP.Children.Count;
			MessageBox.Show(_documInfo.docCode);
		}
		

		private void ShowDocument_Click(object sender, RoutedEventArgs e)
        {
			/*
			Grid gridForPtint = A4;
			
			FixedDocument fixedDocument = new FixedDocument();
			PageContent pageContent = new PageContent();
			FixedPage fPage = new FixedPage();
			fPage.Children.Add(A4);
			pageContent.Child = fPage;
			fixedDocument.Pages.Add(pageContent);

            // Предположим, что мы хотим отобразить содержимое первой ячейки (Cell 1)
            //TextBlock cellContent = (gridForPtint.Children[0] as TextBlock).Text;

            //// Создаем FlowDocument
            //var flowDocument = new FlowDocument();
            //var paragraph = new Paragraph(new Run(cellContent));
            //flowDocument.Blocks.Add(paragraph);

            //// Устанавливаем документ в DocumentViewer
            //myDocumentViewer.Document = flowDocument;
            myDocumentViewer.Document = fixedDocument;
            */
        }
	}
}
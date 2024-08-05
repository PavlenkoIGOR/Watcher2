/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 08/02/2024
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Controls;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified.BLL.Services
{
	/// <summary>
	/// Description of CreateA4AndFillForTechProcess.
	/// </summary>
	internal class CreateA4AndFillForTechProcess
	{
		A4Format _A4Form;
		DocumInfo _documInfo;
		readonly SheetAndSheetsGridCreateClass _sheetsAndSheet;
		readonly StackCreatingClass _stackCreatingClass;
		readonly TechProcGridCreatingClass _fotTechProcTab;
		readonly A4CreatingClass _A4CreatingClass;
		readonly Creating2x2GridClass _creating2x2GridClass;
		readonly AddA4DeleteA4GridClass _addA4DeleteA4Class;
		
		internal CreateA4AndFillForTechProcess(DocumInfo di, A4Format form, StackPanel sp)
		{
			_documInfo = di;
			_A4Form = form;

			_A4CreatingClass = new A4CreatingClass(_A4Form);
			_sheetsAndSheet = new SheetAndSheetsGridCreateClass(_documInfo);
			_stackCreatingClass = new StackCreatingClass();
			_fotTechProcTab = new TechProcGridCreatingClass(sp);
			_creating2x2GridClass = new Creating2x2GridClass();
			_addA4DeleteA4Class = new AddA4DeleteA4GridClass(_documInfo, _A4Form, sp);
		}
		
		internal Grid CreateA4AndFill()
		{
			Grid a4TPComplete = _A4CreatingClass.CreatA4();
			
			//создание таблицы с тех.процессом
			Grid techProcGrid = _fotTechProcTab.CreateMainTable();
			
			//создание таблицы с количеством листов
			Grid sheetAndSheets = _sheetsAndSheet.CreateSheetAndSheetsGrid();
			
			//создание основной сетки 2х2
			Grid grid2x2 = _creating2x2GridClass.Creating2x2Grid();
			Grid.SetRow(grid2x2, 0);
			Grid.SetColumn(grid2x2, 0);
			grid2x2.Children.Add(techProcGrid);
			grid2x2.Children.Add(sheetAndSheets);
			
			//создание StackPanel для сетки с тех.процессом
			StackPanel stackTP = _stackCreatingClass.CreateStackPanelIntoTeckProcesstable();
			Grid.SetRow(stackTP, techProcGrid.RowDefinitions.Count - 1);
			Grid.SetColumn(stackTP, 4);
			Grid.SetColumnSpan(stackTP, 2);
			
			//cсоздание таблицы с кнопками "Добавить после/удалить после"
			Grid addA4DeleteA4 = _addA4DeleteA4Class.AddA4DeleteA4(a4TPComplete);
			Grid.SetRow(addA4DeleteA4, a4TPComplete.RowDefinitions.Count - 1);
			Grid.SetColumn(addA4DeleteA4, a4TPComplete.ColumnDefinitions.Count - 1);
			
			techProcGrid.Children.Add(stackTP);
			
			a4TPComplete.Children.Add(grid2x2);
			a4TPComplete.Children.Add(addA4DeleteA4);
			
			return a4TPComplete;
		}
	}
}

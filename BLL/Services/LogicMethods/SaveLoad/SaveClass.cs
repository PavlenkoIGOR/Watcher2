/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 05.08.2024
 * Time: 9:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified.BLL.Services.LogicMethods.SaveLoad
{
	/// <summary>
	/// Description of SaveClass.
	/// </summary>
	internal class SaveClass
	{
		StackPanel _serMainSP;
		internal SaveClass(StackPanel sp)
		{
			_serMainSP = sp;
		}
		
				/// <summary>
		/// Метод для сериализации
		/// </summary>
		/// <returns></returns>
		internal void SaveDocument()
		{
			//serMainSP = FindName("TechProcSP") as StackPanel;
			
			int NumOfRow = 0;
			TechProcMainSP_Serialize techProcMainSP_Serialize = new TechProcMainSP_Serialize();

			TextBox_Serialize textBoxInTProc_Serialize = new TextBox_Serialize();
			StackPanel_Serialize stackPanel_Serialize = new StackPanel_Serialize();

			GridInStackPanel_Serialize gridInStackPanel_Serialize = new GridInStackPanel_Serialize();			
			TP_TabSerialize tP_TabSerialize = new TP_TabSerialize();

			for (int a = 0; a < _serMainSP.Children.Count; a++) //смотрим все элементы в StackPanel (т.е. А4);
			{
                A4Serialize a4Serialize = new A4Serialize();
				//for (int g = 0; g < _mainSP.Children[a].Count;) { }
				if (_serMainSP.Children[a] != null)	//если дочерний объект это А4 и не null
				{
					Grid a4 = _serMainSP.Children[a] as Grid;
					for (int d = 0; d < a4.Children.Count; d++)    //смотрим все элементы внутри А4 (2х2Grid);
					{
						if (d == 0 && a4.Children[0] != null) //берётся самый первый дочерний элемент (это и есть 2х2Grid)
                        {
							Grid a4Child = a4.Children[d] as Grid;  //то создаётся Grid со ссылкой на grid2X2
							Grid2x2_Serialize grid2X2_Serialize = new Grid2x2_Serialize();




							for (int i = 0; i < a4Child.Children.Count; i++)   //смотрим все объекты в таблице grid2X2
							{
								if (i == 0) //здесь находится tb с цифрой 6
								{
                                    TextBox_Serialize textBox_Serialize = new TextBox_Serialize
                                    {
                                        TextBoxRow = Grid.GetRow(a4Child.Children[i]),
                                        TextBoxColumn = Grid.GetColumn(a4Child.Children[i]),
                                        TextBoxRowSpan = Grid.GetRowSpan(a4Child.Children[i]),
                                        TextBoxColumnSpan = Grid.GetColumnSpan(a4Child.Children[i]),
                                        TextBox_Text = ((TextBox)a4Child.Children[i]).Text
                                    };
									grid2X2_Serialize.textBox_Serialize = textBox_Serialize;
								}
                                
								if (i == 1) //здесь находится таблица с техпроцессом
								{
									TechProc_Serialize techProc_Serialize = new TechProc_Serialize();

									Grid TPGrid = (Grid)a4Child.Children[i];   //создаётся объект с ссылкой на таблицу с ТП

									for (int t = 0; t < TPGrid.Children.Count; t++) //смотрим все объекты в таблице с техпроцессом
									{
										if (TPGrid.Children[t] is TextBox)  //если дочерний объект TextBox
										{
											techProc_Serialize.TextBoxsList_Serialize.Add(new TextBox_Serialize()
											{
												TextBoxRow = Grid.GetRow(TPGrid.Children[t]),
												TextBoxColumn = Grid.GetColumn(TPGrid.Children[t]),
												TextBoxColumnSpan = Grid.GetColumnSpan(TPGrid.Children[t]),
												TextBoxRowSpan = Grid.GetRowSpan(TPGrid.Children[t]),
												TextBox_Text = ((TextBox)TPGrid.Children[t]).Text
											});
											
											if ((TPGrid.Children[t] as TextBox).Name == "NumOfRow") {
												NumOfRow++;
											}
										}
										if (TPGrid.Children[t] is StackPanel)   //если дочерний это StackPanel
										{
											StackPanel tpSP = (StackPanel)TPGrid.Children[t];

											List<GridInStackPanel_Serialize> gridInStackPanel_Ser = new List<GridInStackPanel_Serialize>();
											int count = 0;
											foreach (var childSP in tpSP.Children)
											{
												if (childSP is Grid)
												{
													List<TextBox_Serialize> tbSer = new List<TextBox_Serialize>();
													foreach (var tb in (childSP as Grid).Children)
													{
														tbSer.Add(new TextBox_Serialize()
														{
															TextBoxColumn = Grid.GetColumn((TextBox)tb),
															TextBoxRow = Grid.GetRowSpan((TextBox)tb),
															TextBox_Text = ((TextBox)tb).Text
														});
													}
													gridInStackPanel_Ser.Add(new GridInStackPanel_Serialize()
													{
														GridsInStackPanelRow = count++,
														TextBoxsInStackPanel = tbSer
													});
												}
											}
											techProc_Serialize.StackPanelsList_Serialize.Add(new StackPanel_Serialize
											{
												StackPanelRowInTechProcGrid = Grid.GetRow((StackPanel)tpSP),
												StackPanelColumnInTechProcGrid = Grid.GetColumn((StackPanel)tpSP),
												StackPanelSpanColumn = Grid.GetColumnSpan((StackPanel)tpSP),
												gridsInStackPanel = gridInStackPanel_Ser
											});
										}
									}

									grid2X2_Serialize.techProc_Serialize = techProc_Serialize;
								}

								if (i == 2) //здесь находится SheetAndSheetsGrid
                                {
									Grid sheetAndSheetsGrid = a4Child.Children[i] as Grid;

                                    SheetSheetsGrid_Serialize sheetSheetsGrid_Serialize = new SheetSheetsGrid_Serialize();
                                    foreach (var item in sheetAndSheetsGrid.Children)
									{
										TextBox_Serialize textBoxInSheetAndSheets = new TextBox_Serialize() {
											TextBoxRow = Grid.GetRow(item as TextBox),
											TextBoxColumn = Grid.GetColumn(item as TextBox),
											TextBoxColumnSpan = Grid.GetColumnSpan(item as TextBox),
											TextBoxRowSpan = Grid.GetRowSpan(item as TextBox),
											TextBox_Text = (item as TextBox).Text
                                        };
                                        sheetSheetsGrid_Serialize.tbInSheetAndSheets.Add(textBoxInSheetAndSheets);
                                    }
                                    sheetSheetsGrid_Serialize.Rows = sheetAndSheetsGrid.RowDefinitions.Count;
                                    sheetSheetsGrid_Serialize.Column = sheetAndSheetsGrid.ColumnDefinitions.Count;
                                    sheetSheetsGrid_Serialize.SheetNum = 55;
                                    sheetSheetsGrid_Serialize.SheetsQuantity = 101;

                                    grid2X2_Serialize.sheetSheetsGrid_Serialize = sheetSheetsGrid_Serialize;
								}

							}

							//задаются параметры 
							grid2X2_Serialize.RowQuantity = a4Child.RowDefinitions.Count;
							grid2X2_Serialize.ColumnQuantity = a4Child.ColumnDefinitions.Count;
							grid2X2_Serialize.NameGrid = a4Child.Name;

							a4Serialize.grid2X2_Serialize = grid2X2_Serialize;
						}
					}
					//задаются параметры А4
					a4Serialize.A4_Width = (_serMainSP.Children[a] as Grid).Width;
                    a4Serialize.A4_Height = (_serMainSP.Children[a] as Grid).Height;
                    a4Serialize.HorizontalAlignment = HorizontalAlignment.Center;
                    a4Serialize.VerticalAlignment = VerticalAlignment.Top;
                    a4Serialize.A4Rows = (_serMainSP.Children[a] as Grid).RowDefinitions.Count;
                    a4Serialize.A4Columns = (_serMainSP.Children[a] as Grid).ColumnDefinitions.Count;                  
				}
                techProcMainSP_Serialize.a4List.Add(a4Serialize);
            }
            techProcMainSP_Serialize.spVertAlignment = VerticalAlignment.Stretch;
            techProcMainSP_Serialize.spHorizAlignment = HorizontalAlignment.Stretch;

            // сохранение данных
            using (FileStream fs = new FileStream(@"D:/Watcher.xml", FileMode.Create, FileAccess.Write)) 
            {
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TechProcMainSP_Serialize));
				xmlSerializer.Serialize(fs, techProcMainSP_Serialize);
				
				fs.Close();
			}
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 05.08.2024
 * Time: 9:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace watcherWPF_modified.BLL.Services.LogicMethods
{
	/// <summary>
	/// Description of BrutForceIn2Tab.
	/// </summary>
	internal class BrutForceIn2Tab
	{
		StackPanel _mainSP;
		internal BrutForceIn2Tab(StackPanel sp)
		{
			_mainSP = sp;
		}
		
		internal void BrutForceIn2TabMethod(/*StackPanel _mainSP*/)
		{
			int NumOfRow = 0;
			int sheetsQuantity=0;
			int A4Quantity = 0;
			#region
	
			for (int a = 0; a < _mainSP.Children.Count; a++) //смотрим все элементы в StackPanel (т.е. А4);
			{

				//for (int g = 0; g < _mainSP.Children[a].Count;) { }
				if (_mainSP.Children[a] != null)	//если дочерний объект это А4 и не null
				{
					Grid a4 = _mainSP.Children[a] as Grid;
					for (int d = 0; d < a4.Children.Count; d++)    //смотрим все элементы внутри А4 (2х2Grid);
					{
						if (d == 0 && a4.Children[0] != null) //берётся самый первый дочерний элемент (это и есть 2х2Grid)
                        {
							Grid a4Child = a4.Children[d] as Grid;  //то создаётся Grid со ссылкой на grid2X2

							for (int i = 0; i < a4Child.Children.Count; i++)   //смотрим все объекты в таблице grid2X2
							{
								if (i == 0) //здесь находится tb с цифрой 6
								{
//
								}
                                
								if (i == 1) //здесь находится таблица с техпроцессом
								{
									Grid TPGrid = (Grid)a4Child.Children[i];   //создаётся объект с ссылкой на таблицу с ТП

									for (int t = 0; t < TPGrid.Children.Count; t++) //смотрим все объекты в таблице с техпроцессом
									{
										if (TPGrid.Children[t] is TextBox)  //если дочерний объект TextBox
										{											
											if ((TPGrid.Children[t] as TextBox).Name == "NumOfRow")	//если у дочернего TextBox имя "NumOfRow"
											{
												NumOfRow++;
												(TPGrid.Children[t] as TextBox).Text = NumOfRow.ToString();
											}
										}
										if (TPGrid.Children[t] is StackPanel)   //если дочерний это StackPanel
										{
											StackPanel tpSP = (StackPanel)TPGrid.Children[t];
											int count = 0;
											foreach (var childSP in tpSP.Children)
											{
												if (childSP is Grid)
												{
													foreach (var tb in (childSP as Grid).Children)
													{

													}
												}
											}
										}
									}
								}

								if (i == 2) //здесь находится SheetAndSheetsGrid
                                {
									Grid sheetAndSheetsGrid = a4Child.Children[i] as Grid;

                                    foreach (var item in sheetAndSheetsGrid.Children)
									{
                                    	if ((item as FrameworkElement).Name == "SheetsQuantity") {
                                    		sheetsQuantity++;
                                    		(item as TextBox).Text = sheetsQuantity.ToString();
                                    	}                                    	
                                    }
								}

							}
						}
					}
				}
			}
			#endregion

			//MessageBox.Show(NumOfRow.ToString());
			//MessageBox.Show(A4Quantity.ToString());
		}
	}
}

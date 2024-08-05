/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of SheetSheets_Serialize.
	/// </summary>
	public class SheetSheetsGrid_Serialize
	{
		public string SheetAndSheetsGridName { get; set; }
		public int RowIn2x2 { get; set; }
		public int ColumnIn2x2 { get;set; }
		public int Rows { get; set; }
		public int Column { get; set; }
		public int? SheetNum { get; set;}
		public int? SheetsQuantity { get; set;}
		public List<TextBox_Serialize> tbInSheetAndSheets { get; set; }
		
		public SheetSheetsGrid_Serialize()
		{
			tbInSheetAndSheets = new List<TextBox_Serialize>();
        }
	}
}

/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of Grid2x2_Serialize.
	/// </summary>
	public class Grid2x2_Serialize
	{
		public string NameGrid { get; set; }
		//public int Grid2x2InA4Row_Ser {  get; set; }
		public int? RowQuantity { get; set; }
		public int? ColumnQuantity { get; set; }
		public TextBox_Serialize textBox_Serialize { get; set; }
		public TechProc_Serialize techProc_Serialize { get; set; }
		public SheetSheetsGrid_Serialize sheetSheetsGrid_Serialize { get; set;}
		
		public Grid2x2_Serialize()
		{
			textBox_Serialize  = new TextBox_Serialize();
		}
	}
}

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
	/// Description of TechProc_Serialize.
	/// </summary>
	public class TechProc_Serialize
	{
		public string TechProcTableName { set{TechProcTableName = "TechProcTable";} }
	    public int TechProcTable_RowInA4 { get; set; }
	    public int TechProcTable_ColumnInA4 { get; set; }
	    public List<TextBox_Serialize> TextBoxsList_Serialize {get; set;}
	    public List<StackPanel_Serialize> StackPanelsList_Serialize { get; set; }
		
		public TechProc_Serialize()
		{
			TextBoxsList_Serialize = new List<TextBox_Serialize>();
			StackPanelsList_Serialize = new List<StackPanel_Serialize>();
		}
	}
}

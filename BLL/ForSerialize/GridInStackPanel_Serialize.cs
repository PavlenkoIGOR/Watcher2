/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of GridInStackPanel_Serialize.
	/// </summary>
	public class GridInStackPanel_Serialize
	{
	    public string GridInStackPanelName { get; set; }
	    public int? GridsInStackPanelRow { get; set; }
	    public List<TextBox_Serialize> TextBoxsInStackPanel{ get; set; }
	    
		public GridInStackPanel_Serialize()
		{
		}
	}
}

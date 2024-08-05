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
	/// Description of StackPanel_Serialize.
	/// </summary>
	public class StackPanel_Serialize
	{
	    public string StackPanelName { get; set; }
	    public int StackPanelRowInTechProcGrid { get; set; }
	    public int StackPanelColumnInTechProcGrid { get; set; }
	    public int StackPanelSpanColumn { get; set; }
	    public List<GridInStackPanel_Serialize> gridsInStackPanel {get;set;}

	    public StackPanel_Serialize()
		{
	    	gridsInStackPanel = new List<GridInStackPanel_Serialize>();
		}
	}
}

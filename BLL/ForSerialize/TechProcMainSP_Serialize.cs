/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 05.08.2024
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of TechProcMainSP_Serialize.
	/// </summary>
	public class TechProcMainSP_Serialize
	{
		public VerticalAlignment spVertAlignment { get; set; }
		public HorizontalAlignment spHorizAlignment { get; set; }
		public List<A4Serialize> a4List { get; set; }
		
		public TechProcMainSP_Serialize()
		{
			a4List = new List<A4Serialize>();
		}
		
	}
}

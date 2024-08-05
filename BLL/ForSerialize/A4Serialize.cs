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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of A4Serialize.
	/// </summary>
	public class A4Serialize
	{
		public double A4_Height {  get; set; }
		public double A4_Width {  get; set; }
		public VerticalAlignment VerticalAlignment { get; set; }
		public HorizontalAlignment HorizontalAlignment { get; set; }
		public string A4Name { get; set; }
		public int A4Rows { get; set; }
		public int A4Columns { get; set; }
        /*
        [NonSerialized] public VerticalAlignment VerticalAlignment {get; set;} = VerticalAlignment.Top;
        [NonSerialized] public HorizontalAlignment HorizontalAlignment {get; set;} = HorizontalAlignment.Center;
        [NonSerialized] public float Height {get; set;}
        [NonSerialized] public float Width {get; set;}
        [NonSerialized] public Brushes bgColor {get;set;} = Brushes.Green;
        */
		public Grid2x2_Serialize grid2X2_Serialize { get; set; }
		//public List<AddDeleteA4>? AddDeleteA4_Serialize { get; set; }
		   
		public A4Serialize()
		{
			grid2X2_Serialize = new Grid2x2_Serialize();
		}
	}
}

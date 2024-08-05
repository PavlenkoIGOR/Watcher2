/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/30/2024
 * Time: 16:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace watcherWPF_modified.BLL.Services.SchemasPages
{
	/// <summary>
	/// Description of A4ForSchemasTabCreator.
	/// </summary>
	internal class A4ForSchemasTabCreator
	{
		private A4Format _a4Format;
		internal A4ForSchemasTabCreator(A4Format a4Format)
		{
			_a4Format = a4Format;
		}
		
		internal Grid A4ForShemasTabCreate()
		{
			Grid A4SchemasGrid = new Grid()
			{
				Width = _a4Format.A4WidthVert,
				Height = _a4Format.A4HeightVert,
				Background = Brushes.Brown,
				VerticalAlignment = VerticalAlignment.Top,
				HorizontalAlignment = HorizontalAlignment.Center
			};
			return A4SchemasGrid;
			
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/30/2024
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using watcherWPF_modified.BLL;
using watcherWPF_modified.BLL.ForSerialize;
using watcherWPF_modified.BLL.Services.SchemasPages;

namespace watcherWPF_modified
{
	/// <summary>
	/// Interaction logic for SchemasPages.xaml
	/// </summary>
	public partial class SchemasPages : Page
	{
		A4Format _a4Format;
		DocumInfo _docInfo;
		A4ForSchemasTabCreator _a4Creator;
		SchemasGridCreator _schemasGridGraetor;
		
		public SchemasPages(A4Format a4Form, DocumInfo docInf)
		{
			_a4Format = a4Form;
			_docInfo = docInf;
			_a4Creator = new A4ForSchemasTabCreator(_a4Format);
			_schemasGridGraetor = new SchemasGridCreator(_a4Format);
			
			InitializeComponent();
			
			InsertFirstSchema();
		}
		
		void InsertFirstSchema()
		{
			Grid newA4 = _a4Creator.A4ForShemasTabCreate();
			
			Grid newSchemasGrid = _schemasGridGraetor.CreateGridForSchema();
			Grid.SetRow(newSchemasGrid,0);
			Grid.SetColumn(newSchemasGrid,0);
			newA4.Children.Add(newSchemasGrid);
			
			ScrollViewer sv = FindName("scrollViewerSchemas") as ScrollViewer;

			sv.Content = newA4;
		}
	}
}
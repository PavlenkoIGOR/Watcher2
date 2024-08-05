/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/23/2024
 * Time: 14:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of DocumkInfo.
	/// </summary>
	public class DocumInfo
	{
		internal int SheetNumber {get; set;}
		internal int SheetsQuantity {get; set;}
		internal string docName {get; set;}
		internal string docCode {get; set;}
		
		public DocumInfo()
		{
		}

		#region INotifyPropertyChanged implementation

		//public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}
/*
 namespace watcherWPF_modified.BLL.ForSerialize
{
	public class DocumInfo
	{
		internal int SheetNumber {get; set;}
		internal int SheetsQuantity {get; set;}
		internal string docName {get; set;}
		internal string docCode {get; set;}
		
		public DocumInfo()
		{
		}
	}
}
 */
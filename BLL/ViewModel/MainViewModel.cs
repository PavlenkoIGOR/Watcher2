/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/30/2024
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified.BLL.ViewModel
{
	/// <summary>
	/// Description of MainViewModel.
	/// </summary>
	public class MainViewModel
	{
		public TexBViewModel _texBVM;
		public RichTBViewModel _richTBVM;
		public DocumInfoViewModel _docIVM;
		

		
		public MainViewModel(TexBViewModel TBVM, RichTBViewModel RTVM, DocumInfoViewModel docIVM)
		{
			_texBVM = TBVM;
			_richTBVM = RTVM;
			_docIVM = docIVM;
		}
		
		#region PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName = null)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
		
		public TexBViewModel TexBVM
		{
			get { return _texBVM; }
			set
			{
				_texBVM = value;
				OnPropertyChanged("TexBVM");
			}
		}
		
		public RichTBViewModel RichTBVM
		{
			get { return _richTBVM; }
			set
			{
				_richTBVM = value;
				OnPropertyChanged("RichTBVM");
			}
		}
		
		public DocumInfoViewModel docIVM
		{
			get{ return _docIVM; }
			set
			{
				_docIVM = value;
				OnPropertyChanged("docIVM");
			}
		}
	}
}
/*
namespace watcherWPF_modified.BLL.ViewModel
{
	public class MainViewModel
	{
		public TexBViewModel TexBVM;
		public RichTBViewModel RichTBVM;
		
		public MainViewModel(TexBViewModel TBVM, RichTBViewModel RTVM)
		{
			TexBVM = TBVM;
			RichTBVM = RTVM;
		}
	}
}
 */

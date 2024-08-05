/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/25/2024
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified.BLL.ViewModel
{
	/// <summary>
	/// Description of TexBViewModel.
	/// </summary>
	public class TexBViewModel : INotifyPropertyChanged
	{
		private DocumInfo _docInfo;
		private string _docCode;
		public TexBViewModel(/*DocumInfo di*/)
		{
			_docInfo = new DocumInfo();
			//_docCode = _docInfo.docCode;
		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
		}
		#endregion
		
		public string docCode
		{
			get {return _docCode;}
			set 
			{
				_docCode = value;
				OnPropertyChanged();
			}
		}
	}
}

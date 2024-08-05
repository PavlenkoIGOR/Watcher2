/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/30/2024
 * Time: 10:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified.BLL.ViewModel
{
	/// <summary>
	/// Description of RichTBViewModel.
	/// </summary>
	public class RichTBViewModel : INotifyPropertyChanged
	{
		private DocumInfo _docInfo;
		string _Test;
		
		public RichTBViewModel(DocumInfo di)
		{
			//_docInfo = new DocumInfo();
			_docInfo = di;
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName = null) 	//если не указать = null, то в строке OnPropertyChanged(); надо
																				//будет передавать параметр в данном случае "DocCode". 
																				//Примечание: если в xaml разметке
																				//в строке Text="{Binding Test, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" нет UpdateSourceTrigger=PropertyChanged
																				//то изменения в связанных ячейках будут происходить после перевода фокуса с активного поля  
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

		#endregion
		
		public string Test 	//Text="{Binding Test, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" - DocCode имя свойства в классе к которому привязывается свойство объекта в xaml. 
								//Оно же передаётся (если не указан null см.выше) в OnPropertyChanged("Test")
        {
			get {return _Test;}
            set
            {
                if (Test != value)
                {
                    _Test = value;
                    OnPropertyChanged("Test");
                }
            }
        }
	}
}
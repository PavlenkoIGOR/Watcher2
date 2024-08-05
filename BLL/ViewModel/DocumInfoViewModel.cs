/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 07/30/2024
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using watcherWPF_modified.BLL.ForSerialize;

namespace watcherWPF_modified.BLL.ViewModel
{
	/// <summary>
	/// Description of DocumInfoViewModel.
	/// </summary>
	public class DocumInfoViewModel : INotifyPropertyChanged
	{
		private DocumInfo _docInfo;
		public DocumInfoViewModel(DocumInfo di)
		{
			_docInfo = di;
		}
		
				#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName = null) 	//если не указать = null, то в строке OnPropertyChanged(); надо
																				//будет передавать параметр в данном случае "DocCode". 
																				//Примечание: если в xaml разметке
																				//в строке Text="{Binding DocCode, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" нет UpdateSourceTrigger=PropertyChanged
																				//то изменения в связанных ячейках будут происходить после перевода фокуса с активного поля
																				//Допоплнение: т.к. на данном этапе в DataContext записывается MainViewModel, а остальные VM записывается в MainViewModel, то Binding DocCode
																				//необходимо заменить на Binding docIVM.DocCode. docIVM - это свойство в MainViewModel.
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

		#endregion
		
		public string DocCode 	//Text="{Binding DocCode, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" - DocCode имя свойства в классе к которому привязывается свойство объекта в xaml. 
								//Оно же передаётся (если не указан null см.выше) в OnPropertyChanged("DocCode")
        {
			get {return _docInfo.docCode;}
            set
            {
            	_docInfo.docCode = value;
            	OnPropertyChanged("DocCode");
            }
        }
		public int DocSheetsQuantity
        {
			get {return _docInfo.SheetsQuantity;}
            set
            {
            	_docInfo.SheetsQuantity = value;
            	OnPropertyChanged("DocSheetsQuantity");
            }
        }
	}
}

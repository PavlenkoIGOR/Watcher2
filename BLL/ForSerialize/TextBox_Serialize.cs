/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of TextBox_Serialize.
	/// </summary>
	public class TextBox_Serialize
	{
		public int TextBoxRow { get; set; }
		public int TextBoxColumn { get; set; }
		public int? TextBoxColumnSpan { get; set; }
		public int? TextBoxRowSpan { get; set; }
		public string TextBox_Text { get; set; }
		
	}
}

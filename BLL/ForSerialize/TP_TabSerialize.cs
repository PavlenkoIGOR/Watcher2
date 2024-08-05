/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace watcherWPF_modified.BLL.ForSerialize
{
	/// <summary>
	/// Description of TP_TabSerialize.
	/// </summary>
	public class TP_TabSerialize
	{
	    public string TabName { get; set; }
	    public A4Serialize A4Serialize { get; set; }
	    
		public TP_TabSerialize()
		{
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 02.08.2024
 * Time: 13:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace watcherWPF_modified.BLL.Services.AppController
{
	/// <summary>
	/// Description of NumeratorTBForPP.
	/// </summary>
	internal static class NumeratorTBForPP
	{
		
		internal static List<TBForPP> TBForPPList;
		
		static NumeratorTBForPP()
		{
			TBForPPList = new List<TBForPP>();
		}
		
		
	}
}

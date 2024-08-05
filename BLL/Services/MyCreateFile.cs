/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace watcherWPF_modified.BLL.Services
{
	/// <summary>
	/// Description of MyCreateFile.
	/// </summary>
	public static class MyCreateFile
	{
		internal static string[] paths = { @"d:\","elems.txt"};
    	internal static string pathFull = "";
    	internal static void MyCreateFileMethod(List<UIElement> list)
    	{
        	pathFull = System.IO.Path.Combine(paths);
       		if (!File.Exists(pathFull))
        	{
            	File.Create(pathFull);
        	}

        	using (FileStream fs = new FileStream(pathFull, FileMode.Append, FileAccess.Write, FileShare.None))
        	{
            	using (StreamWriter sw = new StreamWriter(fs))
            	{
                	foreach (UIElement element in list)
                	{
                		sw.WriteLine(String.Format("{0}", element.GetType()));
                	}
            	}
        	}
		}
	}
}
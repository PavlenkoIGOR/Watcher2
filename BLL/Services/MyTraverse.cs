/*
 * Created by SharpDevelop.
 * User: pavlenko_i_l
 * Date: 16.01.2024
 * Time: 10:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace watcherWPF_modified.BLL.Services
{
	/// <summary>
	/// Description of MyTraverse.
	/// </summary>
	public static class MyTraverse
	{
		internal static void TraverseElements(DependencyObject parent, List<UIElement> elements)
    	{
        	int count = VisualTreeHelper.GetChildrenCount(parent);
        	for (int i = 0; i < count; i++)
        	{
            	DependencyObject child = VisualTreeHelper.GetChild(parent, i);
            	if (child is UIElement)
            	{
                	elements.Add(child as UIElement);
                	if (child is TabItem || child is TabControl)
                	{
                    	TraverseElements(child, elements);
                	}
                	
            	}
        	}
    	}
	}
}
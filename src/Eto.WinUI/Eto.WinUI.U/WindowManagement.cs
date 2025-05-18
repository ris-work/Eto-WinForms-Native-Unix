using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace Eto.WinUI.U
{

public static class WindowHelper
	{

		public static Microsoft.UI.Xaml.Controls.Frame RootFrame;
		// Keep a collection of all active windows.
		private static readonly List<Microsoft.UI.Xaml.Window> _registeredWindows = new List<Microsoft.UI.Xaml.Window>();

		/// <summary>
		/// Call this method when a Window is created.
		/// </summary>
		public static void RegisterWindow(Microsoft.UI.Xaml.Window window)
		{
			if (window == null)
				return;

			if (!_registeredWindows.Contains(window))
			{
				_registeredWindows.Add(window);
			}
		}

		/// <summary>
		/// If you close a window, you can unregister it.
		/// </summary>
		public static void UnregisterWindow(Microsoft.UI.Xaml.Window window)
		{
			if (window != null)
			{
				_registeredWindows.Remove(window);
			}
		}

		/// <summary>
		/// Retrieves the Window hosting the given source. The source can be either a FrameworkElement or a ResourceDictionary.
		/// </summary>
		public static Microsoft.UI.Xaml.Window GetRootWindow(object source)
		{
			System.Console.WriteLine($"Source: {source.GetType()}");
			if (source is Microsoft.UI.Xaml.Window w)
			{
				System.Console.WriteLine($"Window {w}");
				//return GetWindowFromXamlRoot(w.XamlRoot);
			}
			else if (source is Microsoft.UI.Xaml.Controls.Frame f)
			{
				System.Console.WriteLine($"Window {f}");
				//return GetWindowFromXamlRoot(element.XamlRoot);
			}
			else if (source is FrameworkElement element)
			{
				//return GetWindowFromXamlRoot(f.XamlRoot);
			}
			else if (source is ResourceDictionary dictionary)
			{
				// In a ResourceDictionary, look for any FrameworkElement and use its XamlRoot.
				foreach (var value in dictionary.Values)
				{
					if (value is FrameworkElement fe && fe.XamlRoot != null)
					{
						var window = GetWindowFromXamlRoot(fe.XamlRoot);
						if (window != null)
						{
							return window;
						}
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Matches a given XamlRoot with the Window whose content has the same XamlRoot.
		/// </summary>
		private static Microsoft.UI.Xaml.Window GetWindowFromXamlRoot(XamlRoot xamlRoot)
		{
			if (xamlRoot == null)
				return null;

			foreach (var window in _registeredWindows)
			{
				if (window.Content is FrameworkElement content)
				{
					// If the element's XamlRoot matches, we've found the hosting window.
					if (content.XamlRoot == xamlRoot)
					{
						return window;
					}
				}
			}
			return null;
		}
	}


public static class FrameworkElementExtensions
	{
		/// <summary>
		/// Traverses the visual tree upward starting from the given FrameworkElement 
		/// until it reaches the root element.
		/// </summary>
		/// <param name="element">The starting FrameworkElement.</param>
		/// <returns>The root FrameworkElement in the visual tree or null if none found.</returns>
		public static FrameworkElement GetRootElement(this FrameworkElement element)
		{
			if (element == null)
				return null;

			// Start at the current element
			DependencyObject current = element;
			DependencyObject parent = VisualTreeHelper.GetParent(current);

			// Traverse upward until no parent is found.
			while (parent != null)
			{
				current = parent;
				parent = VisualTreeHelper.GetParent(current);
			}

			// Return the topmost element as a FrameworkElement if possible.
			return current as FrameworkElement;
		}
	}


}


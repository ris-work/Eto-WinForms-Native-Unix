using Eto.WinUI.U;
using mui = Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Eto.WinUI.Forms;

public class FormHandler : WinUIWindow<mui.Window, Form, Form.ICallback>, Form.IHandler
{
	protected override mui.Window CreateControl() {
		System.Console.WriteLine($"FH: Window not created, returning Current: {mui.Window.Current.GetType()}");
		mui.Window.Current.Content = new mui.Controls.TextBlock() { Text = "AB" };
		//WindowHelper.RootFrame;
		//mui.Window.Current.Activate();
		return mui.Window.Current; 
	}

	public bool ShowActivated { get; set; }
	public bool CanFocus { get; set; }

	public void Show()
	{
		//Control.CoreWindow.Di = Windows.UI.Core.CoreWindowActivationMode.ActivatedNotForeground;
		System.Console.WriteLine($"FH: Show() called");
		Control.Activate();
	}
}

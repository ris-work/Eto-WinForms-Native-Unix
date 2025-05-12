// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");
// Enable Unix support for System.Drawing.Common programmatically.
// This must be called before any code that uses System.Drawing.
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);

Console.WriteLine("Unix support for System.Drawing.Common is now enabled!");

// Your application code goes here.
// For example, you could perform image processing tasks here.
var platform = new Eto.WinForms.Platform();

var app = new Application(platform);
app.Run(new T());

public class T : Eto.Forms.Form
{
	public T()
	{
		Button B = new() { Text = "A" };
		B.Click += (e, a) =>
		{
			this.Content = new Panel() { Content = new Label() { Text = "Clicked" } };
		};
		Content = new Panel()
		{
			Content = B
		};
		MinimumSize = new Eto.Drawing.Size(200,200);
	}
}
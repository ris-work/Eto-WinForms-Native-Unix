using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml;
using Windows.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.


namespace Eto.Test.WinUI
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	public partial class App : Microsoft.UI.Xaml.Application
	{
		Eto.Forms.Application app;
		
		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			
			//Windows.UI.Core.CoreDispatcher.HasThreadAccessOverride = true;
			this.InitializeComponent();
			app = new TestApplication(new Eto.WinUI.Platform());
		}

		/// <summary>
		/// Invoked when the application is launched.
		/// </summary>
		/// <param name="args">Details about the launch request and process.</param>
		protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
		{
			app.Attach(this);
		}
		[STAThread]
		public static void Main(string[] args)
		{
			// This lambda creates a new instance of your App defined in App.xaml / App.xaml.cs
			/*Windows.UI.Xaml.Application.Start(p => {
				var app = new App();
				app.InitializeComponent();
				return app;
			});*/
			Microsoft.UI.Xaml.Application.Start(p => {
				var app = new App();
				app.InitializeComponent();
				
			});
		}
	}
}

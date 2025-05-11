using Eto;
using Eto.Test;

namespace Eto.Test.WinForms
{
	class Startup
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Enable Unix support for System.Drawing.Common programmatically.
			// This must be called before any code that uses System.Drawing.
			AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);

			Console.WriteLine("Unix support for System.Drawing.Common is now enabled!");

			// Your application code goes here.
			// For example, you could perform image processing tasks here.
			var platform = new Eto.WinForms.Platform();
			platform.Add<INativeHostControls>(() => new NativeHostControls());

			var app = new TestApplication(platform);
			app.TestAssemblies.Add(typeof(Startup).Assembly);
			app.Run();
		}
	}
}


using UIKit;
using Uno.UI.Hosting;
using Eto.Test.UWinUI;

App.InitializeLogging();

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseAppleUIKit()
    .Build();

host.Run();

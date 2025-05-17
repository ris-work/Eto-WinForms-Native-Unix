using UIKit;
using Uno.UI.Hosting;
using eto.test.winui;

App.InitializeLogging();

var host = UnoPlatformHostBuilder.Create()
    .App(() => new App())
    .UseAppleUIKit()
    .Build();

host.Run();

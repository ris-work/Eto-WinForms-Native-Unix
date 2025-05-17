using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Eto.Forms;
//using Uno.Resizetizer;
using Uno.UI;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Eto.Test.UWinUI
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
            this.InitializeComponent();
            app = new Eto.Test.TestApplication(new Eto.WinUI.Platform());
            
        }

        protected Microsoft.UI.Xaml.Window? MainWindow { get; private set; }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            MainWindow = new Microsoft.UI.Xaml.Window();
#if DEBUG
            //MainWindow.UseStudio();
#endif


            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (MainWindow.Content is not Frame rootFrame)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // Place the frame in the current Window
                MainWindow.Content = rootFrame;

                //rootFrame.NavigationFailed += OnNavigationFailed;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), args.Arguments);
            }


            //MainWindow.SetWindowIcon();
            // Ensure the current window is active

            //MainWindow.Activate();

            //app.Attach(app);
            //MainWindow.Activate();
            app.Initialized += (_, _) => { 
                Console.Error.WriteLine("Initialized");
                foreach (var window in ApplicationHelper.Windows)
                {
                    Console.WriteLine($"Title: {window.Title}");
                    //window.Activate();
                }
                ApplicationHelper.Windows[1].Closed += (_, _) => { Console.WriteLine("Exiting..."); this.Exit();  };
                ApplicationHelper.Windows[1].Activate();
                
            };
            app.Terminating += (_, _) => {
                Console.Error.WriteLine("Terminating...");
                foreach (var window in ApplicationHelper.Windows)
                {
                    Console.WriteLine($"Title: {window.Title}");
                    window.Close();
                }
                
            };
            var EA = app.Attach(rootFrame);
            //rootFrame.Content = ((FrameworkElement)EA.ControlObject);
            
            
        }



        public static void InitializeLogging()
        {

        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        /*protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            app.Attach(this);
        }*/
        
    }
}

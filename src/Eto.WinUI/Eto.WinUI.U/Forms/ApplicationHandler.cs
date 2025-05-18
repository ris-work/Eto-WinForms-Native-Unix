using Eto.WinUI.U;

namespace Eto.WinUI.Forms;

public class ApplicationHandler : WidgetHandler<mux.Application, Application, Application.ICallback>, Application.IHandler
{
	mud.DispatcherQueue? _dispatcher;
	Thread? _mainThread;

	public bool QuitIsSupported => true;
	public Keys CommonModifier => Keys.Control;
	public Keys AlternateModifier => Keys.Alt;
	public string? BadgeLabel { get; set; }
	public bool IsActive { get; }

	public ApplicationHandler()
	{
		Control = mux.Application.Current;
	}

	public void AsyncInvoke(Action action)
	{
		_dispatcher.TryEnqueue(new mud.DispatcherQueueHandler(action));
	}

	public void Attach(object context)
	{
		System.Console.WriteLine($"Root: (Before cast) {WindowHelper.GetRootWindow( context)}, {context.GetType()}");
		if (context is mux.Application Control)
		{
			System.Console.WriteLine($"Root (cast as Application): {WindowHelper.GetRootWindow(context)}, {Control.GetType()}");
			//Control = context as mux.Application;

			Control.Resources.MergedDictionaries.Add(
				new mux.ResourceDictionary
				{

					Source = new Uri("ms-appx:///Eto.WinUI/Forms/Controls/BindingTemplates.xaml")
				});

			Callback.OnInitialized(Widget, EventArgs.Empty);
		}
		else if (context is mux.FrameworkElement ControlFE)
		{
			System.Console.WriteLine($"Root (cast as FE): {WindowHelper.GetRootWindow(context)}, {ControlFE.GetType()}");
			//Control = context as mux.Application;
			System.Console.WriteLine($"Root element: {ControlFE.GetRootElement()}");
			WindowHelper.RootFrame = (mux.Controls.Frame)ControlFE.GetRootElement();

			ControlFE.Resources.MergedDictionaries.Add(
				new mux.ResourceDictionary
				{

					Source = new Uri("ms-appx:///Eto.WinUI/Forms/Controls/BindingTemplates.xaml")
				});

			Callback.OnInitialized(Widget, EventArgs.Empty);
		}
		else if (context is mux.ResourceDictionary MD)
		{
			System.Console.WriteLine($"Root: {WindowHelper.GetRootWindow(context)}, {MD.GetType()}");
			//Control = context as mux.Application;
			Console.WriteLine("Merged dictionary");

			MD.MergedDictionaries.Add(
				new mux.ResourceDictionary
				{

					Source = new Uri("ms-appx:///Eto.WinUI/Forms/Controls/BindingTemplates.xaml")
				});

			Callback.OnInitialized(Widget, EventArgs.Empty);
		}
		else
		{
			
			System.Console.WriteLine($"Did not cast; {context.GetType()}");
			Control = context as mux.Application;

			Control.Resources.MergedDictionaries.Add(
				new mux.ResourceDictionary
				{

					Source = new Uri("ms-appx:///Eto.WinUI/Forms/Controls/BindingTemplates.xaml")
				});

			Callback.OnInitialized(Widget, EventArgs.Empty);
		}
	}

	protected override void Initialize()
	{
		base.Initialize();
		_dispatcher = mud.DispatcherQueue.GetForCurrentThread();
		_mainThread = Thread.CurrentThread;
	}

	public void Invoke(Action action)
	{

		if (_dispatcher == null || Thread.CurrentThread == _mainThread)
			action();
		else
		{
			var mre = new ManualResetEvent(false);
			_dispatcher.TryEnqueue(() =>
			{
				action();
				mre.Set();
			});
			mre.WaitOne();
		}
	}

	public void OnMainFormChanged()
	{
		//mux.Application.Current..MainWindow = Widget.MainForm.ToNative();
	}

	public void Open(string url)
	{
		Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
	}

	public void Quit()
	{
		Control.Exit();
	}

	public void Restart()
	{
	}

	public void Run()
	{
		Callback.OnInitialized(Widget, EventArgs.Empty);
	}

	public void RunIteration()
	{
		//var frame = new DispatcherFrame();
		//Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
		//Dispatcher.PushFrame(frame);
		//WpfFrameworkElementHelper.ShouldCaptureMouse = false;
	}
}

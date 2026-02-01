using Calabonga.Wpf.Mvvm.Core;
using Calabonga.Wpf.Mvvm.ViewModels;
using Calabonga.Wpf.Mvvm.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Windows;

namespace Calabonga.Wpf.Mvvm;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    internal const string DarkThemeName = "ThemeDark.xaml";
    internal const string LightThemeName = "ThemeLight.xaml";

    public App()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("logs/local-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, shared: true)
            .CreateLogger();

        Services = DependencyContainer.ConfigureServices();
    }

    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public static new App Current => (App)Application.Current;

    /// <summary>
    /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
    /// </summary>
    private IServiceProvider Services { get; set; }

    /// <summary>Raises the <see cref="E:System.Windows.Application.Startup" /> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var shell = Services.GetService<MainWindow>();
        var shellViewModel = Services.GetService<MainWindowViewModel>();

        if (shellViewModel is null || shell is null)
        {
            return;
        }

        shell.DataContext = shellViewModel;

        shell.Show();
    }

    /// <summary>
    /// Requires to load Application Resources
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Application_Startup(object sender, StartupEventArgs e) => InitializeComponent();

    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("Application shutdown successful");
        Log.CloseAndFlush();
        base.OnExit(e);
    }
}

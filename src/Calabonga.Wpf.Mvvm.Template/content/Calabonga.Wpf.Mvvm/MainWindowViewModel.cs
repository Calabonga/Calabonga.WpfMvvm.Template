using Calabonga.Wpf.Mvvm.Core;

namespace Calabonga.Wpf.Mvvm;

/// <summary>
/// ViewModel for MainWindow
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(IVersionService versionService)
        => Title = $"WPF with MVVM (v{versionService.Version})";
}
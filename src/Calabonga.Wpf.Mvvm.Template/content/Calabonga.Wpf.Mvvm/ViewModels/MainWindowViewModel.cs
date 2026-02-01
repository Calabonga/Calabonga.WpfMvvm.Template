using Calabonga.Wpf.Mvvm.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace Calabonga.Wpf.Mvvm.ViewModels;

/// <summary>
/// ViewModel for MainWindow
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(IVersionService versionService)
    {
        Title = $"WPF with MVVM (v{versionService.Version})";
    }

    #region property IsDarkTheme

    /// <summary>
    /// Property IsDarkTheme
    /// </summary>
    [ObservableProperty] private bool _isDarkTheme;

    #endregion

    #region partials

    partial void OnIsDarkThemeChanged(bool value)
    {
        var selectedThemeName = value ? App.DarkThemeName : App.LightThemeName;
        var resourceDictionary = (ResourceDictionary)Application.LoadComponent(new Uri(selectedThemeName, UriKind.Relative));
        Application.Current.Resources.MergedDictionaries.RemoveAt(0);
        Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
    }

    #endregion
}

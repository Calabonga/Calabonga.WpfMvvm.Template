namespace Calabonga.Wpf.Mvvm.Core;

/// <summary>
/// Demo interface
/// </summary>
public interface IVersionService
{
    string Version { get; }
}

/// <summary>
/// Demo interface implementation <see cref="IVersionService"/>
/// </summary>
public class VersionService : IVersionService
{
    public VersionService() => Version = "1.0.5";

    public string Version { get; }
}
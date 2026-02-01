namespace Calabonga.Wpf.Mvvm.Core;

/// <summary>
/// This interface is for demo purposes only.
/// You can delete it in any time you want.
/// </summary>
public interface IVersionService
{
    string Version { get; }
}

/// <summary>
/// This interface implementation is for demo purposes only. Please see <see cref="IVersionService"/>.
/// </summary>
public class VersionService : IVersionService
{
    public VersionService()
    {
        Version = "3.0.0";
    }

    public string Version { get; }
}

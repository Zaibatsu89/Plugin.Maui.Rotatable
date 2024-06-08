using System.ComponentModel;

namespace Plugin.Maui.Rotatable;

public partial class RotatableImplementation : IRotatable, INotifyPropertyChanged
{
    private bool _isPortrait = false;
    /// <inheritdoc cref="IRotatable.IsPortrait" />
    public bool IsPortrait
    {
        get
        {
            return _isPortrait;
        }
        private set
        {
            if (_isPortrait != value)
            {
                _isPortrait = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPortrait)));
            }
        }
    }

    public RotatableImplementation()
    {
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop) return; // TODO: support desktop form factor
        DeviceDisplay.MainDisplayInfoChanged += OnWindowInfoChanged;
        IsPortrait = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait;
    }

    ~RotatableImplementation()
    {
        DeviceDisplay.MainDisplayInfoChanged -= OnWindowInfoChanged;
    }

    private void OnWindowInfoChanged(object? sender, DisplayInfoChangedEventArgs e)
    {
        IsPortrait = e.DisplayInfo.Orientation == DisplayOrientation.Portrait;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
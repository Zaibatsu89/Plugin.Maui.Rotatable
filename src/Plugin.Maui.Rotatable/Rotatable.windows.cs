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

    private readonly MauiWinUIWindow? _window;

    public RotatableImplementation()
    {
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            // pak window
            _window = (Application.Current?.Windows[0]?.Handler?.PlatformView as MauiWinUIWindow)
                ?? throw new NullReferenceException("No window found.");
            // als window bestaat, abonneer op SizeChanged
            _window.SizeChanged += OnWindowInfoChanged;
            // stel IsPortrait in
            IsPortrait = _window.Bounds.Width < _window.Bounds.Height;
        }
        else
        {
            DeviceDisplay.MainDisplayInfoChanged += OnWindowInfoChanged;
            IsPortrait = DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait;
        }
    }

    ~RotatableImplementation()
    {
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            _window!.SizeChanged -= OnWindowInfoChanged; // would have been thrown as NullReferenceException in constructor already
        }
        else
        {
            DeviceDisplay.MainDisplayInfoChanged -= OnWindowInfoChanged;
        }
    }

    private void OnWindowInfoChanged(object? sender, Microsoft.UI.Xaml.WindowSizeChangedEventArgs e)
    {
        IsPortrait = e.Size.Width < e.Size.Height;
    }

    private void OnWindowInfoChanged(object? sender, DisplayInfoChangedEventArgs e)
    {
        IsPortrait = e.DisplayInfo.Orientation == DisplayOrientation.Portrait;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
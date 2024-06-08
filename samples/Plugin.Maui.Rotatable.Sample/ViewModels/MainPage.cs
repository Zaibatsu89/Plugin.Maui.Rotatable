namespace Plugin.Maui.Rotatable.Sample.ViewModels;

public class MainPage : RotatableImplementation
{
    private bool _isAvailable = false;
    public bool IsAvailable
    {
        get
        {
            return _isAvailable;
        }
        private set
        {
            SetProperty(ref _isAvailable, value);
        }
    }

    public MainPage()
    {
        IsAvailable = true;
    }
}
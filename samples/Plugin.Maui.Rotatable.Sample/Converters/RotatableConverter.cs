using System.Globalization;

namespace Plugin.Maui.Rotatable.Sample.Converters;

public class RotatableColumnConverter<T> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not bool isPortrait)
        {
            return 0;
        }

        if (isPortrait)
        {
            return 0;
        }
        // landscape
        return 1;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

public class RotatableColumnSpanConverter<T> : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not bool isPortrait)
        {
            return 0;
        }

        if (isPortrait)
        {
            return 3;
        }
        // landscape
        return 1;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
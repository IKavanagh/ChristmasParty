using System.Globalization;

namespace Christmas.View.Converters;

public class BoolToStyleConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || values.Length < 3 || values.Any(o => o is null))
        {
            return null;
        }

        string styleName = (values[0] is bool b && b ? values[1] : values[2]).ToString();
        return Application.Current.Resources.TryGetValue(styleName, out var style) ? (Style)style : null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

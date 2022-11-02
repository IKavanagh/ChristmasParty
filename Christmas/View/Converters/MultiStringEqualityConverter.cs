using System.Globalization;

namespace Christmas.View.Converters;

public class MultiStringEqualityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || values.Length < 2)
        {
            return true;
        }

        string first = values[0]?.ToString();
        return values.Skip(1).All(o => o?.ToString().Equals(first) == true) || values.All(o => o is null);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

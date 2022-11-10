using System.Globalization;

namespace Christmas.View.Converters;

/// <summary>
/// An IMultiValueConverter that expects an object and an
/// <see cref="IEnumerable{T}" /> as the binding parameters. The index of
/// the object in the <see cref="IEnumerable{T}" /> is modulus with 3 and 
/// then converted into a colour. The default colours are the
/// Primary, Secondary and Tertiary colours defined in the
/// resources. Red, green and blue act as fallback colours.
/// </summary>
public class ItemsSourceRowToColorMultiConverter : IMultiValueConverter
{
    public Color Primary { get; set; }
    public Color Secondary { get; set; }
    public Color Tertiary { get; set; }

    public ItemsSourceRowToColorMultiConverter()
    {
        var resources = Application.Current.Resources;

        Primary = resources.TryGetValue("Primary", out var primary) ? (Color)primary : Colors.Red;
        Secondary = resources.TryGetValue("Secondary", out var secondary) ? (Color)secondary : Colors.Green;
        Tertiary = resources.TryGetValue("Tertiary", out var tertiary) ? (Color)tertiary : Colors.Blue;
    }
    
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[1] is not null && values[0] is not null)
        {
            int index = ((IEnumerable<object>)values[1]).ToList().IndexOf(values[0]);
            return (index % 3) switch
            {
                0 => Primary,
                1 => Secondary,
                2 => Tertiary,
                _ => Colors.Transparent,
            };
        }

        return Colors.White;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

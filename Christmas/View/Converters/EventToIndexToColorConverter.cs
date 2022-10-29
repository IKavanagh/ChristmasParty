using Christmas.Model;
using Christmas.ViewModel;
using System.Globalization;

namespace Christmas.View.Converters;

/// <summary>
/// Converts an event to an index within its TemplatedParent and
/// converts the index to one of three colours. The default colours
/// are read from Application.Current.Resources using "Primary",
/// "Secondary" and "Tertiary" as the keys. Fallback values of Red,
/// Green, Blue are used if any of the resources don't exist.
/// 
/// The Converter expects the ConverterParameter passed to it
/// is a page with a BindingContext type of EventsViewModel.
/// </summary>
public class EventToIndexToColorConverter : IValueConverter
{
    public Color Primary { get; set; }
    public Color Secondary { get; set; }
    public Color Tertiary { get; set; }

    public EventToIndexToColorConverter()
    {
        var resources = Application.Current.Resources;

        Primary = resources.TryGetValue("Primary", out var primary) ? (Color)primary : Colors.Red;
        Secondary = resources.TryGetValue("Secondary", out var secondary) ? (Color)secondary : Colors.Green;
        Tertiary = resources.TryGetValue("Tertiary", out var tertiary) ? (Color)tertiary : Colors.Blue;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Event @event = (Event)value;
        EventsViewModel viewModel = (EventsViewModel)((Page)parameter).BindingContext;

        int index = viewModel.ThursdayEvents.IndexOf(@event);
        if (index == -1)
        {
            index = viewModel.FridayEvents.IndexOf(@event);
        }

        return (index % 3) switch
        {
            0 => Primary,
            1 => Secondary,
            2 => Tertiary,
            _ => Colors.Transparent
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
